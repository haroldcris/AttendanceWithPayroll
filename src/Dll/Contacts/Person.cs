using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiTech;
using Dapper.Contrib.Extensions;

namespace Dll.Contacts
{
    [Table("Person")]
    public partial class Person: AiTech.Entities.Entity
    {
        public PersonName Name { get; set; }

        public Enums.GenderType Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public Location.Location Address { get; set; }


        public Person()
        {
            Name = new PersonName();
            Address = new Location.Location();


            BirthDate = new DateTime(1920, 1, 1);

            StartTrackingChanges();
        }


        /// <summary>
        /// Starts Tracking Field Values
        /// </summary>
        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>();

            OriginalValues.Add("Gender", this.Gender);
            OriginalValues.Add("BirthDate", this.BirthDate);


            //Objects
            this.Name.StartTrackingChanges();
            this.Address.StartTrackingChanges();
        }

        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!this.Gender.Equals(OriginalValues["Gender"])) changes.Add("Gender", this.Gender);
            if (!this.BirthDate.Equals(OriginalValues["BirthDate"])) changes.Add("BirthDate", this.BirthDate);


            // Name Object
            var changesInName = this.Name.GetChangedValues();
            foreach (var changedItem in changesInName)
                changes.Add(changedItem.Key, changedItem.Value);

            // Address Object
            var changesInAddress = this.Address.GetChangedValues();
            foreach (var changedItem in changesInAddress)
                changes.Add(changedItem.Key, changedItem.Value);


            if (changes.Count > 0 && RowStatus != AiTech.Entities.RecordStatus.NewRecord) RowStatus = AiTech.Entities.RecordStatus.ModifiedRecord;
            return changes;
        }
    }
}
