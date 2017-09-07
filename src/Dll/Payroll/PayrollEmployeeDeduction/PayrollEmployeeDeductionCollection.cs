using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using System;

namespace Dll.Payroll
{
    public class PayrollEmployeeDeductionCollection : EntityCollection<PayrollEmployeeDeduction>
    {
        private PayrollEmployee _parentEmployee;

        public PayrollEmployeeDeductionCollection()
        {

        }


        public PayrollEmployeeDeductionCollection(PayrollEmployee parent)
        {
            _parentEmployee = parent;
        }


        public void LoadAllItemsWithDeduction()
        {
            const string query = @"Select ed.* 
                                    , d.Code, d.Description, d.Mandatory, d.Priority, d.Active
                                    
                                    from Payroll_EmployeeDeduction ed 
                                    inner join Payroll_Employee pe on ed.EmpId = pe.Id
                                    inner join Payroll_Deduction d on d.Id = ed.DeductionId

                                    where pe.Id = @PayrollEmpId";


            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query(query, new { PayrollEmpId = _parentEmployee.Id });


                foreach (var result in results)
                {
                    var item = new PayrollEmployeeDeduction();

                    item.Map(result);

                    item.DeductionClass.Map(result);
                    item.DeductionClass.Id = result.DeductionId;

                    item.StartTrackingChanges();

                    ItemCollection.Add(item);
                }
            }
        }


        public void AddMandatoryDeductions()
        {
            const string query = @"Select d.Id, d.Code, d.Description, d.Mandatory, d.Priority, d.Active
                                    from Payroll_Deduction d 
                                    where Mandatory = 1 order by d.Code";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query<Deduction>(query, new { PayrollEmpId = _parentEmployee.Id });


                foreach (var result in results)
                {
                    var item = new PayrollEmployeeDeduction();

                    item.Id = 0;

                    item.DateFrom = new DateTime(1920, 1, 1);
                    item.DateTo = new DateTime(2079, 1, 1);

                    item.Remarks = "";

                    item.DeductionId = result.Id;
                    item.DeductionClass.Map(result);

                    item.EmpId = _parentEmployee.Id;

                    item.StartTrackingChanges();

                    Add(item);
                }
            }
        }

    }
}
