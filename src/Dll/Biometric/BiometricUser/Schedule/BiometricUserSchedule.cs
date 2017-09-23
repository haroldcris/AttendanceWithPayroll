using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.Biometric
{

    public interface IBiometricUserSchedule
    {
        int BiometricId { get; set; }
        DateTime MonIn { get; set; }
        DateTime MonOut { get; set; }
        DateTime TueIn { get; set; }
        DateTime TueOut { get; set; }
        DateTime WedIn { get; set; }
        DateTime WedOut { get; set; }
        DateTime ThuIn { get; set; }
        DateTime ThuOut { get; set; }
        DateTime FriIn { get; set; }
        DateTime FriOut { get; set; }

    }



    [Table("Biometric_Schedule_Weekly")]
    public class BiometricUserSchedule : Entity, IBiometricUserSchedule
    {

        #region Default Properties
        public int BiometricId { get; set; }
        public DateTime MonIn { get; set; }
        public DateTime MonOut { get; set; }
        public DateTime TueIn { get; set; }
        public DateTime TueOut { get; set; }
        public DateTime WedIn { get; set; }
        public DateTime WedOut { get; set; }
        public DateTime ThuIn { get; set; }
        public DateTime ThuOut { get; set; }
        public DateTime FriIn { get; set; }
        public DateTime FriOut { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"BiometricId", this.BiometricId},
                {"MonIn", this.MonIn},
                {"MonOut", this.MonOut},
                {"TueIn", this.TueIn},
                {"TueOut", this.TueOut},
                {"WedIn", this.WedIn},
                {"WedOut", this.WedOut},
                {"ThuIn", this.ThuIn},
                {"ThuOut", this.ThuOut},
                {"FriIn", this.FriIn},
                {"FriOut", this.FriOut}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.BiometricId, OriginalValues["BiometricId"])) changes.Add("BiometricId", this.BiometricId);
            if (!Equals(this.MonIn, OriginalValues["MonIn"])) changes.Add("MonIn", this.MonIn);
            if (!Equals(this.MonOut, OriginalValues["MonOut"])) changes.Add("MonOut", this.MonOut);
            if (!Equals(this.TueIn, OriginalValues["TueIn"])) changes.Add("TueIn", this.TueIn);
            if (!Equals(this.TueOut, OriginalValues["TueOut"])) changes.Add("TueOut", this.TueOut);
            if (!Equals(this.WedIn, OriginalValues["WedIn"])) changes.Add("WedIn", this.WedIn);
            if (!Equals(this.WedOut, OriginalValues["WedOut"])) changes.Add("WedOut", this.WedOut);
            if (!Equals(this.ThuIn, OriginalValues["ThuIn"])) changes.Add("ThuIn", this.ThuIn);
            if (!Equals(this.ThuOut, OriginalValues["ThuOut"])) changes.Add("ThuOut", this.ThuOut);
            if (!Equals(this.FriIn, OriginalValues["FriIn"])) changes.Add("FriIn", this.FriIn);
            if (!Equals(this.FriOut, OriginalValues["FriOut"])) changes.Add("FriOut", this.FriOut);



            return changes;
        }


    }

}
