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
    public abstract class DataWriter<T, TCol>
        where T : Entity
        where TCol : EntityCollection<T>, new()
    {
        protected TCol _List;
        protected string DataWriterUsername;

        public DataWriter(string username, T item)
        {
            DataWriterUsername = username;
            _List = new TCol();
            _List.Attach(item);
        }

        public DataWriter(string username, IEnumerable<T> items)
        {
            DataWriterUsername = username;
            _List = new TCol();
            _List.AttachRange(items);
        }


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

        protected bool ExecuteCommand(SqlCommand cmd, T item, string errorDescription)
        {
            return DatabaseAction.ExecuteCommand<T>(cmd, item, errorDescription);
        }

        protected void UpdateItemRecordInfo(T item, SqlDataReader reader)
        {
            if (!reader.Read()) throw new Exception("Error Inserting New Item");

            item.Id = reader.GetInt32(reader.GetOrdinal("Id"));

            item.Created = reader.GetDateTime(reader.GetOrdinal("Created"));
            item.CreatedBy = reader["CreatedBy"].ToString();
            item.Modified = reader.GetDateTime(reader.GetOrdinal("Modified"));
            item.ModifiedBy = reader["ModifiedBy"].ToString();
        }




    }
}
