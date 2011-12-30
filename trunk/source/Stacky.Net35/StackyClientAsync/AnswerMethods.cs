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
        public void GetAnswers(Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            Execute<Answer>("answers", null, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public void GetAnswers(IEnumerable<int> ids, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            Execute<Answer>("answers", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public void GetAnswer(int id, Action<Answer> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            GetAnswers(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public void GetAnswerComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            Execute<Comment>("answers", new string[] { ids.Vectorize(), "comments" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public void GetAnswerComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<AnswerSort> options)
        {
            GetAnswerComments(id.ToArray(), onSuccess, onError, options);
        }
    }
}