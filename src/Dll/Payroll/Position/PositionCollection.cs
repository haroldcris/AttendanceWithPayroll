using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Payroll
{
    public class PositionCollection : EntityCollection<Position>
    {

        public bool LoadItemsFromDb()
        {
            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = "Select * from Payroll_Position";
                var items = db.Query<Position>(sql);
                foreach (var item in items)
                {
                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }
            return true;
        }
    }

}
