﻿using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace AiTech.Account
{

    public interface IAccountUser
    {
        string Username { get; set; }
    }



    [Table("AccountUsers")]
    public class AccountUser : Entity, IAccountUser
    {
        
        #region Default Properties
        public string Username { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();
            OriginalValues.Add("Username", this.Username);

        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.Username, OriginalValues["Username"])) changes.Add("Username", this.Username);



            return changes;
        }


    }

}