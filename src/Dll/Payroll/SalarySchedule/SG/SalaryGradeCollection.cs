using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;

namespace Dll.Payroll
{
    public class SalaryGradeCollection : EntityCollection<SalaryGrade>
    {
        public Func<int> OnSalaryScheduleIdRequest;

        public bool LoadItemsFromDb()
        {

            if (OnSalaryScheduleIdRequest == null)
                throw new Exception("OnSalaryScheduleIdRequest handler not assigned");

            var salarySchedId = OnSalaryScheduleIdRequest();


            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var query = "Select * from [Payroll_SalaryGrade] where SalaryScheduleId = @SalarySchedId";
                var items = db.Query<SalaryGrade>(query, new { SalarySchedId = salarySchedId });

                foreach (var item in items)
                {
                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }

            return true;
        }

        public void LoadDefaultItems()
        {
            var salarySchedId = OnSalaryScheduleIdRequest();

            for (var i = 1; i <= 50; i++)
            {
                var sg = new SalaryGrade();
                sg.SalaryScheduleId = salarySchedId;

                sg.SG = i;
                sg.Step1 = 0;
                sg.Step2 = 0;
                sg.Step3 = 0;
                sg.Step4 = 0;
                sg.Step5 = 0;
                sg.Step6 = 0;
                sg.Step7 = 0;
                sg.Step8 = 0;

                Add(sg);
            }
        }
    }

}
