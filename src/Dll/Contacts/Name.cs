namespace Dll.Contacts
{
    public class PersonName //: ITrackableObject
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string MiddleInitial { get; set; }
        public string NameExtension { get; set; }

        public string MaidenMiddlename { get; set; }

        public PersonName()
        {
            Lastname = "";
            Firstname = "";
            Middlename = "";
            MiddleInitial = "";
            NameExtension = "";
            MaidenMiddlename = "";
        }




        public string FullMaidenName
        {
            get
            {
                //Middlename will be your Lastname
                var str = $"{Middlename} , {Firstname} {MaidenMiddlename} {NameExtension}";

                return str.TrimEnd();
            }
        }



        public string Fullname
        {
            get
            {
                //if (!string.IsNullOrEmpty(MaidenMiddlename))
                //{
                //    sMiddle = Lastname;
                //    sLast = MaidenMiddlename;
                //}


                var str = $"{Lastname} , {Firstname} {Middlename} {NameExtension}";

                return str.TrimEnd();
            }

        }


        public string FullnameWithMaiden
        {
            get
            {

                var str = $"{Middlename}-{Lastname} , {Firstname} {MaidenMiddlename} {NameExtension}";

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

        //public string FullnameWithFirstnameFirst
        //{
        //    get
        //    {
        //        var str = string.Empty;

        //        str += Firstname;
        //        str += " " + Middlename;
        //        str += " " + Lastname;
        //        str += " " + NameExtension;

        //        return str.TrimEnd();
        //    }
        //}




        //public Dictionary<string, object> OriginalValues { get; private set; }
        ///// <summary>
        ///// Starts Tracking Changes inside Dictionary
        ///// </summary>
        //public void StartTrackingChanges()
        //{
        //    OriginalValues = new Dictionary<string, object>();

        //    OriginalValues.Add("Lastname", Lastname);
        //    OriginalValues.Add("Firstname", Firstname);
        //    OriginalValues.Add("Middlename", Middlename);
        //    OriginalValues.Add("MiddleInitial", MiddleInitial);
        //    OriginalValues.Add("NameExtension", NameExtension);
        //    OriginalValues.Add("MaidenMiddlename", MaidenMiddlename);
        //}

        //public Dictionary<string, object> GetChangedValues()
        //{
        //    var changes = new Dictionary<string, object>();

        //    if (!Equals(Lastname, OriginalValues["Lastname"])) changes.Add("Lastname", Lastname);
        //    if (!Equals(Firstname, OriginalValues["Firstname"])) changes.Add("Firstname", Firstname);
        //    if (!Equals(Middlename, OriginalValues["Middlename"])) changes.Add("Middlename", Middlename);
        //    if (!Equals(MiddleInitial, OriginalValues["MiddleInitial"])) changes.Add("MiddleInitial", MiddleInitial);
        //    if (!Equals(NameExtension, OriginalValues["NameExtension"])) changes.Add("NameExtension", NameExtension);
        //    if (!Equals(MaidenMiddlename, OriginalValues["MaidenMiddlename"])) changes.Add("MaidenMiddlename", MaidenMiddlename);

        //    return changes;
        //}
    }
}
