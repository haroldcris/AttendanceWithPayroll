using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    public interface ISubject
    {
        string SubjectCode { get; set; }        string Description { get; set; }
    }



    [Table("Student_Subject")]
    public class Subject : Entity, ISubject
    {

        #region Default Properties
        public string SubjectCode { get; set; }        public string Description { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"SubjectCode", this.SubjectCode},                {"Description", this.Description}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.SubjectCode, OriginalValues["SubjectCode"])) changes.Add("SubjectCode", this.SubjectCode);            if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);



            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.SubjectCode != null) SubjectCode = recordSource.SubjectCode;
            if (recordSource.Description != null) Description = recordSource.Description;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }




        public override string ToString()
        {
            return $"{SubjectCode}  {Description}";
        }

    }

}
