namespace Stacky
{
    using System;
    using Newtonsoft.Json;

    public class Site : Entity
    {
        private string type;
        [JsonProperty("site_type")]
        public string Type
        {
            get { return type; }
            set { type = value; NotifyOfPropertyChange(() => Type); }
        }

        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; NotifyOfPropertyChange(() => Name); }
        }

        private string logoUrl;
        [JsonProperty("logo_url")]
        public string LogoUrl
        {
            get { return logoUrl; }
            set { logoUrl = value; NotifyOfPropertyChange(() => LogoUrl); }
        }

        private string apiSiteParameter;
        [JsonProperty("api_site_parameter")]
        public string ApiSiteParameter
        {
            get { return apiSiteParameter; }
            set { apiSiteParameter = value; NotifyOfPropertyChange(() => ApiSiteParameter); }
        }

        private string audience;
        [JsonProperty("audience")]
        public string Audience
        {
            get { return audience; }
            set { audience = value; NotifyOfPropertyChange(() => Audience); }
        }

        private string siteUrl;
        [JsonProperty("site_url")]
        public string SiteUrl
        {
            get { return siteUrl; }
            set { siteUrl = value; NotifyOfPropertyChange(() => SiteUrl); }
        }

        private string iconUrl;
        [JsonProperty("icon_url")]
        public string IconUrl
        {
            get { return iconUrl; }
            set { iconUrl = value; NotifyOfPropertyChange(() => IconUrl); }
        }

        private SiteState state;
        [JsonProperty("state"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SiteState State
        {
            get { return state; }
            set { state = value; NotifyOfPropertyChange(() => State); }
        }

        private string[] aliases;
        [JsonProperty("aliases")]
        public string[] Aliases
        {
            get { return aliases; }
            set { aliases = value; NotifyOfPropertyChange(() => Aliases); }
        }

        private SiteStyle styling;
        [JsonProperty("styling")]
        public SiteStyle Styling
        {
            get { return styling; }
            set { styling = value; NotifyOfPropertyChange(() => Styling); }
        }

        private DateTime closedBetaDate;
        [JsonProperty("closed_beta_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ClosedBetaDate
        {
            get { return closedBetaDate; }
            set { closedBetaDate = value; NotifyOfPropertyChange(() => ClosedBetaDate); }
        }

        private DateTime openBetaDate;
        [JsonProperty("open_beta_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OpenBetaDate
        {
            get { return openBetaDate; }
            set { openBetaDate = value; NotifyOfPropertyChange(() => OpenBetaDate); }
        }

        private DateTime launchDate;
        [JsonProperty("launch_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LaunchDate
        {
            get { return launchDate; }
            set { launchDate = value; NotifyOfPropertyChange(() => LaunchDate); }
        }

        private string faviconUrl;
        [JsonProperty("favicon_url")]
        public string FaviconUrl
        {
            get { return faviconUrl; }
            set { faviconUrl = value; NotifyOfPropertyChange(() => FaviconUrl); }
        }

        private string twitterAccount;
        [JsonProperty("twitter_account")]
        public string TwitterAccount
        {
            get { return twitterAccount; }
            set { twitterAccount = value; NotifyOfPropertyChange(() => TwitterAccount); }
        }

        private string[] markdownExtensions;
        [JsonProperty("markdown_extensions")]
        public string[] MarkdownExtensions
        {
            get { return markdownExtensions; }
            set { markdownExtensions = value; NotifyOfPropertyChange(() => MarkdownExtensions); }
        }

        //TODO: Add related_sites
        //public List<RelatedSite> RelatedSites
        //{
        //}
    }
}