using AiTech.LiteOrm.Database;
using Dapper;
using System;
using System.Linq;

namespace Dll.Payroll
{
    public class PayrollPeriodDataReader
    {

        public bool HasExistingPeriod(DateTime period)
        {
            const string query = "SELECT 1 from PAYROLL_PERIOD where CONVERT(DATETIME, DateCovered) = @Period";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query(query, new { Period = period });

                return result.Any();
            }
        }
    }
}
