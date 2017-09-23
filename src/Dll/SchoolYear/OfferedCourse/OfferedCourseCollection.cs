using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class OfferedCourseCollection : EntityCollection<OfferedCourse>
    {

        private Batch _parentBatch;

        public OfferedCourseCollection()
        {

        }

        public OfferedCourseCollection(Batch parent)
        {
            _parentBatch = parent;
        }


        public bool LoadItems()
        {
            ItemCollection.Clear();


            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var items = db.Query<OfferedCourse>(@"Select * from Student_OfferedCourse where BatchId = @BatchId", new { BatchId = _parentBatch.Id });

                if (items == null) return true;

                foreach (var item in items)
                {
                    var multiple = db.QueryMultiple(@"Select * from Student_Batch where Id = @BatchId
                                                    Select * from Student_Course where Id = @CourseId",
                                                        new { BatchId = item.BatchId, CourseId = item.CourseId });

                    item.BatchClass = multiple.Read<Batch>().Single();
                    item.CourseClass = multiple.Read<Course>().Single();

                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }
            return true;
        }
    }
}
