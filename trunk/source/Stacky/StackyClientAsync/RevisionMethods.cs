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
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevisions(IEnumerable<string> ids, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<Revision>("revisions", new string[] { ids.Vectorize() },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevisions(IEnumerable<Guid> ids, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetRevisions(ids.Select(i => i.ToString()), onSuccess, onError, page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevision(string id, Action<Revision> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetRevisions(new string[] { id }, items => onSuccess(items.FirstOrDefault()), onError, page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevision(Guid id, Action<Revision> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetRevisions(new string[] { id.ToString() }, items => onSuccess(items.FirstOrDefault()), onError, page, pageSize, fromDate, toDate, filter);
        }
    }
}