using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a tag.
    /// See: http://api.stackexchange.com/docs/types/tag
    /// </summary>
    public class Tag : Entity
    {
        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; NotifyOfPropertyChange(() => Name); }
        }

        private int count;
        [JsonProperty("count")]
        public int Count
        {
            get { return count; }
            set { count = value; NotifyOfPropertyChange(() => Count); }
        }

        private bool isRequired;
        [JsonProperty("is_required")]
        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; NotifyOfPropertyChange(() => IsRequired); }
        }

        private bool isModeratorOnly;
        [JsonProperty("is_moderator_only")]
        public bool IsModeratorOnly
        {
            get { return isModeratorOnly; }
            set { isModeratorOnly = value; NotifyOfPropertyChange(() => IsModeratorOnly); }
        }

        private int userid;
        [JsonProperty("user_id")]
        public int UserId
        {
            get { return userid; }
            set { userid = value; NotifyOfPropertyChange(() => UserId); }
        }
    }
}