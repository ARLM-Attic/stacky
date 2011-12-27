﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<User> GetUsers()
        {
            return GetUsers(new UserOptions());
        }

        public virtual IPagedList<User> GetUsers(UserOptions options)
        {
            return GetUsers(options, null);
        }

        public virtual IPagedList<User> GetUsers(IEnumerable<int> userIds)
        {
            return GetUsers(userIds, new UserOptions());
        }

        public virtual IPagedList<User> GetUsers(IEnumerable<int> userIds, UserOptions options)
        {
            return GetUsers(options, new string[] { userIds.Vectorize() });
        }

        private IPagedList<User> GetUsers(UserOptions options, string[] urlParameters)
        {
            var response = MakeRequest<User>("users", urlParameters, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                min = options.Min ?? null,
                max = options.Max ?? null
            });
            return new PagedList<User>(response);
        }

        public virtual User GetUser(int userId)
        {
            return GetUsers(userId.ToArray()).FirstOrDefault();
        }

        public virtual IPagedList<Comment> GetUserMentions(int userId)
        {
            return GetUserMentions(userId, new UserMentionsOptions());
        }

        public virtual IPagedList<Comment> GetUserMentions(int userId, UserMentionsOptions options)
        {
            return GetUserMentions(userId.ToArray(), options);
        }

        public virtual IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds)
        {
            return GetUserMentions(userIds, new UserMentionsOptions());
        }

        public virtual IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds, UserMentionsOptions options)
        {
            var response = MakeRequest<Comment>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                min = options.Min ?? null,
                max = options.Max ?? null
            });
            return new PagedList<Comment>(response);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(int userId)
        {
            return GetUserTimeline(userId, new UserTimelineOptions());
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(int userId, UserTimelineOptions options)
        {
            return GetUserTimeline(userId.ToArray(), options);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(IEnumerable<int> userIds)
        {
            return GetUserTimeline(userIds, new UserTimelineOptions());
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(IEnumerable<int> userIds, UserTimelineOptions options)
        {
            var response = MakeRequest<UserEvent>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                site = this.SiteUrlName,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null
            });
            return new PagedList<UserEvent>(response);
        }

        public virtual IPagedList<Reputation> GetUserReputation(int userId)
        {
            return GetUserReputation(userId, new ReputationOptions());
        }

        public virtual IPagedList<Reputation> GetUserReputation(int userId, ReputationOptions options)
        {
            return GetUserReputation(userId.ToArray(), options);
        }

        public virtual IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds)
        {
            return GetUserReputation(userIds, new ReputationOptions());
        }

        public virtual IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds, ReputationOptions options)
        {
            var response = MakeRequest<Reputation>("users", new string[] { userIds.Vectorize(), "reputation" }, new
            {
                site = this.SiteUrlName,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null
            });
            return new PagedList<Reputation>(response);
        }

        public virtual IPagedList<User> GetModerators()
        {
            return GetModerators(new UserOptions());
        }

        public virtual IPagedList<User> GetModerators(UserOptions options)
        {
            return GetUsers(options, new string[] { "moderators" });
        }
    }
}