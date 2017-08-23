using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PositionDataWriter : SqlMainDataWriter<Position, PositionCollection>
    {
        public PositionDataWriter(string username, Position item) : base(username, item) { }
        public PositionDataWriter(string username, PositionCollection items) : base(username, items) { }


        public override bool SaveChanges()
        {
            return Write(_ => _.Description);
        }



        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Position item)
        {
            cmd.Parameters.AddRange(new[]
              {

                new SqlParameter( "@Code", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

              });

            cmd.Parameters["@Code"].Value = item.Code;
            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_Position] ([Code],[Description],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@Code,@Description,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


    }
}
