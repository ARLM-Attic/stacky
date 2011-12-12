namespace Stacky
{
    using System.Collections.Generic;

    public class PagedList<T> : IPagedList<T>
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }

        public int Count
        {
            get
            {
                if (Items == null)
                    return 0;
                return Items.Count;
            }
        }

        public PagedList(IEnumerable<T> items)
        {
            Items = new List<T>(items);
        }

        public PagedList(Response<T> response)
            : this(response.Items, response)
        {
        }

        private PagedList(IEnumerable<T> items, Response<T> response)
            : this(items)
        {
            TotalItems = response.Total;
            CurrentPage = response.CurrentPage;
            PageSize = response.PageSize;
        }

        protected List<T> Items { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)Items).GetEnumerator();
        }
    }
}