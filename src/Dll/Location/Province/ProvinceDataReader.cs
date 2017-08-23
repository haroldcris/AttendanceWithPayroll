using AiTech.LiteOrm.Database;
using Dapper;
using System.Collections.Generic;

namespace Dll.Location
{
    public class ProvinceDataReader
    {
        public IEnumerable<Province> GetProvinces()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                return db.Query<Province>("Select Id, Province Name from Location_Province Order By Province");
            }
        }
    }
}
