using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Payroll
{
    public class TaxCollection : EntityCollection<Tax>
    {
        public bool LoadItemsFromDb()
        {
            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = "Select * from [Payroll_TaxTable]";
                var items = db.Query<Tax>(sql);

                LoadItemsWith(items);

                //foreach (var item in items)
                //{
                //    item.RowStatus = AiTech.Entities.RecordStatus.NoChanges;
                //    item.StartTrackingChanges();
                //    this.ItemCollection.Add(item);
                //}
            }
            return true;
        }
    }

}
