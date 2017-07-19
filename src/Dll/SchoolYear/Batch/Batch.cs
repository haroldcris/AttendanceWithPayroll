using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.Entities;

namespace Dll.SchoolYear
{

    public interface IBatch
    {
        string BatchName { get; set; }
        string Semester { get; set; }

    }



    [Table("Batch")]
    public class Batch : Entity, IBatch
    {

        #region Default Properties
        public string BatchName { get; set; }
        public string Semester { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();
            OriginalValues.Add("BatchName", this.BatchName);
            OriginalValues.Add("Semester", this.Semester);

            //string[] x = { "ssss", "sss", "sss" };

        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.BatchName, OriginalValues["BatchName"])) changes.Add("BatchName", this.BatchName);
            if (!Equals(this.Semester, OriginalValues["Semester"])) changes.Add("Semester", this.Semester);



            return changes;
        }


    }

}
