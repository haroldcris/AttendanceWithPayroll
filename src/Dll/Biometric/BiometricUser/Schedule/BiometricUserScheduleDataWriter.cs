using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Biometric
{
    public class BiometricUserScheduleDataWriter : SqlMainDataWriter<BiometricUserSchedule, BiometricUserScheduleCollection>
    {

        public BiometricUserScheduleDataWriter(string username, BiometricUserSchedule item) : base(username, item) { }
        public BiometricUserScheduleDataWriter(string username, BiometricUserScheduleCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, BiometricUserSchedule item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@BiometricId", SqlDbType.Int) ,
                new SqlParameter( "@MonIn", SqlDbType.Date) ,
                new SqlParameter( "@MonOut", SqlDbType.Date) ,
                new SqlParameter( "@TueIn", SqlDbType.Date) ,
                new SqlParameter( "@TueOut", SqlDbType.Date) ,
                new SqlParameter( "@WedIn", SqlDbType.Date) ,
                new SqlParameter( "@WedOut", SqlDbType.Date) ,
                new SqlParameter( "@ThuIn", SqlDbType.Date) ,
                new SqlParameter( "@ThuOut", SqlDbType.Date) ,
                new SqlParameter( "@FriIn", SqlDbType.Date) ,
                new SqlParameter( "@FriOut", SqlDbType.Date)
            });

            cmd.Parameters["@BiometricId"].Value = item.BiometricId;
            cmd.Parameters["@MonIn"].Value = item.MonIn;
            cmd.Parameters["@MonOut"].Value = item.MonOut;
            cmd.Parameters["@TueIn"].Value = item.TueIn;
            cmd.Parameters["@TueOut"].Value = item.TueOut;
            cmd.Parameters["@WedIn"].Value = item.WedIn;
            cmd.Parameters["@WedOut"].Value = item.WedOut;
            cmd.Parameters["@ThuIn"].Value = item.ThuIn;
            cmd.Parameters["@ThuOut"].Value = item.ThuOut;
            cmd.Parameters["@FriIn"].Value = item.FriIn;
            cmd.Parameters["@FriOut"].Value = item.FriOut;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Biometric_Schedule_Weekly] ([BiometricId],[MonIn],[MonOut],[TueIn],[TueOut],[WedIn],[WedOut],[ThuIn],[ThuOut],[FriIn],[FriOut]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@BiometricId,@MonIn,@MonOut,@TueIn,@TueOut,@WedIn,@WedOut,@ThuIn,@ThuOut,@FriIn,@FriOut)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.BiometricId.ToString());
        }


    }
}
