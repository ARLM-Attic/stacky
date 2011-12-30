namespace Stacky
{
    using Newtonsoft.Json;

    public class Error : Entity
    {
        private int id;
        [JsonProperty("error_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        private string name;
        [JsonProperty("error_name")]
        public string Name
        {
            get { return name; }
            set { name = value; NotifyOfPropertyChange(() => Name); }
        }

        private string description;
        [JsonProperty("description")]
        public string Description
        {
            get { return description; }
            set { description = value; NotifyOfPropertyChange(() => Description); }
        }
    }
}