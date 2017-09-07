using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Dll.Payroll.Tests
{
    [TestClass()]
    public class TableSSSTests
    {
        [TestMethod()]
        public void GetContributionOfTest()
        {
            var table = new SSSTable();

            var result = table.GetContributionOf(2000m);
            Assert.AreEqual(72.7m, result);
            Debug.WriteLine("result is " + result);


            result = table.GetContributionOf(15750);
            Assert.AreEqual(581.3m, result);
            Debug.WriteLine("result is " + result);


            result = table.GetContributionOf(1000);
            Assert.AreEqual(36.3m, result);
            Debug.WriteLine("result is " + result);
        }


    }
}