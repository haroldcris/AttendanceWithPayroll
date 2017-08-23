using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.Payroll
{

    [Table("Payroll_SalarySchedule")]
    public class SalarySchedule : Entity
    {

        #region Default Properties

        public DateTime Effectivity { get; set; }

        public string Remarks { get; set; }

        public PositionSalaryGradeCollection PositionSalaryGrades { get; }
        public SalaryGradeCollection SalaryGrades { get; }

        #endregion

        public SalarySchedule()
        {
            PositionSalaryGrades = new PositionSalaryGradeCollection();
            PositionSalaryGrades.OnSalarySchedIdRequest += () => Id;

            SalaryGrades = new SalaryGradeCollection();
            SalaryGrades.OnSalaryScheduleIdRequest += () => Id;

            Effectivity = DateTime.Today;
        }


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>
            {
                {"Effectivity", Effectivity},
                { "Remarks", Remarks}
            };

        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Effectivity, OriginalValues["Effectivity"])) changes.Add("Effectivity", Effectivity);
            if (!Equals(Remarks, OriginalValues["Remarks"])) changes.Add("Remarks", Remarks);

            return changes;
        }
    }
}
