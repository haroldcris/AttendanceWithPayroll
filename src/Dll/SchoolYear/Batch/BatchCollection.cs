using System.Linq;
using Dapper;
using AiTech.Database;

namespace Dll.SchoolYear
{
    public class BatchCollection : AiTech.Entities.EntityCollection<Batch>
    {

        public bool LoadItemsFromDb()
        {
            this.ItemCollection.Clear();
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = "Select * from Batch";
                var items = db.Query<Batch>(sql).OrderBy(o => o.BatchName)
                                                 .ThenBy(o => o.Semester);

                foreach (var item in items)
                {
                    item.RowStatus = AiTech.Entities.RecordStatus.NoChanges;
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
                db.Open();
                var sql = "Select * from Batch where Id = @Id";
                var items = db.Query<Batch>(sql, new { Id = id }).OrderBy(o => o.BatchName)
                                                                 .ThenBy(o => o.Semester);

                foreach (var item in items)
                {
                    item.RowStatus = AiTech.Entities.RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    this.ItemCollection.Add(item);
                }
            }
            return true;
        }

        public static bool Has(string batchName, string semester)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = "Select 1 Record from Batch where BatchName = @Batch and Semester = @Semester";
                var item = db.Query<int>(sql, new { Batch = batchName, Semester = semester }).FirstOrDefault();

                return item != 0;
            }
        }

    }
}
