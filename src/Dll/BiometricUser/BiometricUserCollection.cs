using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Biometric
{
    public class BiometricUserCollection : EntityCollection<BiometricUser>
    {
        public void LoadItemsFromDb()
        {
            const string query = @"select u.*
                                    , p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], BirthDate, [Gender], [CameraCounter]
                                    from Biometric_User u
                                    inner join person p on u.PersonId = p.Id";

            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                dynamic records = db.Query(query);

                foreach (var record in records)
                {
                    var item = new BiometricUser();

                    item.Map(record);

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
