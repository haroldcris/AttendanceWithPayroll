using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class SubjectDataReader
    {

        public bool HasExistingItem(string subjectCode, int id)
        {
            const string query = "Select 1 from Student_Subject where SubjectCode = @SubjectCode and Id <> @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var ret = db.Query(query, new { SubjectCode = subjectCode, Id = id }).FirstOrDefault();

                return ret == null ? false : true;

            }
        }

    }
}
