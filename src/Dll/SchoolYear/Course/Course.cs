using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    public interface ICourse
    {
        string CourseCode { get; set; }        string Description { get; set; }
    }



    [Table("Student_Course")]
    public class Course : Entity, ICourse
    {

        #region Default Properties
        public string CourseCode { get; set; }        public string Description { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"CourseCode", this.CourseCode},                {"Description", this.Description}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.CourseCode, OriginalValues["CourseCode"])) changes.Add("CourseCode", this.CourseCode);            if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);



            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.CourseCode != null) CourseCode = recordSource.CourseCode;
            if (recordSource.Description != null) Description = recordSource.Description;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }







        /////////////////////////

        public override string ToString()
        {
            return $"{CourseCode} - {Description}";
        }




    }

}
