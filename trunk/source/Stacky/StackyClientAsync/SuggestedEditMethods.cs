using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits
        /// </summary>
        public void GetSuggestedEdits(Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError = null,
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<SuggestedEdit>("suggested-edits", null,
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public void GetSuggestedEdits(IEnumerable<int> ids, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError = null,
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<SuggestedEdit>("suggested-edits", new string[] { ids.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public void GetSuggestedEdit(int id, Action<SuggestedEdit> onSuccess, Action<ApiException> onError = null,
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetSuggestedEdits(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}