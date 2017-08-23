using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{

    [Table("Payroll_PositionSG")]
    public class PositionSalaryGrade : Entity
    {

        #region Default Properties

        public int SalaryScheduleId { get; set; }

        public int PositionId { get; set; }
        public string PositionCode { get; set; }
        public string PositionDescription { get; set; }


        public int SG { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>
            {
                { "SalaryScheduleId", SalaryScheduleId },
                { "PositionId", PositionId },
                { "SG", SG }
            };

        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(SalaryScheduleId, OriginalValues["SalaryScheduleId"])) changes.Add("SalaryScheduleId", SalaryScheduleId);
            if (!Equals(PositionId, OriginalValues["PositionId"])) changes.Add("PositionId", PositionId);
            if (!Equals(SG, OriginalValues["SG"])) changes.Add("SG", SG);

            return changes;
        }
    }
}
