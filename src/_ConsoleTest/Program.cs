using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Dll.Employee.Employee();

            //emp.PersonInfo.Name.Lastname= "Name";
            //n.Lastname = "f";
            emp.PersonInfo.Name.Lastname = "lastname";
            emp.PersonInfo.Name.Firstname = "Firstname";
            emp.PersonInfo.Address.Barangay = "Barangay";
            emp.CurrentPosition = "Position 1";

            var writer = new Dll.Employee.EmployeeDataWriter("user", emp);
            var result = writer.SaveChanges();

            Console.WriteLine(emp.Id);

            emp.StartTrackingChanges();

            emp.PersonInfo.Name.Firstname = "Firstname8888";
            emp.PersonInfo.Gender = Dll.Contacts.Enums.GenderType.Female;
            emp.PersonInfo.BirthDate = new DateTime(1980, 2, 1);

            writer = new Dll.Employee.EmployeeDataWriter("user1", emp);

            writer.SaveChanges();

        }
    }
}
