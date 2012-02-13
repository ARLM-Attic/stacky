namespace Stacky.IntegrationTests
{
    public abstract class IntegrationTest
    {
        public static string Version = "2.0";
        public static string ApiKey = "vvfp9MI3DHe4I5dLjQzTXQ((";

        public IntegrationTest()
        {
            Client = new StackyClient(Version, Sites.StackOverflow, new UrlClient(), new JsonProtocol(), ApiKey);
            ClientAsync = new StackyClientAsync(Version, Sites.StackOverflow.ApiSiteParameter, new UrlClientAsync(), new JsonProtocol(), ApiKey);
        }

        public StackyClient Client { get; set; }
        public StackyClientAsync ClientAsync { get; set; }
    }
}