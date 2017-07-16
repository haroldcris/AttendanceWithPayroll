using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AiTech.Entities;
using System.Data.SqlClient;
using System.Data;

namespace AiTech.Database
{
    public abstract class SqlMainDataWriter<T, TCol> 
        where T : Entity
        where TCol: EntityCollection<T>, new()
    {
        protected TCol _List;
        protected string DataWriterUsername;

        public SqlMainDataWriter(string username, T item)
        {
            DataWriterUsername = username;
            _List = new TCol();
            _List.Attach(item);
        }

        public SqlMainDataWriter(string username, IEnumerable<T> items)
        {
            DataWriterUsername = username;
            _List.AttachRange(items);
        }


        public abstract bool SaveChanges();
        protected abstract void CommitChanges();
        protected abstract void RollbackChanges();

        protected abstract string CreateSqlInsertQuery();
        protected abstract void CreateSqlInsertCommandParameters(SqlCommand cmd, T item);



        protected string CreateSqlUpdateQuery(T item)
        {
            var builder = new SqlUpdateQueryBuilder(item);
            return builder.GetQueryString();
        }

        protected virtual void CreateSqlUpdateCommandParameters(SqlCommand cmd, T item)
        {
            CreateSqlInsertCommandParameters(cmd, item);
            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            cmd.Parameters["@Id"].Value = item.Id;
        }

        protected bool ExecuteCommand(SqlCommand cmd, T item, string errorDescription )
        {
            return DatabaseAction.ExecuteCommand<T>(cmd, item, errorDescription);
        }

    }
}
