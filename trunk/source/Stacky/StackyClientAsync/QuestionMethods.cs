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
        public void GetQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("questions", null,
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public void GetQuestion(int id, Action<Question> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetQuestions(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public void GetQuestions(IEnumerable<int> ids, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("questions", new string[] { ids.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionAnswers(int id, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null,
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetQuestionAnswers(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionAnswers(IEnumerable<int> ids, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null,
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Answer>("questions", new string[] { ids.Vectorize(), "answers" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        public void GetQuestionComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetQuestionComments(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("questions", new string[] { ids.Vectorize(), "comments" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetLinkedQuestions(int id, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, 
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetLinkedQuestions(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetLinkedQuestions(IEnumerable<int> ids, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("questions", new string[] { ids.Vectorize(), "linked" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetRelatedQuestions(int id, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetRelatedQuestions(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetRelatedQuestions(IEnumerable<int> ids, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Question>("questions", new string[] { ids.Vectorize(), "related" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public void GetQuestionTimeline(int id, Action<IPagedList<QuestionTimeline>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetQuestionTimeline(id.ToArray(), onSuccess, onError, page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public void GetQuestionTimeline(IEnumerable<int> ids, Action<IPagedList<QuestionTimeline>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<QuestionTimeline>("questions", new string[] { ids.Vectorize(), "timeline" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetUnansweredQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string tagged = null, string filter = null)
        {
            MakeRequest<Question>("questions", new string[] { "unanswered" }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = GetDateValue(min),
                max = GetDateValue(max),
                tagged = tagged,
                filter = filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public void GetQuestionsWithNoAnswers(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string tagged = null, string filter = null)
        {
            MakeRequest<Question>("questions", new string[] { "no-answers" }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = GetDateValue(min),
                max = GetDateValue(max),
                tagged = tagged,
                filter = filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/search
        /// </summary>
        /// TODO: Fix Sort
        public void SearchQuestions(Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string[] tagged = null, string[] notTagged = null, string inTitle = null, string filter = null)
        {
            if (((tagged != null && tagged.Length == 0) || tagged == null) &&
                ((notTagged != null && notTagged.Length == 0) || notTagged == null))
            {
                throw new ArgumentException("At least one of tagged or intitle must be set on this method");
            }

            MakeRequest<Question>("search", null, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = GetDateValue(min),
                max = GetDateValue(max),
                tagged = tagged != null ? String.Join(";", tagged) : null,
                nottagged = notTagged != null ? String.Join(";", notTagged) : null,
                intitle = inTitle,
                filter = filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/similar
        /// </summary>
        /// TODO: Fix Sort
        public void SimiliarQuestions(string title, Action<IPagedList<Question>> onSuccess, Action<ApiException> onError = null,
            QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string[] tagged = null, string[] notTagged = null, string filter = null)
        {
            MakeRequest<Question>("similar", null, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = GetDateValue(min),
                max = GetDateValue(max),
                tagged = tagged != null ? String.Join(";", tagged) : null,
                nottagged = notTagged != null ? String.Join(";", notTagged) : null,
                title = title,
                filter = filter
            }, response => onSuccess(new PagedList<Question>(response)), onError);
        }
    }
}