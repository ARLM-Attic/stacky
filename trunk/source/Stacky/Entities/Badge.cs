using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stacky
{
    /// <summary>
    /// Represents a badge.
    /// </summary>
    public class Badge : Entity
    {
        private int id;
        private BadgeClass rank;
        private string name;
        private string description;
        private int awardCount;
        private BadgeType type;
        private string link;
        private ShallowUser user;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("badge_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        /// <summary>
        /// Gets or sets the <see cref="BadgeClass"/>.
        /// </summary>
        /// <value>The BadgeClass.</value>
        [JsonProperty("rank"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public BadgeClass Rank
        {
            get { return rank; }
            set { rank = value; NotifyOfPropertyChange(() => Rank); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Badge"/> name.
        /// </summary>
        /// <value>The <see cref="Badge"/> name.</value>
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; NotifyOfPropertyChange(() => Name); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Badge"/> description.
        /// </summary>
        /// <value>The <see cref="Badge"/> description.</value>
        [JsonProperty("description")]
        public string Description
        {
            get { return description; }
            set { description = value; NotifyOfPropertyChange(() => Description); }
        }

        /// <summary>
        /// Gets or sets the award count of this <see cref="Badge"/>.
        /// </summary>
        /// <value>The award count of this <see cref="Badge"/>.</value>
        [JsonProperty("award_count")]
        public int AwardCount
        {
            get { return awardCount; }
            set { awardCount = value; NotifyOfPropertyChange(() => AwardCount); }
        }

        [JsonProperty("badge_type"), JsonConverter(typeof(StringEnumConverter))]
        public BadgeType Type
        {
            get { return type; }
            set { type = value; NotifyOfPropertyChange(() => Type); }
        }

        [JsonProperty("link")]
        public string Link
        {
            get { return link; }
            set { link = value; NotifyOfPropertyChange(() => Link); }
        }
    }
}