using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{

    [Table("Payroll_Position")]
    public class Position : Entity
    {

        #region Default Properties

        public string Code { get; set; }

        public string Description { get; set; }



        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>
            {
                {"Code", Code}, {"Description", Description}
            };

        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Code, OriginalValues["Code"])) changes.Add("Code", Code);
            if (!Equals(Description, OriginalValues["Description"])) changes.Add("Description", Description);

            return changes;
        }
    }
}
