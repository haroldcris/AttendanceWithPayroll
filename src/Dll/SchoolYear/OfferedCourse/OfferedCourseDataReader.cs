using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class OfferedCourseDataReader
    {

        public bool HasExistingItem(int batchId, int courseId, int year, int id)
        {
            const string query = "Select 1 from Student_OfferedCourse where batchId = @BatchId and courseId = @CourseId and yearLevel = @Year and Id <> @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var ret = db.Query(query, new { BatchId = batchId, CourseId = courseId, Year = year, Id = id }).FirstOrDefault();

                return ret == null ? false : true;

            }
        }


    }

}
