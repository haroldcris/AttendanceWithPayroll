using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;

namespace Dll.Payroll
{
	public class PositionSalaryGradeCollection : EntityChildCollection<PositionSalaryGrade, SalarySchedule>
	{
		public bool LoadItemsFromDb()
		{
			this.ItemCollection.Clear();
			
			using (var db = Connection.CreateConnection())
			{
				db.Open();
                var sql = @"Select IsNull(psg.Id,0) Id, p.Id PositionId, p.Code, p.Description, isnull(SG,0) SG from
	                        Payroll_Position p left join  
	                        (SELECT * FROM [Payroll_PositionSG] where SalaryScheduleId = @ParentId ) psg
	                        on p.Id = psg.PositionId";
                          

                dynamic items = db.Query<dynamic>(sql, new { ParentId = Parent.Id });
                
				foreach (var row in items)
				{
                    var item = new PositionSalaryGrade();

                    item.Id = row.Id;
                    item.PositionId = row.PositionId;
                    item.Position = new Position()
                    {
                        Id = row.PositionId,
                        Code = row.Code,
                        Description = row.Description
                    };

                    item.SG = row.SG;

                    item.SalaryScheduleId = Parent.Id;
                    item.SalarySchedule = Parent;

					item.RowStatus = row.Id == 0 ? RecordStatus.NewRecord : RecordStatus.NoChanges;
					item.StartTrackingChanges();

					this.ItemCollection.Add(item);
				}
			}

            HasReadFromDb = true;
			return true;
		}


        public void LoadDefaultItems()
        {
            this.ItemCollection.Clear();
            try
            {
                using (var db = Connection.CreateConnection())
                {
                    db.Open();
                    var sql = @"Select  p.Id PositionId, p.Code, p.Description, 0 SG from Payroll_Position p";

                    dynamic items;
                    items = db.Query<dynamic>(sql);


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

                        item.SalaryScheduleId = Parent.Id;
                        item.SalarySchedule = Parent;

                        item.RowStatus = RecordStatus.NewRecord;
                        item.StartTrackingChanges();

                        this.ItemCollection.Add(item);
                    }
                }
            } catch { throw; }
        }

	}
	
}
