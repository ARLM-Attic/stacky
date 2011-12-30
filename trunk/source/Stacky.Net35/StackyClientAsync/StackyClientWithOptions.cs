using System;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient : StackyClientBase
#else
    public partial class StackyClientAsync : StackyClientBase
#endif
    {
        protected void Execute<TEntity, TMinMax>(string methodName, string[] urlArguments,
            Action<IPagedList<TEntity>> onSuccess,
            Action<ApiException> onError,
            Options options)
            where TEntity : Entity, new()
            where TMinMax : struct
        {
            MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, (response) => onSuccess(new PagedList<TEntity>(response)), onError);
        }

        protected void Execute<TEntity>(string methodName, string[] urlArguments,
            Action<IPagedList<TEntity>> onSuccess,
            Action<ApiException> onError,
            OptionsWithDates options)
            where TEntity : Entity, new()
        {
            MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                filter = options.Filter
            }, (response) => onSuccess(new PagedList<TEntity>(response)), onError);
        }

        protected void Execute<TEntity, TSort, TMinMax>(string methodName, string[] urlArguments,
            Action<IPagedList<TEntity>> onSuccess,
            Action<ApiException> onError,
            Options<TSort, TMinMax> options)
            where TEntity : Entity, new()
            where TSort : struct
            where TMinMax : struct
        {
            MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = options.Min,
                max = options.Max,
                filter = options.Filter
            }, (response) => onSuccess(new PagedList<TEntity>(response)), onError);
        }

        protected void Execute<TEntity, TSort>(string methodName, string[] urlArguments,
            Action<IPagedList<TEntity>> onSuccess,
            Action<ApiException> onError,
            Options<TSort> options)
            where TEntity : Entity, new()
            where TSort : struct
        {
            MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = GetDateValue(options.Min),
                max = GetDateValue(options.Max),
                filter = options.Filter
            }, (response) => onSuccess(new PagedList<TEntity>(response)), onError);
        }
    }
}