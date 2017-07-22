using AiTech.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Contacts
{
    public class PersonCollection: AiTech.Entities.EntityCollection<Person>
    {
        public void LoadItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                dynamic records = db.Query<dynamic>("Select * from Person");

                this.ItemCollection.Clear();
                foreach(var record in records)
                {
                    var item = new Person();

                    item.Id = record.Id;

                    item.Name.Lastname = record.Lastname;
                    item.Name.Firstname = record.Firstname;
                    item.Name.Middlename = record.MiddleName;
                    item.Name.MiddleInitial = record.MiddleInitial;
                    item.Name.NameExtension = record.NameExtension;

                    item.Gender = record.Gender == "Male" ? Enums.GenderType.Male : Enums.GenderType.Female;
                    item.BirthDate = record.BirthDate;

                    //item.CameraCounter = record.CameraCounter;

                    item.Address.Street = record.Street;
                    item.Address.Barangay = record.Barangay;
                    item.Address.Town = record.Town;
                    item.Address.Province = record.Province;

                    item.Created = record.Created;
                    item.Modified = record.Modified;
                    item.CreatedBy = record.CreatedBy;
                    item.ModifiedBy = record.ModifiedBy;


                    item.RowStatus = AiTech.Entities.RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    this.ItemCollection.Add(item);
                }
            }
        }
    }
}
