using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using Dll.Contacts;
using Dll.SchoolYear;
using System.Collections.Generic;

namespace Dll.Student
{

    public interface IStudent
    {
        int PersonId { get; set; }        int StudentNumber { get; set; }
        int SectionId { get; set; }
    }



    [Table("Student")]
    public class Student : Entity, IStudent
    {

        #region Default Properties
        public int PersonId { get; set; }        public int StudentNumber { get; set; }

        public int SectionId { get; set; }
        #endregion

        public Section SectionClass { get; set; }

        public Person PersonClass { get; set; }



        public Student()
        {
            PersonClass = new Person();
            SectionClass = new Section();

        }



        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"PersonId", this.PersonId},                {"StudentNumber", this.StudentNumber},
                {"SectionId", this.SectionId}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.PersonId, OriginalValues["PersonId"])) changes.Add("PersonId", this.PersonId);            if (!Equals(this.StudentNumber, OriginalValues["StudentNumber"])) changes.Add("StudentNumber", this.StudentNumber);

            if (!Equals(this.SectionId, OriginalValues["SectionId"])) changes.Add("SectionId", this.SectionId);


            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.PersonId != null) PersonId = recordSource.PersonId;
            if (recordSource.SectionId != null) SectionId = recordSource.SectionId;
            if (recordSource.StudentNumber != null) StudentNumber = recordSource.StudentNumber;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


    }

}
