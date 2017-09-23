using AiTech.LiteOrm.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Biometric
{
    public class BiometricUserDataWriter : SqlMainDataWriter<BiometricUser, BiometricUserCollection>
    {

        public BiometricUserDataWriter(string username, BiometricUser item) : base(username, item) { }
        public BiometricUserDataWriter(string username, BiometricUserCollection items) : base(username, items) { }


        private TimeSpan ToTimeSpan(DateTime date)
        {
            return new TimeSpan(date.Hour, date.Minute, date.Second);
        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, BiometricUser item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@BiometricId", SqlDbType.Int) ,
                new SqlParameter( "@PersonId", SqlDbType.Int) ,
                new SqlParameter( "@Category", SqlDbType.NVarChar, 30) ,
                new SqlParameter( "@PhoneNumber", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@MonIn", SqlDbType.Time) ,
                new SqlParameter( "@MonOut", SqlDbType.Time) ,
                new SqlParameter( "@TueIn", SqlDbType.Time) ,
                new SqlParameter( "@TueOut", SqlDbType.Time) ,
                new SqlParameter( "@WedIn", SqlDbType.Time) ,
                new SqlParameter( "@WedOut", SqlDbType.Time) ,
                new SqlParameter( "@ThuIn", SqlDbType.Time) ,
                new SqlParameter( "@ThuOut", SqlDbType.Time) ,
                new SqlParameter( "@FriIn", SqlDbType.Time) ,
                new SqlParameter( "@FriOut", SqlDbType.Time) ,
                new SqlParameter( "@SatIn", SqlDbType.Time) ,
                new SqlParameter( "@SatOut", SqlDbType.Time) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@BiometricId"].Value = item.BiometricId;
            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@Category"].Value = item.Category;
            cmd.Parameters["@PhoneNumber"].Value = item.PhoneNumber;
            cmd.Parameters["@MonIn"].Value = ToTimeSpan(item.MonIn);
            cmd.Parameters["@MonOut"].Value = ToTimeSpan(item.MonOut);
            cmd.Parameters["@TueIn"].Value = ToTimeSpan(item.TueIn);
            cmd.Parameters["@TueOut"].Value = ToTimeSpan(item.TueOut);
            cmd.Parameters["@WedIn"].Value = ToTimeSpan(item.WedIn);
            cmd.Parameters["@WedOut"].Value = ToTimeSpan(item.WedOut);
            cmd.Parameters["@ThuIn"].Value = ToTimeSpan(item.ThuIn);
            cmd.Parameters["@ThuOut"].Value = ToTimeSpan(item.ThuOut);
            cmd.Parameters["@FriIn"].Value = ToTimeSpan(item.FriIn);
            cmd.Parameters["@FriOut"].Value = ToTimeSpan(item.FriOut);
            cmd.Parameters["@SatIn"].Value = ToTimeSpan(item.SatIn);
            cmd.Parameters["@SatOut"].Value = ToTimeSpan(item.SatOut);

            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Biometric_User] ([BiometricId],[PersonId],[Category],[PhoneNumber],[MonIn],[MonOut],[TueIn],[TueOut],[WedIn],[WedOut],[ThuIn],[ThuOut],[FriIn],[FriOut],[SatIn],[SatOut],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@BiometricId,@PersonId,@Category,@PhoneNumber,@MonIn,@MonOut,@TueIn,@TueOut,@WedIn,@WedOut,@ThuIn,@ThuOut,@FriIn,@FriOut,@SatIn,@SatOut,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.Id.ToString());
        }


    }
}
