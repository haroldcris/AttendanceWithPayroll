using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class DeductionDataWriter : SqlMainDataWriter<Deduction, DeductionCollection>
    {
        public DeductionDataWriter(string username, Deduction item) : base(username, item) { }
        public DeductionDataWriter(string username, DeductionCollection items) : base(username, items) { }


        public override bool SaveChanges()
        {
            return Write(_ => _.Description);
        }



        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Deduction item)
        {
            cmd.Parameters.AddRange(new[]
            {

                new SqlParameter( "@Code", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@Mandatory", SqlDbType.Bit) ,
                new SqlParameter( "@Priority", SqlDbType.Int) ,
                new SqlParameter( "@Active", SqlDbType.Bit) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

            });


            cmd.Parameters["@Code"].Value = item.Code;
            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@Mandatory"].Value = item.Mandatory;
            cmd.Parameters["@Priority"].Value = item.Priority;
            cmd.Parameters["@Active"].Value = item.Active;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }


        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_deduction] ([Code],[Description],[Mandatory],[Priority],[Active],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@Code,@Description,@Mandatory,@Priority,@Active,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }

    }
}
