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
    internal class SalaryGradeDataWriter : SqlDataWriter<SalaryGrade, SalaryGradeCollection>
    {
        public SalaryGradeDataWriter(string username, SalaryGrade item) : base(username, item) { }
        public SalaryGradeDataWriter(string username, SalaryGradeCollection items) : base(username, items) { }


        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {
            var affectedRecords = 0;

            try
            {
                // Delete All Marked Items
                var deletedItems = _List.Items.Where(_ => _.RowStatus == RecordStatus.DeletedRecord);
                if (deletedItems.Count() != 0)
                    if (DatabaseAction.ExecuteDeleteQuery<SalaryGrade>(DataWriterUsername, deletedItems, db, trn))
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
                            if (string.IsNullOrEmpty(updateQuery)) continue;
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

        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, SalaryGrade item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@SalaryScheduleId", SqlDbType.Int) ,
                new SqlParameter( "@SG", SqlDbType.Int) ,
                new SqlParameter( "@Step1", SqlDbType.Decimal) ,
                new SqlParameter( "@Step2", SqlDbType.Decimal) ,
                new SqlParameter( "@Step3", SqlDbType.Decimal) ,
                new SqlParameter( "@Step4", SqlDbType.Decimal) ,
                new SqlParameter( "@Step5", SqlDbType.Decimal) ,
                new SqlParameter( "@Step6", SqlDbType.Decimal) ,
                new SqlParameter( "@Step7", SqlDbType.Decimal) ,
                new SqlParameter( "@Step8", SqlDbType.Decimal) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });



            cmd.Parameters["@SalaryScheduleId"].Value = item.SalarySchedule.Id;
            cmd.Parameters["@SG"].Value = item.SG;
            cmd.Parameters["@Step1"].Value = item.Step1;
            cmd.Parameters["@Step2"].Value = item.Step2;
            cmd.Parameters["@Step3"].Value = item.Step3;
            cmd.Parameters["@Step4"].Value = item.Step4;
            cmd.Parameters["@Step5"].Value = item.Step5;
            cmd.Parameters["@Step6"].Value = item.Step6;
            cmd.Parameters["@Step7"].Value = item.Step7;
            cmd.Parameters["@Step8"].Value = item.Step8;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }



        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int ); 
						  INSERT INTO [Payroll_SalaryGrade] ([SalaryScheduleId],[SG],[Step1],[Step2],[Step3],[Step4],[Step5],[Step6],[Step7],[Step8],[CreatedBy],[ModifiedBy]) 
							 OUTPUT inserted.Id into @output
						  VALUES (@SalaryScheduleId,@SG,@Step1,@Step2,@Step3,@Step4,@Step5,@Step6,@Step7,@Step8,@CreatedBy,@ModifiedBy)
						  SELECT * from @output";
        }
    }
}
