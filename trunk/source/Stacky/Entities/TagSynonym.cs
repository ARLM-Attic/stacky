using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/tag-synonym
    /// </summary>
    public class TagSynonym : Entity
    {
        /// <summary>
        /// Gets or sets the from tag.
        /// </summary>
        private string fromTag;
        [JsonProperty("from_tag")]
        public string FromTag
        {
            get { return fromTag; }
            set { fromTag = value; NotifyOfPropertyChange(() => FromTag); }
        }

        /// <summary>
        /// Gets or sets the to tag.
        /// </summary>
        private string toTag;
        [JsonProperty("to_tag")]
        public string ToTag
        {
            get { return toTag; }
            set { toTag = value; NotifyOfPropertyChange(() => ToTag); }
        }

        /// <summary>
        /// Gets or sets the applied count
        /// </summary>
        private int appliedCount;
        [JsonProperty("applied_count")]
        public int AppliedCount
        {
            get { return appliedCount; }
            set { appliedCount = value; NotifyOfPropertyChange(() => AppliedCount); }
        }

        /// <summary>
        /// Gets or sets the last applied date
        /// </summary>
        private DateTime lastAppliedDate;
        [JsonProperty("last_applied_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastAppliedDate
        {
            get { return lastAppliedDate; }
            set { lastAppliedDate = value; NotifyOfPropertyChange(() => LastAppliedDate); }
        }

        /// <summary>
        /// Gets or sets the creation date
        /// </summary>
        private DateTime creationDate;
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }
    }
}
