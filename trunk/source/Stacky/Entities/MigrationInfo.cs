using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents information regarding a question which
    /// has been migrated from one site to another
    /// </summary>
    public class MigrationInfo : Entity
    {
        private int questionId;
        [JsonProperty("question_id")]
        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; NotifyOfPropertyChange(() => QuestionId); }
        }

        private Site otherSite;
        [JsonProperty("other_site")]
        public Site OtherSite
        {
            get { return otherSite; }
            set { otherSite = value; NotifyOfPropertyChange(() => OtherSite); }
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