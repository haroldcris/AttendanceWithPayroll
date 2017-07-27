using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.Payroll
{
	
	[Table("Payroll_TaxTable")]
	public partial class Tax : Entity
	{
		
		#region Default Properties
		
		public int TaxID { get; set; }
		
		public string Description { get; set; }
		
		public string ShortDesc { get; set; }
		
		public int Dependent { get; set; }
		
		public decimal Exemption { get; set; }
		
		
		
		#endregion
		
		
		public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("TaxID", this.TaxID);
			OriginalValues.Add("Description", this.Description);
			OriginalValues.Add("ShortDesc", this.ShortDesc);
			OriginalValues.Add("Dependent", this.Dependent);
			OriginalValues.Add("Exemption", this.Exemption);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.TaxID, OriginalValues["TaxID"])) changes.Add("TaxID", this.TaxID);
			if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);
			if (!Equals(this.ShortDesc, OriginalValues["ShortDesc"])) changes.Add("ShortDesc", this.ShortDesc);
			if (!Equals(this.Dependent, OriginalValues["Dependent"])) changes.Add("Dependent", this.Dependent);
			if (!Equals(this.Exemption, OriginalValues["Exemption"])) changes.Add("Exemption", this.Exemption);
			
			return changes;
		}
	}
}
