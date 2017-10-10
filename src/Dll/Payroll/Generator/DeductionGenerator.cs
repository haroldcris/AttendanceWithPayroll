
using System;

namespace Dll.Payroll
{
    public class DeductionGenerator
    {

        public static void UpdateMandatoryDeductions(PayrollEmployee employee)
        {
            if (employee == null) return;

            decimal totalDeduction = 0;
            var taxDeduction = new PayrollEmployeeDeduction();


            var hasSSS = false;
            var hasPhilHealth = false;
            var hasPagibig = false;
            var hasTax = false;

            foreach (var deduction in employee.Deductions.Items)
            {
                switch (deduction.DeductionClass.Code)
                {
                    case "0001": //SSS
                        hasSSS = true;
                        var sssComputer = new SSSTable();
                        deduction.Amount = sssComputer.GetContributionOf(employee.BasicSalary);
                        totalDeduction += deduction.Amount;
                        break;


                    case "0111": //PhilHealth
                        hasPhilHealth = true;
                        var philHealthTable = new PhilHealthTable();
                        deduction.Amount = philHealthTable.GetContributionOf(employee.BasicSalary);
                        totalDeduction += deduction.Amount;
                        break;


                    case "0222": //PagIbig
                        hasPagibig = true;
                        var pagibig = employee.BasicSalary * .01m; //1%
                        if (pagibig > 100) pagibig = 100;
                        deduction.Amount = pagibig;
                        totalDeduction += deduction.Amount;
                        break;

                    case "0036":
                        hasTax = true;
                        taxDeduction = deduction;
                        break;

                    default:
                        break;
                }
            }



            if (!hasSSS) { }

            if (!hasPagibig) { }

            if (!hasPhilHealth) { }


            if (hasTax)
                //throw new Exception("NO Tax deduction");
                taxDeduction.Amount = ComputeTax(employee.BasicSalary, totalDeduction, employee.TaxClass.Exemption);


        }




        //0001   	- SSS
        //0111	- PhilHealth
        //0222   	- Pagibig
        //0036   	- Tax
        public static decimal ComputePagIbig()
        {
            return 300;
        }


        public static decimal ComputeTax(decimal monthlyIncome, decimal monthlyDeductions, int exemptionAmount)
        {
            decimal tax;
            var taxable = monthlyIncome - monthlyDeductions;
            var category = (exemptionAmount - 50000) / 25000;

            if (taxable < 1) return 0;

            if (category < 0) return 0;


            if (category == 0)
            {
                //single

                if (taxable >= 45833)
                {
                    tax = 10416.67m + (0.32m * (taxable - 45833m));

                }
                else if (taxable >= 25000)
                {
                    tax = 4166.67m + (0.3m * (taxable - 25000m));
                }
                else if (taxable > 15833)
                {
                    tax = 1875m + (0.25m * (taxable - 15833m));
                }
                else if (taxable > 10000)
                {
                    tax = 708.33m + (0.2m * (taxable - 10000m));
                }
                else if (taxable >= 6667)
                {
                    tax = 208.33m + (0.15m * (taxable - 6667m));
                }
                else if (taxable >= 5000)
                {
                    tax = 41.67m + (0.1m * (taxable - 5000m));
                }
                else if (taxable >= 4167)
                {
                    tax = 0 + (0.05m * (taxable - 4167m));
                }
                else
                {
                    tax = 0;
                }

            }
            else
            {
                // Married
                if (taxable >= Choose(category, 47917, 50000, 52083, 54167))
                    tax = 10416.67m + (0.32m * (taxable - Choose(category, 47917, 50000, 52083, 54167)));

                else if (taxable >= Choose(category, 27083, 29167, 31250, 33333))
                    tax = 4166.67m + (0.3m * (taxable - Choose(category, 27083, 29167, 31250, 33333)));

                else if (taxable > Choose(category, 17917, 20000, 22083, 24167))
                    tax = 1875m + (0.25m * (taxable - Choose(category, 17917, 20000, 22083, 24167)));

                else if (taxable >= Choose(category, 12083, 14167, 16250, 18333))
                    tax = 708.33m + (0.2m * (taxable - Choose(category, 12083, 14167, 16250, 18333)));

                else if (taxable >= Choose(category, 8750, 10833, 12917, 15000))
                    tax = 208.33m + (0.15m * (taxable - Choose(category, 8750, 10833, 12917, 15000)));

                else if (taxable >= Choose(category, 7083, 9167, 11250, 13333))
                    tax = 41.67m + (0.1m * (taxable - Choose(category, 7083, 9167, 11250, 13333)));

                else if (taxable >= Choose(category, 6250, 8333, 10417, 12500))
                    tax = 0 + (0.05m * (taxable - Choose(category, 6250, 8333, 10417, 12500)));
                else
                    tax = 0;
            }

            if (tax == 0)
            {
                //
                Console.WriteLine("Error HEre");
            }

            return Math.Round(tax, 2, MidpointRounding.AwayFromZero);
        }



        public static decimal Choose(int index, params decimal[] args)
        {
            if (index < 1 || index > args.Length)
            {
                return default(decimal);
            }
            else
            {
                return args[--index];
            }
        }
    }
}
