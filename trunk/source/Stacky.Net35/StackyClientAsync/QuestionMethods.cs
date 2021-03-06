﻿using System;
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
        private void GetQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, string method, string[] urlArgs, string sort, string sortDirection, int? page, int? pageSize, bool includeBody, bool includeComments, bool includeAnswers, DateTime? fromDate, DateTime? toDate, int? min, int? max, params string[] tags)
        {
            MakeRequest<QuestionResponse>(method, urlArgs, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                answers = includeAnswers ? (bool?)true : null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                tagged = tags == null ? (string)null : String.Join(" ", tags),
                sort = sort,
                order = sortDirection,
                min = min ?? null,
                max = max ?? null
            }, (items) => onSuccess(new PagedList<Question>(items.Questions, items)), onError);
        }

        public virtual void GetQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null)
        {
            GetQuestions(onSuccess, onError, new QuestionOptions());
        }

        public virtual void GetQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, QuestionOptions options)
        {
            var sortArgs = options.SortBy.GetAttribute<SortArgsAttribute>();
            GetQuestions(onSuccess, onError, "questions", sortArgs.UrlArgs, sortArgs.Sort, GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual void GetQuestionsByUser(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null)
        {
            GetQuestionsByUser(userId, onSuccess, onError, new QuestionByUserOptions());
        }

        public virtual void GetQuestionsByUser(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, QuestionByUserOptions options)
        {
            GetQuestions(onSuccess, onError, "users", new string[] { userId.ToString(), "questions" }, options.SortBy.ToString().ToLower(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual void GetFavoriteQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null)
        {
            GetFavoriteQuestions(userId, onSuccess, onError, new FavoriteQuestionOptions());
        }

        public virtual void GetFavoriteQuestions(int userId, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, FavoriteQuestionOptions options)
        {
            GetQuestions(onSuccess, onError, "users", new string[] { userId.ToString(), "favorites" }, options.SortBy.ToString().ToLower(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual void GetQuestions(IEnumerable<int> questionIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null)
        {
            GetQuestions(questionIds, onSuccess, onError, new QuestionOptions());
        }

        public virtual void GetQuestions(IEnumerable<int> questionIds, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, QuestionOptions options)
        {
            var sortArgs = options.SortBy.GetAttribute<SortArgsAttribute>();
            string[] urlArgs = sortArgs.UrlArgs.Concat(new string[] { questionIds.Vectorize() }).ToArray();
            GetQuestions(onSuccess, onError, "questions", urlArgs, sortArgs.Sort, GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual void GetQuestion(int questionId, Action<Question> onSuccess, Action<ApiException> onError, bool? includeBody, bool? includeComments, bool? includeAnswers)
        {
            GetQuestions(questionId.ToArray(), returnedQuestions => onSuccess(returnedQuestions.FirstOrDefault()), onError, new QuestionOptions
            {
                IncludeBody = includeBody ?? false,
                IncludeComments = includeComments ?? false,
                IncludeAnswers = includeAnswers ?? false
            });
        }

        public virtual void GetQuestionTimeline(IEnumerable<int> questionIds, Action<IPagedList<PostEvent>> onSuccess, Action<ApiException> onError)
        {
            GetQuestionTimeline(questionIds, onSuccess, onError, new QuestionTimelineOptions());
        }

        public virtual void GetQuestionTimeline(IEnumerable<int> questionIds, Action<IPagedList<PostEvent>> onSuccess, Action<ApiException> onError, QuestionTimelineOptions options)
        {
            MakeRequest<QuestionTimelineResponse>("questions", new string[] { questionIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<PostEvent>(items.Events, items)), onError);
        }

        public virtual void GetQuestionTimeline(int questionId, Action<IPagedList<PostEvent>> onSuccess, Action<ApiException> onError)
        {
            GetQuestionTimeline(questionId, onSuccess, onError, new QuestionTimelineOptions());
        }

        public virtual void GetQuestionTimeline(int questionId, Action<IPagedList<PostEvent>> onSuccess, Action<ApiException> onError, QuestionTimelineOptions options)
        {
            GetQuestionTimeline(questionId.ToArray(), onSuccess, onError, options);
        }

        public virtual void Search(Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError, QuestionSearchOptions options)
        {
            string taggedString = null;
            if (options.Tagged != null)
                taggedString = String.Join(" ", options.Tagged.ToArray());

            string notTaggedString = null;
            if (options.NotTagged != null)
                notTaggedString = String.Join(" ", options.NotTagged.ToArray());

            MakeRequest<QuestionResponse>("search", null, new
            {
                key = apiKey,
                intitle = options.InTitle,
                tagged = taggedString,
                nottagged = notTaggedString,
                sort = options.SortBy.ToString(),
                order = GetSortDirection(options.SortDirection),
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                min = options.Min ?? null,
                max = options.Max ?? null
            }, (items) => onSuccess(new PagedList<Question>(items.Questions, items)), onError);
        }
    }
}