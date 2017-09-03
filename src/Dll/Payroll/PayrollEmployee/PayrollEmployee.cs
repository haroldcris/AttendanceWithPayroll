using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;


namespace Dll.Payroll
{

    public interface IPayrollEmployee
    {
        int EmployeeId { get; set; }
        DateTime DateHired { get; set; }
        string Department { get; set; }
        int TaxId { get; set; }
        int PositionId { get; set; }
        int Step { get; set; }



    }



    [Table("Payroll_Employee")]
    public class PayrollEmployee : Entity, IPayrollEmployee
    {

        #region Default Properties
        public int EmployeeId { get; set; }
        public DateTime DateHired { get; set; }
        public string Department { get; set; }
        public int TaxId { get; set; }
        public int PositionId { get; set; }
        public int Step { get; set; }

        public bool Active { get; set; }


        public string Tin { get; set; }
        public string PhilHealth { get; set; }
        public string PagIbig { get; set; }
        public string SSS { get; set; }

        #endregion


        public decimal BasicSalary { get; set; }

        public int SG { get; set; }


        public PayrollEmployeeDataMapper DataMapper { get; set; }
        public Employee.Employee EmployeeClass { get; set; }
        public Position PositionClass { get; set; }
        public Tax TaxClass { get; set; }




        public PayrollEmployeeDeductionCollection Deductions { get; set; }


        public PayrollEmployee()
        {
            DataMapper = new PayrollEmployeeDataMapper(this);


            EmployeeClass = new Employee.Employee();
            PositionClass = new Position();
            TaxClass = new Tax();

            Deductions = new PayrollEmployeeDeductionCollection(this);
        }

        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>()
            {
                {"EmployeeId", this.EmployeeId},
                {"DateHired", this.DateHired},
                {"Department", this.Department},
                {"TaxId", this.TaxId},
                {"PositionId", this.PositionId},
                {"Step", this.Step},
                {"Tin", this.Tin},
                {"PhilHealth", this.PhilHealth},
                {"PagIbig", this.PagIbig},
                {"SSS", this.SSS},
                {"Active", this.Active}
            };
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();
            if (!Equals(this.EmployeeId, OriginalValues["EmployeeId"])) changes.Add("EmployeeId", this.EmployeeId);
            if (!Equals(this.DateHired, OriginalValues["DateHired"])) changes.Add("DateHired", this.DateHired);
            if (!Equals(this.Department, OriginalValues["Department"])) changes.Add("Department", this.Department);
            if (!Equals(this.TaxId, OriginalValues["TaxId"])) changes.Add("TaxId", this.TaxId);
            if (!Equals(this.PositionId, OriginalValues["PositionId"])) changes.Add("PositionId", this.PositionId);
            if (!Equals(this.Step, OriginalValues["Step"])) changes.Add("Step", this.Step);

            if (!Equals(this.Tin, OriginalValues["Tin"])) changes.Add("Tin", this.Tin);
            if (!Equals(this.PhilHealth, OriginalValues["PhilHealth"])) changes.Add("PhilHealth", this.PhilHealth);
            if (!Equals(this.PagIbig, OriginalValues["PagIbig"])) changes.Add("PagIbig", this.PagIbig);
            if (!Equals(this.SSS, OriginalValues["SSS"])) changes.Add("SSS", this.SSS);

            if (!Equals(this.Active, OriginalValues["Active"])) changes.Add("Active", this.Active);

            return changes;
        }

    }

}
