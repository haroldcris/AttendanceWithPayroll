using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Payroll;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmSalarySchedule_Add : FormWithHeader
    {
        public SalarySchedule ItemData { get; set; }

        public frmSalarySchedule_Add()
        {
            InitializeComponent();

            InitializeSGGrid();

            InitializePositionGrid();

            Load += (s, e) => { ShowData(); };

            CancelButton = btnCancel;
            btnCancel.Click += (s, e) => { Close(); };
            btnOk.Click += (s, e) => { Save(); };

            tabControl1.SelectedTabChanged += (s, e) =>
            {
                SelectNextControl(e.NewTab.AttachedControl, true, true, true, true);
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

            //if (CallerForm.ContainsData(dtEffectivityDate.Value, ItemData.RowId))
            //{
            //    App.Message.ShowValidationError(dtEffectivityDate, "Duplicate Record!");
            //    return false;
            //}
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
                    App.Message.ShowValidationError(this, "Number must be 1 - 50 only", focusControl: false);
                    e.Cancel = true;
                }

            };

            var col = new GridColumn();

            col = grid.CreateColumn("Code", "Code", 80);
            col.AllowEdit = false;

            col = grid.CreateColumn("Position", "Position", 200);
            col.AllowEdit = false;

            col = grid.CreateColumn("SalaryGrade", "Salary Grade", 80, Alignment.MiddleCenter);
            col.DataType = typeof(int);


            col.EditorType = typeof(GridDoubleIntInputEditControl);

        }



        private void InitializeSGGrid()
        {
            SGGrid.InitializeGrid();

            SGGrid.KeyDown += (s, e) =>
            {
                //Select All
                if (e.Control && e.KeyCode == Keys.A) { e.SuppressKeyPress = true; SGGrid.PrimaryGrid.SelectAll(); }
                //Copy
                if (e.Control && e.KeyCode == Keys.C) { e.SuppressKeyPress = true; SGGrid.PrimaryGrid.CopySelectedCellsToClipboard(); }
                //Paste
                if (e.Control && e.KeyCode == Keys.V) { e.SuppressKeyPress = true; PasteToGrid(SGGrid.PrimaryGrid); }
            };


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

        private void PasteToGrid(GridPanel control)
        {
            var clipBoard = Clipboard.GetText();

            var lines = clipBoard.Split('\n');

            var currentRow = control.ActiveCell.RowIndex;
            var currentCol = control.ActiveCell.ColumnIndex;


            for (var row = 0; row < lines.Length; row++)
            {

                var cells = lines[row].Split('\t');

                for (var col = 0; col < cells.Length; col++)
                {
                    GridCell activeCell = control.GetCell(currentRow + row, currentCol + col);

                    if (activeCell == null) continue;

                    if (!activeCell.AllowEdit) continue;


                    decimal result;
                    if (decimal.TryParse(cells[col], out result))
                    {
                        activeCell.Value = result;
                        activeCell.IsSelected = true;
                    }
                    else
                    {
                        activeCell.Value = 0;
                    }

                }

            }

        }

        private void ShowData()
        {
            if (ItemData == null) return;

            dtEffectivityDate.Value = ItemData.Effectivity;
            txtRemarks.Text = ItemData.Remarks;


            //
            //  SHOW SALARY GRADE TABLE
            //
            var row = new GridRow();

            if (!ItemData.SalaryGrades.LoadItemsFromDb())
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

            ItemData.PositionSalaryGrades.LoadItemsFromDb();

            foreach (var itemPosition in ItemData.PositionSalaryGrades.Items)
            {
                row = PositionGrid.PrimaryGrid.CreateNewRow();

                row["Code"].Value = itemPosition.PositionCode;
                row["Position"].Value = itemPosition.PositionDescription;
                row["SalaryGrade"].Value = itemPosition.SG;

                row.Tag = itemPosition;
            }


        }
    }
}
