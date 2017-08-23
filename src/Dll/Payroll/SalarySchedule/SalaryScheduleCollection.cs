using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Payroll
{
    public class SalaryScheduleCollection : EntityCollection<SalarySchedule>
    {
        public bool LoadItemsFromDb()
        {
            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = "Select * from [Payroll_SalarySchedule]";
                var items = db.Query<SalarySchedule>(sql);
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
