using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace Dll.Payroll.Tests
{
    [TestClass()]
    public class PayrollEmployeeCollectionTests
    {
        [TestMethod()]
        public void GetItemsFromDbTest()
        {
            var items = new PayrollEmployeeCollection();

            items.LoadAllItemsFromDb();

            Debug.WriteLine(items.Items.Count());

            Assert.IsTrue(items.Items.Any());
        }
    }
}