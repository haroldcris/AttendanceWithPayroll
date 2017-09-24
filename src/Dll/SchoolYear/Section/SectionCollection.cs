using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System.Linq;

namespace Dll.SchoolYear
{
    public class SectionCollection : EntityCollection<Section>
    {

        private OfferedCourse _parentOfferedCourse;

        public SectionCollection()
        {
            //
        }

        public SectionCollection(OfferedCourse parent)
        {
            _parentOfferedCourse = parent;
        }


        public bool LoadItemsFromDb()
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var items = db.Query<Section>(@"Select * from Student_Section where OfferedCourseId = @id", new { Id = _parentOfferedCourse.Id }).OrderBy(o => o.SectionName);

                LoadItemsWith(items);
            }
            return true;
        }



        public string GetNewSectionName()
        {
            var counter = 1;
            var section = "Section " + counter.ToString();

            while (ItemCollection.Any(_ => _.SectionName == section))
            {
                counter++;
                section = "Section " + counter.ToString();
                
            }

            return section;
        }
    }
}
