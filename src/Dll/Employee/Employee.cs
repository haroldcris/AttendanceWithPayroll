using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using Dll.Contacts;
using System;
using System.Collections.Generic;

namespace Dll.Employee
{

    public interface IEmployee
    {
        int PersonId { get; set; }
        int EmpNum { get; set; }
        string CivilStatus { get; set; }
        Decimal Height { get; set; }
        Decimal Weight { get; set; }
        string GSIS { get; set; }
        string Pagibig { get; set; }
        string PhilHealth { get; set; }
        string SSS { get; set; }
        string Tin { get; set; }

    }



    [Table("Employee")]
    public class Employee : Entity, IEmployee
    {

        #region Default Properties
        public int PersonId { get; set; }
        public int EmpNum { get; set; }
        public string CivilStatus { get; set; }
        public Decimal Height { get; set; }
        public Decimal Weight { get; set; }
        public string GSIS { get; set; }
        public string Pagibig { get; set; }
        public string PhilHealth { get; set; }
        public string SSS { get; set; }
        public string Tin { get; set; }

        #endregion


        public Person PersonClass { get; set; }
        public EmployeeDataMapper DataMapper { get; }

        public Employee()
        {
            PersonClass = new Person();
            DataMapper = new EmployeeDataMapper(this);
        }


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"PersonId", this.PersonId},
                {"EmpNum", this.EmpNum},
                {"CivilStatus", this.CivilStatus},
                {"Height", this.Height},
                {"Weight", this.Weight},
                {"GSIS", this.GSIS},
                {"Pagibig", this.Pagibig},
                {"PhilHealth", this.PhilHealth},
                {"SSS", this.SSS},
                {"Tin", this.Tin}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.PersonId, OriginalValues["PersonId"])) changes.Add("PersonId", this.PersonId);
            if (!Equals(this.EmpNum, OriginalValues["EmpNum"])) changes.Add("EmpNum", this.EmpNum);
            if (!Equals(this.CivilStatus, OriginalValues["CivilStatus"])) changes.Add("CivilStatus", this.CivilStatus);
            if (!Equals(this.Height, OriginalValues["Height"])) changes.Add("Height", this.Height);
            if (!Equals(this.Weight, OriginalValues["Weight"])) changes.Add("Weight", this.Weight);
            if (!Equals(this.GSIS, OriginalValues["GSIS"])) changes.Add("GSIS", this.GSIS);
            if (!Equals(this.Pagibig, OriginalValues["Pagibig"])) changes.Add("Pagibig", this.Pagibig);
            if (!Equals(this.PhilHealth, OriginalValues["PhilHealth"])) changes.Add("PhilHealth", this.PhilHealth);
            if (!Equals(this.SSS, OriginalValues["SSS"])) changes.Add("SSS", this.SSS);
            if (!Equals(this.Tin, OriginalValues["Tin"])) changes.Add("Tin", this.Tin);



            return changes;
        }


    }

}
