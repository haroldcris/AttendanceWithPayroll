using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;

using Dapper;

namespace Dll.Contacts
{
    public class PersonCollection : EntityCollection<Person>
    {
        public void LoadItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                dynamic records = db.Query("Select * from Person");

                ItemCollection.Clear();

                foreach (var record in records)
                {
                    var item = new Person();
                    item.DataMapper.Map(record);

                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }
        }
    }
}
