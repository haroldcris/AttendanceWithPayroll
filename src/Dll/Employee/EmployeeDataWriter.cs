using AiTech.Database;
using AiTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Employee
{
    public class EmployeeDataWriter 
    {
        protected  EmployeeCollection _List;
        protected string DataWriterUsername;

        public EmployeeDataWriter(string username, Employee item)
        {
            _List = new EmployeeCollection();

            DataWriterUsername = username;
            if (_List == null) throw new ArgumentNullException();

            _List.Attach(item);
        }

        public EmployeeDataWriter(string username, EmployeeCollection items)
        {
            _List = items;

            DataWriterUsername = username;
        }


        public  bool SaveChanges()
        {
            var affectedRecords = 0;

            SqlConnection db;
            SqlTransaction trn;

            try
            {
                db = Connection.CreateConnection();
                db.Open();

                trn = db.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can not establish connection to server", ex);
            }


            try
            {
                // Delete All Marked Items
                var deletedItems = _List.Items.Where(_ => _.RowStatus == RecordStatus.DeletedRecord);
                if (deletedItems.Count() != 0)
                    if (DatabaseAction.ExecuteDeleteQuery<Employee>(DataWriterUsername, deletedItems, db, trn))
                        affectedRecords += deletedItems.Count();


                foreach (var item in _List.Items)
                {
                    switch (item.Id)
                    {
                        case 0:  // New RECORD
                            if (item.PersonInfo.Id == 0)
                            {
                                var personWriter = new Contacts.PersonDataWriter(DataWriterUsername, item.PersonInfo);
                                personWriter.SaveChanges(db, trn);
                            }

                            if (ExecuteInsertCommand(item, db, trn))
                                affectedRecords++;
                            break;

                        default: // UPdate
                            if (DatabaseAction.ExecuteUpdateQuery<Employee>(DataWriterUsername, item.PersonInfo.Name.FullnameWithLastnameFirst(), item, db, trn))
                                affectedRecords++;


                            //Save SubClass Here;

                            // PersonInfo
                            var personInfoWriter = new Contacts.PersonDataWriter(DataWriterUsername, item.PersonInfo);
                                personInfoWriter.SaveChanges(db, trn);


                            break;
                    }
                    
                }

                trn.Commit();

                CommitChanges();
                return affectedRecords > 0;
            }
            catch
            {
                trn.Rollback();
                RollbackChanges();
                throw;
            }
            finally
            {
                db.Close();
            }
        }

        protected  void CommitChanges()
        {
            _List.CommitChanges();

            foreach(var item in _List.Items)
            {
                item.PersonInfo.RowStatus = RecordStatus.NoChanges;
            }
        }

        protected  void RollbackChanges()
        {
            _List.RollBackChanges();

            foreach (var item in _List.Items)
            {
                if (item.PersonInfo.RowStatus == RecordStatus.NewRecord) item.Id = 0;
            }
        }

        private bool ExecuteInsertCommand(Employee item, SqlConnection db, SqlTransaction trn)
        {
            try
            {
                using (var cmd = new SqlCommand(@"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Employees] ([PersonId],[CurrentPosition],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@PersonId,@CurrentPosition,@CreatedBy,@ModifiedBy)
						  SELECT * from @output", db, trn))
                {
                    cmd.Parameters.AddRange(new[]
                    {

                    new SqlParameter( "@PersonId", SqlDbType.Int) ,
                    new SqlParameter( "@CurrentPosition", SqlDbType.NVarChar, 50) ,
                    new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                    new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

                    });


                    cmd.Parameters["@PersonId"].Value = item.PersonInfo.Id;
                    cmd.Parameters["@CurrentPosition"].Value = item.CurrentPosition;
                    cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
                    cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;


                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        DatabaseAction.UpdateItemRecordInfo(item, reader);
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}
