using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;

namespace Dll.Payroll
{
	public class DeductionCollection : EntityCollection<Deduction>
	{
		public bool LoadItemsFromDb()
		{
			this.ItemCollection.Clear();
			
			using (var db = Connection.CreateConnection())
			{
				db.Open();
				var sql = "Select * from [Payroll_Deduction]";
				var items = db.Query<Deduction>(sql);
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
