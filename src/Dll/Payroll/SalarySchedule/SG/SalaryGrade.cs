using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{

    [Table("Payroll_SalaryGrade")]
    public partial class SalaryGrade : Entity
    {

        #region Default Properties

        public int SalaryScheduleId { get; set; }

        public int SG { get; set; }

        public decimal Step1 { get; set; }

        public decimal Step2 { get; set; }

        public decimal Step3 { get; set; }

        public decimal Step4 { get; set; }

        public decimal Step5 { get; set; }

        public decimal Step6 { get; set; }

        public decimal Step7 { get; set; }

        public decimal Step8 { get; set; }


        #endregion



        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("SalaryScheduleId", SalaryScheduleId);
            OriginalValues.Add("SG", SG);
            OriginalValues.Add("Step1", Step1);
            OriginalValues.Add("Step2", Step2);
            OriginalValues.Add("Step3", Step3);
            OriginalValues.Add("Step4", Step4);
            OriginalValues.Add("Step5", Step5);
            OriginalValues.Add("Step6", Step6);
            OriginalValues.Add("Step7", Step7);
            OriginalValues.Add("Step8", Step8);
        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(SalaryScheduleId, OriginalValues["SalaryScheduleId"])) changes.Add("SalaryScheduleId", SalaryScheduleId);
            if (!Equals(SG, OriginalValues["SG"])) changes.Add("SG", SG);
            if (!Equals(Step1, OriginalValues["Step1"])) changes.Add("Step1", Step1);
            if (!Equals(Step2, OriginalValues["Step2"])) changes.Add("Step2", Step2);
            if (!Equals(Step3, OriginalValues["Step3"])) changes.Add("Step3", Step3);
            if (!Equals(Step4, OriginalValues["Step4"])) changes.Add("Step4", Step4);
            if (!Equals(Step5, OriginalValues["Step5"])) changes.Add("Step5", Step5);
            if (!Equals(Step6, OriginalValues["Step6"])) changes.Add("Step6", Step6);
            if (!Equals(Step7, OriginalValues["Step7"])) changes.Add("Step7", Step7);
            if (!Equals(Step8, OriginalValues["Step8"])) changes.Add("Step8", Step8);

            return changes;
        }
    }
}
