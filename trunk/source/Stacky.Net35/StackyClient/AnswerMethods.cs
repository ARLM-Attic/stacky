using System.Collections.Generic;
using System.Linq;
using System;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers
        /// </summary>
        public IPagedList<Answer> GetAnswers()
        {
            return GetAnswers(null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers
        /// </summary>
        public IPagedList<Answer> GetAnswers(Options<AnswerSort> options)
        {
            return Execute<Answer>("answers", null, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public IPagedList<Answer> GetAnswers(IEnumerable<int> ids, Options<AnswerSort> options)
        {
            return Execute<Answer>("answers", new string[] { ids.Vectorize() }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/answers-by-ids
        /// </summary>
        public Answer GetAnswer(int id, Options<AnswerSort> options)
        {
            return GetAnswers(id.ToArray(), options).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public IPagedList<Comment> GetAnswerComments(IEnumerable<int> ids, Options<AnswerSort> options)
        {
            return Execute<Comment>("answers", new string[] { ids.Vectorize(), "comments" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments-on-answers
        /// </summary>
        public IPagedList<Comment> GetAnswerComments(int id, Options<AnswerSort> options)
        {
            return GetAnswerComments(id.ToArray(), options);
        }
    }
}