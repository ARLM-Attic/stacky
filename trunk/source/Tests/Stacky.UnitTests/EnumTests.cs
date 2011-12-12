using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.UnitTests
{
    [TestClass]
    public class EnumTests
    {
        [TestMethod]
        public void GetEnumValue_DetectsNull()
        {
            string result = EnumHelper.GetQueryStringValue(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetEnumValue_ConvertsToLowerCase()
        {
            string result = BadgeSort.Rank.GetQueryStringValue();
            Assert.AreEqual("rank", result);
        }

        [TestMethod]
        public void GetEnumValue_UnderscoresForCamelCasing()
        {
            string result = BadgeMinMax.TagBased.GetQueryStringValue();
            Assert.AreEqual("tag_based", result);
        }
    }
}
