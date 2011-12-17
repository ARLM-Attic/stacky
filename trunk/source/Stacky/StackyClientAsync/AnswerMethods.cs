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
        /// See: http://api.stackexchange.com/docs/answers
        /// </summary>
        public void GetAnswers(Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null,
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Answer>("answers", null, onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public void GetAnswers(IEnumerable<int> ids, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, 
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Answer>("answers", new string[] { ids.Vectorize() }, onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public void GetAnswer(int id, Action<Answer> onSuccess, Action<ApiException> onError = null,
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetAnswers(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public void GetAnswerComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, 
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("answers", new string[] { ids.Vectorize(), "comments" }, onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public void GetAnswerComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, 
            AnswerSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetAnswerComments(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}