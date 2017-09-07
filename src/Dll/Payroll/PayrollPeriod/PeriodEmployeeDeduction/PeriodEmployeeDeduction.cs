using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.Payroll
{

    public interface IPeriodEmployeeDeduction
    {
        int PeriodEmployeeId { get; set; }
        int DeductionId { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        DateTime DateReceived { get; set; }
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        Decimal Amount { get; set; }
        bool Mandatory { get; set; }
        bool Priority { get; set; }

    }



    [Table("Payroll_PeriodEmployeeDeduction")]
    public class PeriodEmployeeDeduction : Entity, IPeriodEmployeeDeduction
    {

        #region Default Properties
        public int PeriodEmployeeId { get; set; }
        public int DeductionId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Decimal Amount { get; set; }
        public bool Mandatory { get; set; }
        public bool Priority { get; set; }

        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"PeriodEmployeeId", this.PeriodEmployeeId},
                {"DeductionId", this.DeductionId},
                {"Code", this.Code},
                {"Description", this.Description},
                {"DateReceived", this.DateReceived},
                {"DateFrom", this.DateFrom},
                {"DateTo", this.DateTo},
                {"Amount", this.Amount},
                {"Mandatory", this.Mandatory},
                {"Priority", this.Priority}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.PeriodEmployeeId, OriginalValues["PeriodEmployeeId"])) changes.Add("PeriodEmployeeId", this.PeriodEmployeeId);
            if (!Equals(this.DeductionId, OriginalValues["DeductionId"])) changes.Add("DeductionId", this.DeductionId);
            if (!Equals(this.Code, OriginalValues["Code"])) changes.Add("Code", this.Code);
            if (!Equals(this.Description, OriginalValues["Description"])) changes.Add("Description", this.Description);
            if (!Equals(this.DateReceived, OriginalValues["DateReceived"])) changes.Add("DateReceived", this.DateReceived);
            if (!Equals(this.DateFrom, OriginalValues["DateFrom"])) changes.Add("DateFrom", this.DateFrom);
            if (!Equals(this.DateTo, OriginalValues["DateTo"])) changes.Add("DateTo", this.DateTo);
            if (!Equals(this.Amount, OriginalValues["Amount"])) changes.Add("Amount", this.Amount);
            if (!Equals(this.Mandatory, OriginalValues["Mandatory"])) changes.Add("Mandatory", this.Mandatory);
            if (!Equals(this.Priority, OriginalValues["Priority"])) changes.Add("Priority", this.Priority);



            return changes;
        }


    }

}
