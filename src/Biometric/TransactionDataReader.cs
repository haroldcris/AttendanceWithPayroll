using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Biometric
{
    public class TransactionDataReader
    {

        public static string GetCellnumOfBiometricId(long id)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<string>(@"Select Cellnum from Person p inner join Biometric b on p.id = b.PersonId
                                                    where BiometricId = @biometricId", new { biometricId = id }).FirstOrDefault();

                return result;
            }
        }
    }
}
