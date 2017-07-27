using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;

namespace Dll.Payroll
{
	public class PositionSalaryGradeCollection : EntityCollection<PositionSalaryGrade>
	{
        public SalarySchedule SalarySchedule { get; set; }
        public PositionSalaryGradeCollection(SalarySchedule salarySchedule)
        {
            SalarySchedule = salarySchedule;
        }

		public bool LoadItemsFromDb()
		{
			this.ItemCollection.Clear();
			
			using (var db = Connection.CreateConnection())
			{
				db.Open();
				var sql = @"Select  p.Id PositionId, p.Code, p.Description, isnull(SG,0) SG from
                            Payroll_Position p left join  [Payroll_PositionSG] psg on 
                            p.Id = psg.PositionId";

                dynamic items;
                if (SalarySchedule.Id == 0)
                {
                    items = db.Query<dynamic>(sql);
                }
                else
                {
                    sql += " where SalaryScheduleId = " + SalarySchedule.Id;
                    items = db.Query<dynamic>(sql);
                }
				
                
				foreach (var row in items)
				{
                    var item = new PositionSalaryGrade();

                    item.PositionId = row.PositionId;
                    item.Position = new Position()
                    {
                        Id = row.PositionId,
                        Code = row.Code,
                        Description = row.Description
                    };

                    item.SG = row.SG;
                    item.SalaryScheduleId = SalarySchedule.Id;
                    
					item.RowStatus = RecordStatus.NoChanges;
					item.StartTrackingChanges();
					this.ItemCollection.Add(item);
				}
			}
			return true;
		}
	}
	
}
