using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiTech.Database;
using AiTech.Entities;
using System.Data;

namespace Dll.Payroll
{
    internal class PositionSalaryGradeDataWriter : SqlDataWriter <PositionSalaryGrade, PositionSalaryGradeCollection>
    {
        public PositionSalaryGradeDataWriter(string username, PositionSalaryGrade item) : base(username, item) { }
        public PositionSalaryGradeDataWriter(string username, PositionSalaryGradeCollection items) : base(username, items) { }

        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            var affectedRecords = 0;

            try
            {
                // Delete All Marked Items
                var deletedItems = _List.Items.Where(_ => _.RowStatus == RecordStatus.DeletedRecord);
                if (deletedItems.Count() != 0)
                    if (DatabaseAction.ExecuteDeleteQuery<Entity>(DataWriterUsername, deletedItems, db, trn))
                        affectedRecords += deletedItems.Count();


                SqlCommand cmd;
                foreach (var item in _List.Items)
                {

                    switch (item.RowStatus)
                    {
                        case RecordStatus.DeletedRecord: continue; 

                        case RecordStatus.NewRecord:
                            var insertQuery = CreateSqlInsertQuery();
                            cmd = new SqlCommand(insertQuery, db, trn);

                            CreateSqlInsertCommandParameters(cmd, item);

                            if (ExecuteCommand(cmd, item, item.SG.ToString()))
                                affectedRecords++;
                            break;


                        default: // UPDATE

                            var updateQuery = CreateSqlUpdateQuery(item);
                            if (string.IsNullOrEmpty(updateQuery)) break;
                            cmd = new SqlCommand(updateQuery, db, trn);

                            CreateSqlUpdateCommandParameters(cmd, item);

                            if (ExecuteCommand(cmd, item, item.SG.ToString()))
                                affectedRecords++;

                            break;
                    }

                    //
                    // Save SubClass Here;
                    //                                    							

                }

                return affectedRecords > 0;
            }
            catch
            {
                throw;
            }

        }

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PositionSalaryGrade item)
        {
            cmd.Parameters.AddRange(new[]
             {

                new SqlParameter( "@SalaryScheduleId", SqlDbType.Int) ,
                new SqlParameter( "@PositionId", SqlDbType.Int) ,
                new SqlParameter( "@SG", SqlDbType.Int) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)

              });



            cmd.Parameters["@SalaryScheduleId"].Value = item.SalarySchedule.Id;

            cmd.Parameters["@PositionId"].Value = item.PositionId;

            cmd.Parameters["@SG"].Value = item.SG;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int); 
                        INSERT INTO [Payroll_PositionSG] ([SalaryScheduleId],[PositionId],[SG],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id into @output
						  VALUES (@SalaryScheduleId,@PositionId,@SG,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }
    }
}
