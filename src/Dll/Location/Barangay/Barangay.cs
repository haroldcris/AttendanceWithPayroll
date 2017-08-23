using AiTech.LiteOrm;
using System.Collections.Generic;

namespace Dll.Location
{


    public class Barangay : Entity
    {
        public string Province { get; set; }
        public string Town { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }



        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();
            OriginalValues.Add("Province", Province);
            OriginalValues.Add("Town", Town);
            OriginalValues.Add("Name", Name);

        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Province, OriginalValues["Province"])) changes.Add("Province", Province);
            if (!Equals(Town, OriginalValues["Town"])) changes.Add("Town", Town);
            if (!Equals(Name, OriginalValues["Name"])) changes.Add("Name", Name);


            return changes;
        }
    }
}
