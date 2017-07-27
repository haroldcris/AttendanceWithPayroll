using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.Payroll
{
	
	[Table("Payroll_Deduction")]
	public partial class Deduction : Entity
	{
		
		#region Default Properties
		
		public string Code { get; set; }
		
		public string Description { get; set; }
		
		public bool Mandatory { get; set; }
		
		public int Priority { get; set; }
		
		public bool Active { get; set; }
		
		
		
		#endregion
		
		
		public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("Code", this.Code);
			OriginalValues.Add("Description", this.Description);
			OriginalValues.Add("Mandatory", this.Mandatory);
			OriginalValues.Add("Priority", this.Priority);
			OriginalValues.Add("Active", this.Active);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.Code, OriginalValues["Code"])) changes.Add("Code", this.Code);
			if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);
			if (!Equals(this.Mandatory, OriginalValues["Mandatory"])) changes.Add("Mandatory", this.Mandatory);
			if (!Equals(this.Priority, OriginalValues["Priority"])) changes.Add("Priority", this.Priority);
			if (!Equals(this.Active, OriginalValues["Active"])) changes.Add("Active", this.Active);
			
			return changes;
		}
	}
}
