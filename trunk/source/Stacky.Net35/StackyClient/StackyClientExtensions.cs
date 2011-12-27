using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        protected IPagedList<TEntity> Execute<TEntity, TSort>(string methodName, string[] urlArguments, Options<TSort, DateTime> options)
            where TEntity : Entity, new()
            where TSort : struct
        {
            var response = MakeRequest<TEntity>(methodName, urlArguments, new
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
            });
            return new PagedList<TEntity>(response);
        }

        protected IPagedList<TEntity> Execute<TEntity, TSort, TMinMax>(string methodName, string[] urlArguments, Options<TSort, TMinMax> options)
            where TEntity : Entity, new()
            where TSort : struct
            where TMinMax : struct
        {
            var response = MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = options.Min ?? null,
                max = options.Max ?? null,
                filter = options.Filter
            });
            return new PagedList<TEntity>(response);
        }
    }
}
