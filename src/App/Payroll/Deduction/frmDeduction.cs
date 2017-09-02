using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Payroll;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.Payroll
{
    public partial class frmDeduction : MdiClientGridForm
    {
        internal DeductionCollection ItemDataCollection = new DeductionCollection();
        public frmDeduction()
        {
            InitializeComponent();

            Header = " PAYROLL DEDUCTIONS ";
            HeaderColor = App.BarColor.PayrollDeductionColor;

            Load += (s, e) => { RefreshData(); };
        }




        protected override IEnumerable<Entity> LoadItems()
        {
            ItemDataCollection.LoadItemsFromDb();
            return ItemDataCollection.Items;
        }


        protected override void InitializeGrid()
        {
            base.InitializeGrid();

            SGrid.InitializeGrid();


            var grid = SGrid.PrimaryGrid;

            grid.GroupByRow.Visible = false;

            var col = grid.CreateColumn("Code", "Code", 80, Alignment.MiddleCenter);
            col.GroupBoxEffects = GroupBoxEffects.None;

            grid.CreateColumn("Description", "Description", 200);

            col = grid.CreateColumn("Mandatory", "Mandatory", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);

            col = grid.CreateColumn("Priority", "Priority", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);

            col = grid.CreateColumn("Active", "Active", 80, Alignment.MiddleCenter);
            col.EditorType = typeof(GridCheckBoxXEditControl);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);

        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Deduction)item;

            row.Cells["Code"].Value = currentItem.Code;
            row.Cells["Description"].Value = currentItem.Description;

            row.Cells["Mandatory"].Value = currentItem.Mandatory;
            row.Cells["Priority"].Value = currentItem.Priority;
            row.Cells["Active"].Value = currentItem.Active;

            row.CellStyles.Default = currentItem.Active ? null : new CellVisualStyle() { Background = new Background(System.Drawing.Color.LightGray) };

            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Deduction();

            using (var frm = new frmDeduction_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            App.LogAction("Deduction", "Created Deduction: " + newItem.Description);

            ItemDataCollection.Add(newItem);
            return newItem;
        }



        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Deduction)item;

            using (var frm = new frmDeduction_Add())
            {
                if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Deduction", "Updated Deduction: " + selectedItem.Description);

            return true;
        }



        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Deduction)item).Description;

            afterConfirm = (currentItem) =>
            {
                try
                {
                    var deletedItem = (Deduction)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new DeductionDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();

                    App.LogAction("Deduction", "Deleted Deduction: " + deletedItem.Description);

                    ItemDataCollection.Remove((Deduction)currentItem);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }



    }
}
