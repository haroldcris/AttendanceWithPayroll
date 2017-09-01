using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Data.SqlClient;

namespace Dll.Contacts
{
    public class MobileNumberCollection : EntityCollection<MobileNumber>
    {
        private Person _person;
        public MobileNumberCollection()
        {

        }

        public MobileNumberCollection(Person parentPerson)
        {
            _person = parentPerson;
        }



        public void LoadItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                LoadItemsFromDb(db);
            }
        }


        public void LoadItemsFromDb(SqlConnection db)
        {
            dynamic records = db.Query("Select * from Person_MobileNumber where PersonId = @PersonId", new { PersonId = _person.Id });

            ItemCollection.Clear();

            foreach (var record in records)
            {
                var item = new MobileNumber
                {
                    Id = record.Id,
                    PersonId = record.PersonId,
                    PhoneNumber = record.PhoneNumber,
                    RowStatus = RecordStatus.NoChanges
                };


                item.StartTrackingChanges();
                ItemCollection.Add(item);
            }
        }
    }
}
