using AiTech.LiteOrm;

namespace Dll.Payroll
{
    public class PayrollEmployeeDataMapper : EntityMapper<PayrollEmployee>
    {
        public PayrollEmployeeDataMapper(PayrollEmployee entityOwner) : base(entityOwner)
        {
        }

        public void Map(dynamic recordSource)
        {
            if (recordSource.Id != null) ItemData.Id = recordSource.Id;
            if (recordSource.EmployeeId != null) ItemData.EmployeeId = recordSource.EmployeeId;
            if (recordSource.DateHired != null) ItemData.DateHired = recordSource.DateHired;
            if (recordSource.Department != null) ItemData.Department = recordSource.Department;
            if (recordSource.TaxId != null) ItemData.TaxId = recordSource.TaxId;
            if (recordSource.PositionId != null) ItemData.PositionId = recordSource.PositionId;
            if (recordSource.Step != null) ItemData.Step = recordSource.Step;


            if (recordSource.BasicSalary != null) ItemData.BasicSalary = recordSource.BasicSalary;
            if (recordSource.SG != null) ItemData.SG = recordSource.SG;


            if (recordSource.Pagibig != null) ItemData.PagIbig = recordSource.Pagibig;
            if (recordSource.PhilHealth != null) ItemData.PhilHealth = recordSource.PhilHealth;
            if (recordSource.SSS != null) ItemData.SSS = recordSource.SSS;
            if (recordSource.Tin != null) ItemData.Tin = recordSource.Tin;



            if (recordSource.Active != null) ItemData.Active = recordSource.Active;


            if (recordSource.Created != null) ItemData.Created = recordSource.Created;
            if (recordSource.Modified != null) ItemData.Modified = recordSource.Modified;
            if (recordSource.CreatedBy != null) ItemData.CreatedBy = recordSource.CreatedBy;
            if (recordSource.ModifiedBy != null) ItemData.ModifiedBy = recordSource.ModifiedBy;
        }
    }
}
