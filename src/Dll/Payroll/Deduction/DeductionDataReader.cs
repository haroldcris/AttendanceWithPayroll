using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.Payroll
{
    public class DeductionDataReader
    {
        public Deduction GetItemWithCode(string code)
        {
            const string query = "Select * from [Payroll_Deduction] where Code = @Code";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<Deduction>(query, new { Code = code }).FirstOrDefault();

                if (result == null) return null;

                result.RowStatus = RecordStatus.NoChanges;
                result.StartTrackingChanges();

                return result;
            }
        }
    }
}
