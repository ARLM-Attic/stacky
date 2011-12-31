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
        public void InvalidateAccessTokens(IEnumerable<string> tokens, Action<IPagedList<AccessToken>> onSuccess, Action<ApiException> onError, Options options)
        {
            MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "invalidate" }, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<AccessToken>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/invalidate-access-tokens
        /// </summary>
        public void InvalidateAccessToken(string token, Action<AccessToken> onSuccess, Action<ApiException> onError, Options options)
        {
            InvalidateAccessTokens(new string[] { token }, items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public void ReadAccessTokens(IEnumerable<string> tokens, Action<IPagedList<AccessToken>> onSuccess, Action<ApiException> onError, Options options)
        {
            MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "read" }, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<AccessToken>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public void ReadAccessToken(string token, Action<AccessToken> onSuccess, Action<ApiException> onError, Options options)
        {
            ReadAccessTokens(new string[] { token }, items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/create-filter
        /// </summary>
        public void CreateFilter(IEnumerable<string> include, IEnumerable<string> exclude, Action<Filter> onSuccess, Action<ApiException> onError, string baseFilter, bool? isUnsafe)
        {
            MakeRequest<Filter>("similar", null, new
            {
                include = include.TryVectorize(),
                exclude = exclude.TryVectorize(),
                @base = baseFilter,
                @unsafe = isUnsafe
            }, response => onSuccess(response.Items.FirstOrDefault()), onError);
        }

        /// <summary>
        /// http://api.stackexchange.com/docs/read-filter
        /// </summary>
        public void GetFilters(IEnumerable<string> filters, Action<IEnumerable<Filter>> onSuccess, Action<ApiException> onError, string filter)
        {
            MakeRequest<Filter>("similar", new string[] { filters.Vectorize() }, new
            {
                filter = filter
            }, response => onSuccess(response.Items), onError);
        }

        /// <summary>
        /// http://api.stackexchange.com/docs/read-filter
        /// </summary>
        public void GetFilters(string filter, Action<Filter> onSuccess, Action<ApiException> onError)
        {
            GetFilters(new string[] { filter }, items => onSuccess(items.FirstOrDefault()), onError, null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/sites
        /// </summary>
        public void GetSites(Action<IPagedList<Site>> onSuccess, Action<ApiException> onError, Options options)
        {
            MakeRequest<Site>("sites", null, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<Site>(response)), onError);
        }

        public void GetAssociatedUsers(IEnumerable<int> ids, Action<IPagedList<NetworkUser>> onSuccess, Action<ApiException> onError, Options options)
        {
            MakeRequest<NetworkUser>("users", new string[] { ids.Vectorize(), "associated" }, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<NetworkUser>(response)), onError);
        }

        public void GetAssociatedUsers(int id, Action<IPagedList<NetworkUser>> onSuccess, Action<ApiException> onError, string filter)
        {
            GetAssociatedUsers(id.ToArray(), onSuccess, onError, new Options { Filter = filter });
        }
    }
}