using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/users
        /// </summary>
        public IPagedList<User> GetUsers(UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            return Execute<User, Int32>("users", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public IPagedList<User> GetUsers(IEnumerable<int> ids, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            return Execute<User, Int32>("users", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public User GetUser(int id, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            return GetUsers(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public IPagedList<Answer> GetUserAnswers(IEnumerable<int> ids, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Answer>("users", new string[] { ids.Vectorize(), "answers" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public IPagedList<Answer> GetUserAnswers(int id, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserAnswers(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public IPagedList<Badge> GetUserBadges(IEnumerable<int> ids, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            return Execute<Badge, BadgeMinMax>("users", new string[] { ids.Vectorize(), "badges" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public IPagedList<Badge> GetUserBadges(int id, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            return GetUserBadges(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public IPagedList<Comment> GetUserComments(IEnumerable<int> ids, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("users", new string[] { ids.Vectorize(), "comments" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public IPagedList<Comment> GetUserComments(int id, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserComments(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-by-users-to-user
        /// </summary>
        public IPagedList<Comment> GetUserCommentsTo(IEnumerable<int> fromIds, IEnumerable<int> toIds, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("users", new string[] { fromIds.Vectorize(), "comments", toIds.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}