namespace Stacky
{
    using System.Collections.Generic;

    public interface IPagedList<T> : IEnumerable<T>
    {
        int TotalItems { get; }
        int CurrentPage { get; }
        int PageSize { get; }
        int Count { get; }
    }
}