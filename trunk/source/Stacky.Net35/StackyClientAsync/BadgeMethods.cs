﻿using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public virtual void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError)
        {
            GetBadges(onSuccess, onError, "badges", null);
        }

        private void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError, string method, string[] urlArguments)
        {
            MakeRequest<Badge>(method, urlArguments, new
            {
                site = this.SiteUrlName
            }, (items) => onSuccess(items.Items), onError);
        }

        public virtual void GetUsersByBadge(int userId, Action<IPagedList<User>> onSuccess, Action<ApiException> onError)
        {
            GetUsersByBadge(userId, onSuccess, onError, new BadgeByUserOptions());
        }

        public virtual void GetUsersByBadge(int userId, Action<IPagedList<User>> onSuccess, Action<ApiException> onError, BadgeByUserOptions options)
        {
            GetUsersByBadge(userId.ToArray(), onSuccess, onError, options);
        }

        public virtual void GetUsersByBadge(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null)
        {
            GetUsersByBadge(userIds, onSuccess, onError, new BadgeByUserOptions());
        }

        public virtual void GetUsersByBadge(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError, BadgeByUserOptions options)
        {
            MakeRequest<User>("badges", new string[] { userIds.Vectorize(), "badges" }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
            }, (items) => onSuccess(new PagedList<User>(items)), onError);
        }

        public virtual void GetTagBasedBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
        {
            GetBadges(onSuccess, onError, "badges", new string[] { "tags" });
        }
    }
}