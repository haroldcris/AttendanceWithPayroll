using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.Payroll
{
	
	[Table("Payroll_SalarySchedule")]
	public partial class SalarySchedule : Entity
	{
		
		#region Default Properties
		
		public string Effectivity { get; set; }
		
		public string Remarks { get; set; }

        public PositionSalaryGradeCollection PositionSalaryGrades { get; set; }

        #endregion

        public SalarySchedule()
        {
            this.PositionSalaryGrades = new PositionSalaryGradeCollection(this);
        }

        public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("Effectivity", this.Effectivity);
			OriginalValues.Add("Remarks", this.Remarks);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.Effectivity, OriginalValues["Effectivity"])) changes.Add("Effectivity", this.Effectivity);
			if (!Equals(this.Remarks, OriginalValues["Remarks"])) changes.Add("Remarks", this.Remarks);
			
			return changes;
		}
	}
}
