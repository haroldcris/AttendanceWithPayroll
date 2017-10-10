using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dll.Employee.Tests
{
    [TestClass()]
    public class EmployeeDataReaderTests
    {
        [TestMethod()]
        public void GetIdOfTest()
        {
            var reader = new EmployeeDataReader();

            var result = reader.GetIdOf(2);

            Assert.AreEqual(0, result);


        }



        [TestMethod()]
        public void TestClassFunction()
        {
            var r = new Root();
            var s = new Stem();

            r.Id = 1;


            Assert.AreEqual(0, s.ParentId);

            s.GetParentId = () => { return r.Id; };

            s.Test();

            Assert.AreEqual(1, s.ParentId);

        }


        class Root
        {
            public int Id { get; set; }
        }

        class Stem
        {
            public Func<int> GetParentId;
            public int ParentId { get; set; }

            public void Test()
            {
                if (GetParentId != null)
                    ParentId = GetParentId();
            }
        }
    }
}