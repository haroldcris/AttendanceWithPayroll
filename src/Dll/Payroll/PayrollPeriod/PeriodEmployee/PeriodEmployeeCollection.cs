using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Payroll
{
    public class PeriodEmployeeCollection : EntityCollection<PeriodEmployee>
    {
        private readonly PayrollPeriod _parentPayrollPeriod;

        public PeriodEmployeeCollection()
        {

        }

        public PeriodEmployeeCollection(PayrollPeriod parent)
        {
            _parentPayrollPeriod = parent;
        }



        public void LoadAllItems()
        {
            const string query = "SELECT * FROM Payroll_PeriodEmployee where PeriodId = @PeriodId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query<PeriodEmployee>(query, new { PeriodId = _parentPayrollPeriod.Id });

                foreach (var item in results) item.Deductions.LoadAllItems(db);
                LoadItemsWith(results);
            }

        }

    }
}
