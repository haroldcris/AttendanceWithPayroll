using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

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

        public SalarySchedule SalarySchedule { get; set; }

        public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("SalaryScheduleId", this.SalaryScheduleId);
			OriginalValues.Add("SG", this.SG);
			OriginalValues.Add("Step1", this.Step1);
			OriginalValues.Add("Step2", this.Step2);
			OriginalValues.Add("Step3", this.Step3);
			OriginalValues.Add("Step4", this.Step4);
			OriginalValues.Add("Step5", this.Step5);
			OriginalValues.Add("Step6", this.Step6);
			OriginalValues.Add("Step7", this.Step7);
			OriginalValues.Add("Step8", this.Step8);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.SalaryScheduleId, OriginalValues["SalaryScheduleId"])) changes.Add("SalaryScheduleId", this.SalaryScheduleId);
			if (!Equals(this.SG, OriginalValues["SG"])) changes.Add("SG", this.SG);
			if (!Equals(this.Step1, OriginalValues["Step1"])) changes.Add("Step1", this.Step1);
			if (!Equals(this.Step2, OriginalValues["Step2"])) changes.Add("Step2", this.Step2);
			if (!Equals(this.Step3, OriginalValues["Step3"])) changes.Add("Step3", this.Step3);
			if (!Equals(this.Step4, OriginalValues["Step4"])) changes.Add("Step4", this.Step4);
			if (!Equals(this.Step5, OriginalValues["Step5"])) changes.Add("Step5", this.Step5);
			if (!Equals(this.Step6, OriginalValues["Step6"])) changes.Add("Step6", this.Step6);
			if (!Equals(this.Step7, OriginalValues["Step7"])) changes.Add("Step7", this.Step7);
			if (!Equals(this.Step8, OriginalValues["Step8"])) changes.Add("Step8", this.Step8);
			
			return changes;
		}
	}
}
