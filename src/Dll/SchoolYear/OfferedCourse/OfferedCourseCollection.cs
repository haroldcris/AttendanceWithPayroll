using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;

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

            var query = @"select oc.*
                            , BatchName, Semester 
                            , CourseCode, Description 

                        from Student_OfferedCourse oc 
                            inner join Student_Course c on oc.CourseId = c.Id 
                            inner join Student_Batch b on oc.BatchId = b.Id
                        where oc.BatchId = @BatchId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query(query, new { BatchId = _parentBatch.Id });

                if (results == null) return true;

                foreach (var result in results)
                {
                    var item = new OfferedCourse();

                    item.Map(result);

                    //Batch
                    item.BatchClass.Id = result.BatchId;
                    item.BatchClass.BatchName = result.BatchName;
                    item.BatchClass.Semester = result.Semester;

                    //Course
                    item.CourseClass.Id = result.CourseId;
                    item.CourseClass.CourseCode = result.CourseCode;
                    item.CourseClass.Description = result.Description;


                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();
                    ItemCollection.Add(item);
                }
            }
            return true;
        }
    }
}
