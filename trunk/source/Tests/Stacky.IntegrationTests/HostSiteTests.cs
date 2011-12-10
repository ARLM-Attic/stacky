using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
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
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }
    }
}