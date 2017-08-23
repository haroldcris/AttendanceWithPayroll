using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class EmployeeDataWriter : SqlMainDataWriter<Employee, EmployeeCollection>
    {
        public EmployeeDataWriter(string username, Employee item) : base(username, item) { }
        public EmployeeDataWriter(string username, EmployeeCollection items) : base(username, items) { }


        public override bool SaveChanges()
        {
            return Write(_ => _.PersonInfo.Name.FullnameWithLastnameFirst);
        }



        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Employee item)
        {
            cmd.Parameters.AddRange(new[]
                   {

                    new SqlParameter( "@PersonId", SqlDbType.Int) ,
                    new SqlParameter( "@CurrentPosition", SqlDbType.NVarChar, 50) ,
                    new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                    new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

                    });

            cmd.Parameters["@PersonId"].Value = item.PersonInfo.Id;
            cmd.Parameters["@CurrentPosition"].Value = item.CurrentPosition;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Employee] ([PersonId],[CurrentPosition],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PersonId,@CurrentPosition,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }

    }
}
