using AiTech.Database;
using AiTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Contacts
{
    public class PersonDataWriter 
    {
        protected PersonCollection _List;
        protected string DataWriterUsername;

        public PersonDataWriter(string username, Person item)
        {
            _List = new PersonCollection();

            DataWriterUsername = username;
            if (_List == null) throw new ArgumentNullException();

            _List.Attach(item);
        }

        public PersonDataWriter(string username, IEnumerable<Person> items)
        {
            _List = new PersonCollection();

            DataWriterUsername = username;

            _List.AttachRange(items);
        }


        public bool SaveChanges(SqlConnection db = null, SqlTransaction trn = null)
        {
            bool localDb = (db == null);

            if (localDb)
            {
                try
                {
                    db = Connection.CreateConnection();
                    db.Open();

                    trn = db.BeginTransaction();

                } catch(Exception ex)
                {
                    throw new InvalidOperationException("Can not establish connection to server", ex);
                }
            }

            try
            {
                // Delete All Marked Items
                var deletedItems = _List.Items.Where(_ => _.RowStatus == RecordStatus.DeletedRecord);
                if (deletedItems.Count() != 0)
                    DatabaseAction.ExecuteDeleteQuery<Person>(DataWriterUsername, deletedItems, db, trn);


                foreach (var item in _List.Items)
                {
                    switch(item.Id)
                    {
                        case 0: //New
                            ExecuteInsertCommand(item, db, trn);
                            break;

                        default: // Update
                            //DatabaseAction.ExecuteUpdateQuery<Person>(DataWriterUsername, item.Name.FullnameWithLastnameFirst(), item, db, trn);
                            ExecuteUpdateCommand(item, db, trn);
                            break;
                    }

                    //Save SubClass Here;
                    
                }

                if (localDb) trn.Commit();
                return true;
            }
            catch
            {
                if (localDb) trn.Rollback();
                throw;
            }
            finally
            {
                if (localDb) db.Close();
            }
        }



        private void CreateSqlCommandParameters(SqlCommand cmd, Person item)
        {
            cmd.Parameters.Clear();

            cmd.Parameters.AddRange(new[]
                    {

                        new SqlParameter( "@Lastname", SqlDbType.NVarChar, 50) ,
                        new SqlParameter( "@Firstname", SqlDbType.NVarChar, 50) ,
                        new SqlParameter( "@MiddleName", SqlDbType.NVarChar, 50) ,
                        new SqlParameter( "@Mi", SqlDbType.NVarChar, 5) ,
                        new SqlParameter( "@NameExtension", SqlDbType.NVarChar, 10) ,
                        new SqlParameter( "@Gender", SqlDbType.NVarChar, 10) ,
                        new SqlParameter( "@BirthDate", SqlDbType.Date) ,
                        new SqlParameter( "@Street", SqlDbType.NVarChar, 100) ,
                        new SqlParameter( "@Barangay", SqlDbType.NVarChar, 50) ,
                        new SqlParameter( "@Town", SqlDbType.NVarChar, 50) ,
                        new SqlParameter( "@Province", SqlDbType.NVarChar, 50) ,
                        new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                        new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

                    });



            cmd.Parameters["@Lastname"].Value = item.Name.Lastname;
            cmd.Parameters["@Firstname"].Value = item.Name.Firstname;
            cmd.Parameters["@MiddleName"].Value = item.Name.Middlename;
            cmd.Parameters["@Mi"].Value = item.Name.MiddleInitial;
            cmd.Parameters["@NameExtension"].Value = item.Name.NameExtension;

            cmd.Parameters["@Gender"].Value = item.Gender == Enums.GenderType.Male ? "Male" : "Female";

            cmd.Parameters["@BirthDate"].Value = item.BirthDate;

            cmd.Parameters["@Street"].Value = item.Address.Street;
            cmd.Parameters["@Barangay"].Value = item.Address.Barangay;
            cmd.Parameters["@Town"].Value = item.Address.Town;
            cmd.Parameters["@Province"].Value = item.Address.Province;

            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }
      


        private void ExecuteInsertCommand(Person item, SqlConnection db, SqlTransaction trn)
        {
            try
            {
                using (var cmd = new SqlCommand(@"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Persons] ([Lastname],[Firstname],[MiddleName],[Mi],[NameExtension],[Gender],[BirthDate],[Street],[Barangay],[Town],[Province],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@Lastname,@Firstname,@MiddleName,@Mi,@NameExtension,@Gender,@BirthDate,@Street,@Barangay,@Town,@Province,@CreatedBy,@ModifiedBy)
						  SELECT * from @output", db, trn))
                {

                    CreateSqlCommandParameters(cmd, item);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        DatabaseAction.UpdateItemRecordInfo(item, reader);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error Saving " + item.Name.FullnameWithFirstnameFirst(), ex);
            }
        }


        private void ExecuteUpdateCommand(Person item, SqlConnection db, SqlTransaction trn)
        {
            var builder = new SqlUpdateQueryBuilder(item);
            var query = builder.GetQueryString();

            try
            {
                using (var cmd = new SqlCommand(query, db, trn))
                {

                    CreateSqlCommandParameters(cmd, item);

                    //Add Id
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    cmd.Parameters["@Id"].Value = item.Id;

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        DatabaseAction.UpdateItemRecordInfo(item, reader);
                    }
                }
            }

            catch (Exception ex)

            {
                throw new ArgumentException("Error Saving " + item.Name.FullnameWithFirstnameFirst(), ex);
            }

        }

    }
}
