using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace AiTech.Account
{
    [Table("AccountTokens")]
    public class AccountToken: Entity
    {		
		#region Default Properties
		        		
        public string Username {get; set;}        		
        public string Token {get; set;}        		
        public DateTime Expiration {get; set;}        		
        public string WindowsUsername {get; set;}        		
        public string MachineName {get; set;}        		
        public string IpAddress {get; set;}

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Username", this.Username);
            OriginalValues.Add("Token", this.Token);
            OriginalValues.Add("Expiration", this.Expiration);
            OriginalValues.Add("WindowsUsername", this.WindowsUsername);
            OriginalValues.Add("MachineName", this.MachineName);
            OriginalValues.Add("IpAddress", this.IpAddress);
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (this.RowStatus == RecordStatus.DeletedRecord) return changes;


            if (!Equals(this.Username, OriginalValues["Username"]))
                changes.Add("Username", this.Username);

            if (!Equals(this.Token, OriginalValues["Token"]))
                changes.Add("Token", this.Token);

            if (!Equals(this.Expiration, OriginalValues["Expiration"]))
                changes.Add("Expiration", this.Expiration);

            if (!Equals(this.WindowsUsername, OriginalValues["WindowsUsername"]))
                changes.Add("WindowsUsername", this.WindowsUsername);

            if (!Equals(this.MachineName, OriginalValues["MachineName"]))
                changes.Add("MachineName", this.MachineName);

            if (!Equals(this.IpAddress, OriginalValues["IpAddress"]))
                changes.Add("IpAddress", this.IpAddress);

            if (changes.Count > 0) this.RowStatus = RecordStatus.ModifiedRecord;
            return changes;
        }
    }
	
}
