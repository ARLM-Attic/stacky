using System;
using System.Linq;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Post> GetPosts()
        {
            return GetPosts(null);
        }

        public IPagedList<Post> GetPosts(Options<PostSort> options)
        {
            return Execute<Post>("posts", null, options);
        }

        public IPagedList<Post> GetPosts(IEnumerable<int> ids, Options<PostSort> options)
        {
            return Execute<Post>("posts", new string[] { ids.Vectorize() }, options);
        }

        public Post GetPosts(int id, Options<PostSort> options)
        {
            return GetPosts(id.ToArray(), options).FirstOrDefault();
        }

        public IPagedList<Comment> GetPostComments(IEnumerable<int> ids, Options<CommentSort> options)
        {
            return Execute<Comment>("posts", new string[] { ids.Vectorize(), "comments" }, options);
        }

        public IPagedList<Revision> GetPostRevisions(int id, OptionsWithDates options)
        {
            return GetPostRevisions(id.ToArray(), options);
        }

        public IPagedList<Revision> GetPostRevisions(IEnumerable<int> ids, OptionsWithDates options)
        {
            return Execute<Revision>("posts", new string[] { ids.Vectorize(), "revisions" }, options);
        }

        public IPagedList<SuggestedEdit> GetPostSuggestedEdits(int id, Options<SuggestedEditSort> options)
        {
            return GetPostSuggestedEdits(id.ToArray(), options);
        }

        public IPagedList<SuggestedEdit> GetPostSuggestedEdits(IEnumerable<int> ids, Options<SuggestedEditSort> options)
        {
            return Execute<SuggestedEdit>("posts", new string[] { ids.Vectorize(), "suggested-edits" }, options);
        }
    }
}