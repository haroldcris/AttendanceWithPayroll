using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class CourseCollection : EntityCollection<Course>
    {
        public bool LoadAllItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var items = db.Query<Course>(@"Select * from Student_Course").OrderBy(o => o.CourseCode);

                LoadItemsWith(items);
            }
            return true;
        }
    }

}
