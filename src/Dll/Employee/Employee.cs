using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Dll.Employee
{
    [Table("Employee")]
    public class Employee : AiTech.Entities.Entity
    {
        public Contacts.Person PersonInfo { get; set; }

        public string CurrentPosition { get; set; }

        public Employee()
        {
            PersonInfo = new Contacts.Person();

            StartTrackingChanges();
        }



        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("CurrentPosition", this.CurrentPosition);


            //Sub Objects
            this.PersonInfo.StartTrackingChanges();
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(CurrentPosition, OriginalValues["CurrentPosition"])) changes.Add("CurrentPosition", this.CurrentPosition);


            // Name SubObject
            //var changesInPerson = this.PersonInfo.GetChangedValues();
            //foreach (var changedItem in changesInPerson)
            //    changes.Add(changedItem.Key, changedItem.Value);

            if (changes.Count > 0 && RowStatus != AiTech.Entities.RecordStatus.NewRecord) RowStatus = AiTech.Entities.RecordStatus.ModifiedRecord;
            return changes;
        }

    }
}
