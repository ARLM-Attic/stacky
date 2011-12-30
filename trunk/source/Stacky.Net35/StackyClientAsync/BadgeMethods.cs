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
        public void GetBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, Options<BadgeSort, BadgeMinMax> options)
        {
            Execute<Badge, BadgeMinMax>("badges", null, onSuccess, onError, options);
        }

        public void GetBadge(int id, Action<Badge> onSuccess, Action<ApiException> onError, string filter)
        {
            GetBadges(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, new OptionsWithDates { Filter = filter });
        }

        public void GetBadges(IEnumerable<int> ids, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<Badge>("badges", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        public void GetNamedBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, Options<BadgeSort, BadgeMinMax> options)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { "name" }, onSuccess, onError, options);
        }

        public void GetRecentlyAwardedBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { "recipients" }, onSuccess, onError, options);
        }

        public void GetRecentlyAwardedBadges(int id, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetRecentlyAwardedBadges(id.ToArray(), onSuccess, onError, options);
        }

        public void GetRecentlyAwardedBadges(IEnumerable<int> ids, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { ids.Vectorize(), "recipients" }, onSuccess, onError, options);
        }

        public void GetTagBasedBadges(Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, Options<BadgeSort, BadgeMinMax> options)
        {
            Execute<Badge, BadgeMinMax>("badges", new string[] { "tags" }, onSuccess, onError, options);
        }
    }
}