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
        public void GetPosts(Action<IPagedList<Post>> onSuccess, Action<ApiException> onError, Options<PostSort> options)
        {
            Execute<Post>("posts", null, onSuccess, onError, options);
        }

        public void GetPosts(IEnumerable<int> ids, Action<IPagedList<Post>> onSuccess, Action<ApiException> onError, Options<PostSort> options)
        {
            Execute<Post>("posts", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        public void GetPosts(int id, Action<Post> onSuccess, Action<ApiException> onError, Options<PostSort> options)
        {
            GetPosts(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        public void GetPostComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, Options<CommentSort> options)
        {
            Execute<Comment>("posts", new string[] { ids.Vectorize(), "comments" }, onSuccess, onError, options);
        }

        public void GetPostRevisions(int id, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetPostRevisions(id.ToArray(), onSuccess, onError, options);
        }

        public void GetPostRevisions(IEnumerable<int> ids, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<Revision>("posts", new string[] { ids.Vectorize(), "revisions" }, onSuccess, onError, options);
        }

        public void GetPostSuggestedEdits(int id, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            GetPostSuggestedEdits(id.ToArray(), onSuccess, onError, options);
        }

        public void GetPostSuggestedEdits(IEnumerable<int> ids, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            Execute<SuggestedEdit>("posts", new string[] { ids.Vectorize(), "suggested-edits" }, onSuccess, onError, options);
        }
    }
}