using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="User">user's</see> reputation change.
    /// </summary>
    public class Reputation : Entity
    {
        private int userId;
        [JsonProperty("user_id")]
        public int UserId
        {
            get { return userId; }
            set { userId = value; NotifyOfPropertyChange(() => UserId); }
        }

        private int postId;
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; NotifyOfPropertyChange(() => PostId); }
        }

        private PostType postType;
        [JsonProperty("post_type")]
        public PostType PostType
        {
            get { return postType; }
            set { postType = value; NotifyOfPropertyChange(() => PostType); }
        }

        private VoteType voteType;
        [JsonProperty("vote_type")]
        public VoteType VoteType
        {
            get { return voteType; }
            set { voteType = value; NotifyOfPropertyChange(() => VoteType); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        private string link;
        [JsonProperty("link")]
        public string Link
        {
            get { return link; }
            set { link = value; NotifyOfPropertyChange(() => Link); }
        }

        private int reputationChange;
        [JsonProperty("reputation_change")]
        public int ReputationChange
        {
            get { return reputationChange; }
            set { reputationChange = value; NotifyOfPropertyChange(() => ReputationChange); }
        }

        private DateTime onDate;
        [JsonProperty("on_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OnDate
        {
            get { return onDate; }
            set { onDate = value; NotifyOfPropertyChange(() => OnDate); }
        }
    }
}