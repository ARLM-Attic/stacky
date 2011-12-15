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
        /// TODO: Fix Sort
        public IPagedList<Comment> GetUserCommentsTo(IEnumerable<int> fromIds, IEnumerable<int> toIds, UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("users", new string[] { fromIds.Vectorize(), "comments", toIds.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserFavoriteQuestions(IEnumerable<int> userIds, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "favorites" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        public IPagedList<Question> GetUserFavoriteQuestions(int userId, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserFavoriteQuestions(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("users", new string[] { userIds.Vectorize(), "mentioned" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public IPagedList<Comment> GetUserMentions(int userId, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserMentions(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public IPagedList<Privilege> GetUserPrivileges(IEnumerable<int> userIds, int? page = null, int? pageSize = null, string filter = null)
        {
            return Execute<Privilege>("users", new string[] { userIds.Vectorize(), "privileges" },
                null, null, page, pageSize, null, null, null, null, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public IPagedList<Privilege> GetUserPrivileges(int userId, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserPrivileges(userId.ToArray(), page, pageSize, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestions(IEnumerable<int> userIds, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestions(int userId, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserQuestions(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestionsWithNoAnswers(IEnumerable<int> userIds, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "no-answers" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestionsWithNoAnswers(int userId, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserQuestionsWithNoAnswers(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnacceptedQuestions(IEnumerable<int> userIds, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unaccepted" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnacceptedQuestions(int userId, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserUnacceptedQuestions(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnansweredQuestions(IEnumerable<int> userIds, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unanswered" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users  
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnansweredQuestions(int userId, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserUnansweredQuestions(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users
        /// </summary>
        public IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return Execute<Reputation>("users", new string[] { userIds.Vectorize(), "reputation" },
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users 
        /// </summary>
        public IPagedList<Reputation> GetUserReputation(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetUserReputation(userId.ToArray(), page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users
        /// </summary>
        public IPagedList<SuggestedEdit> GetUserSuggestedEdits(IEnumerable<int> userIds, SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<SuggestedEdit>("users", new string[] { userIds.Vectorize(), "suggested-edits" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users 
        /// </summary>
        public IPagedList<SuggestedEdit> GetUserUnansweredQuestions(int userId, SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserSuggestedEdits(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public IPagedList<Tag> GetUserTags(IEnumerable<int> userIds, TagSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Tag>("users", new string[] { userIds.Vectorize(), "tags" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public IPagedList<Tag> GetUserTags(int userId, TagSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetUserTags(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}