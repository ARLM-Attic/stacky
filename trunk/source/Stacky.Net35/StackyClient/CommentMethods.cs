using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments
        /// </summary>
        public IPagedList<Comment> GetComments()
        {
            return GetComments(null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments
        /// </summary>
        public IPagedList<Comment> GetComments(Options<CommentSort> options)
        {
            return Execute<Comment>("comments", null, options);
        }

        public IPagedList<Comment> GetComments(int id, Options<CommentSort> options)
        {
            return GetComments(id.ToArray(), options);
        }

        public IPagedList<Comment> GetComments(IEnumerable<int> ids, Options<CommentSort> options)
        {
            return Execute<Comment>("comments", new string[] { ids.Vectorize() }, options);
        }
    }
}