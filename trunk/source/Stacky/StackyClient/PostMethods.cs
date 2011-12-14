using System;
using System.Linq;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Post> GetPosts(PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Post>("posts", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public IPagedList<Post> GetPosts(IEnumerable<int> ids, PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Post>("posts", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public Post GetPosts(int id, PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetPosts(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }

        public IPagedList<Comment> GetPostComments(IEnumerable<int> ids, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Comment>("posts", new string[] { ids.Vectorize(), "comments" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public IPagedList<Revision> GetPostRevisions(int id, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetPostRevisions(id.ToArray(), page, pageSize, fromDate, toDate, filter);
        }

        public IPagedList<Revision> GetPostRevisions(IEnumerable<int> ids, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<Revision>("posts", new string[] { ids.Vectorize(), "revisions" },
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        public IPagedList<SuggestedEdit> GetPostSuggestedEdits(int id, SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetPostSuggestedEdits(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, filter);
        }

        public IPagedList<SuggestedEdit> GetPostSuggestedEdits(IEnumerable<int> ids, SuggestedEditSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            ValidateVectorizedParameters(ids);
            return Execute<SuggestedEdit>("posts", new string[] { ids.Vectorize(), "suggested-edits" },
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }
    }
}