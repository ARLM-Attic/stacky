#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace Stacky
{
    public class JsonPayload<T> : IPayload<T>
        where T : new()
    {
        public ResponseError Error { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }

        public Response<T> Data { get; set; }

        public JsonPayload()
        {
        }

        public JsonPayload(string json)
        {
            Parse(json, this);
        }

        protected static void Parse<T>(string json, JsonPayload<T> response)
           where T : new()
        {
            response.Body = json;
            if (json.Contains("\"error\":"))
            {
                //TODO: parse errors
                //response.Error = SerializationHelper.DeserializeJson<ErrorResponse>(json).Error;
                return;
            }
            response.Data = SerializationHelper.DeserializeJson<Response<T>>(json);
        }
    }
}