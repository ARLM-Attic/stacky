using System;
using System.Linq;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Post> GetPosts(PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Post, PostSort>("posts", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public IPagedList<Post> GetPosts(IEnumerable<int> ids, PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Post, PostSort>("posts", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public Post GetPosts(int id, PostSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetPosts(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }

        public IPagedList<Comment> GetPostComments(IEnumerable<int> ids, CommentSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Comment, CommentSort>("posts", new string[] { ids.Vectorize(), "comments" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public Revision GetPostRevision(int id, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetPostRevision(id.ToArray(), page, pageSize, fromDate, toDate, filter).FirstOrDefault();
        }

        public IPagedList<Revision> GetPostRevision(IEnumerable<int> ids, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return Execute<Revision, CommentSort>("posts", new string[] { ids.Vectorize(), "revisions" },
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }
    }
}