using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WakeMeUpApp.API;

namespace TestSuite
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        //Time Test - Basic Flow
        public void TimeBasic()
        {
            Time time = new Time()
            {
                Hour = 12,
                Minute = 0,
                Second = 0
            };
            time.adjustment();
            CommonTimeTestCase(12,0,0,time);
        }

        [TestMethod]
        //Time Test - Alternative Flow
        public void TimeAlternate()
        {
            Time time = new Time() {
                Hour = 25,
                Minute = 70,
                Second = 90
            };
            time.adjustment();
            CommonTimeTestCase(1, 10, 30, time);
        }

        [TestMethod]
        //Time Test - Basic Flow - Negative Hour
        public void TimeExceptionHour()
        {
            Time time = new Time()
            {
                Hour = -12,
                Minute = 70,
                Second = 90
            };
            time.adjustment();
            CommonTimeTestCase(12, 10, 30, time);
        }

        [TestMethod]
        //Time Test - Basic Flow - Negative Minute / Second
        public void TimeExceptionMinute()
        {
            Time time = new Time()
            {
                Hour = 25,
                Minute = -9,
                Second = 90
            };
            time.adjustment();
            CommonTimeTestCase(1, 51, 30, time);
        }

        [TestMethod]
        //Time Test - Basic Flow - Add(Time)
        public void TimeAddBasic()
        {
            Time time1 = new Time()
            {
                Hour = 12,
                Minute = 0,
                Second = 0
            };
            Time time2 = new Time()
            {
                Hour = 11,
                Minute = 0,
                Second = 0
            };
            time1.Add(time2);
            CommonTimeTestCase(23, 0, 0, time1);
        }

        [TestMethod]
        //Time Test - Basic Flow - Subtract(Time)
        public void TimeSubtractBasic()
        {
            Time time1 = new Time()
            {
                Hour = 12,
                Minute = 0,
                Second = 0
            };
            Time time2 = new Time()
            {
                Hour = 11,
                Minute = 0,
                Second = 0
            };
            time1.Subtract(time2);
            CommonTimeTestCase(1, 0, 0, time1);
        }

        [TestMethod]
        //Time Test - Basic Flow - Subtract(Time)
        public void TimeExceptionSubtract()
        {
            Time time1 = new Time()
            {
                Hour = 12,
                Minute = 0,
                Second = 0
            };
            Time time2 = new Time()
            {
                Hour = 13,
                Minute = 0,
                Second = 0
            };
            time1.Subtract(time2);
            CommonTimeTestCase(23, 0, 0, time1);
        }

        public void CommonTimeTestCase(int hour, int minute, int second, Time time)
        {
            Assert.AreEqual(hour, time.Hour);
            Assert.AreEqual(minute, time.Minute);
            Assert.AreEqual(second, time.Second);
        }
    }
}
