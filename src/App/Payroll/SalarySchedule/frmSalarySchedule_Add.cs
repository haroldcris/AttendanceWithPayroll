﻿using System;
using System.Windows.Forms;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Payroll;

namespace Winform.Payroll
{
    public partial class frmSalarySchedule_Add : FormWithHeader, ISave
    {
        public frmSalarySchedule_Add()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;


            #region Initialize DirtyHandler

            DirtyStatus = new DirtyFormHandler(this);

            this.AskToSaveOnDirtyClosing();
            this.ConvertEnterToTab();
            Shown += (s, e) =>
            {
                ShowData();
                DirtyStatus.Clear();
            };

            CancelButton = btnCancel;
            btnOk.Click += (s, e) => FileSave();

            #endregion


            InitializeSGGrid();

            InitializePositionGrid();

            tabControl1.SelectedTabChanged += (s, e) =>
            {
                SelectNextControl(e.NewTab.AttachedControl, true, true, true, true);
            };
        }

        public SalarySchedule ItemData { get; set; }

        public DirtyFormHandler DirtyStatus { get; }


        public bool FileSave()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DataIsValid()) return false;

                ItemData.Effectivity = dtEffectivityDate.Value;
                ItemData.Remarks = txtRemarks.Text;

                //SalaryGrades 
                foreach (var gridElement in SGGrid.PrimaryGrid.Rows)
                {
                    var row = (GridRow) gridElement;
                    var rowData = (SalaryGrade) row.Tag;
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
                foreach (var gridElement in PositionGrid.PrimaryGrid.Rows)
                {
                    var row = (GridRow) gridElement;
                    var rowData = (PositionSalaryGrade) row.Tag;
                    if (rowData == null) continue;

                    rowData.SG = int.Parse(row["SalaryGrade"].Value.ToString());
                }


                //Save to the Database
                var dataWriter = new SalaryScheduleDataWriter(App.CurrentUser.User.Username, ItemData);
                dataWriter.SaveChanges();

                DirtyStatus.Clear();
                DialogResult = DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowError(ex, this);
                return false;
            }
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
            //    MessageDialog.ShowValidationError(dtEffectivityDate, "Duplicate Record!");
            //    return false;
            //}

            var reader = new SalaryScheduleDataReader();
            var foundItem = reader.GetItemWithEffectivity(dtEffectivityDate.Value);
            if (foundItem != null && foundItem.Id != ItemData.Id)
            {
                MessageDialog.ShowValidationError(dtEffectivityDate, "Duplicate Effectivity Date");
                return false;
            }
            return true;
        }


        private void InitializePositionGrid()
        {
            PositionGrid.InitializeGrid();

            var grid = PositionGrid.PrimaryGrid;

            grid.EnableClipboardPasteNumbers();
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
                    MessageDialog.ShowValidationError(this, "Number must be 1 - 50 only", focusControl: false);
                    e.Cancel = true;
                }
            };

            var col = grid.CreateColumn("Code", "Code", 80);
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


            var grid = SGGrid.PrimaryGrid;

            grid.EnableClipboardPasteNumbers();
            grid.GroupByRow.Visible = false;
            grid.SelectionGranularity = SelectionGranularity.Cell;
            grid.UseAlternateRowStyle = true;

            grid.AllowEdit = true;
            grid.MultiSelect = true;


            //grid.InitialActiveRow = RelativeRow.FirstRow;
            //grid.InitialSelection = RelativeSelection.FirstCell;

            for (var step = 1; step <= 8; step++)
            {
                var col = grid.CreateColumn("Step" + step, "Step " + step, 75, Alignment.MiddleRight);
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


            //
            //  SHOW SALARY GRADE TABLE
            //
            GridRow row;

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

                row["Code"].Value = itemPosition.PositionClass.Code;
                row["Position"].Value = itemPosition.PositionClass.Description;
                row["SalaryGrade"].Value = itemPosition.SG;

                row.Tag = itemPosition;
            }
        }
    }
}