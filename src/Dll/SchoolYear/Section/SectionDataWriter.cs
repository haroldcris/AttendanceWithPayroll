using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.SchoolYear
{
    public class SectionDataWriter : SqlMainDataWriter<Section, SectionCollection>
    {

        public SectionDataWriter(string username, Section item) : base(username, item) { }
        public SectionDataWriter(string username, SectionCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Section item)
        {
            cmd.Parameters.AddRange(new[]
            {
            new SqlParameter( "@OfferedCourseId", SqlDbType.Int) ,            new SqlParameter( "@SectionName", SqlDbType.NVarChar, 20) ,            new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,            new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@OfferedCourseId"].Value = item.OfferedCourseId;
            cmd.Parameters["@SectionName"].Value = item.SectionName;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Student_Section] ([OfferedCourseId],[SectionName],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@OfferedCourseId,@SectionName,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.SectionName);
        }


    }
}
