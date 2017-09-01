using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}