using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using Dll.Contacts;
using System;
using System.Collections.Generic;

namespace Dll.Biometric
{

    public interface IBiometricUser
    {
        int BiometricId { get; set; }
        int PersonId { get; set; }
        string Category { get; set; }
        string PhoneNumber { get; set; }
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

        DateTime SatIn { get; set; }
        DateTime SatOut { get; set; }
    }



    [Table("Biometric_User")]
    public class BiometricUser : Entity, IBiometricUser
    {

        #region Default Properties
        public int BiometricId { get; set; }
        public int PersonId { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
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

        public DateTime SatIn { get; set; }
        public DateTime SatOut { get; set; }

        #endregion


        public Person PersonClass { get; set; }

        public BiometricLogCollection BiometricLogs { get; set; }


        public BiometricUser()
        {
            PersonClass = new Person();

            BiometricLogs = new BiometricLogCollection(this);

        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"BiometricId", this.BiometricId},
                {"PersonId", this.PersonId},
                {"Category", this.Category},
                {"PhoneNumber", this.PhoneNumber},
                {"MonIn", this.MonIn},
                {"MonOut", this.MonOut},
                {"TueIn", this.TueIn},
                {"TueOut", this.TueOut},
                {"WedIn", this.WedIn},
                {"WedOut", this.WedOut},
                {"ThuIn", this.ThuIn},
                {"ThuOut", this.ThuOut},
                {"FriIn", this.FriIn},
                {"FriOut", this.FriOut},
                {"SatIn", this.SatIn},
                {"SatOut", this.SatOut},
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.BiometricId, OriginalValues["BiometricId"])) changes.Add("BiometricId", this.BiometricId);
            if (!Equals(this.PersonId, OriginalValues["PersonId"])) changes.Add("PersonId", this.PersonId);
            if (!Equals(this.Category, OriginalValues["Category"])) changes.Add("Category", this.Category);
            if (!Equals(this.PhoneNumber, OriginalValues["PhoneNumber"])) changes.Add("PhoneNumber", this.PhoneNumber);
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

            if (!Equals(this.SatIn, OriginalValues["SatIn"])) changes.Add("SatIn", this.SatIn);
            if (!Equals(this.SatOut, OriginalValues["SatOut"])) changes.Add("SatOut", this.SatOut);



            return changes;
        }



        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;

            if (recordSource.BiometricId != null) BiometricId = recordSource.BiometricId;
            if (recordSource.PersonId != null) PersonId = recordSource.PersonId;
            if (recordSource.Category != null) Category = recordSource.Category;
            if (recordSource.PhoneNumber != null) PhoneNumber = recordSource.PhoneNumber;
            if (recordSource.MonIn != null) MonIn = DateTime.Today + recordSource.MonIn;
            if (recordSource.MonOut != null) MonOut = DateTime.Today + recordSource.MonOut;
            if (recordSource.TueIn != null) TueIn = DateTime.Today + recordSource.TueIn;
            if (recordSource.TueOut != null) TueOut = DateTime.Today + recordSource.TueOut;
            if (recordSource.WedIn != null) WedIn = DateTime.Today + recordSource.WedIn;
            if (recordSource.WedOut != null) WedOut = DateTime.Today + recordSource.WedOut;
            if (recordSource.ThuIn != null) ThuIn = DateTime.Today + recordSource.ThuIn;
            if (recordSource.ThuOut != null) ThuOut = DateTime.Today + recordSource.ThuOut;
            if (recordSource.FriIn != null) FriIn = DateTime.Today + recordSource.FriIn;
            if (recordSource.FriOut != null) FriOut = DateTime.Today + recordSource.FriOut;
            if (recordSource.SatIn != null) SatIn = DateTime.Today + recordSource.SatIn;
            if (recordSource.SatOut != null) SatOut = DateTime.Today + recordSource.SatOut;


            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


    }

}
