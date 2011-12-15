namespace Stacky
{
    using Newtonsoft.Json;

    public class TagScore : Entity
    {
        private ShallowUser user;
        [JsonProperty("user")]
        public ShallowUser User
        {
            get { return user; }
            set { user = value; NotifyOfPropertyChange(() => User); }
        }

        private int score;
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; NotifyOfPropertyChange(() => Score); }
        }

        private int postCount;
        [JsonProperty("post_count")]
        public int PostCount
        {
            get { return postCount; }
            set { postCount = value; NotifyOfPropertyChange(() => PostCount); }
        }
    }
}