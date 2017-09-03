using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PayrollPeriodDataWriter : SqlMainDataWriter<PayrollPeriod, PayrollPeriodCollection>
    {

        public PayrollPeriodDataWriter(string username, PayrollPeriod item) : base(username, item) { }
        public PayrollPeriodDataWriter(string username, PayrollPeriodCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PayrollPeriod item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@PayrollType", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@DateCovered", SqlDbType.SmallDateTime) ,
                new SqlParameter( "@PayrollCategory", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@Remarks", SqlDbType.NVarChar, 100) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@PayrollType"].Value = item.PayrollType;
            cmd.Parameters["@DateCovered"].Value = item.DateCovered;
            cmd.Parameters["@PayrollCategory"].Value = item.PayrollCategory;
            cmd.Parameters["@Remarks"].Value = item.Remarks;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_Period] ([PayrollType],[DateCovered],[PayrollCategory],[Remarks],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PayrollType,@DateCovered,@PayrollCategory,@Remarks,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            return Write(_ => _.DateCovered.ToString());
        }


    }
}
