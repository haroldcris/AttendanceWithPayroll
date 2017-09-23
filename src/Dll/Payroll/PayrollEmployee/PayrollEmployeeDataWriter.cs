using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PayrollEmployeeDataWriter : SqlMainDataWriter<PayrollEmployee, PayrollEmployeeCollection>
    {

        public PayrollEmployeeDataWriter(string username, PayrollEmployee item) : base(username, item) { }
        public PayrollEmployeeDataWriter(string username, PayrollEmployeeCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PayrollEmployee item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@EmployeeId", SqlDbType.Int) ,
                new SqlParameter( "@DateHired", SqlDbType.Date) ,
                new SqlParameter( "@Department", SqlDbType.NVarChar, 30) ,
                new SqlParameter( "@TaxId", SqlDbType.Int) ,
                new SqlParameter( "@PositionId", SqlDbType.Int) ,
                new SqlParameter( "@Step", SqlDbType.TinyInt) ,
                new SqlParameter( "@Tin", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@PagIbig", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@PhilHealth", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@Active", SqlDbType.Bit) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@EmployeeId"].Value = item.EmployeeId;
            cmd.Parameters["@DateHired"].Value = item.DateHired;
            cmd.Parameters["@Department"].Value = item.Department;
            cmd.Parameters["@TaxId"].Value = item.TaxId;
            cmd.Parameters["@PositionId"].Value = item.PositionId;
            cmd.Parameters["@Step"].Value = item.Step;
            cmd.Parameters["@Tin"].Value = item.Tin;
            cmd.Parameters["@PagIbig"].Value = item.PagIbig;
            cmd.Parameters["@PhilHealth"].Value = item.PhilHealth;
            cmd.Parameters["@Active"].Value = item.Active;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_Employee] ([EmployeeId],[DateHired],[Department],[TaxId],[PositionId],[Step],[Tin],[PagIbig],[PhilHealth],[Active],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@EmployeeId,@DateHired,@Department,@TaxId,@PositionId,@Step,@Tin,@PagIbig,@PhilHealth,@Active,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges()
        {
            this.AfterItemSave += PayrollEmployeeDataWriter_AfterItemSave;
            return Write(_ => _.EmployeeClass.PersonClass.Name.Fullname);
        }

        private void PayrollEmployeeDataWriter_AfterItemSave(object sender, EntityEventArgs e)
        {
            var item = (PayrollEmployee)e.ItemData;


            //if (item.RowStatus == RecordStatus.NewRecord)
            //{
            //Update Id of Children
            foreach (var o in item.Deductions.Items)
            {
                o.EmpId = item.Id;
            }
            //}


            //PayEmpDeductions
            var writer = new PayrollEmployeeDeductionDataWriter(DataWriterUsername, item.Deductions);
            writer.SaveChanges(e.Connection, e.Transaction);


        }
    }
}
