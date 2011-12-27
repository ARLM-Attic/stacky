using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IEnumerable<Badge> GetBadges()
        {
            return GetBadges("badges", null);
        }

        private IEnumerable<Badge> GetBadges(string method, string[] urlArguments)
        {
            return MakeRequest<Badge>(method, urlArguments, new
            {
                site = this.SiteUrlName
            }).Items;
        }

        public virtual IEnumerable<User> GetUsersByBadge(int badgeId)
        {
            return GetUsersByBadge(badgeId, new BadgeByUserOptions());
        }

        public virtual IEnumerable<User> GetUsersByBadge(int badgeId, BadgeByUserOptions options)
        {
            return GetUsersByBadge(badgeId.ToArray(), options);
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> badgeIds)
        {
            return GetUsersByBadge(badgeIds, new BadgeByUserOptions());
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> badgeIds, BadgeByUserOptions options)
        {
            var response = MakeRequest<User>("badges", new string[] { badgeIds.Vectorize() }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
            });
            return new PagedList<User>(response);
        }

        public virtual IEnumerable<Badge> GetTagBasedBadges()
        {
            return GetBadges("badges", new string[] { "tags" });
        }
    }
}