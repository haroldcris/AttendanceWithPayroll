using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Dll.Payroll
{

    public interface IPayrollEmployeeDeduction
    {
        int EmpId { get; set; }
        int DeductionId { get; set; }
        Decimal Amount { get; set; }
        DateTime DateReceived { get; set; }
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        string Remarks { get; set; }

    }



    [Table("Payroll_EmployeeDeduction")]
    public class PayrollEmployeeDeduction : Entity, IPayrollEmployeeDeduction
    {

        #region Default Properties
        public int EmpId { get; set; }
        public int DeductionId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Remarks { get; set; }

        #endregion

        public Deduction DeductionClass { get; set; }

        public PayrollEmployeeDeduction()
        {
            DeductionClass = new Deduction();
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"EmpId", this.EmpId},
                {"DeductionId", this.DeductionId},
                {"Amount", this.Amount},
                {"DateReceived", this.DateReceived},
                {"DateFrom", this.DateFrom},
                {"DateTo", this.DateTo},
                {"Remarks", this.Remarks}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.EmpId, OriginalValues["EmpId"])) changes.Add("EmpId", this.EmpId);
            if (!Equals(this.DeductionId, OriginalValues["DeductionId"])) changes.Add("DeductionId", this.DeductionId);
            if (!Equals(this.Amount, OriginalValues["Amount"])) changes.Add("Amount", this.Amount);
            if (!Equals(this.DateReceived, OriginalValues["DateReceived"])) changes.Add("DateReceived", this.DateReceived);
            if (!Equals(this.DateFrom, OriginalValues["DateFrom"])) changes.Add("DateFrom", this.DateFrom);
            if (!Equals(this.DateTo, OriginalValues["DateTo"])) changes.Add("DateTo", this.DateTo);
            if (!Equals(this.Remarks, OriginalValues["Remarks"])) changes.Add("Remarks", this.Remarks);



            return changes;
        }



        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;
            if (recordSource.EmpId != null) EmpId = recordSource.EmpId;
            if (recordSource.DeductionId != null) DeductionId = recordSource.DeductionId;
            if (recordSource.Amount != null) Amount = recordSource.Amount;
            if (recordSource.DateReceived != null) DateReceived = recordSource.DateReceived;
            if (recordSource.DateFrom != null) DateFrom = recordSource.DateFrom;
            if (recordSource.DateTo != null) DateTo = recordSource.DateTo;
            if (recordSource.Remarks != null) Remarks = recordSource.Remarks;

            if (recordSource.Created != null) Created = recordSource.Created;
            if (recordSource.Modified != null) Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ModifiedBy = recordSource.ModifiedBy;
        }

    }

}
