using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a question.
    /// </summary>
    [JsonObject]
    public class Question : Entity
    {
        private int id;
        [JsonProperty("question_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        private DateTime lastEditDate;
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; NotifyOfPropertyChange(() => LastEditDate); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private DateTime lastActivityDate;
        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate
        {
            get { return lastActivityDate; }
            set { lastActivityDate = value; NotifyOfPropertyChange(() => LastActivityDate); }
        }

        private DateTime lockedDate;
        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate
        {
            get { return lockedDate; }
            set { lockedDate = value; NotifyOfPropertyChange(() => LockedDate); }
        }

        private int score;
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; NotifyOfPropertyChange(() => Score); }
        }

        private DateTime communityOwnedDate;
        [JsonProperty("community_owned_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CommunityOwnedDate
        {
            get { return communityOwnedDate; }
            set { communityOwnedDate = value; NotifyOfPropertyChange(() => CommunityOwnedDate); }
        }

        private int answerCount;
        [JsonProperty("answer_count")]
        public int AnswerCount
        {
            get { return answerCount; }
            set { answerCount = value; NotifyOfPropertyChange(() => AnswerCount); }
        }

        private int acceptedAnswerId;
        [JsonProperty("accepted_answer_id")]
        public int AcceptedAnswerId
        {
            get { return acceptedAnswerId; }
            set { acceptedAnswerId = value; NotifyOfPropertyChange(() => AcceptedAnswerId); }
        }

        private MigrationInfo migratedTo;
        [JsonProperty("migrated_to")]
        public MigrationInfo MigratedTo
        {
            get { return migratedTo; }
            set { migratedTo = value; NotifyOfPropertyChange(() => MigratedTo); }
        }

        private MigrationInfo migratedFrom;
        [JsonProperty("migrated_from")]
        public MigrationInfo MigratedFrom
        {
            get { return migratedFrom; }
            set { migratedFrom = value; NotifyOfPropertyChange(() => MigratedFrom); }
        }

        private DateTime bountyClosesDate;
        [JsonProperty("bounty_closes_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime BountyClosesDate
        {
            get { return bountyClosesDate; }
            set { bountyClosesDate = value; NotifyOfPropertyChange(() => BountyClosesDate); }
        }

        private int bountyAmount;
        [JsonProperty("bounty_amount")]
        public int BountyAmount
        {
            get { return bountyAmount; }
            set { bountyAmount = value; NotifyOfPropertyChange(() => BountyAmount); }
        }

        private DateTime closedDate;
        [JsonProperty("closed_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ClosedDate
        {
            get { return closedDate; }
            set { closedDate = value; NotifyOfPropertyChange(() => ClosedDate); }
        }

        private DateTime protectedDate;
        [JsonProperty("protected_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ProtectedDate
        {
            get { return protectedDate; }
            set { protectedDate = value; NotifyOfPropertyChange(() => ProtectedDate); }
        }

        private string body;
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        private List<string> tags = new List<string>();
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; NotifyOfPropertyChange(() => Tags); }
        }

        private string closedReason;
        [JsonProperty("closed_reason")]
        public string ClosedReason
        {
            get { return closedReason; }
            set { closedReason = value; NotifyOfPropertyChange(() => ClosedReason); }
        }

        private int upVoteCount;
        [JsonProperty("up_vote_count")]
        public int UpVoteCount
        {
            get { return upVoteCount; }
            set { upVoteCount = value; NotifyOfPropertyChange(() => UpVoteCount); }
        }

        private int downVoteCount;
        [JsonProperty("down_vote_count")]
        public int DownVoteCount
        {
            get { return downVoteCount; }
            set { downVoteCount = value; NotifyOfPropertyChange(() => DownVoteCount); }
        }

        private int favoriteCount;
        [JsonProperty("favorite_count")]
        public int FavoriteCount
        {
            get { return favoriteCount; }
            set { favoriteCount = value; NotifyOfPropertyChange(() => FavoriteCount); }
        }

        private int viewCount;
        [JsonProperty("view_count")]
        public int ViewCount
        {
            get { return viewCount; }
            set { viewCount = value; NotifyOfPropertyChange(() => ViewCount); }
        }

        private ShallowUser owner;
        [JsonProperty("owner")]
        public ShallowUser Owner
        {
            get { return owner; }
            set { owner = value; NotifyOfPropertyChange(() => Owner); }
        }

        private List<Comment> comments = new List<Comment>();
        public List<Comment> Comments
        {
            get { return comments; }
            set { comments = value; NotifyOfPropertyChange(() => Comments); }
        }

        private List<Answer> answers = new List<Answer>();
        public List<Answer> Answers
        {
            get { return answers; }
            set { answers = value; NotifyOfPropertyChange(() => Answers); }
        }

        private string link;
        [JsonProperty("link")]
        public string Link
        {
            get { return link; }
            set { link = value; NotifyOfPropertyChange(() => Link); }
        }

        private bool isAnswered;
        [JsonProperty("is_answered")]
        public bool IsAnswered
        {
            get { return isAnswered; }
            set { isAnswered = value; NotifyOfPropertyChange(() => IsAnswered); }
        }
    }
}