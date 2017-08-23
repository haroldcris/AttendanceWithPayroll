using AiTech.LiteOrm;
using System.Collections.Generic;

namespace Dll.Location
{

    public class Town : Entity
    {
        public Province ProvinceClass { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }


        public Town()
        {
            ProvinceClass = new Province();
        }

        public override string ToString()
        {
            return Name;
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();
            OriginalValues.Add("Name", Name);
            OriginalValues.Add("ZipCode", ZipCode);
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            //if (!Equals(this.Province, OriginalValues["Province"])) changes.Add("Province", this.Province);
            if (!Equals(Name, OriginalValues["Name"])) changes.Add("Name", Name);
            if (!Equals(ZipCode, OriginalValues["ZipCode"])) changes.Add("ZipCode", ZipCode);

            return changes;
        }
    }
}
