﻿using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    public interface IOfferedCourse
    {
        int BatchId { get; set; }
    }



    [Table("Student_OfferedCourse")]
    public class OfferedCourse : Entity, IOfferedCourse
    {

        #region Default Properties
        public int BatchId { get; set; }

        #endregion

        public Batch BatchClass { get; set; }
        public Course CourseClass { get; set; }

        public SectionCollection Sections { get; set; }

        public OfferedCourse()
        {
            BatchClass = new Batch();
            CourseClass = new Course();

            Sections = new SectionCollection(this);
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"BatchId", this.BatchId},
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.BatchId, OriginalValues["BatchId"])) changes.Add("BatchId", this.BatchId);



            return changes;
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.BatchId != null) BatchId = recordSource.BatchId;
            if (recordSource.CourseId != null) CourseId = recordSource.CourseId;
            if (recordSource.YearLevel != null) YearLevel = recordSource.YearLevel;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


    }

}