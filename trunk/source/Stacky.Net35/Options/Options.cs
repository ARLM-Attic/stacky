namespace Stacky
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Options
    {
        public int? Page = null;
        public int? PageSize = null;
        public string Filter = null;
    }

    //int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null
    public class OptionsWithDates : Options
    {   
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
    }

    public class Options<TSort, TMaxMin> : OptionsWithDates
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

    public class TaggedOptions<TSort> : Options<TSort>
        where TSort : struct
    {
        public IEnumerable<string> Tagged = null;

        public string GetListValue(IEnumerable<string> items)
        {
            if (items == null || items.Count() == 0)
                return null;
            return String.Join(";", items.ToArray());
        }
    }

    public class TopAnswerOptions
    {
        public int? Page = null;
        public int? PageSize = null;
        public AnswerTimePeriod Period = AnswerTimePeriod.AllTime;
        public string Filter = null;
    }
}