using System.Collections.Generic;
using System;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Badge> GetBadges(BadgeSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromdate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null)
        {
            var response = MakeRequest<Badge>("badges", null, new
            {
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromDate = GetDateValue(fromdate),
                toDate = GetDateValue(toDate),
                min = GetEnumValue(min),
                max = GetEnumValue(max)
            });
            return new PagedList<Badge>(response);
        }

        private IEnumerable<Badge> GetBadges(string method, string[] urlArguments)
        {
            return MakeRequest<Badge>(method, urlArguments, new
            {
                site = this.SiteUrlName,
            }).Items;
        }

        public virtual IEnumerable<User> GetUsersByBadge(int badgeId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUsersByBadge(badgeId.ToArray(), page, pageSize, fromDate, toDate);
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> badgeIds, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<User>("badges", new string[] { badgeIds.Vectorize() }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<User>(response);
        }

        public virtual IEnumerable<Badge> GetTagBasedBadges()
        {
            return GetBadges("badges", new string[] { "tags" });
        }

        public virtual IEnumerable<Badge> GetUserBadges(int userId)
        {
            return GetUserBadges(userId.ToArray());
        }

        public virtual IEnumerable<Badge> GetUserBadges(IEnumerable<int> userIds)
        {
            return MakeRequest<Badge>("users", new string[] { userIds.Vectorize(), "badges" }, new
            {
                site = this.SiteUrlName
            }).Items;
        }
    }
}