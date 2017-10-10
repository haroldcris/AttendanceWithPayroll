using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.Student
{
    public class StudentCollection : EntityCollection<Student>
    {

        public void LoadAllItemsFromDb()
        {
            const string query = @"select s.* 
                                    , p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], BirthDate, [Gender], [CameraCounter]
                                    , BirthCountry, BirthProvince, BirthTown
                                    , OfferedCourseId
                                    , SectionName
                                    from student s
                                    inner join person p on s.PersonId = p.Id 
                                    left join Student_Section sec on sec.Id = s.SectionId";

            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                dynamic records = db.Query(query);

                foreach (var record in records)
                {
                    var item = new Student();

                    item.Map(record);

                    //Person
                    item.PersonClass.DataMapper.Map(record);
                    item.PersonClass.DataMapper.Map(_ => _.Id, (int)record.PersonId);

                    //Section
                    item.SectionClass.Map(record);
                    item.SectionClass.Id = record.SectionId;


                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }
        }


    }
}
