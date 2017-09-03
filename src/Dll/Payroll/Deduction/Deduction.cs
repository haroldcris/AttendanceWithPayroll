using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{

    [Table("Payroll_Deduction")]
    public partial class Deduction : Entity
    {

        #region Default Properties

        public string Code { get; set; }

        public string Description { get; set; }

        public bool Mandatory { get; set; }

        public int Priority { get; set; }

        public bool Active { get; set; }



        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Code", Code);
            OriginalValues.Add("Description", Description);
            OriginalValues.Add("Mandatory", Mandatory);
            OriginalValues.Add("Priority", Priority);
            OriginalValues.Add("Active", Active);
        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Code, OriginalValues["Code"])) changes.Add("Code", Code);
            if (!Equals(Description, OriginalValues["Description"])) changes.Add("Description", Description);
            if (!Equals(Mandatory, OriginalValues["Mandatory"])) changes.Add("Mandatory", Mandatory);
            if (!Equals(Priority, OriginalValues["Priority"])) changes.Add("Priority", Priority);
            if (!Equals(Active, OriginalValues["Active"])) changes.Add("Active", Active);

            return changes;
        }



        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.Code != null) Code = recordSource.Code;
            if (recordSource.Description != null) Description = recordSource.Description;
            if (recordSource.Mandatory != null) Mandatory = recordSource.Mandatory;
            if (recordSource.Priority != null) Priority = recordSource.Priority;
            if (recordSource.Active != null) Active = recordSource.Active;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }


    }
}
