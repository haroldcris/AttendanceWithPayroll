using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.SchoolYear
{
    public class SubjectDataWriter : SqlMainDataWriter<Subject, SubjectCollection>
    {

        public SubjectDataWriter(string username, Subject item) : base(username, item) { }
        public SubjectDataWriter(string username, SubjectCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Subject item)
        {
            cmd.Parameters.AddRange(new[]
            {
            new SqlParameter( "@SubjectCode", SqlDbType.NVarChar, 20) ,            new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,            new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,            new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@SubjectCode"].Value = item.SubjectCode;
            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Student_Subject] ([SubjectCode],[Description],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@SubjectCode,@Description,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.Description);
        }


    }
}
