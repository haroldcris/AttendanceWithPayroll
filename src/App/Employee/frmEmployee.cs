using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using Dll.Employee;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Winform.Employee
{
    public partial class frmEmployee : MdiClientGridForm
    {
        internal EmployeeCollection ItemDataCollection = new EmployeeCollection();

        public frmEmployee()
        {
            InitializeComponent();

            Header = " EMPLOYEES ";
            HeaderColor = App.BarColor.EmployeeColor;

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

            var col = grid.CreateColumn("Empnum", "Employee No.", 80, Alignment.MiddleCenter);


            // grid.CreateColumn("CameraCounter", "Image File", 85);

            grid.CreateColumn("Lastname", "Lastname", 90);
            grid.CreateColumn("Firstname", "Firstname", 100);
            grid.CreateColumn("Middlename", "Middlename", 80);
            grid.CreateColumn("NameExtension", "Ext", 40);

            grid.CreateColumn("Gender", "Gender");

            grid.CreateColumn("CivilStatus", "Civil Status");

            grid.CreateColumn("Birthdate", "Birthdate", 80, Alignment.MiddleCenter);

            //grid.CreateColumn("BirthTown", "Town", 120);
            //grid.CreateColumn("BirthProvince", "Province", 85);
            //grid.CreateColumn("BirthCountry", "Country", 70);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);
        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Dll.Employee.Employee)item;

            row.Cells["Empnum"].Value = currentItem.EmpNum;

            row.Cells["Lastname"].Value = currentItem.PersonClass.Name.Lastname;
            row.Cells["Firstname"].Value = currentItem.PersonClass.Name.Firstname;
            row.Cells["Middlename"].Value = currentItem.PersonClass.Name.Middlename;
            row.Cells["NameExtension"].Value = currentItem.PersonClass.Name.NameExtension;

            row.Cells["Gender"].Value = currentItem.PersonClass.Gender == GenderType.Male ? "Male" : "Female";

            row.Cells["Birthdate"].Value = currentItem.PersonClass.BirthDate.ToString("dd - MMM - yyyy");

            //row.Cells["BirthCountry"].Value = currentItem.PersonClass.BirthCountry;
            //row.Cells["BirthProvince"].Value = currentItem.PersonClass.BirthProvince;
            //row.Cells["BirthTown"].Value = currentItem.PersonClass.BirthTown;


            row.Cells["CivilStatus"].Value = currentItem.CivilStatus;


            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Dll.Employee.Employee();

            //App.MdiMainForm.OpenForm(frm, "Employee");
            ////f.Show(this);

            using (var frm = new frmEmployee_Add())
            {
                frm.ItemData = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return null;
            }

            App.LogAction("Employee", "Created Employee : " + newItem.EmpNum);

            ItemDataCollection.Add(newItem);
            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Dll.Employee.Employee)item;

            using (var frm = new frmEmployee_Add())
            {
                if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
                frm.ItemData = selectedItem;
                if (frm.ShowDialog() != DialogResult.OK) return false;
            }

            App.LogAction("Employee", "Updated Employee : " + selectedItem.EmpNum);

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Dll.Employee.Employee)item).PersonClass.Name.Fullname;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (Dll.Employee.Employee)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new EmployeeDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Dll.Employee.Employee)currentItem);

                    App.LogAction("Employee", "Deleted Employee : " + deletedItem.EmpNum);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (Dll.Employee.Employee)this.SelectedItem;
            if (item == null) return;

            //var frm = new frmAssignSubject(this);
            //var result = frm.ShowDialog();
            //if (result != DialogResult.OK) return;
        }
    }
}