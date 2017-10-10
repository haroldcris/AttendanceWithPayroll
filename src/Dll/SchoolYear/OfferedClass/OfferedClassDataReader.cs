using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class OfferedClassDataReader
    {
        public OfferedClass GetItemOf(int id)
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
                                    inner join Person p on p.Id = e.PersonId
                                    where c.Id = @Id";


            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query(query, new { Id = id });

                if (result == null) return null;

                var item = new OfferedClass();

                item.MapFull(result);

                item.RowStatus = RecordStatus.NoChanges;
                item.StartTrackingChanges();

                return item;
            }
        }


        public bool HasExisting(int subjectId, int sectionId, int id)
        {
            const string query = "SELECT 1 from Student_OfferedClass where SubjectId = @SubjectId and SectionId = @SectionId and Id <> @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { SubjectId = subjectId, SectionId = sectionId, Id = id });

                return result.Any();
            }
        }
    }
}
