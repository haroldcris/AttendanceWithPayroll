using System;
using System.Data.SqlClient;
using System.Linq;
using AiTech.Database;
using System.Data;
using AiTech.Entities;

namespace Dll.Payroll
{
    public class TaxDataWriter : SqlMainDataWriter<Tax, TaxCollection>
    {
        public TaxDataWriter(string username, Tax item) : base(username, item) { }
        public TaxDataWriter(string username, TaxCollection items) : base(username, items) { }


        public override bool SaveChanges()
        {
            var affectedRecords = 0;

            SqlTransaction trn;
            using (var db = Connection.CreateConnection())
            {
                try
                {
                    db.Open();
                    trn = db.BeginTransaction();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Can not establish connection to server", ex);
                }


                try
                {
                    // Delete All Marked Items
                    var deletedItems = _List.Items.Where(_ => _.RowStatus == RecordStatus.DeletedRecord);
                    if (deletedItems.Count() != 0)
                        if (DatabaseAction.ExecuteDeleteQuery<Tax>(DataWriterUsername, deletedItems, db, trn))
                            affectedRecords += deletedItems.Count();

                    SqlCommand cmd;
                    foreach (var item in _List.Items)
                    {
                        if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                        switch (item.RowStatus)
                        {
                            case RecordStatus.DeletedRecord: break;

                            case RecordStatus.NewRecord:
                                item.RowStatus = RecordStatus.NewRecord;

                                var insertQuery = CreateSqlInsertQuery();
                                cmd = new SqlCommand(insertQuery, db, trn);

                                CreateSqlInsertCommandParameters(cmd, item);

                                if (ExecuteCommand(cmd, item, item.Description))
                                    affectedRecords++;
                                break;


                            default: // UPDATE

                                var updateQuery = CreateSqlUpdateQuery(item);
                                if (string.IsNullOrEmpty(updateQuery)) continue;
                                cmd = new SqlCommand(updateQuery, db, trn);

                                CreateSqlUpdateCommandParameters(cmd, item);

                                if (ExecuteCommand(cmd, item, item.Description))
                                    affectedRecords++;

                                break;
                        }

                        //
                        // Save SubClass Here;
                        //                               							

                    }

                    trn.Commit();

                    CommitChanges();
                    return affectedRecords > 0;
                }
                catch
                {
                    trn.Rollback();
                    RollbackChanges();
                    throw;
                }
            }

        }



        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Tax item)
        {
            cmd.Parameters.AddRange(new[]
              {

                new SqlParameter( "@TaxID", SqlDbType.TinyInt) ,                new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,                new SqlParameter( "@ShortDesc", SqlDbType.NVarChar, 20) ,                new SqlParameter( "@Dependent", SqlDbType.TinyInt) ,                new SqlParameter( "@Exemption", SqlDbType.Decimal) ,                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

              });



            cmd.Parameters["@TaxID"].Value = item.TaxID;
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
						  INSERT INTO [Payroll_Taxtable] ([TaxID],[Description],[ShortDesc],[Dependent],[Exemption],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@TaxID,@Description,@ShortDesc,@Dependent,@Exemption,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }

        protected override void CommitChanges()
        {
            _List.CommitChanges();
        }
        protected override void RollbackChanges()
        {
            _List.RollBackChanges();
        }
    }
}
