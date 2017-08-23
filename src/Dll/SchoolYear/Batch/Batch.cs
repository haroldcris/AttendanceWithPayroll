using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    [Table("Batch")]
    public class Batch : Entity
    {

        #region Default Properties
        public string BatchName { get; set; }
        public string Semester { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues =
                new Dictionary<string, object>
                {
                    {"BatchName", BatchName},
                    { "Semester", Semester}
                };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(BatchName, OriginalValues["BatchName"])) changes.Add("BatchName", BatchName);
            if (!Equals(Semester, OriginalValues["Semester"])) changes.Add("Semester", Semester);

            return changes;
        }


    }

}
