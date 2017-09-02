using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Employee
{
    public class EmployeeDataWriter : SqlMainDataWriter<Employee, EmployeeCollection>
    {

        public EmployeeDataWriter(string username, Employee item) : base(username, item) { }
        public EmployeeDataWriter(string username, EmployeeCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Employee item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@PersonId", SqlDbType.Int) ,
                new SqlParameter( "@EmpNum", SqlDbType.Int) ,
                new SqlParameter( "@CivilStatus", SqlDbType.NVarChar, 10) ,
                new SqlParameter( "@Height", SqlDbType.Decimal) ,
                new SqlParameter( "@Weight", SqlDbType.Decimal) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@EmpNum"].Value = item.EmpNum;
            cmd.Parameters["@CivilStatus"].Value = item.CivilStatus;
            cmd.Parameters["@Height"].Value = item.Height;
            cmd.Parameters["@Weight"].Value = item.Weight;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Employee] ([PersonId],[EmpNum],[CivilStatus],[Height],[Weight],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PersonId,@EmpNum,@CivilStatus,@Height,@Weight,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.EmpNum.ToString());
        }


    }
}
