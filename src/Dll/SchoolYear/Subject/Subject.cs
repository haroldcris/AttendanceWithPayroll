﻿using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using AiTech.LiteOrm;

namespace Dll.SchoolYear
{

    public interface ISubject
    {
        string SubjectCode { get; set; }
    }



    [Table("Student_Subject")]
    public class Subject : Entity, ISubject
    {

        #region Default Properties
        public string SubjectCode { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"SubjectCode", this.SubjectCode},
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(this.SubjectCode, OriginalValues["SubjectCode"])) changes.Add("SubjectCode", this.SubjectCode);



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


    }

}