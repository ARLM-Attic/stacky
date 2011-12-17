using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments
        /// </summary>
        public IPagedList<Comment> GetComments(CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("comments", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public IPagedList<Comment> GetComments(int id, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetComments(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public IPagedList<Comment> GetComments(IEnumerable<int> ids, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("comments", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}