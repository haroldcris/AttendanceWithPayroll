using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Dynamic;

namespace Dll.Contacts.Tests
{
    [TestClass()]
    public class PersonDataMapperTests
    {
        [TestMethod()]
        public void PersonMapSameObjectTest()
        {
            var p = new Employee.Employee();

            var q = p.PersonClass.DataMapper.Item();

            Assert.AreSame(p.PersonClass, q);
        }


        [TestMethod()]
        public void PersonMapTest()
        {
            var p = new Employee.Employee();

            dynamic item = new ExpandoObject();
            item.Id = 9;


            //String
            p.PersonClass.DataMapper.Map(_ => _.BirthCountry, "Philippines");
            Debug.WriteLine("Birth Country " + p.PersonClass.BirthCountry);
            Assert.AreEqual("Philippines", p.PersonClass.BirthCountry);


            //int
            p.PersonClass.DataMapper.Map(_ => _.Id, 9);
            Debug.WriteLine("Id " + p.PersonClass.Id);
            Assert.AreEqual(9, p.PersonClass.Id);


            //Date Time
            p.PersonClass.DataMapper.Map(_ => _.BirthDate, DateTime.Today);
            Debug.WriteLine("BirthDate " + p.PersonClass.BirthDate);
            Assert.AreEqual(DateTime.Today, p.PersonClass.BirthDate);


            //int
            var myId = (int)item.Id;
            p.PersonClass.DataMapper.Map(_ => _.Id, myId);
            Debug.WriteLine("Id " + p.PersonClass.Id);
            Assert.AreEqual(9, p.PersonClass.Id);
        }
    }
}