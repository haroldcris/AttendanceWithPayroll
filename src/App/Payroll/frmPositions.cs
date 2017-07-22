using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System;
using System.Threading.Tasks;

namespace Winform.Payroll
{
    public partial class frmPositions : MDIClientForm
    {
        public frmPositions()
        {
            InitializeComponent();

            InitializeGrid();
        }


        public override bool FileSave()
        {
            return DoSave(() =>
            {
                //MyManager.SetItems(MyList.Items);

                //MyManager.SaveChanges();

                //Update_Data();
            });
        }


        private void LoadItems()
        {
            //MyList = new TricycleCollection();
            //MyList.AttachRange(MyManager.GetList());            
        }

        private void InitializeGrid()
        {
            SGrid.InitializeGrid();

            SGrid.CreateColumn("Code", "Code", 75, Alignment.MiddleCenter);
            SGrid.CreateColumn("Description", "Description", 130, Alignment.MiddleLeft);

            SGrid.CreateColumn("CreatedBy", "Created By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Created", "Created", 130, Alignment.MiddleLeft);
            SGrid.CreateColumn("ModifiedBy", "Modified By", 90, Alignment.MiddleLeft);
            SGrid.CreateColumn("Modified", "Modified", 130, Alignment.MiddleLeft);
        }



        private void RefreshData()
        {
            DoRefresh(async () =>
            {
                progressBarX1.Visible = true;

                var grid = SGrid.PrimaryGrid;
                grid.Rows.Clear();

                await Task.Factory.StartNew(() =>
                {
                    LoadItems();
                });

                progressBarX1.Visible = false;
                //Show_Data();
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //var grid = SGrid.PrimaryGrid;
                //if (grid.ActiveRow == null) return;
                //var item = (Tricycle)grid.ActiveRow.Tag;

                //var frm = new frmTricycle_Add();
                //    frm.MyTricycle = item;

                //frm.Owner = this;
                //if (frm.ShowDialog() != DialogResult.OK) return;
                //    frm.Dispose();

                //if (item.Id != 0) item.RowStatus = AiTech.CrudPattern.RecordStatus.ModifiedRecord;
                //DirtyStatus.SetDirty();
                //((GridRow)grid.ActiveRow).RowDirty = true;
                //Show_DataOnRow((GridRow)grid.ActiveRow, item);

            }
            catch (Exception ex)
            {
                My.Message.ShowError(ex, this);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading");
            RefreshData();
            Console.WriteLine("Exit RefreshData");
        }


    }
}
