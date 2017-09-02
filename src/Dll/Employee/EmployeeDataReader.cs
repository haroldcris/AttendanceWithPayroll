using AiTech.LiteOrm.Database;
using AiTech.LiteOrm.Database.Search;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Dll.Employee
{
    public class EmployeeDataReader
    {

        public Employee GetEmployeeWithId(int id)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                return GetEmployeeWithId(id, db);
            }
        }


        public Employee GetEmployeeWithId(int id, SqlConnection db)
        {
            const string query = "select p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], [Gender], " +
                                 " e.* from Employee e inner join Person p on p.Id = e.PersonId " +
                                 "where e.Id = @Id";

            db.Open();

            var result = db.Query(query, new { Id = id }).FirstOrDefault();

            if (result == null) return null;

            var item = new Employee();

            item.DataMapper.Map(result);


            item.PersonClass.DataMapper.Map(result);
            //item.PersonClass.DataMapper.Map(o => o.Id, result.PersonId);
            if (result.PersonId != null) item.PersonClass.Id = result.PersonId;

            result.StartTrackingChanges();

            return result;
        }


        public int GetIdOf(int empnum)
        {
            const string query = "select Id from Employee where Empnum = @Empnum";
            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query<int>(query, new { Empnum = empnum }).FirstOrDefault();
                return result;
            }

        }

        public IEnumerable<Employee> SearchItem(string searchItem, SearchStyleEnum searchStyle)
        {
            const string query = @"SELECT e.Id, e.EmpNum 
                        , p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], [Gender]
                        from person p inner join Employee e on p.Id = e.PersonId 
                        where Replace(DBO.FULLNAME(LASTNAME, FIRSTNAME, MIDDLENAME, MiddleInitial, 0, NAMEEXTENSION),' ','') like @Criteria";

            var results = Search.SearchData<dynamic>(searchItem, query, searchStyle);

            var itemCollection = new List<Employee>();

            foreach (var result in results)
            {
                var item = new Employee();
                item.DataMapper.Map(result);


                item.PersonClass.DataMapper.Map(result);
                item.PersonClass.Id = result.PersonId;


                item.StartTrackingChanges();

                itemCollection.Add(item);
            }

            return itemCollection;
        }


        public Employee GetBasicProfileOf(int employeeId)
        {
            const string query = "select p.Id PersonId, [Lastname], [Firstname], [Middlename], [MiddleInitial], [NameExtension], [MaidenMiddlename], [Gender], CameraCounter, " +
                                 " e.Id, EmpNum from Employee e inner join Person p on p.Id = e.PersonId " +
                                 " where e.Id = @Id";

            using (var db = Connection.CreateConnection())
            {
                db.Open();
                var result = db.Query(query, new { Id = employeeId }).FirstOrDefault();

                if (result == null) return null;

                var employee = new Employee();

                employee.DataMapper.Map(result);
                employee.PersonClass.DataMapper.Map(result);

                employee.StartTrackingChanges();
                return employee;
            }
        }


        public bool HasExistingPersonId(int personId)
        {
            const string query = "SELECT 1 from Employee where PersonId = @PersonId";

            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var result = db.Query<int>(query, new { PersonId = personId });

                return result.Any();
            }
        }

    }
}
