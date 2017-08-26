using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;
using System.Linq;

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

                const string query = "Select * from [Payroll_SalaryGrade] where SalaryScheduleId = @SalarySchedId";

                var items = db.Query<SalaryGrade>(query, new { SalarySchedId = salarySchedId });

                if (!items.Any()) return false;

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
            ItemCollection.Clear();

            var salarySchedId = OnSalaryScheduleIdRequest();

            for (var i = 1; i <= 32; i++)
            {
                var sg = new SalaryGrade
                {
                    SalaryScheduleId = salarySchedId,
                    SG = i,
                    Step1 = 0,
                    Step2 = 0,
                    Step3 = 0,
                    Step4 = 0,
                    Step5 = 0,
                    Step6 = 0,
                    Step7 = 0,
                    Step8 = 0
                };

                //sg.RowStatus = RecordStatus.NewRecord;
                Add(sg);
            }
        }
    }

}
