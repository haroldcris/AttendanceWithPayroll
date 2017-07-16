using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AiTech.Entities;
using System.Data.SqlClient;

namespace AiTech.Database
{
    public abstract class SqlDataWriter <T> where T: Entities.Entity
    {
        protected EntityCollection<T> _List;
        protected string DataWriterUsername;

        public SqlDataWriter(string username, T item)
        {
            DataWriterUsername = username;
            if (_List == null) throw new ArgumentNullException();

            _List.Attach(item);
        }

        public SqlDataWriter(string username , IEnumerable<T> items )
        {
            DataWriterUsername = username;
            _List.AttachRange(items);
        }

        public virtual bool SaveChanges()
        {
            return SaveChanges(null, null);
        }

        public abstract bool SaveChanges(SqlConnection db, SqlTransaction trn);

        protected abstract void CommitChanges();
        protected abstract void RollbackChanges();

    }
}
