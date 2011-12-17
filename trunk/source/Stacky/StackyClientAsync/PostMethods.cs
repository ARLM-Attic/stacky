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
        public void GetPosts(Action<IPagedList<Post>> onSuccess, Action<ApiException> onError = null,
            PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Post>("posts", null,
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetPosts(IEnumerable<int> ids, Action<IPagedList<Post>> onSuccess, Action<ApiException> onError = null,
            PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Post>("posts", new string[] { ids.Vectorize() },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetPosts(int id, Action<Post> onSuccess, Action<ApiException> onError = null, 
            PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetPosts(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetPostComments(IEnumerable<int> ids, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null,
            CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<Comment>("posts", new string[] { ids.Vectorize(), "comments" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public void GetPostRevisions(int id, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetPostRevisions(id.ToArray(), onSuccess, onError, page, pageSize, fromDate, toDate, filter);
        }

        public void GetPostRevisions(IEnumerable<int> ids, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<Revision>("posts", new string[] { ids.Vectorize(), "revisions" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        public void GetPostSuggestedEdits(int id, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError = null, 
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            GetPostSuggestedEdits(id.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, filter);
        }

        public void GetPostSuggestedEdits(IEnumerable<int> ids, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError = null,
            SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            Execute<SuggestedEdit>("posts", new string[] { ids.Vectorize(), "suggested-edits" },
                onSuccess, onError,
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }
    }
}