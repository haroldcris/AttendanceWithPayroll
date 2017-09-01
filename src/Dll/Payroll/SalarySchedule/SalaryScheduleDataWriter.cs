using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Dll.Payroll
{
    public class SalaryScheduleDataWriter : SqlMainDataWriter<SalarySchedule, SalaryScheduleCollection>
    {
        public SalaryScheduleDataWriter(string username, SalarySchedule item) : base(username, item)
        {
        }

        public SalaryScheduleDataWriter(string username, SalaryScheduleCollection items) : base(username, items)
        {
        }

        public override bool SaveChanges()
        {
            AfterItemSave += SalaryScheduleDataWriter_AfterItemSave;

            return Write(_ => _.Effectivity.ToString("yyyy MMMM dd"));
        }


        private void SalaryScheduleDataWriter_AfterItemSave(object sender, EntityEventArgs e)
        {
            var item = (SalarySchedule)e.ItemData;

            //Transfer Id to Child
            if (item.RowStatus == RecordStatus.NewRecord)
            {
                Debug.WriteLine("Salary Schedule is new Record. Setting Children ID..." + item.Id);
                foreach (var sg in item.SalaryGrades.Items)
                {
                    sg.SalaryScheduleId = item.Id;
                }

                foreach (var pos in item.PositionSalaryGrades.Items)
                {
                    pos.SalaryScheduleId = item.Id;
                    pos.SalaryScheduleClass = item;
                }
            }



            // Write Changes to Position
            var posWriter = new PositionSalaryGradeDataWriter(DataWriterUsername, item.PositionSalaryGrades);
            posWriter.SaveChanges(e.Connection, e.Transaction);


            // Write Changes to Salary Grade
            var sgWriter = new SalaryGradeDataWriter(DataWriterUsername, item.SalaryGrades);
            sgWriter.SaveChanges(e.Connection, e.Transaction);
        }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, SalarySchedule item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@Effectivity", SqlDbType.Date),
                new SqlParameter("@Remarks", SqlDbType.NVarChar, 50),
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 20),
                new SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@Effectivity"].Value = item.Effectivity;
            cmd.Parameters["@Remarks"].Value = item.Remarks;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;
        }


        protected override string CreateSqlInsertQuery()
        {
            return
                @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_SalarySchedule] ([Effectivity],[Remarks],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@Effectivity,@Remarks,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }
    }
}