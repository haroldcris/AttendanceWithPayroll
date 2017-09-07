using AiTech.LiteOrm;
using Dapper;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PeriodEmployeeDeductionCollection : EntityCollection<PeriodEmployeeDeduction>
    {
        private readonly PeriodEmployee _periodEmployee;
        public PeriodEmployeeDeductionCollection()
        {

        }


        public PeriodEmployeeDeductionCollection(PeriodEmployee parent)
        {
            _periodEmployee = parent;
        }
        public void LoadAllItems(SqlConnection db)
        {
            const string query = "Select * from Payroll_PeriodEmployeeDeduction where PeriodEmployeeId = @PeriodEmployeeId";

            var results = db.Query<PeriodEmployeeDeduction>(query, new { PeriodEmployeeId = _periodEmployee.Id });

            if (results == null) return;

            LoadItemsWith(results);
        }

    }
}
