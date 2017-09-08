using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace AiTech.Biometric
{

    public interface ITransaction
    {
        long AutoID { get; set; }
        DateTime CalendarDate { get; set; }
        long BiometricId { get; set; }
        DateTime TimeLog { get; set; }
        string Station { get; set; }
        string IPAddress { get; set; }
        string InOut { get; set; }
        string EntryType { get; set; }
        string AutoInOut { get; set; }
        DateTime SmsDate { get; set; }

    }



    [Table("Biometric_DeviceLog")]
    public class Transaction : Entity, ITransaction
    {

        #region Default Properties
        public long AutoID { get; set; }
        public DateTime CalendarDate { get; set; }
        public long BiometricId { get; set; }
        public DateTime TimeLog { get; set; }
        public string Station { get; set; }
        public string IPAddress { get; set; }
        public string InOut { get; set; }
        public string EntryType { get; set; }
        public string AutoInOut { get; set; }
        public DateTime SmsDate { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"AutoID", this.AutoID},
                {"CalendarDate", this.CalendarDate},
                {"BiometricId", this.BiometricId},
                {"TimeLog", this.TimeLog},
                {"Station", this.Station},
                {"IPAddress", this.IPAddress},
                {"InOut", this.InOut},
                {"EntryType", this.EntryType},
                {"AutoInOut", this.AutoInOut},
                {"SmsDate", this.SmsDate}
            };
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
