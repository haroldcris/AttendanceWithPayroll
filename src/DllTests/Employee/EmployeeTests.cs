using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Diagnostics;

namespace Dll.Employee.Tests
{
    [TestClass()]
    public class EmployeeTests
    {
        private Employee CreateEmployee()
        {
            var emp = new Employee();

            var rnd = new Random();

            var id = rnd.Next(1, 500).ToString();


            emp.PersonInfo.Name.Lastname = "Lastname " + id;
            emp.PersonInfo.Name.Firstname = "Firstname " + id;

            emp.PersonInfo.BirthDate = DateTime.Today.AddDays(rnd.Next(17,35) * -1);

            emp.PersonInfo.Address.Barangay = "Barangay " + id;
            emp.PersonInfo.Address.Town = "Town " + id;
            emp.PersonInfo.Address.Province = "Province " + id;

            emp.CurrentPosition = "Position" + id;

            return emp;
        }

        [TestMethod()]
        public void AddEmployeeToDb()
        {
            var emp = CreateEmployee();

            var writer = new EmployeeDataWriter("username", emp);

            var result = writer.SaveChanges();

            Debug.WriteLine("Getting ID Number of Employee");
            Debug.WriteLine(emp.Id);

            Assert.AreEqual(true, result);
        }


        [TestMethod()]
        public void CheckIfTrackingChangesWorks()
        {
            var emp = CreateEmployee();

            emp.StartTrackingChanges();

            emp.PersonInfo.Name.Middlename = "Middlen";
            emp.PersonInfo.Address.Barangay = "NewBarangay";

            var changedValues = emp.GetChangedValues();

            Assert.AreEqual(0 , changedValues.Count);


            changedValues = emp.PersonInfo.GetChangedValues();

            Debug.WriteLine(changedValues.Count + " Total here");
            foreach (var item in changedValues)
            {
                Debug.WriteLine(item.Key + " => " + item.Value.ToString());
            }

            Assert.AreEqual(2, changedValues.Count);
        }


        [TestMethod()]
        public void CheckingForUpdateSql()
        {
            var emp = CreateEmployee();
            emp.StartTrackingChanges();

            emp.PersonInfo.Name.Firstname = "First8889";
            emp.PersonInfo.Gender = Contacts.Enums.GenderType.Female;
            emp.PersonInfo.BirthDate = new DateTime(1980, 2, 1);

            //var builder = new AiTech.Database.SqlUpdateQueryBuilder(emp);
            //var query = builder.GetQueryString();

            var writer = new EmployeeDataWriter("user1", emp);

            var result = writer.SaveChanges();

            Assert.AreEqual(true, result);

        }
    }
}