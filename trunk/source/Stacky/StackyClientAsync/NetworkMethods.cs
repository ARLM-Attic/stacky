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
        /// See: http://api.stackexchange.com/docs/invalidate-access-tokens
        /// </summary>
        public void InvalidateAccessTokens(IEnumerable<string> tokens, Action<IPagedList<AccessToken>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "invalidate" }, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            }, response => onSuccess(new PagedList<AccessToken>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/invalidate-access-tokens
        /// </summary>
        public void InvalidateAccessToken(string token, Action<AccessToken> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, string filter = null)
        {
            InvalidateAccessTokens(new string[] { token }, items => onSuccess(items.FirstOrDefault()), onError, page, pageSize, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public void ReadAccessTokens(IEnumerable<string> tokens, Action<IPagedList<AccessToken>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "read" }, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            }, response => onSuccess(new PagedList<AccessToken>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public void ReadAccessToken(string token, Action<AccessToken> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = null, string filter = null)
        {
            ReadAccessTokens(new string[] { token }, items => onSuccess(items.FirstOrDefault()), onError, page, pageSize, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/create-filter
        /// </summary>
        public void CreateFilter(IEnumerable<string> include, IEnumerable<string> exclude, Action<Filter> onSuccess, Action<ApiException> onError = null,
            string baseFilter = null, bool? isUnsafe = null)
        {
            MakeRequest<Filter>("similar", null, new
            {
                include = TryVectorize(include),
                exclude = TryVectorize(exclude),
                @base = baseFilter,
                @unsafe = isUnsafe
            }, response => onSuccess(response.Items.FirstOrDefault()), onError);
        }

        private string TryVectorize(IEnumerable<string> items)
        {
            if (items == null || items.Count() == 0)
                return null;
            return items.Vectorize();
        }

        /// <summary>
        /// http://api.stackexchange.com/docs/read-filter
        /// </summary>
        public void GetFilters(IEnumerable<string> filters, Action<IEnumerable<Filter>> onSuccess, Action<ApiException> onError = null, string filter = null)
        {
            MakeRequest<Filter>("similar", new string[] { filters.Vectorize() }, new
            {
                filter = filter
            }, response => onSuccess(response.Items), onError);
        }

        /// <summary>
        /// http://api.stackexchange.com/docs/read-filter
        /// </summary>
        public void GetFilters(string filter, Action<Filter> onSuccess, Action<ApiException> onError = null)
        {
            GetFilters(new string[] { filter }, items => onSuccess(items.FirstOrDefault()), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/sites
        /// </summary>
        public void GetSites(Action<IPagedList<Site>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<Site>("sites", null, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            }, response => onSuccess(new PagedList<Site>(response)), onError);
        }

        public void GetAssociatedUsers(IEnumerable<int> ids, Action<IPagedList<NetworkUser>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<NetworkUser>("users", new string[] { ids.Vectorize(), "associated" }, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            }, response => onSuccess(new PagedList<NetworkUser>(response)), onError);
        }

        public void GetAssociatedUsers(int id, Action<IPagedList<NetworkUser>> onSuccess, Action<ApiException> onError = null, string filter = null)
        {
            GetAssociatedUsers(id.ToArray(), onSuccess, onError, null, null, filter);
        }
    }
}