using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class SubjectCollection : EntityCollection<Subject>
    {
        public bool LoadAllItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var items = db.Query<Subject>(@"Select * from Student_Subject").OrderBy(o => o.SubjectCode);

                LoadItemsWith(items);
            }
            return true;
        }
    }
}
