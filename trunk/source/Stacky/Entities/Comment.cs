using System;
using Newtonsoft.Json;

namespace Stacky
{
    public class Comment : Entity
    {
        private int id;
        [JsonProperty("comment_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

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

        private int score;
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; NotifyOfPropertyChange(() => Score); }
        }

        private bool edited;
        [JsonProperty("edited")]
        public bool Edited
        {
            get { return edited; }
            set { edited = value; NotifyOfPropertyChange(() => Edited); }
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
    }
}