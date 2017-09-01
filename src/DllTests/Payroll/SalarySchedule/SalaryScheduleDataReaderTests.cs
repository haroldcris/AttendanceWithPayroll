using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dll.Payroll.Tests
{
    [TestClass()]
    public class SalaryScheduleDataReaderTests
    {
        [TestMethod()]
        public void GetSalaryOfPositionIdTest()
        {
            var reader = new SalaryScheduleDataReader();

            var result = reader.GetSalaryOfPositionId(54, 1, DateTime.Today);

            Assert.AreEqual<Decimal>((decimal)25290.00, result);
        }
    }
}