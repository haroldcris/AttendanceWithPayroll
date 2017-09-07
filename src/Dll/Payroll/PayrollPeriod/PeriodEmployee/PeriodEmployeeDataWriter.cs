using AiTech.LiteOrm.Database;
using System.Data;
using System.Data.SqlClient;

namespace Dll.Payroll
{
    public class PeriodEmployeeDataWriter : SqlDataWriter<PeriodEmployee, PeriodEmployeeCollection>
    {

        public PeriodEmployeeDataWriter(string username, PeriodEmployee item) : base(username, item) { }
        public PeriodEmployeeDataWriter(string username, PeriodEmployeeCollection items) : base(username, items) { }


        protected override void CreateSqlInsertCommandParameters(SqlCommand cmd, PeriodEmployee item)
        {
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter( "@PeriodId", SqlDbType.Int) ,
                new SqlParameter( "@PersonId", SqlDbType.Int) ,
                new SqlParameter( "@EmpId", SqlDbType.Int) ,
                new SqlParameter( "@EmpNum", SqlDbType.Int) ,
                new SqlParameter( "@Lastname", SqlDbType.NVarChar, 25) ,
                new SqlParameter( "@Firstname", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@Middlename", SqlDbType.NVarChar, 25) ,
                new SqlParameter( "@MI", SqlDbType.NVarChar, 2) ,
                new SqlParameter( "@NameExtension", SqlDbType.NVarChar, 3) ,
                new SqlParameter( "@Gender", SqlDbType.NVarChar, 10) ,
                new SqlParameter( "@BirthDate", SqlDbType.Date) ,
                new SqlParameter( "@DateHired", SqlDbType.Date) ,
                new SqlParameter( "@CurrentPosition", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@SG", SqlDbType.TinyInt) ,
                new SqlParameter( "@Step", SqlDbType.TinyInt) ,
                new SqlParameter( "@PagIbig", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@PhilHealth", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@SSS", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@TIN", SqlDbType.NVarChar, 15) ,
                new SqlParameter( "@TaxId", SqlDbType.TinyInt) ,
                new SqlParameter( "@TaxShortDesc", SqlDbType.NVarChar, 30) ,
                new SqlParameter( "@TaxDescription", SqlDbType.NVarChar, 50) ,
                new SqlParameter( "@TaxExemption", SqlDbType.Decimal) ,
                new SqlParameter( "@GrossBasicSalary", SqlDbType.Decimal) ,
                new SqlParameter( "@PaymentCode", SqlDbType.NVarChar, 10) ,
                new SqlParameter( "@PaymentType", SqlDbType.NVarChar, 30) ,
                new SqlParameter( "@BasicSalary", SqlDbType.Decimal) ,
                new SqlParameter( "@pFrom", SqlDbType.DateTime) ,
                new SqlParameter( "@pTo", SqlDbType.DateTime) ,
                new SqlParameter( "@Department", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@CameraCounter", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@SalarySchedID", SqlDbType.BigInt) ,
                new SqlParameter( "@CreatedBy", SqlDbType.NVarChar, 20) ,
                new SqlParameter( "@ModifiedBy", SqlDbType.NVarChar, 20)
            });

            cmd.Parameters["@PeriodId"].Value = item.PeriodId;
            cmd.Parameters["@PersonId"].Value = item.PersonId;
            cmd.Parameters["@EmpId"].Value = item.EmpId;
            cmd.Parameters["@EmpNum"].Value = item.EmpNum;
            cmd.Parameters["@Lastname"].Value = item.Lastname;
            cmd.Parameters["@Firstname"].Value = item.Firstname;
            cmd.Parameters["@Middlename"].Value = item.Middlename;
            cmd.Parameters["@MI"].Value = item.MI;
            cmd.Parameters["@NameExtension"].Value = item.NameExtension;
            cmd.Parameters["@Gender"].Value = item.Gender;
            cmd.Parameters["@BirthDate"].Value = item.BirthDate;
            cmd.Parameters["@DateHired"].Value = item.DateHired;
            cmd.Parameters["@CurrentPosition"].Value = item.CurrentPosition;
            cmd.Parameters["@SG"].Value = item.SG;
            cmd.Parameters["@Step"].Value = item.Step;
            cmd.Parameters["@PagIbig"].Value = item.PagIbig;
            cmd.Parameters["@PhilHealth"].Value = item.PhilHealth;
            cmd.Parameters["@SSS"].Value = item.SSS;
            cmd.Parameters["@TIN"].Value = item.TIN;
            cmd.Parameters["@TaxId"].Value = item.TaxId;
            cmd.Parameters["@TaxShortDesc"].Value = item.TaxShortDesc;
            cmd.Parameters["@TaxDescription"].Value = item.TaxDescription;
            cmd.Parameters["@TaxExemption"].Value = item.TaxExemption;
            cmd.Parameters["@GrossBasicSalary"].Value = item.GrossBasicSalary;
            cmd.Parameters["@PaymentCode"].Value = item.PaymentCode;
            cmd.Parameters["@PaymentType"].Value = item.PaymentType;
            cmd.Parameters["@BasicSalary"].Value = item.BasicSalary;
            cmd.Parameters["@pFrom"].Value = item.pFrom;
            cmd.Parameters["@pTo"].Value = item.pTo;
            cmd.Parameters["@Department"].Value = item.Department;
            cmd.Parameters["@CameraCounter"].Value = item.CameraCounter;
            cmd.Parameters["@SalarySchedID"].Value = item.SalarySchedID;
            cmd.Parameters["@CreatedBy"].Value = DataWriterUsername;
            cmd.Parameters["@ModifiedBy"].Value = DataWriterUsername;

        }

        protected override string CreateSqlInsertQuery()
        {
            return @"DECLARE @output table ( Id int, Created Datetime, CreatedBy nvarchar(20), Modified DateTime, ModifiedBy nvarchar(20)); 
                          INSERT INTO [Payroll_PeriodEmployee] ([PeriodId],[PersonId],[EmpId],[EmpNum],[Lastname],[Firstname],[Middlename],[MI],[NameExtension],[Gender],[BirthDate],[DateHired],[CurrentPosition],[SG],[Step],[PagIbig],[PhilHealth],[SSS],[TIN],[TaxId],[TaxShortDesc],[TaxDescription],[TaxExemption],[GrossBasicSalary],[PaymentCode],[PaymentType],[BasicSalary],[pFrom],[pTo],[Department],[CameraCounter],[SalarySchedID],[CreatedBy],[ModifiedBy]) 
                             OUTPUT inserted.Id, inserted.Created, inserted.CreatedBy, inserted.Modified, inserted.ModifiedBy into @output
                          VALUES (@PeriodId,@PersonId,@EmpId,@EmpNum,@Lastname,@Firstname,@Middlename,@MI,@NameExtension,@Gender,@BirthDate,@DateHired,@CurrentPosition,@SG,@Step,@PagIbig,@PhilHealth,@SSS,@TIN,@TaxId,@TaxShortDesc,@TaxDescription,@TaxExemption,@GrossBasicSalary,@PaymentCode,@PaymentType,@BasicSalary,@pFrom,@pTo,@Department,@CameraCounter,@SalarySchedID,@CreatedBy,@ModifiedBy)
                          SELECT * from @output";
        }


        public override bool SaveChanges(SqlConnection db, SqlTransaction trn)
        {

            AfterItemSave += PeriodEmployeeDataWriter_AfterItemSave;
            return Write(_ => "Employee Number : " + _.EmpNum.ToString(), db, trn);

        }

        private void PeriodEmployeeDataWriter_AfterItemSave(object sender, EntityEventArgs e)
        {
            var item = (PeriodEmployee)e.ItemData;


            if (item.RowStatus == AiTech.LiteOrm.RecordStatus.NewRecord)
            {
                //Transfer All ID to Children
                foreach (var d in item.Deductions.Items)
                {
                    d.PeriodEmployeeId = item.Id;
                }
            }


            var writer = new PeriodEmployeeDeductionDataWriter(DataWriterUsername, item.Deductions);
            writer.SaveChanges(e.Connection, e.Transaction);


        }
    }
}
