using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;
using System;

namespace Dll.Payroll
{
	public class SalaryGradeCollection : EntityChildCollection <SalaryGrade, SalarySchedule>
	{

        public bool LoadItemsFromDb()
		{
            
            if (Parent == null) throw new ArgumentException("Parent Salary Schedule is NOT Set.");

			this.ItemCollection.Clear();

			using (var db = Connection.CreateConnection())
			{
				db.Open();
				var sql = "Select * from [Payroll_SalaryGrade] where SalaryScheduleId = @SalarySchedId";
				var items = db.Query<SalaryGrade>(sql, new { SalarySchedId = Parent.Id });

                foreach (var item in items)
				{
                    item.SalarySchedule = Parent;
                    item.SalaryScheduleId = Parent.Id;

					item.RowStatus = RecordStatus.NoChanges;
					item.StartTrackingChanges();
					this.ItemCollection.Add(item);
				}
			}

            HasReadFromDb = true;
			return true;
		}

        public void LoadDefaultItems()
        {
            for (var i = 1; i <=50; i++)
            {
                var sg = new SalaryGrade();
                sg.SalaryScheduleId = Parent.Id;
                sg.SalarySchedule = Parent;

                sg.SG = i;
                sg.Step1 = 0;
                sg.Step2 = 0;
                sg.Step3 = 0;
                sg.Step4 = 0;
                sg.Step5 = 0;
                sg.Step6 = 0;
                sg.Step7 = 0;
                sg.Step8 = 0;

                this.Add(sg);
            }
        }
	}
	
}
