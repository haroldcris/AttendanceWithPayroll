using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.Payroll
{

    public interface IPayrollPeriod
    {
        string PayrollType { get; set; }
        DateTime DateCovered { get; set; }
        //string PayrollCategory { get; set; }
        string Remarks { get; set; }

    }



    [Table("Payroll_Period")]
    public class PayrollPeriod : Entity, IPayrollPeriod
    {

        #region Default Properties
        public string PayrollType { get; set; }
        public DateTime DateCovered { get; set; }
        //public string PayrollCategory { get; set; }
        public string Remarks { get; set; }

        #endregion

        public PeriodEmployeeCollection Employees { get; set; }


        public PayrollPeriod()
        {
            Employees = new PeriodEmployeeCollection(this);
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"PayrollType", this.PayrollType},
                {"DateCovered", this.DateCovered},
                //{"PayrollCategory", this.PayrollCategory},
                {"Remarks", this.Remarks}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.PayrollType, OriginalValues["PayrollType"])) changes.Add("PayrollType", this.PayrollType);
            if (!Equals(this.DateCovered, OriginalValues["DateCovered"])) changes.Add("DateCovered", this.DateCovered);
            //if (!Equals(this.PayrollCategory, OriginalValues["PayrollCategory"])) changes.Add("PayrollCategory", this.PayrollCategory);
            if (!Equals(this.Remarks, OriginalValues["Remarks"])) changes.Add("Remarks", this.Remarks);



            return changes;
        }


    }

}
