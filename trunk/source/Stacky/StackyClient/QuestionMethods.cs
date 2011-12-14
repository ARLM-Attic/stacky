using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See https://api.stackexchange.com/docs/questions
        /// </summary>
        public IPagedList<Question> GetQuestions(QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("questions", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public Question GetQuestion(int id, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetQuestions(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }

        /// <summary>
        /// https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public IPagedList<Question> GetQuestions(IEnumerable<int> ids, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Question>("questions", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Answer> GetQuestionAnswers(int id, AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetQuestionAnswers(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Answer> GetQuestionAnswers(IEnumerable<int> ids, AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Answer>("questions", new string[] { ids.Vectorize(), "answers" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        public IPagedList<Comment> GetQuestionComments(int id, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetQuestionComments(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Comment> GetQuestionComments(IEnumerable<int> ids, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Comment>("questions", new string[] { ids.Vectorize(), "comments" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetLinkedQuestions(int id, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetLinkedQuestions(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetLinkedQuestions(IEnumerable<int> ids, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Question>("questions", new string[] { ids.Vectorize(), "linked" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetRelatedQuestions(int id, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetRelatedQuestions(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetRelatedQuestions(IEnumerable<int> ids, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Question>("questions", new string[] { ids.Vectorize(), "related" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public IPagedList<QuestionTimeline> GetQuestionTimeline(int id, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetQuestionTimeline(id.ToArray(), page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public IPagedList<QuestionTimeline> GetQuestionTimeline(IEnumerable<int> ids, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<QuestionTimeline>("questions", new string[] { ids.Vectorize(), "timeline" },
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUnansweredQuestions(QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string tagged = null, string filter = null)
        {
            var response = MakeRequest<Question>("questions", new string[] { "unanswered" }, new
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
            });
            return new PagedList<Question>(response);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetQuestionsWithNoAnswers(QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string tagged = null, string filter = null)
        {
            var response = MakeRequest<Question>("questions", new string[] { "no-answers" }, new
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
            });
            return new PagedList<Question>(response);
        }
    }
}