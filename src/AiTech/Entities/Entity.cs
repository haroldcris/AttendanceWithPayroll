using System;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;

namespace AiTech.Entities
{

    #region Entity Definition
    public abstract class Entity : IRecordInfo, ITrackableObject
    {
        public int Id { get; set; }

        [Write(false)]
        public string RowId { get; set; }

        [Write(false)]
        public RecordStatus RowStatus { get; set; }

        [Write(false)]
        protected internal bool IsNewRecord { get; set; }


        #region Record Info Fields

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        [Write(false)]
        public DateTime Created { get; set; }

        [Write(false)]
        public DateTime Modified { get; set; }

        #endregion

        public Entity()
        {
            RowId = Guid.NewGuid().ToString();

            RowStatus = RecordStatus.NoChanges;

            //Changes = new Dictionary<string, object>();

            TableName = GetTableName();
            PrimaryKey = GetPrimaryKey();

            Created = new DateTime(1920, 1, 1);
            Modified = new DateTime(1920, 1, 1);

            OriginalValues = new Dictionary<string, object>();
        }


        protected internal string TableName;
        /// <summary>
        /// Get The Table Name from Entity
        /// </summary>
        /// <returns></returns>
        private string GetTableName()
        {
            var tableNameAttribute = this.GetType().GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            if (tableNameAttribute == null)
                return this.GetType().Name;

            return tableNameAttribute.Name;
        }

        protected internal string PrimaryKey;
        private string GetPrimaryKey()
        {
            var keyAttribute = this.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).FirstOrDefault();
            if (keyAttribute == null)
                return "Id";

            return keyAttribute.Name;
        }



        public Dictionary<string, object> OriginalValues { get; protected set; }
        public abstract void StartTrackingChanges();
        public abstract Dictionary<string, object> GetChangedValues();

    }

    #endregion


    #region Collection Definition
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntityName">Name of the Entity inside Collection</typeparam>
    [Serializable]
    public abstract class EntityCollection<TEntityName> where TEntityName : Entity
    {
        protected internal ICollection<TEntityName> ItemCollection;

        public IEnumerable<TEntityName> Items { get; set; }

        public EntityCollection()
        {
            ItemCollection = new List<TEntityName>();
            Items = ItemCollection.AsEnumerable(); //.Where(o => o.RowStatus != RecordStatus.DeletedRecord);
        }


        public virtual void Add(TEntityName item)
        {
            var itemFound = ItemCollection.FirstOrDefault(x => x.RowId == item.RowId);
            if (itemFound != null) throw new Exception("Record Already Exists");

            item.RowStatus = RecordStatus.NewRecord;
            ItemCollection.Add(item);
        }

        public virtual void AddRange(IEnumerable<TEntityName> items)
        {
            foreach (var item in items)
                Add(item);
        }

        public virtual void Attach(TEntityName item)
        {
            ItemCollection.Add(item);
        }

        public virtual void AttachRange(IEnumerable<TEntityName> items)
        {
            foreach (var item in items)
                Attach(item);
        }

        public virtual void Remove(TEntityName item)
        {
            //Check if it has an Id. If it has it means, it is from DB.
            if (item.Id == 0)
            {
                ItemCollection.Remove(item);
                return;
            }

            //Find the User
            var foundItem = ItemCollection.FirstOrDefault(o => o.Id == item.Id || o.RowId == item.RowId);
            if (foundItem == null) throw new Exception("Record Not Found");

            foundItem.RowStatus = RecordStatus.DeletedRecord;
        }

        public virtual void RemoveAll()
        {
            for (var i = ItemCollection.Count - 1; i >= 0; i--)
            {
                var item = ItemCollection.ElementAt(i);
                if (item.Id == 0)
                {
                    ItemCollection.Remove(item);
                    continue;
                }

                item.RowStatus = RecordStatus.DeletedRecord;
            }

        }

        public virtual void Remove(int index)
        {
            var item = ItemCollection.ElementAt(index);
            if (item == null) return;
            Remove(item);
        }

        [Obsolete("No longer used")]
        internal IEnumerable<TEntityName> GetItemsWithStatus(RecordStatus status)
        {
            return ItemCollection.Where(r => r.RowStatus == status);
        }


        public void CommitChanges()
        {
            var deletedItems = ItemCollection.Where(o => o.RowStatus == RecordStatus.DeletedRecord).ToList();
            foreach (var item in deletedItems)
                ItemCollection.Remove(item);

            foreach (var item in ItemCollection)
            {
                item.RowStatus = RecordStatus.NoChanges;
                item.StartTrackingChanges();
            }  
        }

        public void RollBackChanges()
        {
            foreach (var item in ItemCollection)
            {
                if (item.RowStatus == RecordStatus.NewRecord) item.Id = 0;
            }
        }


        /// <summary>
        /// Call this Method right after LoadItemsFromDb to Transfer data to ItemCollection
        /// </summary>
        /// <param name="items"></param>
        protected internal void LoadItems(IEnumerable<TEntityName> items)
        {
            ItemCollection.Clear();
            foreach (var item in items)
            {
                item.RowStatus = RecordStatus.NoChanges;
                item.StartTrackingChanges();
                ItemCollection.Add(item);
            }
        }

        /// <summary>
        /// Switch to check if previously loaded from Database
        /// </summary>
        public bool HasReadFromDb { get; protected set; }

        public IEnumerable<TEntityName> GetDirtyItems()
        {
            return ItemCollection.Where(r => r.RowStatus != RecordStatus.NoChanges);
        }

        /// <summary>
        /// Set this one to FALSE to if you want to fetch from db
        /// </summary>
        //public bool ReadFromCache { get; set; }

        //public void CopyTo<TCollection>(TCollection destination) where TCollection : EntityCollection<TEntityName>
        //{
        //    destination.ItemCollection.Clear();
        //    foreach (var item in this.ItemCollection)
        //    {
        //        TEntityName newItem = (TEntityName)Activator.CreateInstance(typeof(TEntityName));
        //        item.CopyTo<TEntityName>(ref newItem);
        //        destination.ItemCollection.Add(newItem);
        //    }
        //}

    }


    [Serializable]
    public abstract class EntityChildCollection <TEntityName, TParent> : EntityCollection<TEntityName>
        where TEntityName : Entity
    {
        public TParent Parent { get; private set; }

        public void SetParentTo(TParent parent)
        {
            Parent = parent;
        }

    }
    #endregion


    #region Interfaces

    public interface IRecordInfo
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }


    public interface IRecordStatus
    {
        RecordStatus RecordStatus { get; set; }
    }


    public interface ITransaction
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }


    public interface ITrackableObject
    {
        Dictionary<string, object> OriginalValues { get; }
        void StartTrackingChanges();
        Dictionary<string, object> GetChangedValues();
    }


    public enum RecordStatus
    {
        NoChanges = 0,
        DeletedRecord = 1,
        ModifiedRecord = 2,
        NewRecord = 3
    }


    #endregion

}

