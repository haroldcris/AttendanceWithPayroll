using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiTech.Database;
using Dapper;

namespace AiTech.Biometric
{
    public class TransactionDataReader
    {

        public static string GetCellnumOfBiometricId(long id)
        {
            using (var db = AiTech.Database.Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<string>(@"Select Cellnum from Person p inner join Biometric b on p.id = b.PersonId
                                                    where BiometricId = @biometricId", new {biometricId = id}).FirstOrDefault();

                return result;   
            }
        }
    }
}
