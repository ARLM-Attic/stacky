using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Badge> GetBadges()
        {
            return GetBadges(null);
        }

        public virtual IPagedList<Badge> GetBadges(Options<BadgeSort, BadgeMinMax> options)
        {
            return Execute<Badge, BadgeMinMax>("badges", null, options);
        }

        public virtual Badge GetBadge(int id)
        {
            return GetBadge(id, null);
        }

        public virtual Badge GetBadge(int id, string filter)
        {
            var options = new Options<BadgeSort, BadgeMinMax>
            {
                Filter = filter
            };
            return GetBadges(id.ToArray(), options).FirstOrDefault();
        }

        public virtual IPagedList<Badge> GetBadges(IEnumerable<int> ids, Options<BadgeSort, BadgeMinMax> options)
        {
            return Execute<Badge, BadgeSort, BadgeMinMax>("badges", new string[] { ids.Vectorize() }, options);
        }

        public virtual IPagedList<Badge> GetNamedBadges()
        {
            return GetNamedBadges(null);
        }

        public virtual IPagedList<Badge> GetNamedBadges(Options<BadgeSort, BadgeMinMax> options)
        {
            return Execute<Badge, BadgeMinMax>("badges", new string[] { "name" }, options);
        }

        public virtual IPagedList<Badge> GetRecentlyAwardedBadges(Options options)
        {
            return Execute<Badge, BadgeMinMax>("badges", new string[] { "recipients" }, options);
        }

        public virtual IPagedList<Badge> GetRecentlyAwardedBadges(int id, Options options)
        {
            return GetRecentlyAwardedBadges(id.ToArray(), options);
        }

        public virtual IPagedList<Badge> GetRecentlyAwardedBadges(IEnumerable<int> ids, Options options)
        {
            return Execute<Badge, BadgeMinMax>("badges", new string[] { ids.Vectorize(), "recipients" }, options);
        }

        public virtual IPagedList<Badge> GetTagBasedBadges(Options<BadgeSort, BadgeMinMax> options)
        {
            return Execute<Badge, BadgeMinMax>("badges", new string[] { "tags" }, options);
        }
    }
}