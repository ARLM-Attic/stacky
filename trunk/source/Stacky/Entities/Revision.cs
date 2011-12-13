using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="Question"/> or <see cref="Answer"/> revision.
    /// </summary>
    public class Revision : Entity
    {
        private Guid revisionGuid;
        [JsonProperty("revision_guid")]
        public Guid RevisionGuid
        {
            get { return revisionGuid; }
            set { revisionGuid = value; NotifyOfPropertyChange(() => RevisionGuid); }
        }

        private int revisionNumber;
        [JsonProperty("revision_number")]
        public int RevisionNumber
        {
            get { return revisionNumber; }
            set { revisionNumber = value; NotifyOfPropertyChange(() => RevisionNumber); }
        }

        private RevisionType revisionType;
        [JsonProperty("revision_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RevisionType RevisionType
        {
            get { return revisionType; }
            set { revisionType = value; NotifyOfPropertyChange(() => RevisionType); }
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

        private bool isRollback;
        [JsonProperty("is_rollback")]
        public bool IsRollback
        {
            get { return isRollback; }
            set { isRollback = value; NotifyOfPropertyChange(() => IsRollback); }
        }

        private string lastBody;
        [JsonProperty("last_body")]
        public string LastBody
        {
            get { return lastBody; }
            set { lastBody = value; NotifyOfPropertyChange(() => LastBody); }
        }

        private string body;
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        private bool setCommunityWiki;
        [JsonProperty("set_community_wiki")]
        public bool SetCommunityWiki
        {
            get { return setCommunityWiki; }
            set { setCommunityWiki = value; NotifyOfPropertyChange(() => SetCommunityWiki); }
        }

        private ShallowUser user;
        [JsonProperty("user")]
        public ShallowUser User
        {
            get { return user; }
            set { user = value; NotifyOfPropertyChange(() => User); }
        }

        private List<string> lastTags = new List<string>();
        [JsonProperty("last_tags")]
        public List<string> LastTags
        {
            get { return lastTags; }
            set { lastTags = value; NotifyOfPropertyChange(() => LastTags); }
        }

        private List<string> tags = new List<string>();
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; NotifyOfPropertyChange(() => Tags); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        private string lastTitle;
        [JsonProperty("last_title")]
        public string LastTitle
        {
            get { return lastTitle; }
            set { lastTitle = value; NotifyOfPropertyChange(() => LastTitle); }
        }
    }
}