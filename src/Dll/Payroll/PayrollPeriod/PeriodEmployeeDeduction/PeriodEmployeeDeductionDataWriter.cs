using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PeriodEmployeeDeductionDataWriter : SqlDataWriter<PeriodEmployeeDeduction, PeriodEmployeeDeductionCollection>
    {

        public PeriodEmployeeDeductionDataWriter(string username, PeriodEmployeeDeduction item) : base(username, item) { }
        public PeriodEmployeeDeductionDataWriter(string username, PeriodEmployeeDeductionCollection items) : base(username, items) { }



        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PeriodEmployeeDeduction item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@PeriodEmployeeId", SqlDbType.Int) ,
                new SqlParameter( "@DeductionId", SqlDbType.Int) ,
                new SqlParameter( "@Code", SqlDbType.NVarChar, 10) ,
                new SqlParameter( "@Description", SqlDbType.NVarChar, 100) ,
                new SqlParameter( "@DateReceived", SqlDbType.DateTime) ,
                new SqlParameter( "@DateFrom", SqlDbType.DateTime) ,
                new SqlParameter( "@DateTo", SqlDbType.DateTime) ,
                new SqlParameter( "@Amount", SqlDbType.Decimal) ,
                new SqlParameter( "@Mandatory", SqlDbType.Bit) ,
                new SqlParameter( "@Priority", SqlDbType.Bit) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@PeriodEmployeeId"].Value = item.PeriodEmployeeId;
            cmd.Parameters["@DeductionId"].Value = item.DeductionId;
            cmd.Parameters["@Code"].Value = item.Code;
            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@DateReceived"].Value = item.DateReceived;
            cmd.Parameters["@DateFrom"].Value = item.DateFrom;
            cmd.Parameters["@DateTo"].Value = item.DateTo;
            cmd.Parameters["@Amount"].Value = item.Amount;
            cmd.Parameters["@Mandatory"].Value = item.Mandatory;
            cmd.Parameters["@Priority"].Value = item.Priority;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_PeriodEmployeeDeduction] ([PeriodEmployeeId],[DeductionId],[Code],[Description],[DateReceived],[DateFrom],[DateTo],[Amount],[Mandatory],[Priority],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PeriodEmployeeId,@DeductionId,@Code,@Description,@DateReceived,@DateFrom,@DateTo,@Amount,@Mandatory,@Priority,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }



        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            return Write(_ => _.Description, db, trn);
        }


    }
}
