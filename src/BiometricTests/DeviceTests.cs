using Microsoft.VisualStudio.TestTools.UnitTesting;
using AiTech.Biometric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AiTech.Biometric.Tests
{
    [TestClass()]
    public class DeviceTests
    {
        [TestMethod()]
        public void GetPlatformTest()
        {
            var dev = new Device("192.168.0.211");

            Debug.WriteLine("Created CLass");

            if (!dev.Connect())
            {
                Assert.Fail();
                return;
            }

            Debug.WriteLine("I am connected");

            Assert.IsTrue(dev.IsConnected);
        }
    }
}