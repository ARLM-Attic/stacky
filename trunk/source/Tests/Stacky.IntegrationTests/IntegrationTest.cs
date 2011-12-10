namespace Stacky.IntegrationTests
{
    public abstract class IntegrationTest
    {
        public static string Version = "2.0";
        public static string ApiKey = "LU9IfwI8IEScM3yYAjHimA";

        public IntegrationTest()
        {
            Client = new StackyClient(Version, Sites.StackOverflow, new UrlClient(), new JsonProtocol());
            ClientAsync = new StackyClientAsync(Version, Sites.StackOverflow.ApiSiteParameter, new UrlClientAsync(), new JsonProtocol());
        }

        public StackyClient Client { get; set; }
        public StackyClientAsync ClientAsync { get; set; }
    }
}