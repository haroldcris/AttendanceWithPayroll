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
    public abstract class SqlMainDataWriter<T, TCol> :DataWriter<T, TCol>
        where T : Entity
        where TCol: EntityCollection<T>, new()
    {
        public SqlMainDataWriter(string username, T item) : base(username, item) { }
        public SqlMainDataWriter(string username, TCol items) : base(username, items.Items) { }


        public abstract bool SaveChanges();
        protected abstract void CommitChanges();
        protected abstract void RollbackChanges();

    }
}
