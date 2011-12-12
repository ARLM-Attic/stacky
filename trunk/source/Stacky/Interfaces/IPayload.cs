namespace Stacky
{
    public interface IPayload<T>
        where T : new()
    {
        string Body { get; }
        ResponseError Error { get; }
        string Method { get; }
        Response<T> Data { get; set; }
    }
}