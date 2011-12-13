using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stacky
{
    public class Post : Entity
    {
        private string body;
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
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

        private DateTime lastEditDate;
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; NotifyOfPropertyChange(() => LastEditDate); }
        }
        
        private PostType postType;
        [JsonProperty("post_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostType PostType
        {
            get { return postType; }
            set { postType = value; NotifyOfPropertyChange(() => PostType); }
        }

        private int postId;
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; NotifyOfPropertyChange(() => PostId); }
        }

        private ShallowUser owner;
        [JsonProperty("owner")]
        public ShallowUser Owner
        {
            get { return owner; }
            set { owner = value; NotifyOfPropertyChange(() => Owner); }
        }

        private ShallowUser replyTo;
        [JsonProperty("reply_to_user")]
        public ShallowUser ReplyTo
        {
            get { return replyTo; }
            set { replyTo = value; NotifyOfPropertyChange(() => ReplyTo); }
        }

        private int score;
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; NotifyOfPropertyChange(() => Score); }
        }

        private int upVoteCount;
        [JsonProperty("up_vote_count")]
        public int UpVoteCount
        {
            get { return upVoteCount; }
            set { upVoteCount = value; NotifyOfPropertyChange(() => UpVoteCount); }
        }

        private int downVoteCount;
        [JsonProperty("down_count_vote")]
        public int DownVoteCount
        {
            get { return downVoteCount; }
            set { downVoteCount = value; NotifyOfPropertyChange(() => DownVoteCount); }
        }

        private List<Comment> comments = new List<Comment>();
        [JsonProperty("comments")]
        public List<Comment> Comments
        {
            get { return comments; }
            set { comments = value; NotifyOfPropertyChange(() => Comments); }
        }
    }
}