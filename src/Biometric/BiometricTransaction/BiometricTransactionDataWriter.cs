using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Biometric
{
    public class BiometricTransactionDataWriter : SqlMainDataWriter<BiometricTransaction, BiometricTransactionCollection>
    {

        public BiometricTransactionDataWriter(string username, BiometricTransaction item) : base(username, item) { }
        public BiometricTransactionDataWriter(string username, BiometricTransactionCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, BiometricTransaction item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@BiometricId", SqlDbType.Int) ,
                new SqlParameter( "@TimeLog", SqlDbType.DateTime) ,
                new SqlParameter( "@Station", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@IpAddress", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@InOut", SqlDbType.NVarChar, 10) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@SmsDate", SqlDbType.DateTime)
            });

            cmd.Parameters["@BiometricId"].Value = item.BiometricId;
            cmd.Parameters["@TimeLog"].Value = item.TimeLog;
            cmd.Parameters["@Station"].Value = item.Station;
            cmd.Parameters["@IpAddress"].Value = item.IpAddress;
            cmd.Parameters["@InOut"].Value = item.InOut;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
            cmd.Parameters["@SmsDate"].Value = item.SmsDate;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Biometric_DeviceLog] ([BiometricId],[TimeLog],[Station],[IpAddress],[InOut],[CreatedBy],[ModifiedBy],[SmsDate]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@BiometricId,@TimeLog,@Station,@IpAddress,@InOut,@CreatedBy,@ModifiedBy,@SmsDate)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.IpAddress);
        }


    }
}
