using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AiTech.Account
{
    public class UserCollection
    {
        //public IEnumerable<AccountUser> Items { get; set; }

        //ICollection<AccountUser> collection = new List<AccountUser>();
        //public UserCollection()
        //{
        //    Items = collection;
        //}

        //public void LoadItems()
        //{
        //    try
        //    {
        //        using (var db = AiTech.Utility.Database.CreateConnection())
        //        {
        //            db.Open();
        //            var result = db.Query<AccountUser>("Select * from AccountUser");

        //            foreach (var item in result)
        //                collection.Add(item);
        //        }
        //    } catch
        //    {
        //        throw;
        //    }
        //}
    }
}
