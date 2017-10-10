using AiTech.LiteOrm.Database;
using Dapper;
using System;
using System.Collections.Generic;

namespace Winform.SMS
{
    internal class Sms
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public string ContactNumber { get; set; }
        public DateTime Sent { get; set; }


        public static IEnumerable<Sms> GetPendingItems()
        {
            var query = "Select * from Sms where Sent <= '19200101'";

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                return db.Query<Sms>(query);
            }
        }


        public bool MarkAsSent()
        {
            var query = "Update Sms set sent = getdate() where Id = @SmsId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var ret = db.Execute(query, new { SmsId = Id });
                return ret != 0;
            }
        }



        public static List<string> Parser(string message)
        {
            var list = new List<string>();

            var words = message.Split(' ');

            var sentence = "";
            foreach (var item in words)
            {
                if ((sentence + item).Length < 120)
                {
                    sentence += " " + item;
                }
                else
                {
                    list.Add(sentence);
                    sentence = item;
                }
            }

            list.Add(sentence);
            return list;
        }
    }
}
