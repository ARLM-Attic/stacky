using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/tag-wiki
    /// </summary>
    public class TagWiki : Entity
    {
        private string tagName;
        [JsonProperty("tag_name")]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; NotifyOfPropertyChange(() => TagName); }
        }

        private string body;
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        private string excerpt;
        [JsonProperty("excerpt")]
        public string Excerpt
        {
            get { return excerpt; }
            set { excerpt = value; NotifyOfPropertyChange(() => Excerpt); }
        }

        private DateTime bodyLastEditDate;
        [JsonProperty("body_last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime BodyLastEditDate
        {
            get { return bodyLastEditDate; }
            set { bodyLastEditDate = value; NotifyOfPropertyChange(() => BodyLastEditDate); }
        }

        private DateTime excerptLastEditDate;
        [JsonProperty("excerpt_last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ExcerptLastEditDate
        {
            get { return excerptLastEditDate; }
            set { excerptLastEditDate = value; NotifyOfPropertyChange(() => ExcerptLastEditDate); }
        }

        private ShallowUser lastBodyEditor;
        [JsonProperty("last_body_editor")]
        public ShallowUser LastBodyEditor
        {
            get { return lastBodyEditor; }
            set { lastBodyEditor = value; NotifyOfPropertyChange(() => LastBodyEditor); }
        }

        private ShallowUser lastExcerptEditor;
        [JsonProperty("last_excerpt_editor")]
        public ShallowUser LastExcerptEditor
        {
            get { return lastExcerptEditor; }
            set { lastExcerptEditor = value; NotifyOfPropertyChange(() => LastExcerptEditor); }
        }
    }
}