using System;

namespace Stacky
{
    public class JsonProtocol : IProtocol
    {
        public IPayload<T> GetResponse<T>(string message) where T : new()
        {
            return new JsonPayload<T>(message);
        }
    }
}