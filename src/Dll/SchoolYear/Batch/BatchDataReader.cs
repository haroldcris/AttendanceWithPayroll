using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class BatchDataReader
    {

        public bool HasExistingItem(string batchName, string semester, int id)
        {
            const string query = "Select 1 from Student_Batch where BatchName = @Batch and Semester = @Semester and Id <> @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var ret = db.Query(query, new { Batch = batchName, Semester = semester, Id = id }).FirstOrDefault();

                return ret == null ? false : true;

            }
        }
    }
}
