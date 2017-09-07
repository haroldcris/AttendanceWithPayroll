using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PayrollEmployeeDeductionDataWriter : SqlDataWriter<PayrollEmployeeDeduction, PayrollEmployeeDeductionCollection>
    {
        public PayrollEmployeeDeductionDataWriter(string username, PayrollEmployeeDeduction item) : base(username, item) { }
        public PayrollEmployeeDeductionDataWriter(string username, PayrollEmployeeDeductionCollection items) : base(username, items) { }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PayrollEmployeeDeduction item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@EmpId", SqlDbType.Int) ,
                new SqlParameter( "@DeductionId", SqlDbType.Int) ,
                new SqlParameter( "@Amount", SqlDbType.Decimal) ,
                new SqlParameter( "@DateFrom", SqlDbType.Date) ,
                new SqlParameter( "@DateTo", SqlDbType.Date) ,
                new SqlParameter( "@Remarks", SqlDbType.NVarChar, 100) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@EmpId"].Value = item.EmpId;
            cmd.Parameters["@DeductionId"].Value = item.DeductionId;
            cmd.Parameters["@Amount"].Value = item.Amount;
            cmd.Parameters["@DateFrom"].Value = item.DateFrom;
            cmd.Parameters["@DateTo"].Value = item.DateTo;
            cmd.Parameters["@Remarks"].Value = item.Remarks;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_EmployeeDeduction] ([EmpId],[DeductionId],[Amount],[DateFrom],[DateTo],[Remarks],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@EmpId,@DeductionId,@Amount,@DateFrom,@DateTo,@Remarks,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            return Write(_ => _.DeductionClass.Description, db, trn);
        }
    }
}
