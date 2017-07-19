using System;
using System.Data.SqlClient;

using AiTech.Database;
using System.Data;
using AiTech.Entities;
using System.Linq;

namespace Dll.SchoolYear
{
    public class CourseDataWriter : SqlMainDataWriter<Course, CourseCollection>
    {
        public CourseDataWriter(string username, Course item) : base(username, item) { }
        public CourseDataWriter(string username, CourseCollection items) : base(username, items) { }

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
                        if (DatabaseAction.ExecuteDeleteQuery<Course>(DataWriterUsername, deletedItems, db, trn))
                            affectedRecords += deletedItems.Count();


                    SqlCommand cmd;
                    foreach (var item in _List.Items)
                    {
                        switch (item.Id)
                        {
                            case 0:  // New RECORD
                                item.RowStatus = RecordStatus.NewRecord;

                                var insertQuery = CreateSqlInsertQuery();
                                cmd = new SqlCommand(insertQuery, db, trn);

                                CreateSqlInsertCommandParameters(cmd, item);

                                if (ExecuteCommand(cmd, item, item.CourseCode))
                                    affectedRecords++;
                                break;


                            default: // UPDATE

                                if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                                var updateQuery = CreateSqlUpdateQuery(item);
                                cmd = new SqlCommand(updateQuery, db, trn);

                                CreateSqlUpdateCommandParameters(cmd, item);

                                if (ExecuteCommand(cmd, item, item.CourseCode))
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

        protected override void CommitChanges()
        {
            _List.CommitChanges();
        }

         protected override void RollbackChanges()
        {
            _List.RollBackChanges();
        }
        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, Course item)
        {
            cmd.Parameters.AddRange(new[]
          {

            new SqlParameter( "@CourseCode", SqlDbType.NVarChar, 20) ,
            new SqlParameter( "@Description", SqlDbType.NVarChar, 50) ,
            new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
            new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

          });



            cmd.Parameters["@CourseCode"].Value = item.CourseCode;
            cmd.Parameters["@Description"].Value = item.Description;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Courses] ([CourseCode],[Description],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@CourseCode,@Description,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }

       
    }
}
