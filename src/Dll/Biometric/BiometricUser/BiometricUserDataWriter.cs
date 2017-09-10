using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Biometric
{
    public class BiometricUserDataWriter : SqlMainDataWriter<BiometricUser, BiometricUserCollection>
    {

        public BiometricUserDataWriter(string username, BiometricUser item) : base(username, item) { }
        public BiometricUserDataWriter(string username, BiometricUserCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, BiometricUser item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@BiometricId", SqlDbType.Int) ,
                new SqlParameter( "@PersonId", SqlDbType.Int) ,
                new SqlParameter( "@Category", SqlDbType.NVarChar, 30) ,
                new SqlParameter( "@PhoneNumber", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@BiometricId"].Value = item.BiometricId;
            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@Category"].Value = item.Category;
            cmd.Parameters["@PhoneNumber"].Value = item.PhoneNumber;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Biometric_User] ([BiometricId],[PersonId],[Category],[PhoneNumber],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@BiometricId,@PersonId,@Category,@PhoneNumber,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.BiometricId.ToString());
        }


    }
}
