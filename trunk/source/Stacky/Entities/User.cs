namespace Stacky
{
    using System;
    using Newtonsoft.Json;

    public class User : ShallowUser
    {
        #region Fields

        private BadgeCounts badgeCounts = new BadgeCounts();
        private int? age;
        private string website;
        private DateTime lastAccessDate;
        private string location;
        private string aboutMe;
        private int questionCount;
        private int answerCount;
        private int viewCount;
        private int upVotes;
        private int downVotes;
        private int reputationChangeDay;
        private int reputationChangeWeek;
        private int reputationChangeMonth;
        private int reputationChangeQuarter;
        private int reputationChangeYear;
        private bool isEmployee;
        private int accountId;
        private DateTime timedPenaltyDate;
        private DateTime creationDate;

        #endregion

        [JsonProperty("reputation_change_day")]
		public int ReputationChangeDay
		{
			get { return reputationChangeDay; }
			set { reputationChangeDay = value; NotifyOfPropertyChange(() => ReputationChangeDay); }
		}

		[JsonProperty("reputation_change_week")]
		public int ReputationChangeWeek
		{
			get { return reputationChangeWeek; }
			set { reputationChangeWeek = value; NotifyOfPropertyChange(() => ReputationChangeWeek); }
		}

		[JsonProperty("reputation_change_month")]
		public int ReputationChangeMonth
		{
			get { return reputationChangeMonth; }
			set { reputationChangeMonth = value; NotifyOfPropertyChange(() => ReputationChangeMonth); }
		}

		[JsonProperty("reputation_change_quarter")]
		public int ReputationChangeQuarter
		{
			get { return reputationChangeQuarter; }
			set { reputationChangeQuarter = value; NotifyOfPropertyChange(() => ReputationChangeQuarter); }
		}

		[JsonProperty("reputation_change_year")]
		public int ReputationChangeYear
		{
			get { return reputationChangeYear; }
			set { reputationChangeYear = value; NotifyOfPropertyChange(() => ReputationChangeYear); }
		}

		/// <summary>
		/// Gets or sets the age.
		/// </summary>
		/// <value>The age.</value>
		[JsonProperty("age")]
		public int? Age
		{
			get { return age; }
			set { age = value; NotifyOfPropertyChange(() => Age); }
		}

		/// <summary>
		/// Gets or sets the website.
		/// </summary>
		/// <value>The website.</value>
		[JsonProperty("website_url")]
		public string Website
		{
			get { return website; }
			set { website = value; NotifyOfPropertyChange(() => Website); }
		}

		/// <summary>
		/// Gets or sets the last access date.
		/// </summary>
		/// <value>The last access date.</value>
		[JsonProperty("last_access_date"), JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime LastAccessDate
		{
			get { return lastAccessDate; }
			set { lastAccessDate = value; NotifyOfPropertyChange(() => LastAccessDate); }
		}

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		/// <value>The location.</value>
		[JsonProperty("location")]
		public string Location
		{
			get { return location; }
			set { location = value; NotifyOfPropertyChange(() => Location); }
		}

		/// <summary>
		/// Gets or sets the about me.
		/// </summary>
		/// <value>The about me.</value>
		[JsonProperty("about_me")]
		public string AboutMe
		{
			get { return aboutMe; }
			set { aboutMe = value; NotifyOfPropertyChange(() => AboutMe); }
		}

		/// <summary>
		/// Gets or sets the answer count.
		/// </summary>
		/// <value>The answer count.</value>
		[JsonProperty("answer_count")]
		public int AnswerCount
		{
			get { return answerCount; }
			set { answerCount = value; NotifyOfPropertyChange(() => AnswerCount); }
		}

		/// <summary>
		/// Gets or sets the view count.
		/// </summary>
		/// <value>The view count.</value>
		[JsonProperty("view_count")]
		public int ViewCount
		{
			get { return viewCount; }
			set { viewCount = value; NotifyOfPropertyChange(() => ViewCount); }
		}

		/// <summary>
		/// Gets or sets up votes.
		/// </summary>
		/// <value>Up votes.</value>
		[JsonProperty("up_vote_count")]
		public int UpVotes
		{
			get { return upVotes; }
			set { upVotes = value; NotifyOfPropertyChange(() => UpVotes); }
		}

		/// <summary>
		/// Gets or sets down votes.
		/// </summary>
		/// <value>Down votes.</value>
		[JsonProperty("down_vote_count")]
		public int DownVotes
		{
			get { return downVotes; }
			set { downVotes = value; NotifyOfPropertyChange(() => DownVotes); }
		}

		/// <summary>
		/// Gets or sets the question count.
		/// </summary>
		/// <value>The question count.</value>
		[JsonProperty("is_employee")]
		public bool IsEmployee
		{
			get { return isEmployee; }
			set { isEmployee = value; NotifyOfPropertyChange(() => IsEmployee); }
		}

		[JsonProperty("account_id")]
		public int AccountId
		{
			get { return accountId; }
			set { accountId = value; NotifyOfPropertyChange(() => AccountId); }
		}

		/// <summary>
		/// Gets or sets the <see cref="BadgeCounts"/>.
		/// </summary>
		/// <value>The <see cref="BadgeCounts"/>.</value>
		[JsonProperty("badge_counts")]
		public BadgeCounts BadgeCounts
		{
			get { return badgeCounts; }
			set { badgeCounts = value; NotifyOfPropertyChange(() => BadgeCounts); }
		}

		[JsonProperty("question_count")]
		public int QuestionCount
		{
			get { return questionCount; }
			set { questionCount = value; NotifyOfPropertyChange(() => QuestionCount); }
		}

		[JsonProperty("timed_penalty_date")]
		public DateTime TimedPenaltyDate
		{
			get { return timedPenaltyDate; }
			set { timedPenaltyDate = value; NotifyOfPropertyChange(() => TimedPenaltyDate); }
		}
    }
}