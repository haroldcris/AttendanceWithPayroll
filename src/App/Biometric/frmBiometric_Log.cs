using C1.C1Schedule;
using Dll.Biometric;
using Dll.Contacts;
using System;
using System.Collections.Generic;
using System.Drawing;
using Library.Tools;

namespace Winform.Biometric
{
    public partial class frmBiometric_Log : MdiClientForm
    {
        public BiometricUser ItemData;

        public frmBiometric_Log()
        {
            InitializeComponent();

            Header = " ATTENDANCE MONITORING ";
            HeaderColor = App.BarColor.AttendanceMonitoring;


            explorerBarGroupRecordInfo.Visible = false;

            dtMonthDate.Value = DateTime.Today;
            Initialize_Calendar();


            Shown += (s, e) => { ShowData(); };
        }



        private void Initialize_Calendar()
        {
            //Format Calendar
            c1Schedule1.AllowDrop = false;
            c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.MonthView;
            c1Schedule1.EditOptions = C1.Win.C1Schedule.EditOptions.None;
            c1Schedule1.CalendarInfo.WeekStart = DayOfWeek.Monday;
            c1Schedule1.ShowTitle = false;
            c1Schedule1.ShowContextMenu = false;
            c1Schedule1.VisualStyle = C1.Win.C1Schedule.UI.VisualStyle.Office2007Blue;
            c1Schedule1.LargeButtons = false;

            c1Schedule1.ShowAppointmentToolTip = true;
            c1Schedule1.ShowGroupNavigation = false;


            c1Schedule1.DataStorage.AppointmentStorage.Clear();


            c1Schedule1.GoToDate(dtMonthDate.Value);


            //var item = new Appointment();

            //item.AllDayEvent = true;
            //item.Start = DateTime.Now;

            //item.Label = new Label(Color.LightGreen, "text", "menu");
            //item.Subject = "BVody here";

            ////c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add(item);
            //var ret = c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
            //ret.Label = new Label(Color.Lime,"In","In");
            //ret.AllDayEvent = true;


            //var ret2 = c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
            //ret2.Label = new Label(Color.Lime, "In", "In");
            //ret2.AllDayEvent = true;
            ////ret2.Start = DateTime.Today + TimeSpan.ho
        }

        private void ShowName(Person person)
        {
            const string template = @"<font color='blue'><h3>%lastname%</h3></font>";


            lblName.Text = template.Replace("%lastname%", person.Name.Fullname);

        }



        private void ShowData()
        {
            ShowName(ItemData.PersonClass);

            lblCameraCounter.Text = ItemData.PersonClass.CameraCounter;

            InputControls.LoadImage(picImage, ItemData.PersonClass.CameraCounter);


            ItemData.BiometricLogs.LoadAllItems();

            Show_LogsToCalendar(ItemData.BiometricLogs.Items);
        }


        private void Show_LogsToCalendar(IEnumerable<BiometricLog> items)
        {

            //c1Schedule1.GoToDate(new DateTime(dtMonthDate.Value.Year, dtMonthDate.Value.Month, 1));

            c1Schedule1.DataStorage.AppointmentStorage.Appointments.Clear();

            foreach (var item in items)
            {
                var node = (Appointment)c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();

                node.AllDayEvent = true;

                node.Label = item.InOut == "In" ? new Label(Color.Lime, "In", "In") : new Label(Color.HotPink, "Out", "Out");

                node.Start = item.CalendarDate;
                node.Subject = item.InOut + "  " + item.TimeLog.ToString("hh:mm:ss tt");
            }

            c1Schedule1.Refresh();

        }

        protected override void Form_Load(object sender, EventArgs e)
        {
            base.Form_Load(sender, e);

            DirtyStatus.DirtySet += (s, arg) =>
            {
                DirtyStatus.Clear();
            };
        }

        private void dtMonthDate_ValueChanged(object sender, EventArgs e)
        {
            c1Schedule1.GoToDate(dtMonthDate.Value);

            //if (ItemData == null) return;

            //ItemData.BiometricLogs.LoadItemsFor(dtMonthDate.Value);

            //Show_LogsToCalendar(ItemData.BiometricLogs.Items);
        }

        private void c1Schedule1_BeforeViewChange(object sender, C1.Win.C1Schedule.BeforeViewChangeEventArgs e)
        {
            if (e.ViewType != C1.Win.C1Schedule.ScheduleViewEnum.MonthView) e.Cancel = true;
        }
    }
}
