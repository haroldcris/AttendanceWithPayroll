using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

namespace Dll.SchoolYear
{
    public class OfferedClassCollection : EntityCollection<OfferedClass>
    {

        public void LoadAllItemsFromDb()
        {
            const string query = @"select c.*
                                    , SubjectCode, Description
                                    , sec.SectionName
                                    , sec.OfferedCourseId
                                    , e.EmpNum
                                    , e.PersonId, Lastname, Firstname, MiddleName, MiddleInitial, MaidenMiddlename, Gender, CameraCounter

                                    from Student_OfferedClass	c
                                    inner join Student_Subject s on c.SubjectId = s.Id
                                    inner join Student_Section sec on c.SectionId = sec.Id
                                    inner join Employee e on e.Id = c.TeacherId
                                    inner join Person p on p.Id = e.PersonId;";


            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query(query);

                foreach (var result in results)
                {
                    var item = new OfferedClass();


                    item.MapFull(result);

                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();

                    ItemCollection.Add(item);
                }

            }
        }
    }
}
