using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.SchoolYear
{
    public class OfferedCourseDataWriter : SqlMainDataWriter<OfferedCourse, OfferedCourseCollection>
    {

        public OfferedCourseDataWriter(string username, OfferedCourse item) : base(username, item) { }
        public OfferedCourseDataWriter(string username, OfferedCourseCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, OfferedCourse item)
        {
            cmd.Parameters.AddRange(new[]
            {
            new SqlParameter( "@BatchId", SqlDbType.Int) ,            new SqlParameter( "@CourseId", SqlDbType.Int) ,            new SqlParameter( "@YearLevel", SqlDbType.TinyInt) ,            new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,            new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@BatchId"].Value = item.BatchId;
            cmd.Parameters["@CourseId"].Value = item.CourseId;
            cmd.Parameters["@YearLevel"].Value = item.YearLevel;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Student_OfferedCourse] ([BatchId],[CourseId],[YearLevel],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@BatchId,@CourseId,@YearLevel,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => "BatchId : " + _.BatchId.ToString());
        }


    }
}
