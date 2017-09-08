using AiTech.LiteOrm;

namespace AiTech.Biometric
{
    public class TransactionCollection : EntityCollection<Transaction>
    {
        //public bool LoadItemsFromDb()
        //{
        //	this.ItemCollection.Clear();

        //	using (var db = Connection.CreateConnection())
        //	{
        //		db.Open();
        //		var sql = "Select * from [Biometric_DeviceLog]";
        //		var items = db.Query<Transaction>(sql);
        //		foreach (var item in items)
        //		{
        //			item.RowStatus = AiTech.Entities.RecordStatus.NoChanges;
        //			item.StartTrackingChanges();
        //			this.ItemCollection.Add(item);
        //		}
        //	}
        //	return true;
        //}
    }

}
