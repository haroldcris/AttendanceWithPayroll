using AiTech.LiteOrm.Database;
using Dapper;
using System.Collections.Generic;

namespace Dll
{
    public sealed class ActionLog
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public string Username { get; set; }



        public static void Log(string module, string action, string username)
        {
            const string query = "INSERT INTO ActionLog ([module],[action],[username]) values (@Module, @Action, @Username)";

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                db.Query(query, new { Module = module, Action = action, Username = username });
            }
        }


        public static IEnumerable<ActionLog> GetAllLogs()
        {
            const string query = "SELECT * from ActionLog";

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                return db.Query<ActionLog>(query);
            }
        }

    }
}
