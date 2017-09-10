using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll
{
    public sealed class Settings
    {
        public int Id { get; set; }

        public string SettingName { get; set; }
        public string DisplayName { get; set; }
        public string Category { get; set; }

        public string Value { get; set; }



        public static string Get(string settingName, string defaultIfNull = null)
        {

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query(@"Select * from Setting where SettingName = @SettingName",
                                        new { SettingName = settingName }).FirstOrDefault();


                return result == null ? defaultIfNull : result.Oprn;
            }
        }



        public static string Set(string settingName, string value)
        {

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query(@"UPDATE [Setting] SET [Value] = @Value where SettingName = @Setting",
                    new { Setting = settingName, Value = value }).FirstOrDefault();

                return result != 0;
            }
        }
    }
}
