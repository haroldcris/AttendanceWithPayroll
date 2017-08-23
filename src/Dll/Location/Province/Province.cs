using AiTech.LiteOrm;
using System.Collections.Generic;

namespace Dll.Location
{
    public class ProvinceCollection : EntityCollection<Province> { }

    public class Province : Entity
    {
        public string Name { get; set; }
        public TownCollection Towns { get; set; }

        public Province()
        {
            Towns = new TownCollection(this);
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();
            OriginalValues.Add("Name", Name);


            // Towns
            foreach (var item in Towns.Items)
                item.StartTrackingChanges();

        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Name, OriginalValues["Name"])) changes.Add("Name", Name);

            return changes;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
