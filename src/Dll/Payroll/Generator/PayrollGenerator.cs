using Dll.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dll.Payroll
{
    public class PayrollGenerator
    {

        public void Generate(PayrollPeriod period, PayrollEmployee selectedEmployee, Action<int, string> callback)
        {
            var list = new List<PayrollEmployee> { selectedEmployee };
            Generate(period, list, callback);
        }




        public void Generate(PayrollPeriod period, IEnumerable<PayrollEmployee> selectedEmployees, Action<int, string> callback)
        {

            var reader = new SalaryScheduleDataReader();
            var salarySched = reader.GetItemFromBaselineDate(period.DateCovered);
            var salarySchedId = salarySched.Id;

            var counter = 0;
            foreach (var employee in selectedEmployees)
            {

                counter++;


                //employee.Deductions.LoadAllItemsWithDeduction();   <--- Call this before Generate on the WInform

                employee.UpdateBasicSalary(period.DateCovered);


                var salary = employee.BasicSalary;

                var deductionList = employee.Deductions.Items.Where(_ => _.DateFrom <= period.DateCovered && _.DateTo >= period.DateCovered)
                                                            .OrderByDescending(_ => _.DeductionClass.Mandatory)
                                                            .ThenByDescending(_ => _.DeductionClass.Priority)
                                                            .ThenByDescending(_ => _.DateFrom)
                                                            .ThenByDescending(_ => _.DateTo).ToList();


                var periodEmployee = CreatePeriodEmployee(period, employee, salarySchedId);


                foreach (var deduction in deductionList)
                {
                    salary = salary - deduction.Amount;


                    //PeriodEmployeeDeduction
                    var empDeduction = new PeriodEmployeeDeduction
                    {
                        DeductionId = deduction.DeductionClass.Id,
                        Code = deduction.DeductionClass.Code,
                        Description = deduction.DeductionClass.Description,
                        DateReceived = deduction.DateReceived,
                        DateFrom = deduction.DateFrom,
                        DateTo = deduction.DateTo,
                        Amount = deduction.Amount,
                        Mandatory = deduction.DeductionClass.Mandatory,
                        Priority = deduction.DeductionClass.Priority
                    };

                    // empDeduction.Id =  ;
                    // empDeduction.PeriodEmployeeId = ;

                    periodEmployee.Deductions.Add(empDeduction);

                }

                periodEmployee.BasicSalary = salary;

                period.Employees.Add(periodEmployee);

                callback?.Invoke(counter, "Generating " + employee.EmployeeClass.PersonClass.Name.Fullname);

            }
        }

        private static PeriodEmployee CreatePeriodEmployee(PayrollPeriod period, PayrollEmployee employee, int salarySchedId)
        {
            return new PeriodEmployee
            {
                PeriodId = period.Id,
                PersonId = employee.EmployeeClass.PersonId,

                EmpId = employee.EmployeeId,
                EmpNum = employee.EmployeeClass.EmpNum,

                Lastname = employee.EmployeeClass.PersonClass.Name.Lastname,
                Firstname = employee.EmployeeClass.PersonClass.Name.Firstname,
                Middlename = employee.EmployeeClass.PersonClass.Name.Middlename,
                MI = employee.EmployeeClass.PersonClass.Name.MiddleInitial,
                NameExtension = employee.EmployeeClass.PersonClass.Name.NameExtension,

                Gender = employee.EmployeeClass.PersonClass.Gender == GenderType.Male ? "Male" : "Female",
                BirthDate = employee.EmployeeClass.PersonClass.BirthDate,

                DateHired = employee.DateHired,

                CurrentPosition = employee.PositionClass.Description,
                SG = employee.SG,
                Step = employee.Step,


                PagIbig = employee.PagIbig,
                PhilHealth = employee.PhilHealth,
                SSS = employee.SSS,
                TIN = employee.Tin,


                TaxId = employee.TaxId,
                TaxShortDesc = employee.TaxClass.ShortDesc,
                TaxDescription = employee.TaxClass.Description,
                TaxExemption = employee.TaxClass.Exemption,


                GrossBasicSalary = employee.BasicSalary,

                PaymentCode = "001",
                PaymentType = "Regular Payroll",


                BasicSalary = 0,   // Temporary Set to 0

                pFrom = period.DateCovered,
                pTo = period.DateCovered,
                Department = employee.Department,
                CameraCounter = employee.EmployeeClass.PersonClass.CameraCounter,
                SalarySchedID = salarySchedId
            };
        }
    }
}
