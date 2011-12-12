namespace Stacky.Entities
{
    using System;
    using Newtonsoft.Json;

    public class NetworkUser : Entity
    {
        #region Fields

        private string siteName;
        private string siteHost;
        private int id;
        private int reputation;
        private int accountId;
        private DateTime creationDate;
        private UserType type;
        private BadgeCounts badgeCounts = new BadgeCounts();

        #endregion

        [JsonProperty("site_name")]
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; NotifyOfPropertyChange(() => SiteName); }
        }

        [JsonProperty("site_host")]
        public string SiteHost
        {
            get { return siteHost; }
            set { siteHost = value; NotifyOfPropertyChange(() => SiteHost); }
        }

        [JsonProperty("user_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        [JsonProperty("reputation")]
        public int Reputation
        {
            get { return reputation; }
            set { reputation = value; NotifyOfPropertyChange(() => Reputation); }
        }

        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type
        {
            get { return type; }
            set { type = value; NotifyOfPropertyChange(() => Type); }
        }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        [JsonProperty("badge_counts")]
        public BadgeCounts BadgeCounts
        {
            get { return badgeCounts; }
            set { badgeCounts = value; NotifyOfPropertyChange(() => BadgeCounts); }
        }
    }
}