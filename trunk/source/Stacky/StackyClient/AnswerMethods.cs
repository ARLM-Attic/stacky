using System.Collections.Generic;
using System;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers
        /// </summary>
        public IPagedList<Answer> GetAnswers(AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Answer>("answers", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public IPagedList<Answer> GetAnswers(IEnumerable<int> ids, AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Answer>("answers", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public Answer GetAnswer(int id, AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetAnswers(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public IPagedList<Comment> GetAnswerComments(IEnumerable<int> ids, AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment>("answers", new string[] { ids.Vectorize(), "comments" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public IPagedList<Comment> GetAnswerComments(int id, AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetAnswerComments(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}