using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.Payroll
{
    [Table("Employee")]
    public class Employee : Entity
    {
        public Contacts.Person PersonInfo { get; set; }

        public string CurrentPosition { get; set; }

        public Employee()
        {
            PersonInfo = new Contacts.Person();

            // StartTrackingChanges();
        }



        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("CurrentPosition", CurrentPosition);


            //Sub Objects
            PersonInfo.StartTrackingChanges();
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(CurrentPosition, OriginalValues["CurrentPosition"])) changes.Add("CurrentPosition", CurrentPosition);


            // Name SubObject
            //var changesInPerson = this.PersonInfo.GetChangedValues();
            //foreach (var changedItem in changesInPerson)
            //    changes.Add(changedItem.Key, changedItem.Value);

            if (changes.Count > 0 && RowStatus != RecordStatus.NewRecord) RowStatus = RecordStatus.ModifiedRecord;
            return changes;
        }

    }
}
