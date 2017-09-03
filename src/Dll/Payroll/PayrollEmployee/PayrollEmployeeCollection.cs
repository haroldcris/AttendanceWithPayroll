using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using Dll.Employee;

namespace Dll.Payroll
{
    public class PayrollEmployeeCollection : EntityCollection<PayrollEmployee>
    {
        public void LoadAllItemsFromDb()
        {

            const string query = @"SELECT p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], [Gender], [CameraCounter]
                                    , e.Id EmployeeId, [EmpNum], [CivilStatus], [Pagibig], [PhilHealth], [SSS], [Tin]
                                    , pe.Id Id, DateHired, Department, TaxId, PositionId, Step, pe.Created, pe.Modified, pe.CreatedBy, pe.ModifiedBy, Active
                                    , pos.Id PositionId, pos.Code PositionCode, pos.Description PositionDescription
                                    , tax.Id TaxId, tax.ShortDesc, tax.Exemption
                                    , dbo.GetSalaryOfPositionId(PositionId, default, default) BasicSalary
                                    , dbo.GetSGOfPositionId(PositionId, default) SG

                                    from Person p
                                        inner join Employee e on p.Id = e.PersonId
                                        inner join Payroll_Employee pe on pe.EmployeeId = e.Id 
                                        inner join Payroll_Position pos on pos.Id = pe.PositionId
                                        inner join Payroll_TaxTable tax on tax.Id = pe.TaxId";

            ItemCollection.Clear();

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var results = db.Query(query);

                var employeeReader = new EmployeeDataReader();


                foreach (var reader in results)
                {
                    var item = new PayrollEmployee();

                    //Payroll Employee
                    item.DataMapper.Map(reader);


                    //Employee
                    item.EmployeeClass.DataMapper.Map(reader);
                    item.EmployeeClass.DataMapper.Map(_ => _.Id, (int)(reader.EmployeeId));

                    //Person
                    item.EmployeeClass.PersonClass.DataMapper.Map(reader);
                    item.EmployeeClass.PersonClass.DataMapper.Map(_ => _.Id, (int)reader.PersonId);


                    //Position
                    item.PositionId = reader.PositionId;
                    item.PositionClass.Id = reader.PositionId;
                    item.PositionClass.Code = reader.PositionCode;
                    item.PositionClass.Description = reader.PositionDescription;

                    //Tax
                    item.TaxClass.Id = reader.TaxId;
                    item.TaxClass.Exemption = reader.Exemption;
                    item.TaxClass.ShortDesc = reader.ShortDesc;



                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();

                    ItemCollection.Add(item);
                }

            }

        }

    }
}
