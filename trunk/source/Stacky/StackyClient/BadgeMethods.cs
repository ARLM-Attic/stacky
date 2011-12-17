using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Badge> GetBadges(BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
			return Execute<Badge, BadgeMinMax>("badges", null,
				sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

		public virtual Badge GetBadge(int id, string filter = null)
		{
			return GetBadges(id.ToArray(), filter: filter).FirstOrDefault();
		}

		public virtual IPagedList<Badge> GetBadges(IEnumerable<int> ids, BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
		{
			ValidateVectorizedParameters(ids);
			return Execute<Badge>("badges", new string[] { ids.Vectorize() },
				sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
		}

		public virtual IPagedList<Badge> GetNamedBadges(BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
		{
			return Execute<Badge, BadgeMinMax>("badges", new string[] { "name" },
				sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
		}

		public virtual IPagedList<Badge> GetRecentlyAwardedBadges(int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
		{
			return Execute<Badge, BadgeMinMax>("badges", new string[] { "recipients" },
				null, null, page, pageSize, fromDate, toDate, null, null, filter);
		}

		public virtual IPagedList<Badge> GetRecentlyAwardedBadges(int id, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
		{
			return GetRecentlyAwardedBadges(id.ToArray(), page, pageSize, fromDate, toDate, filter);
		}

		public virtual IPagedList<Badge> GetRecentlyAwardedBadges(IEnumerable<int> ids, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
		{
			ValidateVectorizedParameters(ids);
			return Execute<Badge, BadgeMinMax>("badges", new string[] { ids.Vectorize(), "recipients" },
				null, null, page, pageSize, fromDate, toDate, null, null, filter);
		}

		public virtual IPagedList<Badge> GetTagBasedBadges(BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
		{
			return Execute<Badge, BadgeMinMax>("badges", new string[] { "tags" },
				sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
		}
    }
}