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
			
			OriginalValues.Add("AutoID", AutoID);
			OriginalValues.Add("CalendarDate", CalendarDate);
			OriginalValues.Add("BiometricId", BiometricId);
			OriginalValues.Add("TimeLog", TimeLog);
			OriginalValues.Add("Station", Station);
			OriginalValues.Add("IPAddress", IPAddress);
			OriginalValues.Add("InOut", InOut);
			OriginalValues.Add("EntryType", EntryType);
			OriginalValues.Add("AutoInOut", AutoInOut);
			OriginalValues.Add("SmsDate", SmsDate);
		}
		
		
		public override Dictionary<string, object> GetChangedValues()
		{
			var changes = new Dictionary<string, object>();
			
			if (!Equals(AutoID, OriginalValues["AutoID"])) changes.Add("AutoID", AutoID);
			if (!Equals(CalendarDate, OriginalValues["CalendarDate"])) changes.Add("CalendarDate", CalendarDate);
			if (!Equals(BiometricId, OriginalValues["BiometricId"])) changes.Add("BiometricId", BiometricId);
			if (!Equals(TimeLog, OriginalValues["TimeLog"])) changes.Add("TimeLog", TimeLog);
			if (!Equals(Station, OriginalValues["Station"])) changes.Add("Station", Station);
			if (!Equals(IPAddress, OriginalValues["IPAddress"])) changes.Add("IPAddress", IPAddress);
			if (!Equals(InOut, OriginalValues["InOut"])) changes.Add("InOut", InOut);
			if (!Equals(EntryType, OriginalValues["EntryType"])) changes.Add("EntryType", EntryType);
			if (!Equals(AutoInOut, OriginalValues["AutoInOut"])) changes.Add("AutoInOut", AutoInOut);
			if (!Equals(SmsDate, OriginalValues["SmsDate"])) changes.Add("SmsDate", SmsDate);
			
			return changes;
		}
	}
}
