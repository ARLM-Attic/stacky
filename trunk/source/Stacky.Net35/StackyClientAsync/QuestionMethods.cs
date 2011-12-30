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
        /// See https://api.stackexchange.com/docs/questions
        /// </summary>
        public void GetQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("questions", null, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public void GetQuestion(int id, Action<Question> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetQuestions(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        /// <summary>
        /// https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public void GetQuestions(IEnumerable<int> ids, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("questions", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionAnswers(int id, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            GetQuestionAnswers(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionAnswers(IEnumerable<int> ids, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            Execute<Answer>("questions", new string[] { ids.Vectorize(), "answers" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        public void GetQuestionComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            GetQuestionComments(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            Execute<Comment>("questions", new string[] { ids.Vectorize(), "comments" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetLinkedQuestions(int id, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetLinkedQuestions(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetLinkedQuestions(IEnumerable<int> ids, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("questions", new string[] { ids.Vectorize(), "linked" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetRelatedQuestions(int id, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            GetRelatedQuestions(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetRelatedQuestions(IEnumerable<int> ids, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, Options<QuestionSort> options)
        {
            Execute<Question>("questions", new string[] { ids.Vectorize(), "related" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public void GetQuestionTimeline(int id, Action<IPagedList<QuestionTimeline>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetQuestionTimeline(id.ToArray(), onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public void GetQuestionTimeline(IEnumerable<int> ids, Action<IPagedList<QuestionTimeline>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<QuestionTimeline>("questions", new string[] { ids.Vectorize(), "timeline" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetUnansweredQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, TaggedOptions<QuestionSort> options)
        {
            MakeRequest<Question>("questions", new string[] { "unanswered" }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = GetDateValue(options.Min),
                max = GetDateValue(options.Max),
                tagged = options.GetListValue(options.Tagged),
                filter = options.Filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionsWithNoAnswers(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, TaggedOptions<QuestionSort> options)
        {
            MakeRequest<Question>("questions", new string[] { "no-answers" }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = GetDateValue(options.Min),
                max = GetDateValue(options.Max),
                tagged = options.GetListValue(options.Tagged),
                filter = options.Filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/search
        /// </summary>
        /// TODO: Fix Sort
        public void SearchQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, QuestionSearchOptions options)
        {
            if (((options.Tagged != null && options.Tagged.Count() == 0) || options.Tagged == null) &&
                String.IsNullOrEmpty(options.InTitle))
            {
                throw new ArgumentException("At least one of tagged or intitle must be set on this method");
            }

            MakeRequest<Question>("search", null, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = GetDateValue(options.Min),
                max = GetDateValue(options.Max),
                tagged = options.GetListValue(options.Tagged),
                nottagged = options.GetListValue(options.NotTagged),
                intitle = options.InTitle,
                filter = options.Filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/similar
        /// </summary>
        /// TODO: Fix Sort
        public void SimiliarQuestions(string title, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError, SimiliarQuestionsOptions options)
        {
            MakeRequest<Question>("similar", null, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = GetDateValue(options.Min),
                max = GetDateValue(options.Max),
                tagged = options.GetListValue(options.Tagged),
                nottagged = options.GetListValue(options.NotTagged),
                title = title,
                filter = options.Filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }
    }
}