using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.Biometric
{
    public class BiometricUserDataReader
    {
        public bool HasExistingBiometricId(int id)
        {
            const string query = "SELECT 1 from Biometric_User where BiometricId = @BiometricId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { BiometricId = id });

                return result.Any();
            }


        }




        public bool HasExistingPersonId(int personId)
        {
            const string query = "SELECT 1 from Biometric_User where PersonId = @PersonId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { PersonId = personId });

                return result.Any();
            }
        }
    }
}
