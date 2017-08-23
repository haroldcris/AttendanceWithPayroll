using AiTech.LiteOrm;
using System.Collections.Generic;

namespace Dll.Contacts
{
    public class PersonName : ITrackableObject
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string MiddleInitial { get; set; }
        public string NameExtension { get; set; }

        public string SpouseLastname { get; set; }

        public PersonName()
        {
            Lastname = "";
            Firstname = "";
            Middlename = "";
            MiddleInitial = "";
            NameExtension = "";
            SpouseLastname = "";
        }




        public string FullMaidenName
        {
            get
            {
                var str = $"{Lastname} , {Firstname} {Middlename} {NameExtension}";

                return str.TrimEnd();
            }
        }



        public string Fullname
        {
            get
            {
                var sLast = Lastname;
                var sMiddle = Middlename;


                if (!string.IsNullOrEmpty(SpouseLastname))
                {
                    sMiddle = Lastname;
                    sLast = SpouseLastname;
                }


                var str = $"{sLast} , {Firstname} {sMiddle} {NameExtension}";

                return str.TrimEnd();
            }

        }


        public string FullnameWithLastnameFirst
        {
            get
            {
                var str = string.Empty;

                str += Lastname;
                str += " , " + Firstname;
                str += " " + Middlename;
                str += " " + NameExtension;

                return str.TrimEnd();
            }
        }

        public string FullnameWithFirstnameFirst
        {
            get
            {
                var str = string.Empty;

                str += Firstname;
                str += " " + Middlename;
                str += " " + Lastname;
                str += " " + NameExtension;

                return str.TrimEnd();
            }
        }




        public Dictionary<string, object> OriginalValues { get; private set; }
        /// <summary>
        /// Starts Tracking Changes inside Dictionary
        /// </summary>
        public void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Lastname", Lastname);
            OriginalValues.Add("Firstname", Firstname);
            OriginalValues.Add("Middlename", Middlename);
            OriginalValues.Add("MiddleInitial", MiddleInitial);
            OriginalValues.Add("NameExtension", NameExtension);
        }

        public Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Lastname, OriginalValues["Lastname"])) changes.Add("Lastname", Lastname);
            if (!Equals(Firstname, OriginalValues["Firstname"])) changes.Add("Firstname", Firstname);
            if (!Equals(Middlename, OriginalValues["Middlename"])) changes.Add("Middlename", Middlename);
            if (!Equals(MiddleInitial, OriginalValues["MiddleInitial"])) changes.Add("MiddleInitial", MiddleInitial);
            if (!Equals(NameExtension, OriginalValues["NameExtension"])) changes.Add("NameExtension", NameExtension);

            return changes;
        }
    }
}
