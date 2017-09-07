using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Payroll
{
    public class PayrollPeriodCollection : EntityCollection<PayrollPeriod>
    {


        public void LoadAllItems()
        {
            const string query = "SELECT * FROM Payroll_Period";


            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query<PayrollPeriod>(query);

                LoadItemsWith(results);
            }

        }

    }
}
