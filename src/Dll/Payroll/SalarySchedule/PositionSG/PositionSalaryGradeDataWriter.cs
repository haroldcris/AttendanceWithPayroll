using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    internal class PositionSalaryGradeDataWriter : SqlDataWriter<PositionSalaryGrade, PositionSalaryGradeCollection>
    {
        public PositionSalaryGradeDataWriter(string username, PositionSalaryGrade item) : base(username, item) { }
        public PositionSalaryGradeDataWriter(string username, PositionSalaryGradeCollection items) : base(username, items) { }

        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {

            return Write(_ => "PositionId " + _.PositionId.ToString(), db, trn);

        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PositionSalaryGrade item)
        {
            cmd.Parameters.AddRange(new[]
             {

                new SqlParameter( "@SalaryScheduleId", SqlDbType.Int) ,
                new SqlParameter( "@PositionId", SqlDbType.Int) ,
                new SqlParameter( "@SG", SqlDbType.Int) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

              });



            cmd.Parameters["@SalaryScheduleId"].Value = item.SalaryScheduleId;

            cmd.Parameters["@PositionId"].Value = item.PositionId;

            cmd.Parameters["@SG"].Value = item.SG;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int); 
                        INSERT INTO [Payroll_PositionSG] ([SalaryScheduleId],[PositionId],[SG],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id into @output
                          VALUES (@SalaryScheduleId,@PositionId,@SG,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }
    }
}
