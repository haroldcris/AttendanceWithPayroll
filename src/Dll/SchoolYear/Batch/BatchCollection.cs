using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class BatchCollection : EntityCollection<Batch>
    {

        public bool LoadAllItemsFromDb()
        {
            const string query = "Select * from Student_Batch";

            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var items = db.Query<Batch>(query);

                if (items == null) return true;

                foreach (var item in items.OrderBy(o => o.BatchName)
                                          .ThenBy(o => o.Semester))
                {
                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    this.ItemCollection.Add(item);
                }
            }
            return true;
        }



        public bool LoadItem(int id)
        {
            using (var db = Connection.CreateConnection())
            {
                const string query = "Select * from Batch where Id = @Id";

                db.Open();

                var items = db.Query<Batch>(query, new { Id = id }).OrderBy(o => o.BatchName)
                                                                 .ThenBy(o => o.Semester);

                LoadItemsWith(items);
            }
            return true;
        }



    }
}
