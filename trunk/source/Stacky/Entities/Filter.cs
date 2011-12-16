using System.Collections.Generic;
namespace Stacky
{
    using Newtonsoft.Json;

    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/filter
    /// </summary>
    public class Filter : Entity
    {
        private string text;
        [JsonProperty("filter")]
        public string Text
        {
            get { return text; }
            set { text = value; NotifyOfPropertyChange(() => Text); }
        }

        private List<string> includedFields;
        [JsonProperty("included_fields")]
        public List<string> IncludedFields
        {
            get { return includedFields; }
            set { includedFields = value; NotifyOfPropertyChange(() => IncludedFields); }
        }

        private FilterType filterType;
        [JsonProperty("filter_type")]
        public FilterType Type
        {
            get { return filterType; }
            set { filterType = value; NotifyOfPropertyChange(() => Type); }
        }
    }
}