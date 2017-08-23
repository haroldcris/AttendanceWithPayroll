using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.SchoolYear
{
    public class CourseDataWriter : SqlMainDataWriter<Course, CourseCollection>
    {
        public CourseDataWriter(string username, Course item) : base(username, item) { }
        public CourseDataWriter(string username, CourseCollection items) : base(username, items) { }

        public override bool SaveChanges()
        {
            return Write(_ => _.CourseCode);

        }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Course item)
        {
            cmd.Parameters.AddRange(new[]
              {

                new SqlParameter( "@CourseCode", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

              });



            cmd.Parameters["@CourseCode"].Value = item.CourseCode;
            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Course] ([CourseCode],[Description],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@CourseCode,@Description,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }


    }
}
