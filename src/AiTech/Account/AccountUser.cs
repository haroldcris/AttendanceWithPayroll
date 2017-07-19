using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace AiTech.Account
{

    public interface IAccountUser
    {
        string Username { get; set; }        string Password { get; set; }
    }



    [Table("AccountUsers")]
    public class AccountUser : Entity, IAccountUser
    {
        
        #region Default Properties
        public string Username { get; set; }        public string Password { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();
            OriginalValues.Add("Username", this.Username);            OriginalValues.Add("Password", this.Password);

        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.Username, OriginalValues["Username"])) changes.Add("Username", this.Username);            if (!Equals(this.Password, OriginalValues["Password"])) changes.Add("Password", this.Password);



            return changes;
        }


    }

}
