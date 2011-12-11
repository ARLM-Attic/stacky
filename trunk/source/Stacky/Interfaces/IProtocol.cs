namespace Stacky
{
    public interface IProtocol
    {
        IPayload<T> GetResponse<T>(string message) where T : new();
    }
}