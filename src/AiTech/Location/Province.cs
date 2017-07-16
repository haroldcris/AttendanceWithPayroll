
using System.Collections.Generic;

namespace AiTech.Location
{
    public struct Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
