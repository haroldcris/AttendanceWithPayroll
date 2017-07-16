using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTech.Location
{
    public struct Barangay
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
