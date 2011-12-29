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
        public IPagedList<Question> GetQuestions()
        {
            return GetQuestions(null);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions
        /// </summary>
        public IPagedList<Question> GetQuestions(Options<QuestionSort> options)
        {
            return Execute<Question>("questions", null, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public Question GetQuestion(int id, Options<QuestionSort> options)
        {
            return GetQuestions(id.ToArray(), options).FirstOrDefault();
        }

        /// <summary>
        /// https://api.stackexchange.com/docs/questions-by-ids
        /// </summary>
        public IPagedList<Question> GetQuestions(IEnumerable<int> ids, Options<QuestionSort> options)
        {
            return Execute<Question>("questions", new string[] { ids.Vectorize() }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Answer> GetQuestionAnswers(int id, Options<AnswerSort> options)
        {
            return GetQuestionAnswers(id.ToArray(), options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/answers-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Answer> GetQuestionAnswers(IEnumerable<int> ids, Options<AnswerSort> options)
        {
            return Execute<Answer>("questions", new string[] { ids.Vectorize(), "answers" }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        public IPagedList<Comment> GetQuestionComments(int id, Options<CommentSort> options)
        {
            return GetQuestionComments(id.ToArray(), options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/comments-on-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Comment> GetQuestionComments(IEnumerable<int> ids, Options<CommentSort> options)
        {
            return Execute<Comment>("questions", new string[] { ids.Vectorize(), "comments" }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetLinkedQuestions(int id, Options<QuestionSort> options)
        {
            return GetLinkedQuestions(id.ToArray(), options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetLinkedQuestions(IEnumerable<int> ids, Options<QuestionSort> options)
        {
            return Execute<Question>("questions", new string[] { ids.Vectorize(), "linked" }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetRelatedQuestions(int id, Options<QuestionSort> options)
        {
            return GetRelatedQuestions(id.ToArray(), options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/linked-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetRelatedQuestions(IEnumerable<int> ids, Options<QuestionSort> options)
        {
            return Execute<Question>("questions", new string[] { ids.Vectorize(), "related" }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public IPagedList<QuestionTimeline> GetQuestionTimeline(int id, OptionsWithDates options)
        {
            return GetQuestionTimeline(id.ToArray(), options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/questions-timeline
        /// </summary>
        public IPagedList<QuestionTimeline> GetQuestionTimeline(IEnumerable<int> ids, OptionsWithDates options)
        {
            ValidateVectorizedParameters(ids);
            return Execute<QuestionTimeline>("questions", new string[] { ids.Vectorize(), "timeline" }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetUnansweredQuestions(TaggedOptions<QuestionSort> options)
        {
            var response = MakeRequest<Question>("questions", new string[] { "unanswered" }, new
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
                tagged = options.Tagged,
                filter = options.Filter
            });
            return new PagedList<Question>(response);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/unanswered-questions
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> GetQuestionsWithNoAnswers(TaggedOptions<QuestionSort> options)
        {
            var response = MakeRequest<Question>("questions", new string[] { "no-answers" }, new
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
            });
            return new PagedList<Question>(response);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/search
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> SearchQuestions(QuestionSearchOptions options)
        {
            if (((options.Tagged != null && options.Tagged.Count() == 0) || options.Tagged == null) &&
                String.IsNullOrEmpty(options.InTitle))
            {
                throw new ArgumentException("At least one of tagged or intitle must be set on this method");
            }

            var response = MakeRequest<Question>("search", null, new
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
            });
            return new PagedList<Question>(response);
        }

        // <summary>
        /// See https://api.stackexchange.com/docs/similar
        /// </summary>
        /// TODO: Fix Sort
        public IPagedList<Question> SimiliarQuestions(string title, SimiliarQuestionsOptions options)
        {
            var response = MakeRequest<Question>("similar", null, new
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
            });
            return new PagedList<Question>(response);
        }
    }
}