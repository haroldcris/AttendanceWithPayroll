using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using Dll.Contacts;
using System.Collections.Generic;

namespace Dll.Biometric
{

    public interface IBiometricUser
    {
        int BiometricId { get; set; }
        int PersonId { get; set; }
        string Category { get; set; }
        string PhoneNumber { get; set; }

    }


    [Table("Biometric_User")]
    public class BiometricUser : Entity, IBiometricUser
    {

        #region Default Properties
        public int BiometricId { get; set; }
        public int PersonId { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }

        #endregion


        public Person PersonClass { get; set; }

        public BiometricUser()
        {
            PersonClass = new Person();
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"BiometricId", this.BiometricId},
                {"PersonId", this.PersonId},
                {"Category", this.Category},
                {"PhoneNumber", this.PhoneNumber}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.BiometricId, OriginalValues["BiometricId"])) changes.Add("BiometricId", this.BiometricId);
            if (!Equals(this.PersonId, OriginalValues["PersonId"])) changes.Add("PersonId", this.PersonId);
            if (!Equals(this.Category, OriginalValues["Category"])) changes.Add("Category", this.Category);
            if (!Equals(this.PhoneNumber, OriginalValues["PhoneNumber"])) changes.Add("PhoneNumber", this.PhoneNumber);



            return changes;
        }


        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.BiometricId != null) BiometricId = recordSource.BiometricId;
            if (recordSource.PersonId != null) PersonId = recordSource.PersonId;
            if (recordSource.Category != null) Category = recordSource.Category;
            if (recordSource.PhoneNumber != null) PhoneNumber = recordSource.PhoneNumber;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }

    }

}
