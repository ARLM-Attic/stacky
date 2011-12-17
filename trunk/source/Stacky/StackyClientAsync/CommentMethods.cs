using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments
        /// </summary>
        public void GetComments(Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, 
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("comments", null,
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetComments(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("comments", new string[] { ids.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}