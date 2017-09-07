using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class TaxDataWriter : SqlMainDataWriter<Tax, TaxCollection>
    {
        public TaxDataWriter(string username, Tax item) : base(username, item) { }
        public TaxDataWriter(string username, TaxCollection items) : base(username, items) { }


        public override bool SaveChanges()
        {
            return Write(_ => _.Description);

        }



        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Tax item)
        {
            cmd.Parameters.AddRange(new[]
              {

                new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@ShortDesc", SqlDbType.NVarChar, 20) ,                new SqlParameter( "@Dependent", SqlDbType.TinyInt) ,                new SqlParameter( "@Exemption", SqlDbType.Int) ,                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

              });


            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@ShortDesc"].Value = item.ShortDesc;
            cmd.Parameters["@Dependent"].Value = item.Dependent;
            cmd.Parameters["@Exemption"].Value = item.Exemption;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }



        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_Taxtable] ([Description],[ShortDesc],[Dependent],[Exemption],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@Description,@ShortDesc,@Dependent,@Exemption,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


    }
}
