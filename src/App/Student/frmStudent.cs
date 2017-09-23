using AiTech.LiteOrm;
using AiTech.Tools.Winform;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Dll.Contacts;
using Dll.Employee;
using Dll.Student;
using System;
using System.Collections.Generic;

namespace Winform.Student
{
    public partial class frmStudent : MdiClientGridForm
    {
        internal StudentCollection ItemDataCollection = new StudentCollection();

        public frmStudent()
        {
            InitializeComponent();

            Header = " STUDENTS ";
            HeaderColor = App.BarColor.StudentColor;

            Load += (s, e) => { RefreshData(); };
        }


        protected override IEnumerable<Entity> LoadItems()
        {
            ItemDataCollection.LoadAllItemsFromDb();
            return ItemDataCollection.Items;
        }


        protected override void InitializeGrid()
        {
            base.InitializeGrid();

            SGrid.InitializeGrid();


            var grid = SGrid.PrimaryGrid;

            grid.GroupByRow.Visible = false;

            var col = grid.CreateColumn("StudentNumber", "Student No.", 80, Alignment.MiddleCenter);


            // grid.CreateColumn("CameraCounter", "Image File", 85);

            grid.CreateColumn("Lastname", "Lastname", 90);
            grid.CreateColumn("Firstname", "Firstname", 100);
            grid.CreateColumn("Middlename", "Middlename", 80);
            grid.CreateColumn("NameExtension", "Ext", 40);

            grid.CreateColumn("Gender", "Gender");

            grid.CreateColumn("Birthdate", "Birthdate", 80, Alignment.MiddleCenter);

            grid.CreateColumn("BirthTown", "Town", 120);
            grid.CreateColumn("BirthProvince", "Province", 85);
            grid.CreateColumn("BirthCountry", "Country", 70);


            grid.CreateRecordInfoColumns();

            // Create COntext Menu;
            CreateGridContextMenu();

            //Define Sort
            grid.SetSort(SGrid.PrimaryGrid.Columns["Lastname"]);
        }


        protected override void Show_DataOnRow(GridRow row, Entity item)
        {
            var currentItem = (Dll.Student.Student)item;

            row.Cells["StudentNumber"].Value = currentItem.StudentNumber;

            row.Cells["Lastname"].Value = currentItem.PersonClass.Name.Lastname;
            row.Cells["Firstname"].Value = currentItem.PersonClass.Name.Firstname;
            row.Cells["Middlename"].Value = currentItem.PersonClass.Name.Middlename;
            row.Cells["NameExtension"].Value = currentItem.PersonClass.Name.NameExtension;

            row.Cells["Gender"].Value = currentItem.PersonClass.Gender == GenderType.Male ? "Male" : "Female";

            row.Cells["Birthdate"].Value = currentItem.PersonClass.BirthDate.ToString("dd - MMM - yyyy");

            row.Cells["BirthCountry"].Value = currentItem.PersonClass.BirthCountry;
            row.Cells["BirthProvince"].Value = currentItem.PersonClass.BirthProvince;
            row.Cells["BirthTown"].Value = currentItem.PersonClass.BirthTown;


            row.ShowRecordInfo(currentItem);
        }


        protected override Entity OnAdd()
        {
            var newItem = new Dll.Student.Student();

            //using (var frm = new frmEmployee_Add())
            //{
            //    frm.ItemData = newItem;
            //    if (frm.ShowDialog() != DialogResult.OK) return null;
            //}

            //App.LogAction("Employee", "Created Employee : " + newItem.EmpNum);

            //ItemDataCollection.Add(newItem);
            return newItem;
        }


        protected override bool OnEdit(Entity item)
        {
            var selectedItem = (Dll.Student.Student)item;

            //using (var frm = new frmEmployee_Add())
            //{
            //    if (selectedItem.Id != 0) selectedItem.RowStatus = RecordStatus.ModifiedRecord;
            //    frm.ItemData = selectedItem;
            //    if (frm.ShowDialog() != DialogResult.OK) return false;
            //}

            App.LogAction("Student", "Updated Student : " + selectedItem.StudentNumber.ToString());

            return true;
        }


        protected override void OnDelete(Entity item, out string message, ref Action<Entity> afterConfirm)
        {
            if (afterConfirm == null) throw new ArgumentNullException(nameof(afterConfirm));

            message = ((Dll.Student.Student)item).PersonClass.Name.Fullname;

            afterConfirm = currentItem =>
            {
                try
                {
                    var deletedItem = (Dll.Employee.Employee)currentItem;


                    deletedItem.RowStatus = RecordStatus.DeletedRecord;

                    //Save to Database
                    var dataWriter = new EmployeeDataWriter(App.CurrentUser.User.Username, deletedItem);
                    dataWriter.SaveChanges();


                    ItemDataCollection.Remove((Dll.Student.Student)currentItem);

                    App.LogAction("Student", "Deleted Student : " + deletedItem.EmpNum);
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowError(ex, this);
                }
            };
        }
    }
}