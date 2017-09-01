using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Contacts
{

    public interface IMobileNumber
    {
        int PersonId { get; set; }
        string PhoneNumber { get; set; }

    }



    [Table("Person_MobileNumber")]
    public class MobileNumber : Entity, IMobileNumber
    {

        #region Default Properties
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"PersonId", this.PersonId},
                {"PhoneNumber", this.PhoneNumber}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.PersonId, OriginalValues["PersonId"])) changes.Add("PersonId", this.PersonId);
            if (!Equals(this.PhoneNumber, OriginalValues["PhoneNumber"])) changes.Add("PhoneNumber", this.PhoneNumber);



            return changes;
        }


    }

}
