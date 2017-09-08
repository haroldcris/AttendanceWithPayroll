using AiTech.LiteOrm;
using AiTech.LiteOrm.Database;
using Dapper;
using Dll.Employee;
using System.Linq;

namespace Dll.Payroll
{
    public class PayrollEmployeeDataReader
    {


        public bool HasExistingId(int empId)
        {
            const string query = @"Select 1 from Payroll_Employee where EmployeeId = @EmpId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query(query, new { EmpId = empId });

                return result.Any();
            }
        }


        public void LoadAllItemsFromDb()
        {

            var query = @"SELECT p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], [Gender], [CameraCounter]
                                    , e.Id EmployeeId, [EmpNum], [CivilStatus], [GSIS], [Pagibig], [PhilHealth], [SSS], [Tin]
                                    , pe.Id Id, DateHired, Department, TaxId, PositionId, Step, pe.Created, pe.Modified, pe.CreatedBy, pe.ModifiedBy
                                    , pos.Id PositionId, pos.Code PositionCode, pos.Description PositionDescription
                                    , tax.Id TaxId, tax.ShortDesc, tax.Exemption , tax.Description TaxDescription
                                    from Person p
                                        inner join Employee e on p.Id = e.PersonId
                                        inner join Payroll_Employee pe on pe.EmployeeId = e.Id 
                                        inner join Payroll_Position pos on pos.Id = pe.PositionId
                                        inner join Payroll_TaxTable tax on tax.Id = pe.TaxId";


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
                    item.TaxClass.Description = reader.TaxDescription;


                    item.RowStatus = RecordStatus.NoChanges;
                    item.StartTrackingChanges();

                }

            }

        }


    }
}
