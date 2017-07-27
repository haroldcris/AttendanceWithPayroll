using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;

namespace Dll.Payroll
{
	public class SalaryScheduleCollection : EntityCollection<SalarySchedule>
	{
		public bool LoadItemsFromDb()
		{
			this.ItemCollection.Clear();
			
			using (var db = Connection.CreateConnection())
			{
				db.Open();
				var sql = "Select * from [Payroll_SalarySchedule]";
				var items = db.Query<SalarySchedule>(sql);
				foreach (var item in items)
				{
					item.RowStatus = AiTech.Entities.RecordStatus.NoChanges;
					item.StartTrackingChanges();
					this.ItemCollection.Add(item);
				}
			}
			return true;
		}
	}
	
}
