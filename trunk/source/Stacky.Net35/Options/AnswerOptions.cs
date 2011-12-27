using System;

namespace Stacky
{
    public class OptionsBase
    {
        public int? Page = null;
        public int? PageSize = null;
        public string Filter = null;
    }

    public class Options<TSort, TMaxMin>
        where TSort : struct
        where TMaxMin : struct
    {
        public TSort? SortBy = null;
        public SortDirection? SortDirection = null;
        public int? Page = null;
        public int? PageSize = null;
        public UnixDateTime? FromDate = null;
        public UnixDateTime? ToDate = null;
        public TMaxMin? Min = null;
        public TMaxMin? Max = null;
        public string Filter = null;
    }

    public class Options<TSort> : Options<TSort, UnixDateTime>
        where TSort : struct
    {
    }

    public class AnswerOptions
    {
        public AnswerSort SortBy = AnswerSort.Creation;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public bool IncludeBody = false;
        public bool IncludeComments = false;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public int? Min = null;
        public int? Max = null;
    }
}