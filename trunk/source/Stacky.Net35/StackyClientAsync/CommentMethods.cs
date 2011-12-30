using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/comments
        /// </summary>
        public void GetComments(Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            Execute<Comment>("comments", null, onSuccess, onError, options);
        }

        public void GetComments(int id, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            GetComments(id.ToArray(), onSuccess, onError, options);
        }

        public void GetComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            Execute<Comment>("comments", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }
    }
}