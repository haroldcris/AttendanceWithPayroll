using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.SchoolYear
{
    public class BatchDataWriter : SqlMainDataWriter<Batch, BatchCollection>
    {
        public BatchDataWriter(string username, Batch item) : base(username, item) { }
        public BatchDataWriter(string username, BatchCollection items) : base(username, items) { }

        public override bool SaveChanges()
        {
            return Write(_ => _.BatchName);
        }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Batch item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@BatchName", SqlDbType.NVarChar, 10) ,
                new SqlParameter( "@Semester", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });


            cmd.Parameters["@BatchName"].Value = item.BatchName;
            cmd.Parameters["@Semester"].Value = item.Semester;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Batch] ([BatchName],[Semester],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@BatchName,@Semester,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }

    }
}
