using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    public interface IOfferedClass
    {
        int SubjectId { get; set; }
        int SectionId { get; set; }
        int TeacherId { get; set; }
        DateTime Mon { get; set; }
        DateTime Tue { get; set; }
        DateTime Wed { get; set; }
        DateTime Thu { get; set; }
        DateTime Fri { get; set; }
        DateTime Sat { get; set; }

        Section SectionClass { get; set; }
        Subject SubjectClass { get; set; }
        Employee.Employee EmployeeClass { get; set; }

    }



    [Table("Student_OfferedClass")]
    public class OfferedClass : Entity, IOfferedClass
    {

        #region Default Properties
        public int SubjectId { get; set; }
        public int SectionId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Mon { get; set; }
        public DateTime Tue { get; set; }
        public DateTime Wed { get; set; }
        public DateTime Thu { get; set; }
        public DateTime Fri { get; set; }
        public DateTime Sat { get; set; }

        #endregion


        public Section SectionClass { get; set; }
        public Subject SubjectClass { get; set; }

        public Employee.Employee EmployeeClass { get; set; }

        public OfferedClass()
        {
            SectionClass = new Section();
            SubjectClass = new Subject();

            EmployeeClass = new Dll.Employee.Employee();
        }



        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"SubjectId", this.SubjectId},
                {"SectionId", this.SectionId},
                {"TeacherId", this.TeacherId},
                {"Mon", this.Mon},
                {"Tue", this.Tue},
                {"Wed", this.Wed},
                {"Thu", this.Thu},
                {"Fri", this.Fri},
                {"Sat", this.Sat}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.SubjectId, OriginalValues["SubjectId"])) changes.Add("SubjectId", this.SubjectId);
            if (!Equals(this.SectionId, OriginalValues["SectionId"])) changes.Add("SectionId", this.SectionId);
            if (!Equals(this.TeacherId, OriginalValues["TeacherId"])) changes.Add("TeacherId", this.TeacherId);
            if (!Equals(this.Mon, OriginalValues["Mon"])) changes.Add("Mon", this.Mon);
            if (!Equals(this.Tue, OriginalValues["Tue"])) changes.Add("Tue", this.Tue);
            if (!Equals(this.Wed, OriginalValues["Wed"])) changes.Add("Wed", this.Wed);
            if (!Equals(this.Thu, OriginalValues["Thu"])) changes.Add("Thu", this.Thu);
            if (!Equals(this.Fri, OriginalValues["Fri"])) changes.Add("Fri", this.Fri);
            if (!Equals(this.Sat, OriginalValues["Sat"])) changes.Add("Sat", this.Sat);



            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.SubjectId != null) SubjectId = recordSource.SubjectId;
            if (recordSource.SectionId != null) SectionId = recordSource.SectionId;
            if (recordSource.TeacherId != null) TeacherId = recordSource.TeacherId;
            if (recordSource.Mon != null) Mon = DateTime.Today + recordSource.Mon;
            if (recordSource.Tue != null) Tue = DateTime.Today + recordSource.Tue;
            if (recordSource.Wed != null) Wed = DateTime.Today + recordSource.Wed;
            if (recordSource.Thu != null) Thu = DateTime.Today + recordSource.Thu;
            if (recordSource.Fri != null) Fri = DateTime.Today + recordSource.Fri;
            if (recordSource.Sat != null) Sat = DateTime.Today + recordSource.Sat;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


        public void MapFull(dynamic recordSource)
        {
            Map(recordSource);

            SubjectClass.Id = recordSource.SubjectId;
            SubjectClass.SubjectCode = recordSource.SubjectCode;
            SubjectClass.Description = recordSource.Description;


            SectionClass.Id = recordSource.SectionId;
            SectionClass.OfferedCourseId = recordSource.OfferedCourseId;
            SectionClass.SectionName = recordSource.SectionName;


            EmployeeClass.EmpNum = recordSource.EmpNum;
            EmployeeClass.PersonId = recordSource.PersonId;
            EmployeeClass.Id = recordSource.TeacherId;

            //e.PersonId, Lastname, Firstname, MiddleName, MiddleInitial, MaidenMiddlename, Gender, CameraCounter
            EmployeeClass.PersonClass.Id = recordSource.PersonId;
            EmployeeClass.PersonClass.Name.Lastname = recordSource.Lastname;
            EmployeeClass.PersonClass.Name.Firstname = recordSource.Firstname;
            EmployeeClass.PersonClass.Name.Middlename = recordSource.Middlename;
            EmployeeClass.PersonClass.Name.MiddleInitial = recordSource.MiddleInitial;
            EmployeeClass.PersonClass.Name.MaidenMiddlename = recordSource.MaidenMiddlename;

            EmployeeClass.PersonClass.Gender = recordSource.Gender == "Male" ? Contacts.GenderType.Male : Contacts.GenderType.Female;

            EmployeeClass.PersonClass.CameraCounter = recordSource.CameraCounter;

        }



    }

}

