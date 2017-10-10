using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.Student
{
    public class StudentDataReader
    {
        public bool HasExistingPersonId(int personId)
        {
            const string query = "SELECT 1 from Student where PersonId = @PersonId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { PersonId = personId });

                return result.Any();
            }
        }


        public bool HasExistingStudentNumber(int studnum, int id)
        {
            const string query = "SELECT 1 from Student where StudentNumber = @StudentNumber and Id <> @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { StudentNumber = studnum, Id = id });

                return result.Any();
            }


        }
    }
}
