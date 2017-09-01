using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Contacts
{
    public class PersonDataWriter : SqlMainDataWriter<Person, PersonCollection>
    {
        public PersonDataWriter(string username, Person item) : base(username, item) { }
        public PersonDataWriter(string username, PersonCollection items) : base(username, items) { }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Person] ([Lastname],[Firstname],[Middlename],[MiddleInitial],[NameExtension],[SpouseLastname],[Gender],[BirthDate],[BirthCountry],[BirthProvince],[BirthTown],[CameraCounter],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@Lastname,@Firstname,@Middlename,@MiddleInitial,@NameExtension,@SpouseLastname,@Gender,@BirthDate,@BirthCountry,@BirthProvince,@BirthTown,@CameraCounter,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Person item)
        {
            cmd.Parameters.Clear();

            cmd.Parameters.AddRange(new[]
             {
                new SqlParameter( "@Lastname", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@Firstname", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@Middlename", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@MiddleInitial", SqlDbType.NVarChar, 5) ,                new SqlParameter( "@NameExtension", SqlDbType.NVarChar, 10) ,                new SqlParameter( "@SpouseLastname", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@Gender", SqlDbType.NVarChar, 10) ,                new SqlParameter( "@BirthDate", SqlDbType.Date) ,                new SqlParameter( "@BirthCountry", SqlDbType.NVarChar, 100) ,                new SqlParameter( "@BirthProvince", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@BirthTown", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@CameraCounter", SqlDbType.NVarChar, 20) ,                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@Lastname"].Value = item.Name.Lastname;
            cmd.Parameters["@Firstname"].Value = item.Name.Firstname;
            cmd.Parameters["@Middlename"].Value = item.Name.Middlename;
            cmd.Parameters["@MiddleInitial"].Value = item.Name.MiddleInitial;
            cmd.Parameters["@NameExtension"].Value = item.Name.NameExtension;
            cmd.Parameters["@SpouseLastname"].Value = item.Name.SpouseLastname;

            cmd.Parameters["@Gender"].Value = item.Gender == GenderType.Male ? "Male" : "Female";

            cmd.Parameters["@BirthDate"].Value = item.BirthDate;
            cmd.Parameters["@BirthCountry"].Value = item.BirthCountry;
            cmd.Parameters["@BirthProvince"].Value = item.BirthProvince;
            cmd.Parameters["@BirthTown"].Value = item.BirthTown;
            cmd.Parameters["@CameraCounter"].Value = item.CameraCounter;

            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }

        public override bool SaveChanges()
        {

            this.AfterItemSave += PersonDataWriter_AfterItemSave;

            return Write(_ => _.Name.Fullname);

        }

        private void PersonDataWriter_AfterItemSave(object sender, EntityEventArgs e)
        {
            //throw new System.NotImplementedException();
            var item = (Person)e.ItemData;


            //Transfer ParentId;
            if (item.RowStatus == RecordStatus.NewRecord)
            {
                foreach (var mobileItem in item.MobileNumbers.Items)
                {
                    mobileItem.PersonId = item.Id;
                }
            }


            //Write Mobile Numbers
            var dataWriter = new MobileNumberDataWriter(DataWriterUsername, item.MobileNumbers);
            dataWriter.SaveChanges(e.Connection, e.Transaction);


        }
    }
}
