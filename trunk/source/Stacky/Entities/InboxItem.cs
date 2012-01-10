namespace Stacky
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/inbox-item
    /// </summary>
    public class InboxItem : Entity
    {
        private InboxItemType itemType;
        [JsonProperty("item_type")]
        public InboxItemType ItemType
        {
            get { return itemType; }
            set { itemType = value; NotifyOfPropertyChange(() => ItemType); }
        }

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

        private int commentId;
        [JsonProperty("comment_id")]
        public int CommentId
        {
            get { return commentId; }
            set { commentId = value; NotifyOfPropertyChange(() => CommentId); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private bool isUnread;
        [JsonProperty("is_unread")]
        public bool IsUnread
        {
            get { return isUnread; }
            set { isUnread = value; NotifyOfPropertyChange(() => IsUnread); }
        }

        private Site site;
        [JsonProperty("site")]
        public Site Site
        {
            get { return site; }
            set { site = value; NotifyOfPropertyChange(() => Site); }
        }

        private string body;
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
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