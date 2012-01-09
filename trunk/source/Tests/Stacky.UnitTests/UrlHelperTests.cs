using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stacky.UnitTests
{
    [TestClass]
    public class UrlHelperTests
    {
        public TestContext TestContext { get; set; }
        private static string version = "1.0";

        #region BuildUrl

        [TestMethod]
        public void BuildUrl_UrlParameters_IncludedInResult()
        {
            var url = UrlHelper.BuildUrl("TestMethod", version, new string[] { "item1", "item2" }, null);
            Assert.AreEqual("http://api.stackexchange.com/" + version + "/TestMethod/item1/item2/", url.ToString());
        }

        [TestMethod]
        public void BuildUrl_NullUrlParameters_ResultsInNoUrlParameters()
        {
            var url = UrlHelper.BuildUrl("TestMethod", version, null, null);
            Assert.AreEqual("http://api.stackexchange.com/" + version + "/TestMethod/", url.ToString());
        }

        [TestMethod]
        public void BuildUrl_UrlParamatersAndQueryStringParameters_BuiltCorrectly()
        {
            var url = UrlHelper.BuildUrl("TestMethod", version, new string[] { "item1", "item2" }, new
            {
                key = "key",
                config = "1"
            });
            Assert.AreEqual("http://api.stackexchange.com/" + version + "/TestMethod/item1/item2/?key=key&config=1", url.ToString());
        }

        #endregion

        #region BuildParameters

        [TestMethod]
        public void BuildParameters_NullParameters_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters((object)null);
            Assert.AreEqual(String.Empty, queryString);
        }

        [TestMethod]
        public void BuildParameters_WithDictionary_NullParameters_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters((Dictionary<string, string>)null);
            Assert.AreEqual(String.Empty, queryString);
        }

        class NoReadableProperties
        {
            private string val;

            public string Value
            {
                set
                {
                    val = value;
                }
            }
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNoReadableProperties_ResultsInEmptyString()
        {
            NoReadableProperties o = new NoReadableProperties();
            string queryString = UrlHelper.BuildParameters(o);
            Assert.AreEqual(String.Empty, queryString);
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNoProperties_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters(4);
            Assert.AreEqual(String.Empty, queryString);
        }

        class TestParameters
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNullValueProperty_ResultsInEmptyString()
        {
            string queryString = UrlHelper.BuildParameters(new TestParameters {Key = null});
            Assert.AreEqual(String.Empty, queryString);
        }

        [TestMethod]
        public void BuildParameters_ObjectWithNullValueProperty_KeyIsSkipped()
        {
            string queryString = UrlHelper.BuildParameters(new TestParameters { Key = null, Value = 1 });
            Assert.AreEqual("Value=1", queryString);
        }

        [TestMethod]
        public void BuildParameters_ValuesAreUrlEncoded()
        {
            string s = "I Owe $100";
            string encoded = Uri.EscapeDataString(s);
            string queryString = UrlHelper.BuildParameters(new {Key = s});
            Assert.AreEqual("Key=" + encoded, queryString);
        }

        [TestMethod]
        public void BuildParameters_QueryStringDoesNotEndInAmpersand()
        {
            string queryString = UrlHelper.BuildParameters(new {Value1 = 3, Value2 = "Me"});
            Assert.IsFalse(queryString.EndsWith("&"));
        }

        [TestMethod]
        public void BuildParameters_WithDictionary_ValuesAreUrlEncoded()
        {
            string s = "I Owe $100";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Key"] = s;
            string encoded = Uri.EscapeDataString(s);
            string queryString = UrlHelper.BuildParameters(parameters);
            Assert.AreEqual("Key=" + encoded, queryString);
        }

        [TestMethod]
        public void BuildParameters_WithDictionary_QueryStringDoesNotEndInAmpersand()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["Value1"] = "3";
            parameters["Value2"] = "Me";
            string queryString = UrlHelper.BuildParameters(parameters);
            Assert.IsFalse(queryString.EndsWith("&"));
        }

        #endregion

        #region ObjectToDictionary

        [TestMethod]
        public void ObjectToDictionary_nullObject_ReturnsEmptyDictionary()
        {
            var d = UrlHelper.ObjectToDictionary(null);
            Assert.AreEqual(0, d.Count);
        }

        [TestMethod]
        public void ObjectToDictionary_AllReadablePropertiesBecomeKeys()
        {
            TestParameters p = new TestParameters { Key = "Key", Value = 1 };
            var d = UrlHelper.ObjectToDictionary(p);
            Assert.AreEqual(2, d.Count);
            Assert.IsTrue(d.ContainsKey("Key"));
            Assert.IsTrue(d.ContainsValue("Key"));
            Assert.IsTrue(d.ContainsKey("Value"));
            Assert.IsTrue(d.ContainsValue("1"));
        }

        [TestMethod]
        public void ObjectToDictionary_ObjectWithNoReadableProperties_ReturnsEmptyDictionary()
        {
            NoReadableProperties o = new NoReadableProperties();
            var d = UrlHelper.ObjectToDictionary(o);
            Assert.AreEqual(0, d.Count);
        }

        [TestMethod]
        public void ObjectToDictionary_ObjectWithNullValueProperty_KeyIsSkipped()
        {
            TestParameters p = new TestParameters { Key = null, Value = 1 };
            var d = UrlHelper.ObjectToDictionary(p);
            Assert.AreEqual(1, d.Count);
            Assert.IsFalse(d.ContainsKey("Key"));
            Assert.IsTrue(d.ContainsKey("Value"));
            Assert.IsTrue(d.ContainsValue("1"));
        }

        #endregion

        [TestMethod]
        public void Bug6099_PoundSignEncodedCorrectly()
        {
            var url = UrlHelper.BuildUrl("questions", version, null, new
            {
                item1 = "test#one",
                item2 = "anotherOne"
            });

            Assert.IsTrue(url.ToString().Contains("%23"));
        }
    }

    [TestClass]
    public class OfflineUrlClientTests
    {
        [TestMethod]
        public void ParamatersMapped()
        {
            string url = "https://api.stackexchange.com/2.0/answers/{id}/comments";
            var newUrl = OfflineUrlClient.MapString(url, new { id = 10 });
            Assert.AreEqual("https://api.stackexchange.com/2.0/answers/10/comments", newUrl);
        }

        [TestMethod]
        public void ResponsesLoadedCorrectly()
        {
            IUrlClient urlClient = new OfflineUrlClient();
            StackyClient client = new StackyClient("2.0", Sites.StackOverflow, urlClient, new JsonProtocol());
            var comments = client.GetAnswerComments(12, AnswerSort.Creation, SortDirection.Descending);
            Assert.IsNotNull(comments);
        }
    }

    public class OfflineUrlClient : IUrlClient
    {
        static List<HttpResponse> responses = new List<HttpResponse>();
        static readonly string InputDirectory = @"C:\Code\Stacky\trunk\data";
        static OfflineUrlClient()
        {
            foreach (string path in Directory.GetFiles(InputDirectory, "*.txt"))
            {
                string[] lines = File.ReadAllLines(path);
                string url = lines[0];
                responses.Add(new HttpResponse
                {
                    Url = new Uri(url),
                    Body = String.Join(Environment.NewLine, lines.Skip(1).Select(l => l))
                });
            }
        }

        public static string MapString(string source, object values)
        {
            var dictionary = UrlHelper.ObjectToDictionary(values);
            foreach (var pair in dictionary)
            {
                source = source.Replace("{" + pair.Key + "}", pair.Value);
            }
            return source;
        }

        public HttpResponse MakeRequest(Uri url)
        {
            return responses.FirstOrDefault(r => UrlEquals(url, r.Url));
        }

        public static bool UrlEquals(Uri url1, Uri url2)
        {
            if (url1.Scheme != url2.Scheme)
                return false;
            if (url1.AbsolutePath != url2.AbsolutePath)
                return false;
            if (!QueryStringEquals(url1.Query, url2.Query))
                return false;
            return true;
        }

        public static bool QueryStringEquals(string query1, string query2)
        {
            return false;
        }
    }

}