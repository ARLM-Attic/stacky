using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Comment> GetComments(CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            var response = MakeRequest<Comment>("comments", null, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                filter = filter
            });
            return new PagedList<Comment>(response);
        }

        public virtual IPagedList<Comment> GetComments(int id, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetComments(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public virtual IPagedList<Comment> GetComments(IEnumerable<int> ids, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            var response = MakeRequest<Comment>("comments", new string[] { ids.Vectorize() }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                filter = filter
            });
            return new PagedList<Comment>(response);
        }
    }
}