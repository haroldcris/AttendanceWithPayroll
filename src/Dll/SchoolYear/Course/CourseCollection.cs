using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;

namespace Dll.SchoolYear
{
	public class CourseCollection : EntityCollection<Course>
	{
        public bool LoadItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = @"Select * from Courses";
                var items = db.Query<Course>(sql).OrderBy(o => o.CourseCode);
                LoadItems(items);
            }
            return true;
        }
    }
	
}
