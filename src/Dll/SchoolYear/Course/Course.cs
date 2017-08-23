using AiTech.LiteOrm;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Dll.SchoolYear
{

    [Table("Course")]
    public partial class Course : Entity
    {

        #region Default Properties

        public string CourseCode { get; set; }

        public string Description { get; set; }



        #endregion


        public override void StartTrackingChanges()
        {
            OriginalValues = new Dictionary<string, object>
            {
                {"CourseCode", CourseCode},
                { "Description", Description}
            };



        }


        public override Dictionary<string, object> GetChangedValues()
        {
            var changes = new Dictionary<string, object>();

            if (!Equals(CourseCode, OriginalValues["CourseCode"])) changes.Add("CourseCode", CourseCode);
            if (!Equals(Description, OriginalValues["Description"])) changes.Add("Description", Description);

            return changes;
        }
    }
}
