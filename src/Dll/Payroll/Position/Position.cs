using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.Payroll
{
	
	[Table("Payroll_Position")]
	public partial class Position : Entity
	{
		
		#region Default Properties
		
		public string Code { get; set; }
		
		public string Description { get; set; }
		
		
		
		#endregion
		
		
		public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("Code", this.Code);
			OriginalValues.Add("Description", this.Description);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.Code, OriginalValues["Code"])) changes.Add("Code", this.Code);
			if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);
			
			return changes;
		}
	}
}
