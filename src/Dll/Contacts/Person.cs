using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;


namespace Dll.Contacts
{
    [Table("Person")]
    public partial class Person : Entity
    {
        public PersonName Name { get; set; }

        public GenderType Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthCountry { get; set; }
        public string BirthProvince { get; set; }
        public string BirthTown { get; set; }


        public string CameraCounter { get; set; }


        public PersonDataMapper DataMapper { get; set; }


        public MobileNumberCollection MobileNumbers { get; set; }


        public Person()
        {
            Name = new PersonName();

            BirthDate = new DateTime(1920, 1, 1);

            DataMapper = new PersonDataMapper(this);

            MobileNumbers = new MobileNumberCollection(this);
        }


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>
            {
                {"Lastname", Name.Lastname},
                {"Firstname", Name.Firstname},
                {"Middlename", Name.Middlename},
                {"MiddleInitial", Name.MiddleInitial},
                {"NameExtension", Name.NameExtension},
                {"MaidenMiddlename", Name.MaidenMiddlename},
                {"Gender", Gender},
                {"BirthDate", BirthDate},
                {"BirthCountry", BirthCountry},
                {"BirthProvince", BirthProvince},
                {"BirthTown", BirthTown},
                {"CameraCounter", CameraCounter}
            };



        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(Name.Lastname, OriginalValues["Lastname"])) changes.Add("Lastname", Name.Lastname);            if (!Equals(Name.Firstname, OriginalValues["Firstname"])) changes.Add("Firstname", Name.Firstname);            if (!Equals(Name.Middlename, OriginalValues["Middlename"])) changes.Add("Middlename", Name.Middlename);            if (!Equals(Name.MiddleInitial, OriginalValues["MiddleInitial"])) changes.Add("MiddleInitial", Name.MiddleInitial);            if (!Equals(Name.NameExtension, OriginalValues["NameExtension"])) changes.Add("NameExtension", Name.NameExtension);
            if (!Equals(Name.MaidenMiddlename, OriginalValues["MaidenMiddlename"])) changes.Add("MaidenMiddlename", Name.MaidenMiddlename);            if (!Equals(Gender, OriginalValues["Gender"])) changes.Add("Gender", Gender);

            if (!Equals(BirthDate, OriginalValues["BirthDate"])) changes.Add("BirthDate", BirthDate);            if (!Equals(BirthCountry, OriginalValues["BirthCountry"])) changes.Add("BirthCountry", BirthCountry);            if (!Equals(BirthProvince, OriginalValues["BirthProvince"])) changes.Add("BirthProvince", BirthProvince);            if (!Equals(BirthTown, OriginalValues["BirthTown"])) changes.Add("BirthTown", BirthTown);            if (!Equals(CameraCounter, OriginalValues["CameraCounter"])) changes.Add("CameraCounter", CameraCounter);            return changes;
        }
    }
}
