using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/event
    /// </summary>
    public class Event : Entity
    {
        private EventType type;
        [JsonProperty("event_type")]
        public EventType Type
        {
            get { return type; }
            set { type = value; NotifyOfPropertyChange(() => Type); }
        }

        private int id;
        [JsonProperty("event_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private string link;
        [JsonProperty("link")]
        public string Link
        {
            get { return link; }
            set { link = value; NotifyOfPropertyChange(() => Link); }
        }

        private string excerpt;
        [JsonProperty("excerpt")]
        public string Excerpt
        {
            get { return excerpt; }
            set { excerpt = value; NotifyOfPropertyChange(() => Excerpt); }
        }
    }
}