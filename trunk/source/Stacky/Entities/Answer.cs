using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/answer
    /// </summary>
    public class Answer : Entity
    {
        private int questionId;
        [JsonProperty("question_id")]
        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; NotifyOfPropertyChange(() => QuestionId); }
        }

        private int answerId;
        [JsonProperty("answer_id")]
        public int AnswerId
        {
            get { return answerId; }
            set { answerId = value; NotifyOfPropertyChange(() => AnswerId); }
        }

        private DateTime lockedDate;
        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate
        {
            get { return lockedDate; }
            set { lockedDate = value; NotifyOfPropertyChange(() => LockedDate); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private DateTime lastEditDate;
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; NotifyOfPropertyChange(() => LastEditDate); }
        }

        private DateTime lastActivityDate;
        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate
        {
            get { return lastActivityDate; }
            set { lastActivityDate = value; NotifyOfPropertyChange(() => LastActivityDate); }
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

        private bool isAccepted;
        [JsonProperty("is_accepted")]
        public bool IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; NotifyOfPropertyChange(() => IsAccepted); }
        }

        private string body;
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        private ShallowUser owner;
        [JsonProperty("owner")]
        public ShallowUser Owner
        {
            get { return owner; }
            set { owner = value; NotifyOfPropertyChange(() => Owner); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
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

        private List<Comment> comments;
        [JsonProperty("comments")]
        public List<Comment> Comments
        {
            get { return comments; }
            set { comments = value; NotifyOfPropertyChange(() => Comments); }
        }

        private string link;
        [JsonProperty("link")]
        public string Link
        {
            get { return link; }
            set { link = value; NotifyOfPropertyChange(() => Link); }
        }
    }
}