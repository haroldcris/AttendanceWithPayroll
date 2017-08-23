using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Location
{
    public class TownDataWriter : SqlDataWriter<Town, TownCollection>
    {
        public TownDataWriter(string username, Town item) : base(username, item) { }
        public TownDataWriter(string username, TownCollection items) : base(username, items) { }

        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            return Write(_ => _.Name, db, trn);
        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Town item)
        {
            cmd.Parameters.AddRange(new[]
            {

                new SqlParameter( "@ProvinceId", SqlDbType.Int) ,
                new SqlParameter( "@Town", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@ZipCode", SqlDbType.NVarChar, 5)

            });

            cmd.Parameters["@ProvinceId"].Value = item.ProvinceClass.Id;
            cmd.Parameters["@Town"].Value = item.Name;
            cmd.Parameters["@ZipCode"].Value = item.ZipCode;
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Location_Towns] ([ProvinceId],[Town],[ZipCode]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@ProvinceId,@Town,@ZipCode)
                          SELECT * from @output";
        }
    }
}
