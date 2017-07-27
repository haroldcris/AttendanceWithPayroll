using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;

namespace Dll.Payroll
{
	public class TaxCollection : EntityCollection<Tax>
	{
		public bool LoadItemsFromDb()
		{
			this.ItemCollection.Clear();
			
			using (var db = Connection.CreateConnection())
			{
				db.Open();
				var sql = "Select * from [Payroll_TaxTable]";
				var items = db.Query<Tax>(sql);
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
