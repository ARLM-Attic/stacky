using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.UnitTests
{
    [TestClass]
    public class DateTests
    {
        [TestMethod]
        public void ImplicitUnixDateToLong()
        {
            DateTime date = DateTime.Now;
            UnixDateTime unixDate = new UnixDateTime(date);

            long actual = unixDate;
            long expected = UnixDateTime.UnixTimeFromDate(date);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplicitLongToUnixDate()
        {
            long date = UnixDateTime.UnixTimeFromDate(DateTime.Now);
            UnixDateTime unixDate = date;

            Assert.AreEqual(date, unixDate.UnixValue);
        }

        [TestMethod]
        public void ImplicitDateTimeToUnixDate()
        {
            DateTime date = DateTime.Now;
            UnixDateTime unixDate = date;

            Assert.AreEqual(date, unixDate.DateValue);
        }

        [TestMethod]
        public void ImplicitUnixDateToDateTime()
        {
            DateTime date = DateTime.Now;
            UnixDateTime unixDate = new UnixDateTime(date);

            DateTime actual = unixDate;
            Assert.AreEqual(date, actual);
        }

        [TestMethod]
        public void ToString_IsUnixDate()
        {
            long date = UnixDateTime.UnixTimeFromDate(DateTime.Now);
            UnixDateTime unixDate = new UnixDateTime(date);

            Assert.AreEqual(date.ToString(), unixDate.ToString());
        }

        [TestMethod]
        public void Uninitialized_DoesntThrowException()
        {
            UnixDateTime value = new UnixDateTime();
            string s = value.ToString();
            long unix = value;
            DateTime date = value;

            value = 1;
            value = DateTime.Now;
        }
    }
}