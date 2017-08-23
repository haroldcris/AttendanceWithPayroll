using AiTech.LiteOrm.Database;
using Dapper;
using System.Collections.Generic;

namespace Dll.Location
{
    public class TownDataReader
    {
        public IEnumerable<Town> GetTownsWithProvinceId(int provinceId)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = "Select Id, Town Name, ZipCode from Location_Town WHERE ProvinceId = @ProvinceId";

                return db.Query<Town>(sql, new { ProvinceId = provinceId });
            }
        }

        public IEnumerable<Town> GetTownsOfProvince(string province)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = @"Select t.Id, Province, Town Name, ZipCode from Location_Town t 
                            inner join [Location_Province] p on t.provinceId = p.Id 
                            WHERE Province = @ProvinceName Order By Town";

                return db.Query<Town>(sql, new { ProvinceName = province });
            }
        }
    }
}
