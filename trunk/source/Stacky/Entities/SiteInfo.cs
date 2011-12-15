using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/info
    /// </summary>
    public class SiteInfo : Entity
    {
        private int totalQuestions;
        [JsonProperty("total_questions")]
        public int TotalQuestions
        {
            get { return totalQuestions; }
            set { totalQuestions = value; NotifyOfPropertyChange(() => TotalQuestions); }
        }

        private int totalUnanswered;
        [JsonProperty("total_unanswered")]
        public int TotalUnanswered
        {
            get { return totalUnanswered; }
            set { totalUnanswered = value; NotifyOfPropertyChange(() => TotalUnanswered); }
        }

        private int totalAccepted;
        [JsonProperty("total_accepted")]
        public int TotalAccepted
        {
            get { return totalAccepted; }
            set { totalAccepted = value; NotifyOfPropertyChange(() => TotalAccepted); }
        }

        private int totalAnswers;
        [JsonProperty("total_answers")]
        public int TotalAnswers
        {
            get { return totalAnswers; }
            set { totalAnswers = value; NotifyOfPropertyChange(() => TotalAnswers); }
        }

        private int questionsPerMinute;
        [JsonProperty("questions_per_minute")]
        public int QuestionsPerMinute
        {
            get { return questionsPerMinute; }
            set { questionsPerMinute = value; NotifyOfPropertyChange(() => QuestionsPerMinute); }
        }

        private int answersPerMinute;
        [JsonProperty("answers_per_minute")]
        public int AnswersPerMinute
        {
            get { return answersPerMinute; }
            set { answersPerMinute = value; NotifyOfPropertyChange(() => AnswersPerMinute); }
        }

        private int totalComments;
        [JsonProperty("total_comments")]
        public int TotalComments
        {
            get { return totalComments; }
            set { totalComments = value; NotifyOfPropertyChange(() => TotalComments); }
        }

        private int totalVotes;
        [JsonProperty("total_votes")]
        public int TotalVotes
        {
            get { return totalVotes; }
            set { totalVotes = value; NotifyOfPropertyChange(() => TotalVotes); }
        }

        private int totalBadges;
        [JsonProperty("total_badges")]
        public int TotalBadges
        {
            get { return totalBadges; }
            set { totalBadges = value; NotifyOfPropertyChange(() => TotalBadges); }
        }

        private int badgesPerMinute;
        [JsonProperty("badges_per_minute")]
        public int BadgesPerMinute
        {
            get { return badgesPerMinute; }
            set { badgesPerMinute = value; NotifyOfPropertyChange(() => BadgesPerMinute); }
        }

        private int totalUsers;
        [JsonProperty("total_users")]
        public int TotalUsers
        {
            get { return totalUsers; }
            set { totalUsers = value; NotifyOfPropertyChange(() => TotalUsers); }
        }

        private int newActiveUsers;
        [JsonProperty("new_active_users")]
        public int NewActiveUsers
        {
            get { return newActiveUsers; }
            set { newActiveUsers = value; NotifyOfPropertyChange(() => NewActiveUsers); }
        }

        private string apiRevision;
        [JsonProperty("api_revision")]
        public string ApiRevision
        {
            get { return apiRevision; }
            set { apiRevision = value; NotifyOfPropertyChange(() => ApiRevision); }
        }

        private Site site;
        [JsonProperty("site")]
        public Site Site
        {
            get { return site; }
            set { site = value; NotifyOfPropertyChange(() => Site); }
        }
    }
}