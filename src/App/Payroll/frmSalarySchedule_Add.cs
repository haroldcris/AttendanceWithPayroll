using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll.Payroll;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace Winform.Payroll
{
    public partial class frmSalarySchedule_Add : FormWithHeader
    {
        public SalarySchedule ItemData { get; set; }
        
        private frmSalarySchedule CallerForm;

       
        public frmSalarySchedule_Add(frmSalarySchedule caller)
        {
            InitializeComponent();

            CallerForm = caller;

            InitializeSGGrid();

            InitializePositionGrid();

            this.Load += (s, e) => { ShowData(); };
            


            this.CancelButton = btnCancel;
            btnCancel.Click += (s, e) => { Dispose(); };
            btnOk.Click += (s, e) => { Save(); };
        }

        private void InitializeFlexGrid()
        {
            //flexSG.KeyDown += (s, e) => { if (e.KeyCode == Keys.Return) e.SuppressKeyPress = true; };
        }

        private void ShowData()
        {
            if (ItemData == null) return;

            //Show Position;

        }


        private bool DataIsValid()
        {
            //if (string.IsNullOrEmpty(txtCode.Text))
            //{
            //    My.Message.ShowValidationError(txtCode, "Code must not be blank");
            //    return false; 
            //}

            //if (string.IsNullOrEmpty(txtDescription.Text))
            //{
            //    My.Message.ShowValidationError(txtDescription, "Description must not be blank");
            //    return false;
            //}

            //if (CallerForm.ContainsData(txtCode.Text , ItemData.RowId))
            //{
            //    My.Message.ShowValidationError(txtCode, "Duplicate Record!");
            //    return false;
            //}
            return true;
        }

        private void Save()
        {
            if (!DataIsValid()) return;

            //ItemData.Code = txtCode.Text.Trim();
            //ItemData.Description = txtDescription.Text.Trim();

            //ItemData.Mandatory = swMandatory.Value;
            //ItemData.Priority = swPriority.Value ? 1 : 0;
            //ItemData.Active = swActive.Value;

            DialogResult = DialogResult.OK;
        }


        private void InitializePositionGrid()
        {
            PositionGrid.InitializeGrid();

            var grid = PositionGrid.PrimaryGrid;
                grid.GroupByRow.Visible = false;
                grid.SelectionGranularity = SelectionGranularity.Cell;
                grid.UseAlternateRowStyle = true;
                grid.AllowEdit = true;
                grid.MultiSelect = true;

            ItemData.PositionSalaryGrades.LoadItemsFromDb();
        }
        private void InitializeSGGrid()
        {
            SGGrid.InitializeGrid();
            SGGrid.KeyDown += (s, e) => { if (e.Control && e.KeyCode == Keys.C) SGGrid.PrimaryGrid.CopySelectedCellsToClipboard(); e.SuppressKeyPress = true; };

            var grid = SGGrid.PrimaryGrid;
            var col = new GridColumn();

            grid.GroupByRow.Visible = false;
            grid.SelectionGranularity = SelectionGranularity.Cell;
            grid.UseAlternateRowStyle = true;
            grid.AllowEdit = true;
            grid.MultiSelect = true;

            for (var step = 1; step <= 8; step++)
            {
                col = grid.CreateColumn("Step" + step, "Step " + step, 75, Alignment.MiddleRight);
                col.ColumnSortMode = ColumnSortMode.None;
                col.DataType = typeof(decimal);
                col.EditorType = typeof(GridDoubleInputEditControl);
                
            }


            var rnd = new Random();
            for (var step = 1; step <= 50; step++)
            {
                var row = grid.CreateNewRow();

                //row["Step1"].Value = rnd.Next(5000, 50000);
                //row["Step2"].Value = rnd.Next(5000, 50000);
                //row["Step3"].Value = rnd.Next(5000, 50000);
                //row["Step4"].Value = rnd.Next(5000, 50000);
                //row["Step5"].Value = rnd.Next(5000, 50000);
                //row["Step6"].Value = rnd.Next(5000, 50000);
                //row["Step7"].Value = rnd.Next(5000, 50000);
                //row["Step8"].Value = rnd.Next(5000, 50000);
               
            }

        }

    }
}
