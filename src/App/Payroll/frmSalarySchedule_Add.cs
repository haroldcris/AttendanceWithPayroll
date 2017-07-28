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

            this.tabControl1.SelectedTabChanged += (s, e) =>
            {
                this.SelectNextControl(e.NewTab.AttachedControl, true, true, true, true);
            };
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

            if (CallerForm.ContainsData(dtEffectivityDate.Value, ItemData.RowId))
            {
                My.Message.ShowValidationError(dtEffectivityDate, "Duplicate Record!");
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (!DataIsValid()) return;

            ItemData.Effectivity = dtEffectivityDate.Value;
            ItemData.Remarks = txtRemarks.Text;

            //SalaryGrades 
            foreach (GridRow row in SGGrid.PrimaryGrid.Rows)
            {
                var rowData = (SalaryGrade)row.Tag;
                if (rowData == null) continue;

                rowData.Step1 = decimal.Parse(row["Step1"].Value.ToString());
                rowData.Step2 = decimal.Parse(row["Step2"].Value.ToString());
                rowData.Step3 = decimal.Parse(row["Step3"].Value.ToString());
                rowData.Step4 = decimal.Parse(row["Step4"].Value.ToString());
                rowData.Step5 = decimal.Parse(row["Step5"].Value.ToString());
                rowData.Step6 = decimal.Parse(row["Step6"].Value.ToString());
                rowData.Step7 = decimal.Parse(row["Step7"].Value.ToString());
                rowData.Step8 = decimal.Parse(row["Step8"].Value.ToString());
            }


            //Position Salary Grade 
            foreach (GridRow row in PositionGrid.PrimaryGrid.Rows)
            {
                var rowData = (PositionSalaryGrade)row.Tag;
                if (rowData == null) continue;

                rowData.SG = int.Parse(row["SalaryGrade"].Value.ToString());
            }


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
            grid.InitialActiveRow = RelativeRow.FirstRow;
            grid.InitialSelection = RelativeSelection.LastCell;


            grid.SuperGrid.CellValidating += (s, e) =>
            {
                if (e.GridCell.ColumnIndex != 1) return;

                var itemValue = int.Parse(e.Value.ToString());

                if (!(itemValue >= 1 && itemValue <= 50))
                {
                    My.Message.ShowValidationError(this, "Number must be 1 - 50 only", focusControl: false);
                    e.Cancel = true;
                }

            };

            var col = new GridColumn();
            col = grid.CreateColumn("Position", "Position", 200, Alignment.MiddleLeft);
            col.AllowEdit = false;

            col = grid.CreateColumn("SalaryGrade", "Salary Grade", 80, Alignment.MiddleCenter);
            col.DataType = typeof(int);
            col.EditorType = typeof(GridDoubleIntInputEditControl);

        }

        private void InitializeSGGrid()
        {
            SGGrid.InitializeGrid();
            SGGrid.KeyDown += (s, e) => { if (e.Control && e.KeyCode == Keys.C) { SGGrid.PrimaryGrid.CopySelectedCellsToClipboard(); e.SuppressKeyPress = true; } };

            var grid = SGGrid.PrimaryGrid;
            var col = new GridColumn();

            grid.GroupByRow.Visible = false;
            grid.SelectionGranularity = SelectionGranularity.Cell;
            grid.UseAlternateRowStyle = true;
            grid.AllowEdit = true;
            grid.MultiSelect = true;


            //grid.InitialActiveRow = RelativeRow.FirstRow;
            //grid.InitialSelection = RelativeSelection.FirstCell;

            for (var step = 1; step <= 8; step++)
            {
                col = grid.CreateColumn("Step" + step, "Step " + step, 75, Alignment.MiddleRight);
                col.ColumnSortMode = ColumnSortMode.None;
                col.DataType = typeof(decimal);
                col.RenderType = typeof(GridDoubleInputEditControl);
                col.EditorType = typeof(GridDoubleIntInputEditControl);
            }


        }

        private void ShowData()
        {
            if (ItemData == null) return;

            dtEffectivityDate.Value = ItemData.Effectivity;
            txtRemarks.Text = ItemData.Remarks;


            var row = new GridRow();

            //
            // Show SalaryGrades
            //
            if (!ItemData.SalaryGrades.HasReadFromDb)
                ItemData.SalaryGrades.LoadItemsFromDb();

            if (ItemData.SalaryGrades.Items.Count() == 0)
                ItemData.SalaryGrades.LoadDefaultItems();

            foreach (var itemSG in ItemData.SalaryGrades.Items)
            {
                row = SGGrid.PrimaryGrid.CreateNewRow();
                //row["SG"].Value = itemSG.SG;
                row["Step1"].Value = itemSG.Step1;
                row["Step2"].Value = itemSG.Step2;
                row["Step3"].Value = itemSG.Step3;
                row["Step4"].Value = itemSG.Step4;
                row["Step5"].Value = itemSG.Step5;
                row["Step6"].Value = itemSG.Step6;
                row["Step7"].Value = itemSG.Step7;
                row["Step8"].Value = itemSG.Step8;

                row.Tag = itemSG;
            }

            //
            // Show Position;
            //
            if (!ItemData.PositionSalaryGrades.HasReadFromDb)
                ItemData.PositionSalaryGrades.LoadItemsFromDb();

            if (ItemData.PositionSalaryGrades.Items.Count() == 0)
                ItemData.PositionSalaryGrades.LoadDefaultItems();

            foreach (var itemPosition in ItemData.PositionSalaryGrades.Items)
            {
                row = PositionGrid.PrimaryGrid.CreateNewRow();
                row["Position"].Value = itemPosition.Position.Description;
                row["SalaryGrade"].Value = itemPosition.SG;

                row.Tag = itemPosition;
            }


        }
    }
}
