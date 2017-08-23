using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.Payroll
{
    public class TaxDataReader
    {
        public Tax GetItemWithId(int id)
        {
            const string query = "Select * from [Payroll_TaxTable] where Id = @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query<Tax>(query, new { Id = id }).FirstOrDefault();

                if (result == null) return null;

                result.RowStatus = RecordStatus.NoChanges;
                result.StartTrackingChanges();
                return result;
            }
        }
    }
}
