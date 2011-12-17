using System;
using System.Linq;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public void GetBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null, 
            BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            Execute<Badge, BadgeMinMax>("badges", null,
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetBadge(int id, Action<Badge> onSuccess, Action<ApiException> onError = null, string filter = null)
        {
            GetBadges(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, filter: filter);
        }

        public void GetBadges(IEnumerable<int> ids, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null, BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Badge>("badges", new string[] { ids.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetNamedBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null,
            BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { "name" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetRecentlyAwardedBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { "recipients" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        public void GetRecentlyAwardedBadges(int id, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetRecentlyAwardedBadges(id.ToArray(), onSuccess, onError, page, pageSize, fromDate, toDate, filter);
        }

        public void GetRecentlyAwardedBadges(IEnumerable<int> ids, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { ids.Vectorize(), "recipients" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        public void GetTagBasedBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null, 
            BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { "tags" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}