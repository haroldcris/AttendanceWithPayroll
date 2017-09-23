using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using C1.C1Excel;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using Dll.Payroll;
using Library.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmPayroll : MdiClientForm, IMdiForm
    {
        public frmPayroll()
        {
            InitializeComponent();

            InitializeGrid();


            Load += (s, e) => { RefreshData(); };
        }

        public PayrollPeriod ItemData { get; set; }


        protected void InitializeGrid()
        {
            SGrid.InitializeGrid();


            var grid = SGrid.PrimaryGrid;
            var col = new GridColumn();

            //SGrid.RowDoubleClick += (s, e) => { btnPayViewProfile.RaiseClick(); };
            //SGrid.ColumnHeaderMouseUp += SGrid_ColumnHeaderMouseUp;

            grid.GroupByRow.Visible = false;
            grid.Filter.Visible = true;
            grid.EnableFiltering = true;

            grid.EnableColumnFiltering = true;
            grid.FilterMatchType = FilterMatchType.RegularExpressions;


            //grid.CheckBoxes = true;

            grid.ShowTreeButtons = true;
            grid.ShowTreeLines = true;



            grid.CreateColumn("Empnum", "Employee No.", 100, Alignment.MiddleCenter);


            grid.CreateColumn("Name", "Name", 200);
            grid.CreateColumn("Gender", "Gender", 50, Alignment.MiddleCenter).Visible = false;

            grid.CreateColumn("Position", "Position", 90);

            grid.CreateColumn("Department", "Department", 90);

            grid.CreateColumn("TaxCode", "Tax Code", 80);

            grid.CreateColumn("SG", "SG", 40, Alignment.MiddleCenter);
            grid.CreateColumn("Step", "Step", 40, Alignment.MiddleCenter);

            col = grid.CreateColumn("Exemption", "Tax Exemption", 80, Alignment.MiddleRight);
            col.RenderType = typeof(GridDoubleInputEditControl);


            col = grid.CreateColumn("GrossBasicSalary", "Gross", 80, Alignment.MiddleRight);
            col.RenderType = typeof(GridDoubleInputEditControl);


            col = grid.CreateColumn("Deductions", "Deductions", 80, Alignment.MiddleRight);
            col.RenderType = typeof(GridDoubleInputEditControl);


            col = grid.CreateColumn("NetSalary", "NetSalary", 80, Alignment.MiddleRight);
            col.RenderType = typeof(GridDoubleInputEditControl);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            //CreateGridContextMenu();

            //Define Sort
            //grid.SetSort(SGrid.PrimaryGrid.Columns["Name"]);
        }


        private GridPanel InitPanel()
        {
            var panel = new GridPanel();

            panel.AllowEdit = false;
            panel.ShowRowHeaders = false;


            panel.SelectionGranularity = SelectionGranularity.Row;
            panel.CreateColumn("code", "Code");
            panel.CreateColumn("description", "Description", 130);
            var col = panel.CreateColumn("amount", "Amount", 80, Alignment.MiddleRight);

            col.RenderType = typeof(GridDoubleInputEditControl);


            return panel;
        }


        protected IEnumerable<PeriodEmployee> LoadItems()
        {
            ItemData.Employees.LoadAllItems();
            return ItemData.Employees.Items;
        }


        private void Show_Data(IEnumerable<PeriodEmployee> items)
        {
            SGrid.PrimaryGrid.Rows.Clear();

            foreach (var item in items)
            {
                if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                var row = SGrid.PrimaryGrid.CreateNewRow();
                row.Tag = item;

                Show_DataOnRow(row, item);



                // Create SUB Grid for Detailed Deductions
                var subPanel = InitPanel();

                row.Rows.Add((subPanel));

                subPanel.Title.Visible = true;
                subPanel.Title.Text = "Detailed Deduction";


                foreach (var deduction in item.Deductions.Items)
                {
                    var subRow = subPanel.CreateNewRow();
                    subRow["code"].Value = deduction.Code;
                    subRow["description"].Value = deduction.Description;
                    subRow["amount"].Value = deduction.Amount;


                }




            }
        }


        protected void Show_DataOnRow(GridRow row, PeriodEmployee item)
        {
            var currentItem = item;

            row.Cells["Empnum"].Value = currentItem.EmpNum;

            var pName = new PersonName();
            pName.Lastname = currentItem.Lastname;
            pName.Firstname = currentItem.Firstname;
            pName.Middlename = currentItem.Middlename;

            row.Cells["Name"].Value = pName.Fullname;

            row.Cells["Gender"].Value = currentItem.Gender == "Male" ? GenderType.Male : GenderType.Female;

            row.Cells["Position"].Value = currentItem.CurrentPosition;
            row.Cells["SG"].Value = currentItem.SG;


            row.Cells["Step"].Value = currentItem.Step;

            row.Cells["Department"].Value = currentItem.Department;

            row.Cells["TaxCode"].Value = currentItem.TaxShortDesc;
            row.Cells["Exemption"].Value = currentItem.TaxExemption;


            row.Cells["GrossBasicSalary"].Value = currentItem.GrossBasicSalary;


            row.Cells["NetSalary"].Value = currentItem.BasicSalary;


            var total = currentItem.Deductions.Items.Sum(_ => _.Amount);

            row.Cells["Deductions"].Value = total;


            row.ShowRecordInfo(currentItem);





        }


        protected void RefreshData()
        {
            DoRefresh(async () =>
            {
                //progressBarX1.Visible = true;

                var grid = SGrid.PrimaryGrid;
                grid.Rows.Clear();

                var items = Enumerable.Empty<PeriodEmployee>();
                await Task.Factory.StartNew(() => { items = LoadItems(); });

                //progressBarX1.Visible = false;
                Show_Data(items);
            });
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                xl.Load(@".\Reports\Payroll_Summary.xlsx");

                var sh = xl.Sheets["Payroll"];
                var header = sh.PrintSettings.Header;

                header = header.Replace("%Date%", DateTime.Now.ToString("dd-MMM-yy hh:mm tt"));
                header = header.Replace("%Title%", ItemData.Remarks);
                //header = header.Replace("%Title%", ItemData.DateCovered.ToString("dd MMMM yyyy"));


                sh.PrintSettings.Header = header;

                //sh.PrintSettings.AutoScale = true;
                //sh.PrintSettings.FitPagesAcross = 1;


                panelStatus.Left = (this.Width / 2) - (panelStatus.Width / 2);
                panelStatus.Visible = true;
                pb.Maximum = ItemData.Employees.Items.Count();

                var row = 1;
                foreach (var item in ItemData.Employees.Items)
                {
                    row++;


                    var pName = new PersonName();
                    pName.Map(item);


                    lblStatus.Text = "Generating " + pName.Fullname + "...";
                    lblStatus.Refresh();

                    sh[row, 0].Value = row - 1;

                    sh[row, 1].Value = item.EmpNum;
                    sh[row, 2].Value = pName.Fullname;
                    sh[row, 5].Value = item.CurrentPosition;

                    sh[row, 8].Value = item.SG;
                    sh[row, 9].Value = item.Step;

                    sh[row, 10].Value = item.GrossBasicSalary;

                    sh[row, 11].Value = item.TaxShortDesc;
                    sh[row, 12].Value = item.TaxExemption;



                    // CREATE PAYSLIP
                    var shPayslip = xl.Sheets["Sheet1"].Clone();
                    shPayslip.Name = "Payslip #" + (row - 1).ToString();
                    xl.Sheets.Add(shPayslip);



                    //Profile Picture
                    var profilePic = new XLPictureShape(InputControls.GetImage(item.CameraCounter), 50, 1300, 900, 900);
                    profilePic.LineStyle = XLShapeLineStyleEnum.Simple;
                    shPayslip.Shapes.Add(profilePic);


                    shPayslip[4, 0].Value = ItemData.Remarks;

                    shPayslip[6, 2].Value = pName.Fullname;
                    shPayslip[7, 2].Value = "Position : " + item.CurrentPosition;
                    shPayslip[8, 2].Value = $"Salary Grade : {item.SG}-{item.Step}";
                    shPayslip[9, 2].Value = $"Tax Code : {item.TaxShortDesc}";


                    shPayslip[11, 4].Value = item.BasicSalary;
                    shPayslip[12, 4].Value = item.GrossBasicSalary;



                    //0111    Medicare(PhilHealth)
                    //0222    PAG - IBIG Premium
                    //0036    BIR Withholding Tax
                    //0001    SSS

                    var sssDeduction = (decimal)0.00;
                    var birDeduction = (decimal)0.00;
                    var philHealthDeduction = (decimal)0.00;
                    var pagibigDeduction = (decimal)0.00;
                    var otherDeduction = (decimal)0.00;
                    var totalDeduction = (decimal)0.00;

                    var payslipRow = 16;
                    foreach (var deduction in item.Deductions.Items)
                    {
                        totalDeduction += deduction.Amount;

                        switch (deduction.Code)
                        {
                            case "0036":
                                birDeduction = deduction.Amount;
                                break;

                            case "0001":
                                sssDeduction = deduction.Amount;
                                break;

                            case "0111":
                                philHealthDeduction = deduction.Amount;
                                break;

                            case "0222":
                                pagibigDeduction = deduction.Amount;
                                break;

                            default:
                                otherDeduction += deduction.Amount;
                                break;
                        }


                        //Do Payslip Deductions
                        //var newRow = shPayslip.Rows[16].Clone();
                        //shPayslip.Rows.Insert(16, newRow);

                        shPayslip[payslipRow, 1].Value = deduction.Code;
                        shPayslip[payslipRow, 2].Value = deduction.Description;
                        shPayslip[payslipRow, 4].Value = deduction.Amount;




                        payslipRow++;

                    }


                    sh[row, 13].Value =
                        birDeduction; // item.Deductions.Items.FirstOrDefault(_ => _.Code == "0036")?.Amount; // Bir
                    sh[row, 14].Value =
                        sssDeduction; // item.Deductions.Items.FirstOrDefault(_ => _.Code == "0001")?.Amount; // SSS
                    sh[row, 15].Value =
                        philHealthDeduction; //  item.Deductions.Items.FirstOrDefault(_ => _.Code == "0111")?.Amount; // PhilHealth
                    sh[row, 16].Value =
                        pagibigDeduction; // item.Deductions.Items.FirstOrDefault(_ => _.Code == "0222")?.Amount; // Pagibig


                    sh[row, 17].Value = otherDeduction;
                    sh[row, 18].Formula = string.Format("=SUM(N{0}:Q{0})", row + 1);

                    sh[row, 19].Value = item.BasicSalary;



                    shPayslip[13, 4].Value = totalDeduction;

                    shPayslip.Locked = true;


                    pb.Value = row;

                }


                sh.PrintSettings.FitPagesAcross = 1;
                sh.Locked = true;


                xl.Sheets.Remove(xl.Sheets["Sheet1"]);

                var targetFolder = Path.Combine(Path.GetTempPath(), "amwp");

                var file = DateTime.Now.ToString("yymmddhhmmss");
                var filename = file + ".xlsx";

                Directory.CreateDirectory(targetFolder);
                xl.Save(Path.Combine(targetFolder, filename));


                panelStatus.Visible = false;

                //System.Threading.Thread.Sleep(1000);
                Process.Start(Path.Combine(targetFolder, filename));

            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                panelStatus.Visible = false;
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SGrid.ActiveFilterPanel != null) return;

            Cursor.Current = Cursors.WaitCursor;

            var grid = SGrid.PrimaryGrid;


            var deleteMessage = ItemData.DateCovered.ToShortDateString();


            var ret = MessageDialog.AskToDelete("<b>" + deleteMessage.ToUpper() + "</b>");

            if (ret != MessageDialogResult.Yes) return;


            ItemData.RowStatus = RecordStatus.DeletedRecord;
            var writer = new PayrollPeriodDataWriter(App.CurrentUser.User.Username, ItemData);
            writer.SaveChanges();


            App.LogAction("Payroll", "Deleted Payroll Period: " + ItemData.DateCovered.ToString("dd MMM yyyy"));

            Close();
        }

        private void SGrid_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;

            //    var grid = SGrid.PrimaryGrid;

            //    var item = (PayrollEmployee)grid.ActiveRow?.Tag;

            //    if (item == null) return;


            //    using (var frm = new frmPayrollEmployee_Add())
            //    {
            //        frm.ItemData = item;
            //        frm.ShowDialog();
            //    }                

            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowError(ex, this);
            //}
        }
    }
}
