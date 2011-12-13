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
		public void GetQueryStringValue_DetectsNull()
        {
            string result = EnumHelper.GetQueryStringValue(null);
            Assert.IsNull(result);
        }

        [TestMethod]
		public void GetQueryStringValue_ConvertsToLowerCase()
        {
            string result = BadgeSort.Rank.GetQueryStringValue();
            Assert.AreEqual("rank", result);
        }

        [TestMethod]
		public void GetQueryStringValue_UnderscoresForCamelCasing()
        {
            string result = BadgeMinMax.TagBased.GetQueryStringValue();
            Assert.AreEqual("tag_based", result);
        }

		[TestMethod]
		public void ParseQueryStringValue_CapitalizedFirstLetter()
		{
			string result = EnumHelper.ParseQueryStringValue("go");
			Assert.AreEqual("Go", result);
		}

		[TestMethod]
		public void ParseQueryStringValue_UnderscoreRemovedAndCamelCased()
		{
			string result = EnumHelper.ParseQueryStringValue("remember_the_milk");
			Assert.AreEqual("RememberTheMilk", result);
		}
    }
}
