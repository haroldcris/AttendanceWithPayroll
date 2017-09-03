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
                {"EmpId", EmpId},
                {"DeductionId", DeductionId},
                {"Amount", Amount},
                {"DateFrom", DateFrom},
                {"DateTo", DateTo},
                {"Remarks", Remarks}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(EmpId, OriginalValues["EmpId"])) changes.Add("EmpId", EmpId);
            if (!Equals(DeductionId, OriginalValues["DeductionId"])) changes.Add("DeductionId", DeductionId);
            if (!Equals(Amount, OriginalValues["Amount"])) changes.Add("Amount", Amount);
            if (!Equals(DateFrom, OriginalValues["DateFrom"])) changes.Add("DateFrom", DateFrom);
            if (!Equals(DateTo, OriginalValues["DateTo"])) changes.Add("DateTo", DateTo);
            if (!Equals(Remarks, OriginalValues["Remarks"])) changes.Add("Remarks", Remarks);


            return changes;
        }


        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) Id = recordSource.Id;

            if (recordSource.EmpId != null) EmpId = recordSource.EmpId;
            if (recordSource.DeductionId != null) DeductionId = recordSource.DeductionId;
            if (recordSource.Amount != null) Amount = recordSource.Amount;
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
