namespace Stacky
{
    using Newtonsoft.Json;

    public class ErrorResponse
    {
        [JsonProperty("error")]
        public ResponseError Error { get; set; }
    }
}