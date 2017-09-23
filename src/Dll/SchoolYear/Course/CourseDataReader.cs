using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class CourseDataReader
    {

        
        public bool HasExistingItem(string courseCode, int id)
        {
            const string query = "Select 1 from Student_Course where CourseCode = @CourseCode and Id <> @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var ret = db.Query(query, new { CourseCode = courseCode, Id = id }).FirstOrDefault();

                return ret == null ? false : true;

            }
        }

    }
}
