using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.Payroll
{
	
	[Table("Payroll_PositionSG")]
	public partial class PositionSalaryGrade : Entity
	{
		
		#region Default Properties
		
		public int SalaryScheduleId { get; set; }
		
		public int PositionId { get; set; }
		
		public int SG { get; set; }

        public Position Position { get; set; }
        public SalarySchedule SalarySchedule { get; set; }


        #endregion


        public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("SalaryScheduleId", this.SalaryScheduleId);
			OriginalValues.Add("PositionId", this.PositionId);
			OriginalValues.Add("SG", this.SG);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.SalaryScheduleId, OriginalValues["SalaryScheduleId"])) changes.Add("SalaryScheduleId", this.SalaryScheduleId);
			if (!Equals(this.PositionId, OriginalValues["PositionId"])) changes.Add("PositionId", this.PositionId);
			if (!Equals(this.SG, OriginalValues["SG"])) changes.Add("SG", this.SG);
			
			return changes;
		}
	}
}
