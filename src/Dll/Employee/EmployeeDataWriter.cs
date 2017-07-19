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
    public class EmployeeDataWriter: SqlMainDataWriter<Employee, EmployeeCollection>
    {
        public EmployeeDataWriter(string username, Employee item) : base(username, item) { }
        public EmployeeDataWriter(string username, EmployeeCollection items) : base(username, items) { }


        public  override bool SaveChanges()
        {
            var affectedRecords = 0;

            SqlTransaction trn;
            using (var db = Connection.CreateConnection())
            {
                try
                {
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


                    SqlCommand cmd;
                    foreach (var item in _List.Items)
                    {
                        switch (item.Id)
                        {
                            case 0:  // New RECORD
                                item.RowStatus = RecordStatus.NewRecord;
                                if (item.PersonInfo.Id == 0)
                                {
                                    var personWriter = new Contacts.PersonDataWriter(DataWriterUsername, item.PersonInfo);
                                    personWriter.SaveChanges(db, trn);
                                }

                                var insertQuery = CreateSqlInsertQuery();
                                cmd = new SqlCommand(insertQuery, db, trn);

                                    CreateSqlInsertCommandParameters(cmd, item);

                                if (ExecuteCommand (cmd, item, item.PersonInfo.Name.FullnameWithLastnameFirst()))
                                    affectedRecords++;
                                break;


                            default: // UPDATE

                                if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                                var updateQuery = CreateSqlUpdateQuery(item);
                                cmd = new SqlCommand(updateQuery, db, trn);

                                    CreateSqlUpdateCommandParameters(cmd, item);

                                if (ExecuteCommand (cmd, item, item.PersonInfo.Name.FullnameWithLastnameFirst()))
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
            }
        }

        protected override  void CommitChanges()
        {
            _List.CommitChanges();

            foreach(var item in _List.Items)
            {
                item.PersonInfo.RowStatus = RecordStatus.NoChanges;
            }
        }

        protected override void RollbackChanges()
        {
            _List.RollBackChanges();

            foreach (var item in _List.Items)
            {
                if (item.PersonInfo.RowStatus == RecordStatus.NewRecord) item.Id = 0;
            }
        }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Employee item)
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
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Employees] ([PersonId],[CurrentPosition],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@PersonId,@CurrentPosition,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }

    }
}
