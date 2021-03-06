﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace Stacky
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StackyClient
    {

        /// <summary>
        /// Gets the users answers.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetUsersAnswers(int userId, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUsersAnswers(userId.ToArray(), sortBy, sortDirection, page, pageSize, includeBody, includeComments, min, max, fromDate, toDate);
        }

        /// <summary>
        /// Gets the users answers.
        /// </summary>
        /// <param name="userIds">The user ids.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetUsersAnswers(IEnumerable<int> userIds, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<AnswerResponse>("users", new string[] { userIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        /// <summary>
        /// Gets the question answers.
        /// </summary>
        /// <param name="questionIds">The question ids.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetQuestionAnswers(IEnumerable<int> questionIds, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<AnswerResponse>("questions", new string[] { questionIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        /// <summary>
        /// Gets the question answers.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetQuestionAnswers(int questionId, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetQuestionAnswers(questionId.ToArray(), sortBy, sortDirection, page, pageSize, includeBody, includeComments, min, max, fromDate, toDate);
        }

        public virtual Answer GetAnswer(int answerId, bool includeBody = true, bool includeComments = true)
        {
            return GetAnswers(answerId.ToArray(), includeBody: includeBody, includeComments : includeComments).FirstOrDefault();
        }

        public virtual IPagedList<Answer> GetAnswers(IEnumerable<int> answerIds, AnswerSort sortBy = AnswerSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<AnswerResponse>("answers", new string[] { answerIds.Vectorize() }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        /// <summary>
        /// Returns all the answers in the system
        /// </summary>
        /// <param name="sortBy">How a collection should be sorted.</param>
        /// <param name="sortDirection"></param>
        /// <param name="page">The pagination offset for the current collection. Affected by the specified pagesize.</param>
        /// <param name="pageSize">The number of collection results to display during pagination. Should be between 0 and 100 inclusive.</param>
        /// <param name="includeBody">When "true", a post's body will be included in the response.</param>
        /// <param name="includeComments">When "true", any comments on a post will be included in the response.</param>
        /// <param name="includeAnswers"> When "true", the answers to a question will be returned</param>
        /// <param name="min">Minimum of the range to include in the response according to the current sort.</param>
        /// <param name="max">Maximum of the range to include in the response according to the current sort.</param>
        /// <param name="fromDate">Unix timestamp of the minimum creation date on a returned item.</param>
        /// <param name="toDate">Unix timestamp of the maximum creation date on a returned item.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetAnswers(AnswerSort sortBy = AnswerSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, bool includeAnswers = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<AnswerResponse>("answers", null, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                answers = includeAnswers ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }
    }
}