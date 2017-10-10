using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;


namespace Dll.Student
{
    public class StudentDataWriter : SqlMainDataWriter<Student, StudentCollection>
    {

        public StudentDataWriter(string username, Student item) : base(username, item) { }
        public StudentDataWriter(string username, StudentCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Student item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@PersonId", SqlDbType.Int) ,
                new SqlParameter( "@SectionId", SqlDbType.Int) ,
                new SqlParameter( "@StudentNumber", SqlDbType.Int) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@SectionId"].Value = item.SectionId;
            cmd.Parameters["@StudentNumber"].Value = item.StudentNumber;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Student] ([PersonId],[SectionId],[StudentNumber],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PersonId,@SectionId,@StudentNumber,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.StudentNumber.ToString());
        }


    }
}
