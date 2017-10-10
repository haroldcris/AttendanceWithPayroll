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

        #endregion


        public Person PersonClass { get; set; }


        [Obsolete("Replace with Map Function")]
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


            return changes;
        }



        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.PersonId != null) PersonId = recordSource.PersonId;
            if (recordSource.EmpNum != null) EmpNum = recordSource.EmpNum;
            if (recordSource.CivilStatus != null) CivilStatus = recordSource.CivilStatus;
            if (recordSource.Height != null) Height = recordSource.Height;
            if (recordSource.Weight != null) Weight = recordSource.Weight;


            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;

        }

    }

}
