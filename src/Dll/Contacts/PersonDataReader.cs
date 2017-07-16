using AiTech.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Contacts
{
    public class PersonDataReader
    {
        public IEnumerable<Person> GetAllItems()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var items = db.Query<Person>("Select * from Persons");

                foreach (var item in items) item.StartTrackingChanges();

                return items;
            }
        }


        public Person GetItemWithId(int id)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var item = db.Query<Person>("Select * from Persons where Id = @id").FirstOrDefault();
                item.StartTrackingChanges();
                return item;
            }
        }
    }
}
