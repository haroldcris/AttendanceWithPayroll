using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AiTech.Location
{
    public class LocationManager
    {
        public IEnumerable<Province> GetProvinces()
        {
            using (var db = Database.Connection.CreateConnection())
            {
                db.Open();
                return db.Query<Province>("Select Id, Province Name from Location_Provinces");
            }
        }

        public IEnumerable<Town> GetTowns(int provinceId)
        {
            using (var db = Database.Connection.CreateConnection())
            {
                db.Open();
                var sql = @"Select Id, Town Name, ZipCode from Location_Towns 
                                WHERE ProvinceId = @ProvinceId";

                return db.Query<Town>(sql, new {ProvinceId = provinceId } );
            }
        }

        public IEnumerable<Town> GetTowns(string province)
        {
            using (var db = Database.Connection.CreateConnection())
            {
                db.Open();
                var sql = @"Select t.Id, Province, Town Name, ZipCode from Location_Towns t
                                inner join Location_Provinces p on t.provinceId = p.Id
                                WHERE Province = @ProvinceName";

                return db.Query<Town>(sql, new { ProvinceName = province });
            }
        }


        public IEnumerable<Barangay> GetBarangays(string province, string town)
        {
            using (var db = Database.Connection.CreateConnection())
            {
                db.Open();
                var sql = @"Select Id, Province, Town, Barangay as Name from Location_Barangays b
                                WHERE Province = @Province and Town = @Town";

                return db.Query<Barangay>(sql, new { Province = province, Town = town });
            }
        }
    }
}
