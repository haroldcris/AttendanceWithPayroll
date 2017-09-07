using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;
using System.Linq;

namespace Dll.Payroll
{
    public class SalaryScheduleDataReader
    {

        /// <summary>
        /// Find the Closest Salary Schedule from the baseline Date
        /// </summary>
        /// <param name="baseline"></param>
        /// <returns></returns>
        public SalarySchedule GetItemFromBaselineDate(DateTime baseline)
        {
            const string query = "Select Id, Effectivity, Remarks from [Payroll_SalarySchedule] where Effectivity <= @Effectivity order by Effectivity Desc";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<SalarySchedule>(query, new { Effectivity = baseline }).FirstOrDefault();

                if (result == null) return null;

                result.RowStatus = RecordStatus.NoChanges;
                result.StartTrackingChanges();

                return result;
            }
        }

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
