using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LeapWoF;
using LeapWoF.Models;

namespace LeapWoF.Tests
{
    [TestClass]
    public class WheelTest
    {
        private Wheel wheel;

        [TestMethod]
        public void SpinTest()
        {
            wheel = new Wheel();
            var spinPrize = wheel.Spin();
            Assert.IsInstanceOfType(spinPrize, typeof(Prize));
        }
    }
}
