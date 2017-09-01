using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;
using System.Linq;

namespace Dll.Payroll
{
    public class SalaryScheduleDataReader
    {
        public SalarySchedule GetItemWithEffectivity(DateTime effectivity)
        {
            const string query = "Select * from [Payroll_SalarySchedule] where Effectivity = @Effectivity";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<SalarySchedule>(query, new { Effectivity = effectivity }).FirstOrDefault();

                if (result == null) return null;

                result.RowStatus = RecordStatus.NoChanges;
                result.StartTrackingChanges();

                return result;
            }
        }


        public decimal GetSalaryOfPositionId(int positionId, int step, DateTime baselineDate)
        {
            const string query = "Select dbo.GetSalaryOfPositionId(@PositionId, @Step, @BaselineDate)";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<decimal>(query, new { PositionId = positionId, Step = step, BaselineDate = baselineDate }).FirstOrDefault();

                return result;
            }
        }

    }
}
