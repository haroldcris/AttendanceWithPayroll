using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiTech.Entities;

namespace Dll.Location
{
    public class Location: ILocation, AiTech.Entities.ITrackableObject
    {
        public string Street { get; set; }
        public string Town { get; set; }
        public string Barangay { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }


        public Location()
        {
            Street = "";
            Town = "";
            Barangay = "";
            Province = "";
            ZipCode = "";
        }

        public Dictionary<string, object> OriginalValues { get; private set; }
        /// <summary>
        /// Starts Tracking Changes inside Dictionary
        /// </summary>
        public void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Street", this.Street);
            OriginalValues.Add("Barangay", this.Barangay);
            OriginalValues.Add("Town", this.Town);
            OriginalValues.Add("Province", this.Province);
            OriginalValues.Add("ZipCode", this.ZipCode);
        }

        public Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals( this.Street, OriginalValues["Street"])) changes.Add("Street", this.Street);
            if (!Equals( this.Barangay, OriginalValues["Barangay"])) changes.Add("Barangay", this.Barangay);
            if (!Equals( this.Town , OriginalValues["Town"])) changes.Add("Town", this.Town);
            if (!Equals( this.Province , OriginalValues["Province"])) changes.Add("Province", this.Province);
            if (!Equals( this.ZipCode , OriginalValues["ZipCode"])) changes.Add("ZipCode", this.ZipCode);
            
            return changes;
        }
    }
}
