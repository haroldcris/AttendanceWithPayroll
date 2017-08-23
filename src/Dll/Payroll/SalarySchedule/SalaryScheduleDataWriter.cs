using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class SalaryScheduleDataWriter : SqlMainDataWriter<SalarySchedule, SalaryScheduleCollection>
    {
        public SalaryScheduleDataWriter(string username, SalarySchedule item) : base(username, item) { }
        public SalaryScheduleDataWriter(string username, SalaryScheduleCollection items) : base(username, items) { }

        public override bool SaveChanges()
        {

            AfterItemSave += SalaryScheduleDataWriter_AfterItemSave;

            return Write(_ => _.Effectivity.ToString("yyyy MMMM dd"));

        }



        private void SalaryScheduleDataWriter_AfterItemSave(object sender, EntityEventArgs e)
        {
            var item = (SalarySchedule)e.ItemData;

            var sgWriter = new SalaryGradeDataWriter(DataWriterUsername, item.SalaryGrades);

            sgWriter.OnSalaryScheduleIdRequest += () => item.Id;

            sgWriter.SaveChanges(e.Connection, e.Transaction);

        }

        protected override void CommitChanges()
        {
            _List.CommitChanges();

            //Sub Classes
            //foreach (var item in _List.Items)
            //{
            //    item.PositionSalaryGrades;
            //    item.SalaryGrades.CommitChanges();
            //}
        }

        protected override void RollbackChanges()
        {
            _List.RollbackChanges();

            //Sub Classes
            //foreach (var item in _List.Items)
            //{
            //    item.PositionSalaryGrades.RollbackChanges();
            //    item.SalaryGrades.RollbackChanges();
            //}
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
