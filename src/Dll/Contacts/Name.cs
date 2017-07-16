using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Contacts
{
    public class PersonName : AiTech.Entities.ITrackableObject
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string MiddleInitial { get; set; }
        public string NameExtension { get; set; }

        public PersonName()
        {
            Lastname = "";
            Firstname = "";
            Middlename = "";
            MiddleInitial = "";
            NameExtension = "";
        }


        public string FullnameWithLastnameFirst()
        {
            var str = string.Empty;

            str += Lastname;
            str += " , " + Firstname;
            str += " " + Middlename;
            str += " " + NameExtension;

            return str.TrimEnd();
        }

        public string FullnameWithFirstnameFirst()
        {
            var str = string.Empty;

            str += Firstname;
            str += " " + Middlename;
            str += " " + Lastname;
            str += " " + NameExtension;

            return str.TrimEnd();
        }




        public Dictionary<string, object> OriginalValues { get; private set; }
        /// <summary>
        /// Starts Tracking Changes inside Dictionary
        /// </summary>
        public void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Lastname", this.Lastname);
            OriginalValues.Add("Firstname", this.Firstname);
            OriginalValues.Add("Middlename", this.Middlename);
            OriginalValues.Add("MiddleInitial", this.MiddleInitial);
            OriginalValues.Add("NameExtension", this.NameExtension);
        }

        public Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.Lastname, OriginalValues["Lastname"])) changes.Add("Lastname", this.Lastname);
            if (!Equals(Firstname, OriginalValues["Firstname"])) changes.Add("Firstname", this.Firstname);
            if (!Equals(Middlename, OriginalValues["Middlename"])) changes.Add("Middlename", this.Middlename);
            if (!Equals(MiddleInitial, OriginalValues["MiddleInitial"])) changes.Add("MiddleInitial", this.MiddleInitial);
            if (!Equals(NameExtension,OriginalValues["NameExtension"])) changes.Add("NameExtension", this.NameExtension);

            return changes;
        }
    }
}
