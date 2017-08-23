using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Location
{
    public class ProvinceDataWriter : SqlMainDataWriter<Province, ProvinceCollection>
    {
        public ProvinceDataWriter(string username, Province item) : base(username, item) { }
        public ProvinceDataWriter(string username, ProvinceCollection items) : base(username, items) { }

        public override bool SaveChanges()
        {
            AfterItemSave += ProvinceDataWriter_AfterItemSave;
            return Write(_ => _.Name);
        }

        private void ProvinceDataWriter_AfterItemSave(object sender, EntityEventArgs e)
        {
            var item = (Province)e.ItemData;

            var townWriter = new TownDataWriter(DataWriterUsername, item.Towns);
            townWriter.SaveChanges(e.Connection, e.Transaction);

        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Province item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@Province", SqlDbType.NVarChar, 50)
            });

            cmd.Parameters["@Province"].Value = item.Name;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Location_Provinces] ([Province]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@Province)
                          SELECT * from @output";
        }

    }
}
