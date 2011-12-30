using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/invalidate-access-tokens
        /// </summary>
        public IPagedList<AccessToken> InvalidateAccessTokens(IEnumerable<string> tokens, Options options)
        {
            var response = MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "invalidate" }, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<AccessToken>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/invalidate-access-tokens
        /// </summary>
        public AccessToken InvalidateAccessToken(string token, Options options)
        {
            return InvalidateAccessTokens(new string[] { token }, options).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public IPagedList<AccessToken> ReadAccessTokens(IEnumerable<string> tokens, Options options)
        {
            var response = MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "read" }, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<AccessToken>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public AccessToken ReadAccessToken(string token, Options options)
        {
            return ReadAccessTokens(new string[] { token }, options).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/create-filter
        /// </summary>
        public Filter CreateFilter(IEnumerable<string> include, IEnumerable<string> exclude, string baseFilter, bool? isUnsafe)
        {
            var response = MakeRequest<Filter>("similar", null, new
            {
                include = TryVectorize(include),
                exclude = TryVectorize(exclude),
                @base = baseFilter,
                @unsafe = isUnsafe
            });
            return response.Items.FirstOrDefault();
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
        public IEnumerable<Filter> GetFilters(IEnumerable<string> filters, string filter)
        {
            var response = MakeRequest<Filter>("similar", new string[] { filters.Vectorize() }, new
            {
                filter = filter
            });
            return response.Items;
        }

        /// <summary>
        /// http://api.stackexchange.com/docs/read-filter
        /// </summary>
        public Filter GetFilters(string filter)
        {
            return GetFilters(new string[] { filter }, null).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/sites
        /// </summary>
        public IPagedList<Site> GetSites()
        {
            return GetSites(new Options());
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/sites
        /// </summary>
        public IPagedList<Site> GetSites(Options options)
        {
            var response = MakeRequest<Site>("sites", null, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<Site>(response);
        }

        public IPagedList<NetworkUser> GetAssociatedUsers(IEnumerable<int> ids, Options options)
        {
            var response = MakeRequest<NetworkUser>("users", new string[] { ids.Vectorize(), "associated" }, new
            {
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<NetworkUser>(response);
        }

        public IPagedList<NetworkUser> GetAssociatedUsers(int id, string filter)
        {
            return GetAssociatedUsers(id.ToArray(), new Options { Filter = filter });
        }
    }
}