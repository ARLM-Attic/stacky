using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stacky
{
    public class SuggestedEdit : Entity
    {
        private int id;
        [JsonProperty("suggested_edit_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        private int postId;
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; NotifyOfPropertyChange(() => PostId); }
        }

        private PostType postType;
        [JsonProperty("post_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostType PostType
        {
            get { return postType; }
            set { postType = value; NotifyOfPropertyChange(() => PostType); }
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

        private string comment;
        [JsonProperty("comment")]
        public string Comment
        {
            get { return comment; }
            set { comment = value; NotifyOfPropertyChange(() => Comment); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private DateTime approvalDate;
        [JsonProperty("approval_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ApprovalDate
        {
            get { return approvalDate; }
            set { approvalDate = value; NotifyOfPropertyChange(() => ApprovalDate); }
        }

        private DateTime rejectionDate;
        [JsonProperty("rejection_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime RejectionDate
        {
            get { return rejectionDate; }
            set { rejectionDate = value; NotifyOfPropertyChange(() => RejectionDate); }
        }

        private ShallowUser proposingUser;
        [JsonProperty("proposing_user")]
        public ShallowUser ProposingUser
        {
            get { return proposingUser; }
            set { proposingUser = value; NotifyOfPropertyChange(() => ProposingUser); }
        }
    }
}
