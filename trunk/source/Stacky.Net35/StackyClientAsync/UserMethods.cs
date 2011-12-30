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
        public void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            Execute<User, Int32>("users", null, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public void GetUsers(IEnumerable<int> ids, Action<IPagedList<User>> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            Execute<User, Int32>("users", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public void GetUser(int id, Action<User> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            GetUsers(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public void GetUserAnswers(IEnumerable<int> ids, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            Execute<Answer>("users", new string[] { ids.Vectorize(), "answers" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public void GetUserAnswers(int id, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            GetUserAnswers(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public void GetUserBadges(IEnumerable<int> ids, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, Options<UserSort, BadgeMinMax> options)
        {
            Execute<Badge, BadgeMinMax>("users", new string[] { ids.Vectorize(), "badges" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public void GetUserBadges(int id, Action<IPagedList<Badge>> onSuccess, Action<ApiException> onError, Options<UserSort, BadgeMinMax> options)
        {
            GetUserBadges(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public void GetUserComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<UserSort> options)
        {
            Execute<Comment>("users", new string[] { ids.Vectorize(), "comments" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public void GetUserComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<UserSort> options)
        {
            GetUserComments(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-by-users-to-user
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserCommentsTo(IEnumerable<int> fromIds, IEnumerable<int> toIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<UserSort> options)
        {
            Execute<Comment>("users", new string[] { fromIds.Vectorize(), "comments", toIds.Vectorize() }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserFavoriteQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "favorites" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        public void GetUserFavoriteQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetUserFavoriteQuestions(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public void GetUserMentions(IEnumerable<int> userIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            Execute<Comment>("users", new string[] { userIds.Vectorize(), "mentioned" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public void GetUserMentions(int userId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            GetUserMentions(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public void GetUserPrivileges(IEnumerable<int> userIds, Action<IPagedList<Privilege>> onSuccess, Action<ApiException> onError, Options options)
        {
            Execute<Privilege>("users", new string[] { userIds.Vectorize(), "privileges" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public void GetUserPrivileges(int userId, Action<IPagedList<Privilege>> onSuccess, Action<ApiException> onError, Options options)
        {
            GetUserPrivileges(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetUserQuestions(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestionsWithNoAnswers(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "no-answers" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserQuestionsWithNoAnswers(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError,  Options<QuestionSort> options)
        {
            GetUserQuestionsWithNoAnswers(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnacceptedQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unaccepted" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnacceptedQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetUserUnacceptedQuestions(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnansweredQuestions(IEnumerable<int> userIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unanswered" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users  
        /// </summary>
        /// TODO: Fix Sort
        public void GetUserUnansweredQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetUserUnansweredQuestions(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users
        /// </summary>
        public void GetUserReputation(IEnumerable<int> userIds, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<Reputation>("users", new string[] { userIds.Vectorize(), "reputation" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users 
        /// </summary>
        public void GetUserReputation(int userId, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetUserReputation(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users
        /// </summary>
        public void GetUserSuggestedEdits(IEnumerable<int> userIds, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            Execute<SuggestedEdit>("users", new string[] { userIds.Vectorize(), "suggested-edits" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users 
        /// </summary>
        public void GetUserUnansweredQuestions(int userId, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            GetUserSuggestedEdits(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public void GetUserTags(IEnumerable<int> userIds, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, Options<TagSort> options)
        {
            Execute<Tag>("users", new string[] { userIds.Vectorize(), "tags" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public void GetUserTags(int userId, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, Options<TagSort> options)
        {
            GetUserTags(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-answers-in-tags
        /// </summary>
        public void GetUserTopAnswersByTag(IEnumerable<int> userIds, IEnumerable<string> tags, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            Execute<Answer>("users", new string[] { userIds.Vectorize(), "tags", tags.Vectorize(), "top-answers" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-answers-in-tags
        /// </summary>
        public void GetUserTopAnswersByTag(int userId, IEnumerable<string> tags, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            GetUserTopAnswersByTag(userId.ToArray(), tags, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answer-tags-on-users
        /// </summary>
        public void GetUserTopAnswersByTag(IEnumerable<int> userIds, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError, Options options)
        {
            Execute<TopTag>("users", new string[] { userIds.Vectorize(), "top-answer-tags" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answer-tags-on-users
        /// </summary>
        public void GetUserTopAnswersByTag(int userId, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError, Options options)
        {
            GetUserTopAnswersByTag(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-questions-in-tags
        /// </summary>
        public void GetUserTopQuestionsByTag(IEnumerable<int> userIds, IEnumerable<string> tags, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("users", new string[] { userIds.Vectorize(), "tags", tags.Vectorize(), "top-questions" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-questions-in-tags
        /// </summary>
        public void GetUserTopQuestionsByTag(int userId, IEnumerable<string> tags, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetUserTopQuestionsByTag(userId.ToArray(), tags, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-question-tags-on-users
        /// </summary>
        public void GetUserTopQuestionsByTag(IEnumerable<int> userIds, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError, Options options)
        {
            Execute<TopTag>("users", new string[] { userIds.Vectorize(), "top-question-tags" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-question-tags-on-users
        /// </summary>
        public void GetUserTopQuestionsByTag(int userId, Action<IPagedList<TopTag>> onSuccess, Action<ApiException> onError, Options options)
        {
            GetUserTopQuestionsByTag(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/timeline-on-users
        /// </summary>
        public void GetUserTimeline(IEnumerable<int> userIds, Action<IPagedList<UserTimeline>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<UserTimeline>("users", new string[] { userIds.Vectorize(), "timeline" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/timeline-on-users
        /// </summary>
        public void GetUserTimeline(int userId, Action<IPagedList<UserTimeline>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetUserTimeline(userId.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/moderators
        /// </summary>
        public void GetModerators(Action<IPagedList<User>> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            Execute<User, Int32>("users", new string[] { "moderators" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/elected-moderators
        /// </summary>
        public void GetElectedModerators(Action<IPagedList<User>> onSuccess, Action<ApiException> onError, Options<UserSort, int> options)
        {
            Execute<User, Int32>("users", new string[] { "moderators", "elected" }, onSuccess, onError, options);
        }
    }
}