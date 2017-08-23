using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.Contacts
{
    public class PersonDataReader
    {

        public Person GetItemWithId(int id)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query("Select * from Person where Id = @id").FirstOrDefault();

                if (result == null) return null;

                var item = new Person();
                item.DataMapper.Map(result);
                item.StartTrackingChanges();

                return item;
            }
        }


        public Person GetItem(string lastname, string firstname, string middlename)
        {
            using (var db = Connection.CreateConnection())
            {
                const string query = @"SELECT Id, Lastname, Firstname, Middlename, MiddleInitial, NameExtension, Gender, BirthDate from
                                        Person where Lastname = @Lastname and Firstname = @Firstname and Middlename = @Middlename";
                db.Open();
                var result = db.Query(query, new { Lastname = lastname, Firstname = firstname, Middlename = middlename }).FirstOrDefault();

                if (result == null) return null;

                var item = new Person();
                item.DataMapper.Map(result);

                return item;
            }
        }
    }
}
