using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Contacts
{
    public class MobileNumberDataWriter : SqlDataWriter<MobileNumber, MobileNumberCollection>
    {

        public MobileNumberDataWriter(string username, MobileNumber item) : base(username, item) { }
        public MobileNumberDataWriter(string username, MobileNumberCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, MobileNumber item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@PersonId", SqlDbType.Int) ,
                new SqlParameter( "@PhoneNumber", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@PhoneNumber"].Value = item.PhoneNumber;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Person_MobileNumber] ([PersonId],[PhoneNumber],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PersonId,@PhoneNumber,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            return Write(_ => _.PhoneNumber, db, trn);
        }
    }
}
