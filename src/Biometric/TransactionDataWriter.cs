using AiTech.LiteOrm.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AiTech.Biometric
{
    public class TransactionDataWriter
    {
        protected Transaction ItemData;


        public TransactionDataWriter(Transaction item)
        {
            ItemData = item;
        }

        public int SaveChanges()
        {
            var ret = 0;

            using (var cn = Connection.CreateConnection())
            {
                cn.Open();

                var cmd = new SqlCommand("Biometric_Save_DeviceLog", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@biometricId", SqlDbType.Int).Value = ItemData.BiometricId; //  biometricId;
                cmd.Parameters.Add("@Station", SqlDbType.NVarChar, 20).Value = ItemData.Station; // station;
                cmd.Parameters.Add("@TimeLog", SqlDbType.DateTime).Value = ItemData.TimeLog; //timelog;
                cmd.Parameters.Add("@InOut", SqlDbType.NVarChar, 20).Value = ItemData.InOut; //state;
                cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar, 20).Value = ItemData.IPAddress;//ipAddress;

                ret = cmd.ExecuteNonQuery();
                if (ret < 1)
                    Console.WriteLine(" Skipping...");
                else
                    Console.WriteLine(" OK");
            }
            return ret;
        }
    }
}
