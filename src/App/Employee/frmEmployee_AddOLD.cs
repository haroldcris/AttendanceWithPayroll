using Dll.Payroll;
using System;

namespace Winform.Employee
{
    public partial class frmEmployee_AddOLD : MdiClientForm
    {
        internal DeductionCollection ItemDataCollection = new DeductionCollection();
        public frmEmployee_AddOLD()
        {
            InitializeComponent();

            Header = " EMPLOYEE PROFILE ";
            HeaderColor = App.BarColor.EmployeeProfileColor;


            ShowName();
            ShowBirth();
        }


        protected override void Form_Load(object sender, EventArgs e)
        {
            base.Form_Load(sender, e);
        }



        private void ShowName()
        {
            const string template = @"Lastname:
                                    <font color='blue'><h5>%lastname%</h5></font><br/>
                                    Firstname:
                                    <font color='blue'><h5>%firstname%</h5></font><br/>
                                    Middlename:
                                    <font color='blue'><h5>%middlename%</h5></font><br/>
                                    Name Extension:
                                    <font color='blue'><h5>%extension%</h5></font><br/>
                                    Gender:
                                    <font color='blue'><h5>%gender%</h5></font>";


            lblName.Text = template.Replace("%lastname%", "LASTNAME - LASTNAME LASTNAME")
                .Replace("%firstname%", "VERY VERY LONG FIRSTNAME")
                .Replace("%middlename%", "MIDDLENAME")
                .Replace("%extension", "JR.");

        }


        private void ShowBirth()
        {
            const string template = @"Birth Date
                                    <font color='blue'><h5>%birth%</h5></font><br/>
                                    Birth Country
                                    <font color='blue'><h5>%country%</h5></font><br/>
                                    Birth Province:
                                    <font color='blue'><h5>%province%</h5></font><br/>
                                    Birth Town:
                                    <font color='blue'><h5>%town%</h5></font><br/>
                                    Gender:
                                    <font color='blue'><h5>%gender%</h5></font><br/>";

            lblBirth.Text = template.Replace("%birth%", "25 JANUARY 1980")
                                    .Replace("%country%", "PHILIPPINES")
                                    .Replace("%province%", "PAMPANGA")
                                    .Replace("%town%", "SAN FERNANDO")
                                    .Replace("%gender%", "MALE");
        }


    }
}
