using AiTech.LiteOrm;
using System;
using System.Collections.Generic;

namespace Dll.Biometric
{
    public class BiometricLog : Entity
    {
        #region Default Properties

        public DateTime CalendarDate { get; set; }
        public DateTime TimeLog { get; set; }
        public string Station { get; set; }
        public string IpAddress { get; set; }
        public string InOut { get; set; }

        #endregion

        public override void StartTrackingChanges()
        {
            //throw new NotImplementedException();
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            //throw new NotImplementedException();
            return new Dictionary<string, object>();
        }
    }
}
