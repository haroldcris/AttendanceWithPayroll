using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{

    [Table("Payroll_TaxTable")]
    public partial class Tax : Entity
    {

        #region Default Properties

        public string Description { get; set; }

        public string ShortDesc { get; set; }

        public int Dependent { get; set; }

        public decimal Exemption { get; set; }



        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Description", Description);
            OriginalValues.Add("ShortDesc", ShortDesc);
            OriginalValues.Add("Dependent", Dependent);
            OriginalValues.Add("Exemption", Exemption);
        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(Description, OriginalValues["Description"])) changes.Add("Description", Description);
            if (!Equals(ShortDesc, OriginalValues["ShortDesc"])) changes.Add("ShortDesc", ShortDesc);
            if (!Equals(Dependent, OriginalValues["Dependent"])) changes.Add("Dependent", Dependent);
            if (!Equals(Exemption, OriginalValues["Exemption"])) changes.Add("Exemption", Exemption);

            return changes;
        }


        public override string ToString()
        {
            return this.Description;
        }
    }


}
