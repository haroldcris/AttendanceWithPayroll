using AiTech.LiteOrm;
using System.Collections.Generic;

namespace Dll.Location
{
    public class TownCollection : EntityCollection<Town>
    {
        public Province ProvinceClass { get; protected set; }

        public TownCollection()
        {
            ProvinceClass = null;
        }

        public TownCollection(Province parent)
        {
            ProvinceClass = parent;
        }

        private void SetParentOf(Town item)
        {
            item.ProvinceClass = ProvinceClass;
        }

        public override void Add(Town item)
        {
            SetParentOf(item);
            base.Add(item);
        }

        public override void AddRange(IEnumerable<Town> items)
        {
            foreach (var item in items) SetParentOf(item);
            base.AddRange(items);
        }
    }
}
