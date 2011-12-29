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
        public IPagedList<User> GetUsers()
        {
            return GetUsers(null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users
        /// </summary>
        public IPagedList<User> GetUsers(Options<UserSort, int> options)
        {
            return Execute<User, Int32>("users", null, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public IPagedList<User> GetUsers(IEnumerable<int> ids, Options<UserSort, int> options)
        {
            return Execute<User, Int32>("users", new string[] { ids.Vectorize() }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/users-by-ids
        /// </summary>
        public User GetUser(int id, Options<UserSort, int> options)
        {
            return GetUsers(id.ToArray(), options).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public IPagedList<Answer> GetUserAnswers(IEnumerable<int> ids, Options<UserSort> options)
        {
            return Execute<Answer>("users", new string[] { ids.Vectorize(), "answers" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-on-users
        /// </summary>
        public IPagedList<Answer> GetUserAnswers(int id, Options<UserSort> options)
        {
            return GetUserAnswers(id.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public IPagedList<Badge> GetUserBadges(IEnumerable<int> ids, Options<UserSort, BadgeMinMax> options)
        {
            return Execute<Badge, BadgeMinMax>("users", new string[] { ids.Vectorize(), "badges" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/badges-on-users
        /// </summary>
        public IPagedList<Badge> GetUserBadges(int id, Options<UserSort, BadgeMinMax> options)
        {
            return GetUserBadges(id.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public IPagedList<Comment> GetUserComments(IEnumerable<int> ids, Options<UserSort> options)
        {
            return Execute<Comment>("users", new string[] { ids.Vectorize(), "comments" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-users
        /// </summary>
        public IPagedList<Comment> GetUserComments(int id, Options<UserSort> options)
        {
            return GetUserComments(id.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-by-users-to-user
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Comment> GetUserCommentsTo(IEnumerable<int> fromIds, IEnumerable<int> toIds, Options<UserSort> options)
        {
            return Execute<Comment>("users", new string[] { fromIds.Vectorize(), "comments", toIds.Vectorize() }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserFavoriteQuestions(IEnumerable<int> userIds, Options<QuestionSort> options)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "favorites" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/favorites-on-users
        /// </summary>
        public IPagedList<Question> GetUserFavoriteQuestions(int userId, Options<QuestionSort> options)
        {
            return GetUserFavoriteQuestions(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds, Options<CommentSort> options)
        {
            return Execute<Comment>("users", new string[] { userIds.Vectorize(), "mentioned" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/mentions-on-users
        /// </summary>
        public IPagedList<Comment> GetUserMentions(int userId, Options<CommentSort> options)
        {
            return GetUserMentions(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public IPagedList<Privilege> GetUserPrivileges(IEnumerable<int> userIds, Options options)
        {
            return Execute<Privilege>("users", new string[] { userIds.Vectorize(), "privileges" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/privileges-on-users
        /// </summary>
        public IPagedList<Privilege> GetUserPrivileges(int userId, Options options)
        {
            return GetUserPrivileges(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestions(IEnumerable<int> userIds, Options<QuestionSort> options)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestions(int userId, Options<QuestionSort> options)
        {
            return GetUserQuestions(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestionsWithNoAnswers(IEnumerable<int> userIds, Options<QuestionSort> options)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "no-answers" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/no-answer-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserQuestionsWithNoAnswers(int userId, Options<QuestionSort> options)
        {
            return GetUserQuestionsWithNoAnswers(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnacceptedQuestions(IEnumerable<int> userIds, Options<QuestionSort> options)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unaccepted" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unaccepted-questions-on-users    
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnacceptedQuestions(int userId, Options<QuestionSort> options)
        {
            return GetUserUnacceptedQuestions(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnansweredQuestions(IEnumerable<int> userIds, Options<QuestionSort> options)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "questions", "unanswered" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/unanswered-questions-on-users  
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUserUnansweredQuestions(int userId, Options<QuestionSort> options)
        {
            return GetUserUnansweredQuestions(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users
        /// </summary>
        public IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds, OptionsWithDates options)
        {
            return Execute<Reputation>("users", new string[] { userIds.Vectorize(), "reputation" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/reputation-on-users 
        /// </summary>
        public IPagedList<Reputation> GetUserReputation(int userId, OptionsWithDates options)
        {
            return GetUserReputation(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users
        /// </summary>
        public IPagedList<SuggestedEdit> GetUserSuggestedEdits(IEnumerable<int> userIds, Options<SuggestedEditSort> options)
        {
            return Execute<SuggestedEdit>("users", new string[] { userIds.Vectorize(), "suggested-edits" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/suggested-edits-on-users 
        /// </summary>
        public IPagedList<SuggestedEdit> GetUserUnansweredQuestions(int userId, Options<SuggestedEditSort> options)
        {
            return GetUserSuggestedEdits(userId.ToArray(), options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public IPagedList<Tag> GetUserTags(IEnumerable<int> userIds, Options<TagSort> options)
        {
            return Execute<Tag>("users", new string[] { userIds.Vectorize(), "tags" }, options);
        }

        /// <summary>
        /// See: https://api.stackexchange.com/docs/tags-on-users
        /// </summary>
        public IPagedList<Tag> GetUserTags(int userId, Options<TagSort> options)
        {
            return GetUserTags(userId.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-answers-in-tags
        /// </summary>
        public IPagedList<Answer> GetUserTopAnswersByTag(IEnumerable<int> userIds, IEnumerable<string> tags, Options<AnswerSort> options)
        {
            return Execute<Answer>("users", new string[] { userIds.Vectorize(), "tags", tags.Vectorize(), "top-answers" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-answers-in-tags
        /// </summary>
        public IPagedList<Answer> GetUserTopAnswersByTag(int userId, IEnumerable<string> tags, Options<AnswerSort> options)
        {
            return GetUserTopAnswersByTag(userId.ToArray(), tags, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answer-tags-on-users
        /// </summary>
        public IPagedList<TopTag> GetUserTopAnswersByTag(IEnumerable<int> userIds, Options options)
        {
            return Execute<TopTag>("users", new string[] { userIds.Vectorize(), "top-answer-tags" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answer-tags-on-users
        /// </summary>
        public IPagedList<TopTag> GetUserTopAnswersByTag(int userId, Options options)
        {
            return GetUserTopAnswersByTag(userId.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-questions-in-tags
        /// </summary>
        public IPagedList<Question> GetUserTopQuestionsByTag(IEnumerable<int> userIds, IEnumerable<string> tags, Options<QuestionSort> options)
        {
            return Execute<Question>("users", new string[] { userIds.Vectorize(), "tags", tags.Vectorize(), "top-questions" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-user-questions-in-tags
        /// </summary>
        public IPagedList<Question> GetUserTopQuestionsByTag(int userId, IEnumerable<string> tags, Options<QuestionSort> options)
        {
            return GetUserTopQuestionsByTag(userId.ToArray(), tags, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-question-tags-on-users
        /// </summary>
        public IPagedList<TopTag> GetUserTopQuestionsByTag(IEnumerable<int> userIds, Options options)
        {
            return Execute<TopTag>("users", new string[] { userIds.Vectorize(), "top-question-tags" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-question-tags-on-users
        /// </summary>
        public IPagedList<TopTag> GetUserTopQuestionsByTag(int userId, Options options)
        {
            return GetUserTopQuestionsByTag(userId.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/timeline-on-users
        /// </summary>
        public IPagedList<UserTimeline> GetUserTimeline(IEnumerable<int> userIds, OptionsWithDates options)
        {
            return Execute<UserTimeline>("users", new string[] { userIds.Vectorize(), "timeline" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/timeline-on-users
        /// </summary>
        public IPagedList<UserTimeline> GetUserTimeline(int userId, OptionsWithDates options)
        {
            return GetUserTimeline(userId.ToArray(), options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/moderators
        /// </summary>
        public IPagedList<User> GetModerators()
        {
            return GetModerators(null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/moderators
        /// </summary>
        public IPagedList<User> GetModerators(Options<UserSort, int> options)
        {
            return Execute<User, Int32>("users", new string[] { "moderators" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/elected-moderators
        /// </summary>
        public IPagedList<User> GetElectedModerators()
        {
            return GetElectedModerators(null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/elected-moderators
        /// </summary>
        public IPagedList<User> GetElectedModerators(Options<UserSort, int> options)
        {
            return Execute<User, Int32>("users", new string[] { "moderators", "elected" }, options);
        }
    }
}