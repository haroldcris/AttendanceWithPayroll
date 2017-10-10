using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.SchoolYear
{
    public class OfferedClassDataWriter : SqlMainDataWriter<OfferedClass, OfferedClassCollection>
    {

        public OfferedClassDataWriter(string username, OfferedClass item) : base(username, item) { }
        public OfferedClassDataWriter(string username, OfferedClassCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, OfferedClass item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@SubjectId", SqlDbType.Int) ,
                new SqlParameter( "@SectionId", SqlDbType.Int) ,
                new SqlParameter( "@TeacherId", SqlDbType.Int) ,
                new SqlParameter( "@Mon", SqlDbType.Time) ,
                new SqlParameter( "@Tue", SqlDbType.Time) ,
                new SqlParameter( "@Wed", SqlDbType.Time) ,
                new SqlParameter( "@Thu", SqlDbType.Time) ,
                new SqlParameter( "@Fri", SqlDbType.Time) ,
                new SqlParameter( "@Sat", SqlDbType.Time) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@SubjectId"].Value = item.SubjectId;
            cmd.Parameters["@SectionId"].Value = item.SectionId;
            cmd.Parameters["@TeacherId"].Value = item.TeacherId;
            cmd.Parameters["@Mon"].Value = item.Mon.ToTimeSpan();
            cmd.Parameters["@Tue"].Value = item.Tue.ToTimeSpan();
            cmd.Parameters["@Wed"].Value = item.Wed.ToTimeSpan();
            cmd.Parameters["@Thu"].Value = item.Thu.ToTimeSpan();
            cmd.Parameters["@Fri"].Value = item.Fri.ToTimeSpan();
            cmd.Parameters["@Sat"].Value = item.Sat.ToTimeSpan();
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Student_OfferedClass] ([SubjectId],[SectionId],[TeacherId],[Mon],[Tue],[Wed],[Thu],[Fri],[Sat],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@SubjectId,@SectionId,@TeacherId,@Mon,@Tue,@Wed,@Thu,@Fri,@Sat,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.Id.ToString());
        }


    }
}
