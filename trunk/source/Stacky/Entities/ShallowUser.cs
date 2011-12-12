namespace Stacky
{
    using System;
    using Newtonsoft.Json;

    public class ShallowUser : Entity
    {
        #region Fields

        private int id;
        private string displayName;
        private int reputation;
        private UserType type;
        private string link;
        private string profileImage;

        #endregion

        [JsonProperty("user_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        [JsonProperty("display_name")]
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; NotifyOfPropertyChange(() => DisplayName); }
        }

        [JsonProperty("reputation")]
        public int Reputation
        {
            get { return reputation; }
            set { reputation = value; NotifyOfPropertyChange(() => Reputation); }
        }

        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type
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

        [JsonProperty("profile_image")]
        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; NotifyOfPropertyChange(() => ProfileImage); }
        }
    }
}
