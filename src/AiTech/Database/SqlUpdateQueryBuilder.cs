using System.Linq;
using System.Text;
using AiTech.Entities;
using System.Collections.Generic;
using System;

namespace AiTech.Database
{
    public class SqlUpdateQueryBuilder
    {
        private Entity _Entity;
        public SqlUpdateQueryBuilder(Entity entity)
        {
            _Entity = entity;
        }

        public string GetQueryString()
        {
            var query = new StringBuilder();
            var changes = _Entity.GetChangedValues();

            Console.WriteLine("Getting changes");
            Console.WriteLine(changes.Count);
            if (changes.Count() != 0)
            {
                query.AppendLine(@"DECLARE @output table ( Modified DateTime, ModifiedBy nvarchar(20)); ");

                query.AppendLine("UPDATE [" + _Entity.TableName + "] SET ");

                ICollection<string> dirtyFields = new List<string>();
                foreach (var i in changes)
                    dirtyFields.Add(i.Key + " = @" + i.Key);
                  

                query.AppendLine( string.Join(",", dirtyFields.ToArray()));

                //Add the modified
                query.AppendLine(" , Modified = GetDate(), ");
                query.AppendLine(" ModifiedBy = @ModifiedBy ");
                query.AppendLine(" OUTPUT inserted.Modified, inserted.ModifiedBy into @output ");
                query.AppendLine($" WHERE {_Entity.PrimaryKey} = @Id");

                query.AppendLine($" Select * from @output ");
            }

            return query.ToString();
        }
    }
}
