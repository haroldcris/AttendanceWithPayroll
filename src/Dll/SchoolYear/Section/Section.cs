using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    public interface ISection
    {
        int OfferedCourseId { get; set; }        string SectionName { get; set; }
    }



    [Table("Student_Section")]
    public class Section : Entity, ISection
    {

        #region Default Properties
        public int OfferedCourseId { get; set; }        public string SectionName { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"OfferedCourseId", this.OfferedCourseId},                {"SectionName", this.SectionName}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.OfferedCourseId, OriginalValues["OfferedCourseId"])) changes.Add("OfferedCourseId", this.OfferedCourseId);            if (!Equals(this.SectionName, OriginalValues["SectionName"])) changes.Add("SectionName", this.SectionName);



            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.OfferedCourseId != null) OfferedCourseId = recordSource.OfferedCourseId;
            if (recordSource.SectionName != null) SectionName = recordSource.SectionName;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


    }

}
