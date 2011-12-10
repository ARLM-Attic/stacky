using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
{
    [TestClass]
    public class HostSiteTests : IntegrationTest
    {
        private StackyClient GetClient(Site site)
        {
            return new StackyClient(IntegrationTest.Version, site, new UrlClient(), new JsonProtocol());
        }

        [TestMethod]
        public void Stacky()
        {
            var client = GetClient(Sites.StackOverflow);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Stack Overflow", stats.Site.Name);
        }
    }
}