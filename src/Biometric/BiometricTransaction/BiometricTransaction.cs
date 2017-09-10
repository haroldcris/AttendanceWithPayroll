using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Biometric
{

    public interface IBiometricTransaction
    {
        DateTime CalendarDate { get; set; }
        int BiometricId { get; set; }
        DateTime TimeLog { get; set; }
        string Station { get; set; }
        string IpAddress { get; set; }
        string InOut { get; set; }
        DateTime SmsDate { get; set; }

    }



    [Table("Biometric_DeviceLog")]
    public class BiometricTransaction : Entity, IBiometricTransaction
    {
        #region Default Properties
        public DateTime CalendarDate { get; set; }
        public int BiometricId { get; set; }
        public DateTime TimeLog { get; set; }
        public string Station { get; set; }
        public string IpAddress { get; set; }
        public string InOut { get; set; }
        public DateTime SmsDate { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"CalendarDate", this.CalendarDate},
                {"BiometricId", this.BiometricId},
                {"TimeLog", this.TimeLog},
                {"Station", this.Station},
                {"IpAddress", this.IpAddress},
                {"InOut", this.InOut},
                {"SmsDate", this.SmsDate}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.CalendarDate, OriginalValues["CalendarDate"])) changes.Add("CalendarDate", this.CalendarDate);
            if (!Equals(this.BiometricId, OriginalValues["BiometricId"])) changes.Add("BiometricId", this.BiometricId);
            if (!Equals(this.TimeLog, OriginalValues["TimeLog"])) changes.Add("TimeLog", this.TimeLog);
            if (!Equals(this.Station, OriginalValues["Station"])) changes.Add("Station", this.Station);
            if (!Equals(this.IpAddress, OriginalValues["IpAddress"])) changes.Add("IpAddress", this.IpAddress);
            if (!Equals(this.InOut, OriginalValues["InOut"])) changes.Add("InOut", this.InOut);
            if (!Equals(this.SmsDate, OriginalValues["SmsDate"])) changes.Add("SmsDate", this.SmsDate);



            return changes;
        }


    }

}
