namespace Stacky
{
    using System;

    //int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null
    public class Options
    {
        public int? Page = null;
        public int? PageSize = null;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public string Filter = null;
    }

    public class Options<TSort, TMaxMin> : Options
        where TSort : struct
        where TMaxMin : struct
    {
        public TSort? SortBy = null;
        public SortDirection? SortDirection = null;
        public TMaxMin? Min = null;
        public TMaxMin? Max = null;
    }

    public class Options<TSort> : Options<TSort, DateTime>
        where TSort : struct
    {
    }
}