namespace Stacky
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/network-user
    /// </summary>
    public class NetworkUser : Entity
    {
        private string siteName;
        [JsonProperty("site_name")]
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; NotifyOfPropertyChange(() => SiteName); }
        }

        private string siteUrl;
        [JsonProperty("site_url")]
        public string SiteUrl
        {
            get { return siteUrl; }
            set { siteUrl = value; NotifyOfPropertyChange(() => SiteUrl); }
        }

        private int userId;
        [JsonProperty("user_id")]
        public int UserId
        {
            get { return userId; }
            set { userId = value; NotifyOfPropertyChange(() => UserId); }
        }

        private int reputation;
        [JsonProperty("reputation")]
        public int Reputation
        {
            get { return reputation; }
            set { reputation = value; NotifyOfPropertyChange(() => Reputation); }
        }

        private int accountId;
        [JsonProperty("account_id")]
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; NotifyOfPropertyChange(() => AccountId); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private UserType userType;
        [JsonProperty("user_type")]
        public UserType UserType
        {
            get { return userType; }
            set { userType = value; NotifyOfPropertyChange(() => UserType); }
        }

        private BadgeCounts badgeCounts;
        [JsonProperty("badge_counts")]
        public BadgeCounts BadgeCounts
        {
            get { return badgeCounts; }
            set { badgeCounts = value; NotifyOfPropertyChange(() => BadgeCounts); }
        }

        private DateTime lastAccessDate;
        [JsonProperty("last_access_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastAccessDate
        {
            get { return lastAccessDate; }
            set { lastAccessDate = value; NotifyOfPropertyChange(() => LastAccessDate); }
        }

        private int answerCount;
        [JsonProperty("answer_count")]
        public int AnswerCount
        {
            get { return answerCount; }
            set { answerCount = value; NotifyOfPropertyChange(() => AnswerCount); }
        }

        private int questionCount;
        [JsonProperty("question_count")]
        public int QuestionCount
        {
            get { return questionCount; }
            set { questionCount = value; NotifyOfPropertyChange(() => QuestionCount); }
        }
    }
}