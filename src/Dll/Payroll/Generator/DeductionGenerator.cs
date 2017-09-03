namespace Dll.Payroll
{
    public class DeductionGenerator
    {


        public static void UpdateMandatoryDeductions(PayrollEmployee employee)
        {
            if (employee == null) return;

            foreach (var deduction in employee.Deductions.Items)
            {
                switch (deduction.DeductionClass.Code)
                {
                    case "0001": //SSS
                        deduction.Amount = ComputeSSS();
                        break;

                    case "0111": //PhilHealth
                        deduction.Amount = ComputePhilHealth();
                        break;

                    case "0222": //PagIbig
                        deduction.Amount = ComputePagIbig();
                        break;

                    case "0036":
                        deduction.Amount = ComputeTax();
                        break;

                    default:
                        break;
                }
            }


        }

        //0001   	- SSS
        //0111	- PhilHealth
        //0222   	- Pagibig
        //0036   	- Tax

        public static decimal ComputeSSS()
        {
            return 200;
        }


        public static decimal ComputePhilHealth()
        {
            return 100;
        }


        public static decimal ComputePagIbig()
        {
            return 300;
        }


        public static decimal ComputeTax()
        {
            return 400;
        }

    }
}
