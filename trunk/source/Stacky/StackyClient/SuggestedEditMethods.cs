using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits
        /// </summary>
        public IPagedList<SuggestedEdit> GetSuggestedEdits(SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<SuggestedEdit>("suggested-edits", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public IPagedList<SuggestedEdit> GetSuggestedEdits(IEnumerable<int> ids, SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<SuggestedEdit>("suggested-edits", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public SuggestedEdit GetSuggestedEdit(int id, SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetSuggestedEdits(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }
    }
}