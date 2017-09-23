using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    public interface IBatch
    {
        string BatchName { get; set; }        string Semester { get; set; }
    }



    [Table("Student_Batch")]
    public class Batch : Entity, IBatch
    {

        #region Default Properties
        public string BatchName { get; set; }        public string Semester { get; set; }

        #endregion


        public OfferedCourseCollection OfferedCourses { get; set; }



        public Batch()
        {
            OfferedCourses = new OfferedCourseCollection(this);

        }




        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"BatchName", this.BatchName},                {"Semester", this.Semester}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.BatchName, OriginalValues["BatchName"])) changes.Add("BatchName", this.BatchName);            if (!Equals(this.Semester, OriginalValues["Semester"])) changes.Add("Semester", this.Semester);



            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.BatchName != null) BatchName = recordSource.BatchName;
            if (recordSource.Semester != null) Semester = recordSource.Semester;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


    }

}
