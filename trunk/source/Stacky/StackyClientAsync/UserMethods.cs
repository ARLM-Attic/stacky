using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/users
        /// </summary>
        public void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            Execute<User, Int32>("users", null,
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public void GetUsers(IEnumerable<int> ids, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            Execute<User, Int32>("users", new string[] { ids.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public void GetUser(int id, Action<User> onSuccess, Action<ApiException> onError = null, 
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            GetUsers(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public void GetUserAnswers(IEnumerable<int> ids, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Answer>("users", new string[] { ids.Vectorize(), "answers" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public void GetUserAnswers(int id, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, 
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserAnswers(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public void GetUserBadges(IEnumerable<int> ids, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            Execute<Badge, BadgeMinMax>("users", new string[] { ids.Vectorize(), "badges" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public void GetUserBadges(int id, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, BadgeMinMax? min = null, BadgeMinMax? max = null, string filter = null)
        {
            GetUserBadges(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public void GetUserComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("users", new string[] { ids.Vectorize(), "comments" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public void GetUserComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, 
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserComments(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-by-users-to-user
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserCommentsTo(IEnumerable<int> fromIds, IEnumerable<int> toIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("users", new string[] { fromIds.Vectorize(), "comments", toIds.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserFavoriteQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "favorites" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        public void GetUserFavoriteQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserFavoriteQuestions(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public void GetUserMentions(IEnumerable<int> userIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("users", new string[] { userIds.Vectorize(), "mentioned" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public void GetUserMentions(int userId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, 
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserMentions(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public void GetUserPrivileges(IEnumerable<int> userIds, Action<IPagedList<Privilege>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            Execute<Privilege>("users", new string[] { userIds.Vectorize(), "privileges" },
                onSuccess, onError,
                null, null, page, pageSize, null, null, null, null, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public void GetUserPrivileges(int userId, Action<IPagedList<Privilege>> onSuccess, Action<ApiException> onError = null, 
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserPrivileges(userId.ToArray(), onSuccess, onError, page, pageSize, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserQuestions(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestionsWithNoAnswers(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "no-answers" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestionsWithNoAnswers(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserQuestionsWithNoAnswers(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnacceptedQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unaccepted" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnacceptedQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserUnacceptedQuestions(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnansweredQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unanswered" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users  
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnansweredQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserUnansweredQuestions(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users
        /// </summary>
        public void GetUserReputation(IEnumerable<int> userIds, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<Reputation>("users", new string[] { userIds.Vectorize(), "reputation" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users 
        /// </summary>
        public void GetUserReputation(int userId, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetUserReputation(userId.ToArray(), onSuccess, onError, page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users
        /// </summary>
        public void GetUserSuggestedEdits(IEnumerable<int> userIds, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError = null,
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<SuggestedEdit>("users", new string[] { userIds.Vectorize(), "suggested-edits" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users 
        /// </summary>
        public void GetUserUnansweredQuestions(int userId, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError = null, 
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserSuggestedEdits(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public void GetUserTags(IEnumerable<int> userIds, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError = null,
            TagSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Tag>("users", new string[] { userIds.Vectorize(), "tags" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public void GetUserTags(int userId, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError = null, 
            TagSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserTags(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-answers-in-tags
        /// </summary>
        public void GetUserTopAnswersByTag(IEnumerable<int> userIds, IEnumerable<string> tags, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null,
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Answer>("users", new string[] { userIds.Vectorize(), "tags", tags.Vectorize(), "top-answers" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-answers-in-tags
        /// </summary>
        public void GetUserTopAnswersByTag(int userId, IEnumerable<string> tags, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, 
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserTopAnswersByTag(userId.ToArray(), tags, onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answer-tags-on-users
        /// </summary>
        public void GetUserTopAnswersByTag(IEnumerable<int> userIds, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            Execute<TopTag>("users", new string[] { userIds.Vectorize(), "top-answer-tags" },
                onSuccess, onError,
                null, null, page, pageSize, null, null, null, null, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answer-tags-on-users
        /// </summary>
        public void GetUserTopAnswersByTag(int userId, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, string filter = null)
        {
            GetUserTopAnswersByTag(userId.ToArray(), onSuccess, onError, page, pageSize, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-questions-in-tags
        /// </summary>
        public void GetUserTopQuestionsByTag(IEnumerable<int> userIds, IEnumerable<string> tags, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "tags", tags.Vectorize(), "top-questions" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-questions-in-tags
        /// </summary>
        public void GetUserTopQuestionsByTag(int userId, IEnumerable<string> tags, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetUserTopQuestionsByTag(userId.ToArray(), tags, onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-question-tags-on-users
        /// </summary>
        public void GetUserTopQuestionsByTag(IEnumerable<int> userIds, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            Execute<TopTag>("users", new string[] { userIds.Vectorize(), "top-question-tags" },
                onSuccess, onError,
                null, null, page, pageSize, null, null, null, null, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-question-tags-on-users
        /// </summary>
        public void GetUserTopQuestionsByTag(int userId, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, string filter = null)
        {
            GetUserTopQuestionsByTag(userId.ToArray(), onSuccess, onError, page, pageSize, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/timeline-on-users
        /// </summary>
        public void GetUserTimeline(IEnumerable<int> userIds, Action<IPagedList<UserTimeline>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<UserTimeline>("users", new string[] { userIds.Vectorize(), "timeline" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/timeline-on-users
        /// </summary>
        public void GetUserTimeline(int userId, Action<IPagedList<UserTimeline>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetUserTimeline(userId.ToArray(), onSuccess, onError, page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/moderators
        /// </summary>
        public void GetModerators(Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            Execute<User, Int32>("users", new string[] { "moderators" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/elected-moderators
        /// </summary>
        public void GetElectedModerators(Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null,
            UserSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string filter = null)
        {
            Execute<User, Int32>("users", new string[] { "moderators", "elected" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/me-unread-inbox
        /// </summary>
        public void GetMyUnreadInbox(string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError = null, 
            DateTime? since = null, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<InboxItem>("me", new string[] { "inbox", "unread" }, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                since = GetDateValue(since),
                filter = filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/user-unread-inbox
        /// </summary>
        public void GetUnreadInbox(int userId, string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError = null,
            DateTime? since = null, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<InboxItem>("users", new string[] { userId.ToString(), "inbox", "unread" }, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                since = GetDateValue(since),
                filter = filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/user-inbox
        /// </summary>
        public void GetInbox(int userId, string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<InboxItem>("users", new string[] { userId.ToString(), "inbox" }, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/user-inbox
        /// </summary>
        public void GetMyInbox(string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<InboxItem>("me", new string[] { "inbox" }, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }
    }
}