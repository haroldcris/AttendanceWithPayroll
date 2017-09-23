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
            new SqlParameter( "@PersonId", SqlDbType.Int) ,            new SqlParameter( "@StudentNumber", SqlDbType.Int)
            });

            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@StudentNumber"].Value = item.StudentNumber;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Student] ([PersonId],[StudentNumber]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PersonId,@StudentNumber)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.StudentNumber.ToString());
        }


    }
}
