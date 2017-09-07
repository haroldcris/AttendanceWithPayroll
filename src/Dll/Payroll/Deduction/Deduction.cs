using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{

    public interface IDeduction
    {
        string Code { get; set; }
        string Description { get; set; }
        bool Mandatory { get; set; }
        bool Priority { get; set; }
        bool Active { get; set; }

    }



    [Table("Payroll_Deduction")]
    public class Deduction : Entity, IDeduction
    {

        #region Default Properties
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        public bool Priority { get; set; }
        public bool Active { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"Code", this.Code},
                {"Description", this.Description},
                {"Mandatory", this.Mandatory},
                {"Priority", this.Priority},
                {"Active", this.Active}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.Code, OriginalValues["Code"])) changes.Add("Code", this.Code);
            if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);
            if (!Equals(this.Mandatory, OriginalValues["Mandatory"])) changes.Add("Mandatory", this.Mandatory);
            if (!Equals(this.Priority, OriginalValues["Priority"])) changes.Add("Priority", this.Priority);
            if (!Equals(this.Active, OriginalValues["Active"])) changes.Add("Active", this.Active);



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
