using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Employee
{
    public class EmployeeCollection : EntityCollection<Employee>
    {

        public void LoadItemsFromDb()
        {
            const string query = @"select e.*
                                    , p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [SpouseLastname], [Gender], [CameraCounter]
                                    from employee e
                                    inner join person p on e.PersonId = p.Id";

            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                dynamic records = db.Query(query);

                foreach (var record in records)
                {
                    var item = new Employee();

                    item.DataMapper.Map(record);

                    item.PersonClass.DataMapper.Map(record);
                    item.PersonClass.DataMapper.Map(_ => _.Id, (int)record.PersonId);


                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }
        }


    }
}
