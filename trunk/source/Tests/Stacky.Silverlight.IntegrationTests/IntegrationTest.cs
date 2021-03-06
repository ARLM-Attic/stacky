using Microsoft.Silverlight.Testing;

namespace Stacky.Silverlight.IntegrationTests
{
    public abstract class IntegrationTest : SilverlightTest
    {
        public static string Version = "1.0";
        public static string ApiKey = "LU9IfwI8IEScM3yYAjHimA";
        public static string BaseUrl = Sites.StackOverflow.ApiEndpoint;
        protected static Site hostSite = Sites.StackOverflow;
        protected static IUrlClient urlClient = new UrlClient();
        protected static IProtocol protocol = new JsonProtocol();

        protected StackyClient Client { get; private set; }
        protected StackAuthClient AuthClient { get; private set; }

        public IntegrationTest()
        {
            Client = new StackyClient(Version, ApiKey, hostSite, urlClient, protocol);
            AuthClient = new StackAuthClient(urlClient, protocol);
        }
    }
}