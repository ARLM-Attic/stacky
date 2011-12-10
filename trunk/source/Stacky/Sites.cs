namespace Stacky
{
    public static class Sites
    {
        public static Site StackOverflow
        {
            get
            {
                return new Site
                {
                    Type = "main_site",
                    Name = "Stack Overflow",
                    LogoUrl = "http://sstatic.net/stackoverflow/img/logo.png",
                    ApiSiteParameter = "stackoverflow",
                    SiteUrl = "http://stackoverflow.com",
                    Audience = "professional and enthusiast programmers",
                    IconUrl = "http://sstatic.net/stackoverflow/img/apple-touch-icon.png",
                    Aliases = new string[] { "http://www.stackoverflow.com" },
                    State = SiteState.Normal,
                    Styling = new SiteStyle
                    {
                        LinkColor = "#0077CC",
                        TagForegroundColor = "#3E6D8E",
                        TagBackgroundColor = "#E0EAF1"
                    },
                    FaviconUrl = "http://sstatic.net/stackoverflow/img/favicon.ico",
                    MarkdownExtensions = new string[] { "Prettify" }
                };
            }
        }
    }
}