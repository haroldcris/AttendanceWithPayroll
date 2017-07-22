using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.SchoolYear
{
	
	[Table("Course")]
	public partial class Course : Entity
	{
		
		#region Default Properties
		
		public string CourseCode { get; set; }
		
		public string Description { get; set; }
		
		
		
		#endregion
		
		
		public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("CourseCode", this.CourseCode);
			OriginalValues.Add("Description", this.Description);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.CourseCode, OriginalValues["CourseCode"])) changes.Add("CourseCode", this.CourseCode);
			if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);
			
			return changes;
		}
	}
}
