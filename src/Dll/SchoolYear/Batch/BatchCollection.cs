using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class BatchCollection : EntityCollection<Batch>
    {

        public bool LoadItemsFromDb()
        {
            const string query = "Select * from Batch";

            ItemCollection.Clear();
            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var items = db.Query<Batch>(query).OrderBy(o => o.BatchName)
                                                  .ThenBy(o => o.Semester);

                foreach (var item in items)
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

        public static bool Has(string batchName, string semester)
        {
            const string query = "Select 1 Record from Batch where BatchName = @Batch and Semester = @Semester";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var item = db.Query<int>(query, new { Batch = batchName, Semester = semester }).FirstOrDefault();

                return item != 0;
            }
        }

    }
}
