using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/user-timeline
    /// </summary>
    public class UserTimeline : Entity
    {
        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private PostType postType;
        [JsonProperty("post_type")]
        public PostType PostType
        {
            get { return postType; }
            set { postType = value; NotifyOfPropertyChange(() => PostType); }
        }

        private TimelineType timelineType;
        [JsonProperty("timeline_type")]
        public TimelineType TimelineType
        {
            get { return timelineType; }
            set { timelineType = value; NotifyOfPropertyChange(() => TimelineType); }
        }

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

        private int commentId;
        [JsonProperty("comment_id")]
        public int CommentId
        {
            get { return commentId; }
            set { commentId = value; NotifyOfPropertyChange(() => CommentId); }
        }

        private int suggestedEditId;
        [JsonProperty("suggested_edit_id")]
        public int SuggestedEditId
        {
            get { return suggestedEditId; }
            set { suggestedEditId = value; NotifyOfPropertyChange(() => SuggestedEditId); }
        }

        private int badgeId;
        [JsonProperty("badge_id")]
        public int BadgeId
        {
            get { return badgeId; }
            set { badgeId = value; NotifyOfPropertyChange(() => BadgeId); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        private string detail;
        [JsonProperty("detail")]
        public string Detail
        {
            get { return detail; }
            set { detail = value; NotifyOfPropertyChange(() => Detail); }
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