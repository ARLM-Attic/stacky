namespace Stacky
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Response<T>
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("pagesize")]
        public int PageSize { get; set; }

        public ResponseError Error { get; set; }
        public List<T> Items { get; set; }
    }
}