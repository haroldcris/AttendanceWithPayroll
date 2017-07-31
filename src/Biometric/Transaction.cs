using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace AiTech.Biometric
{
	
	[Table("Biometric_DeviceLog")]
	public partial class Transaction : Entity
	{
		
		#region Default Properties
		
		public long AutoID { get; set; }
		
		public DateTime? CalendarDate { get; set; }
		
		public long BiometricId { get; set; }
		
		public DateTime TimeLog { get; set; }
		
		public string Station { get; set; }
		
		public string IPAddress { get; set; }
		
		public string InOut { get; set; }
		
		public string EntryType { get; set; }
		
		public string AutoInOut { get; set; }
		
		public DateTime? SmsDate { get; set; }
		
		
		
		#endregion
		
		
		public override void StartTrackingChanges()
		{
			OriginalValues = new Dictionary<string, object>();
			
			OriginalValues.Add("AutoID", this.AutoID);
			OriginalValues.Add("CalendarDate", this.CalendarDate);
			OriginalValues.Add("BiometricId", this.BiometricId);
			OriginalValues.Add("TimeLog", this.TimeLog);
			OriginalValues.Add("Station", this.Station);
			OriginalValues.Add("IPAddress", this.IPAddress);
			OriginalValues.Add("InOut", this.InOut);
			OriginalValues.Add("EntryType", this.EntryType);
			OriginalValues.Add("AutoInOut", this.AutoInOut);
			OriginalValues.Add("SmsDate", this.SmsDate);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(this.AutoID, OriginalValues["AutoID"])) changes.Add("AutoID", this.AutoID);
			if (!Equals(this.CalendarDate, OriginalValues["CalendarDate"])) changes.Add("CalendarDate", this.CalendarDate);
			if (!Equals(this.BiometricId, OriginalValues["BiometricId"])) changes.Add("BiometricId", this.BiometricId);
			if (!Equals(this.TimeLog, OriginalValues["TimeLog"])) changes.Add("TimeLog", this.TimeLog);
			if (!Equals(this.Station, OriginalValues["Station"])) changes.Add("Station", this.Station);
			if (!Equals(this.IPAddress, OriginalValues["IPAddress"])) changes.Add("IPAddress", this.IPAddress);
			if (!Equals(this.InOut, OriginalValues["InOut"])) changes.Add("InOut", this.InOut);
			if (!Equals(this.EntryType, OriginalValues["EntryType"])) changes.Add("EntryType", this.EntryType);
			if (!Equals(this.AutoInOut, OriginalValues["AutoInOut"])) changes.Add("AutoInOut", this.AutoInOut);
			if (!Equals(this.SmsDate, OriginalValues["SmsDate"])) changes.Add("SmsDate", this.SmsDate);
			
			return changes;
		}
	}
}
