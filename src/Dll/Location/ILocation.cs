using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Location
{
    interface ILocation
    {
        string Province { get; set; }
        string Town { get; set; }
        string ZipCode { get; set; }
    }
}
