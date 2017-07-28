using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Dynamic;
using AiTech.Entities;
using System.Data;


namespace AiTech.Database
{
    public class DatabaseAction
    {

        public static bool ExecuteDeleteQuery<T>(string encoder, IEnumerable<T> items, SqlConnection db, SqlTransaction trn = null) where T : Entity
        {
            CheckDbConnection(db);
            var tableName = items.First().TableName;
            var primaryKey = items.First().PrimaryKey;

            var sql = $" Delete from [{tableName}] where {primaryKey} in @Ids";
            return db.Execute(sql, new { Ids = items.Select(_ => _.Id).ToArray() }, trn) != 0;
        }

        //[Obsolete]
        //public static bool ExecuteDeleteQuery<T>(string encoder, T item, SqlConnection db, SqlTransaction trn = null) where T : Entity
        //{
        //    CheckDbConnection(db);

        //    var sql = $" Delete from [{item.TableName}] where {item.PrimaryKey} = @Id";
        //    return db.Execute(sql, item, trn) != 0;
        //}


        //public static bool ExecuteUpdateQuery<T>(string encoder, string errorKeyDescription, T item, SqlConnection db, SqlTransaction trn = null) where T : Entity
        //{
        //    CheckDbConnection(db);

        //    try
        //    {
        //        var query = new SqlUpdateQueryBuilder(item);
        //        var sql = query.GetQueryString();

        //        if (!String.IsNullOrEmpty(sql))
        //        {
        //            item.ModifiedBy = encoder;
        //            dynamic reader = db.Query<dynamic>(sql, item, trn).FirstOrDefault();

        //            if (reader == null) throw new Exception("Record NOT saved\n\nError On Item : " + errorKeyDescription);

        //            //item.Id = reader.Id;
        //            //item.Created = reader.Created;
        //            //item.CreatedBy = reader.CreatedBy;
        //            item.Modified = reader.Modified;
        //            item.ModifiedBy = reader.ModifiedBy;
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (ex.Message.Contains("duplicate"))
        //            throw new Exception("Duplicate Record Error!");
        //        throw;
        //    }
        //}


        //public static bool ExecuteInsertCommand<T>(T item,string errorDescription, SqlCommand cmd) where T: Entity
        //{
        //    try
        //    {
        //        using (cmd)
        //        {
        //            using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
        //            {
        //                UpdateItemRecordInfo(item, reader);
        //                return reader.HasRows;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Error Saving " + errorDescription, ex);
        //    }
        //}


        internal static bool ExecuteCommand<T>(SqlCommand cmd, T item, string errorDescription) where T: Entity
        {
            CheckDbConnection(cmd.Connection);

            try
            {
                if (cmd.CommandText.Length == 0) return false;
                using (cmd)
                {
                    CleanParameters(cmd);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        UpdateItemRecordInfo(item, reader);
                        return reader.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error Saving " + errorDescription, ex);
            }
        }


        protected static void CleanParameters(SqlCommand cmd)
        {
            var query = cmd.CommandText;

            if (string.IsNullOrEmpty(query)) return;

            for (var i = 0; i < cmd.Parameters.Count; i++)
            {
                var param = cmd.Parameters[i];

                if (!query.Contains(param.ParameterName))
                    cmd.Parameters.Remove(param);
            }
        }


        public static void CheckDbConnection(SqlConnection db)
        {
            if (db == null) throw new Exception("DbConnection NOT Set. Use SetDbConnection Property");
        }

        internal static void UpdateItemRecordInfo(Entity item, SqlDataReader reader)
        {
            if (!reader.Read()) return; //throw new Exception("Error Inserting New Item");

            var col = -1;

            if (reader.HasField("Id", out col))
                item.Id = reader.GetInt32(col);

            if (reader.HasField("Created", out col))
                item.Created = reader.GetDateTime(col);

            if (reader.HasField("CreatedBy", out col))
                item.CreatedBy = reader[col].ToString();

            if (reader.HasField("Modified", out col))
                item.Modified = reader.GetDateTime(col);

            if (reader.HasField("ModifiedBy", out col))
                item.ModifiedBy = reader[col].ToString();
        }

       
    }


    public static class DatabaseExtension
    {
        public static bool HasField(this SqlDataReader reader, string name, out int col)
        {
            try
            {
                col = reader.GetOrdinal(name);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                col = -1;
                return false;
            }
        }
    }
}
