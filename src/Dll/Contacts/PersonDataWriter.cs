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
    public class PersonDataWriter : SqlDataWriter<Person, PersonCollection>
    {
        public PersonDataWriter(string username, Person item) : base(username, item) { }
        public PersonDataWriter(string username, PersonCollection items) : base(username, items) { }

        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            try
            {
                var affectedRecords = 0;

                // Delete All Marked Items
                var deletedItems = _List.Items.Where(_ => _.RowStatus == RecordStatus.DeletedRecord);
                if (deletedItems.Count() != 0)
                    if (DatabaseAction.ExecuteDeleteQuery<Person>(DataWriterUsername, deletedItems, db, trn))
                        affectedRecords++;


                var cmd = new SqlCommand();
                foreach (var item in _List.Items)
                {
                    switch (item.Id)
                    {
                        case 0: //New
                            var insertQuery = CreateSqlInsertQuery();
                            cmd = new SqlCommand(insertQuery, db, trn);

                            CreateSqlInsertCommandParameters(cmd, item);

                            if (ExecuteCommand(cmd, item, item.Name.FullnameWithLastnameFirst()))
                                affectedRecords++;
                            break;


                        default: //Update
                            if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                            var updateQuery = CreateSqlUpdateQuery(item);
                            cmd = new SqlCommand(updateQuery, db, trn);

                            CreateSqlUpdateCommandParameters(cmd, item);

                            if (ExecuteCommand(cmd, item, item.Name.FullnameWithLastnameFirst()))
                                affectedRecords++;
                            break;
                    }

                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
				INSERT INTO [Persons] ([Lastname],[Firstname],[MiddleName],[Mi],[NameExtension],[Gender],[BirthDate],[Street],[Barangay],[Town],[Province],[CreatedBy],[ModifiedBy]) 
				    OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
				VALUES (@Lastname,@Firstname,@MiddleName,@Mi,@NameExtension,@Gender,@BirthDate,@Street,@Barangay,@Town,@Province,@CreatedBy,@ModifiedBy)
				SELECT * from @output";
        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Person item)
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


    }
}
