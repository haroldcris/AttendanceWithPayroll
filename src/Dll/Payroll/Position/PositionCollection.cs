using System.Linq;
using Dapper;
using AiTech.Database;
using AiTech.Entities;
using System.Collections.Generic;

namespace Dll.Payroll
{
	public class PositionCollection : EntityCollection<Position>
	{

		public bool LoadItemsFromDb()
		{
			this.ItemCollection.Clear();
			
			using (var db = Connection.CreateConnection())
			{
				db.Open();
				var sql = "Select * from Payroll_Position";
				var items = db.Query<Position>(sql);
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
