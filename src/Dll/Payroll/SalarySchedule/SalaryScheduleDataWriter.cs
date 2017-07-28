using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiTech.Database;
using System.Data;
using AiTech.Entities;

namespace Dll.Payroll
{
    public class SalaryScheduleDataWriter : SqlMainDataWriter<SalarySchedule, SalaryScheduleCollection>
    {
        public SalaryScheduleDataWriter(string username, SalarySchedule item) : base(username, item) { }
        public SalaryScheduleDataWriter(string username, SalaryScheduleCollection items) : base(username, items) { }

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
                        if (DatabaseAction.ExecuteDeleteQuery<SalarySchedule>(DataWriterUsername, deletedItems, db, trn))
                            affectedRecords += deletedItems.Count();

                    SqlCommand cmd;
                    foreach (var item in _List.Items)
                    {
                        if (item.RowStatus == RecordStatus.DeletedRecord) continue;

                        switch (item.RowStatus)
                        {
                            case RecordStatus.DeletedRecord: break;

                            case RecordStatus.NewRecord:
                                var insertQuery = CreateSqlInsertQuery();
                                cmd = new SqlCommand(insertQuery, db, trn);

                                CreateSqlInsertCommandParameters(cmd, item);

                                if (ExecuteCommand(cmd, item, item.Effectivity.ToString("MMM dd yyyy")))
                                    affectedRecords++;


                                //Set ParentId;
                                //foreach (var child in item.SalaryGrades.Items) child.SalaryScheduleId = item.Id;
                                //foreach (var child in item.PositionSalaryGrades.Items) child.SalaryScheduleId = item.Id;


                                break;


                            default: // UPDATE

                                var updateQuery = CreateSqlUpdateQuery(item);
                                if (string.IsNullOrEmpty(updateQuery)) break;
                                cmd = new SqlCommand(updateQuery, db, trn);

                                CreateSqlUpdateCommandParameters(cmd, item);

                                if (ExecuteCommand(cmd, item, item.Effectivity.ToString("MMM dd yyyy")))
                                    affectedRecords++;

                                break;
                        }


                        //
                        // Save SubClass Here;
                        //       
                        
                        //Salary Grade                        							
                        var sgWriter = new SalaryGradeDataWriter(DataWriterUsername, item.SalaryGrades);
                            sgWriter.SaveChanges(db, trn);

                        //PositionSG
                        var psgWriter = new PositionSalaryGradeDataWriter(DataWriterUsername, item.PositionSalaryGrades);
                            psgWriter.SaveChanges(db, trn);


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

            //Sub Classes
            foreach(var item in _List.Items)
            {
                item.PositionSalaryGrades.CommitChanges();
                item.SalaryGrades.CommitChanges();
            }
        }

        protected override void RollbackChanges()
        {
            _List.RollBackChanges();

            //Sub Classes
            foreach (var item in _List.Items)
            {
                item.PositionSalaryGrades.RollBackChanges();
                item.SalaryGrades.RollBackChanges();
            }
        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, SalarySchedule item)
        {
            cmd.Parameters.AddRange(new[]
            {

                new SqlParameter( "@Effectivity", SqlDbType.Date) ,
                new SqlParameter( "@Remarks", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

            });

            cmd.Parameters["@Effectivity"].Value = item.Effectivity;
            cmd.Parameters["@Remarks"].Value = item.Remarks;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }


        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
						  INSERT INTO [Payroll_SalarySchedule] ([Effectivity],[Remarks],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
						  VALUES (@Effectivity,@Remarks,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }


    }
}
