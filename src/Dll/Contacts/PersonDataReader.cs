using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using AiTech.LiteOrm.Database.Search;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
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

                return GetItemWithId(id, db);

            }
        }


        public Person GetItemWithId(int id, SqlConnection db)
        {
            var result = db.Query("Select * from Person where Id = @Id", new { Id = id }).FirstOrDefault();

            if (result == null) return null;

            var item = new Person();
            item.DataMapper.Map(result);


            //Load All Mobile Numbers
            item.MobileNumbers.LoadItemsFromDb(db);


            item.RowStatus = RecordStatus.NoChanges;
            item.StartTrackingChanges();

            return item;
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



        public IEnumerable<Person> SearchItem(string searchItem, SearchStyleEnum searchStyle)
        {
            const string query = @"SELECT p.Id , [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [SpouseLastname], [Gender]
                                   from person p 
                                    where Replace(DBO.FULLNAME(LASTNAME, FIRSTNAME, MIDDLENAME, MiddleInitial, 0, NAMEEXTENSION, SpouseLastname),' ','') like @Criteria";

            var results = Search.SearchData<dynamic>(searchItem, query, searchStyle);

            var itemCollection = new List<Person>();

            foreach (var result in results)
            {
                var item = new Person();
                item.DataMapper.Map(result);


                item.DataMapper.Map(result);

                item.RowStatus = RecordStatus.NoChanges;
                item.StartTrackingChanges();
                itemCollection.Add(item);
            }

            return itemCollection;
        }

    }
}
