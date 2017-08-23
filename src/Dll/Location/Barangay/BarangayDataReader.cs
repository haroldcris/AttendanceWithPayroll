using AiTech.LiteOrm.Database;
using Dapper;
using System.Collections.Generic;

namespace Dll.Location
{
    public class BarangayDataReader
    {
        public IEnumerable<Barangay> GetBarangaysOf(string town, string province)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var sql = @"Select Id, Province, Town, Barangay as Name from Location_Barangay b
                                WHERE Province = @Province and Town = @Town Order By Barangay";

                return db.Query<Barangay>(sql, new { Province = province, Town = town });
            }
        }
    }
}
