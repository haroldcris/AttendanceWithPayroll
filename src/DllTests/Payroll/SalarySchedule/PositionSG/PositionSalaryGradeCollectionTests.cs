using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace Dll.Payroll.Tests
{
    [TestClass()]
    public class PositionSalaryGradeCollectionTests
    {
        [TestMethod()]
        public void LoadLatestScheduleTest()
        {
            var items = new PositionSalaryGradeCollection();

            items.LoadLatestSchedule();


            Assert.IsTrue(items.Items.Any());

            Debug.WriteLine(items.Items.Count() + " items found from database");

        }
    }
}