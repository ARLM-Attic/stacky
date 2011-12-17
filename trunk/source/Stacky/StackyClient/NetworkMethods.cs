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
        public IPagedList<AccessToken> InvalidateAccessTokens(IEnumerable<string> tokens, int? page = null, int? pageSize = null, string filter = null)
        {
            var response = MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "invalidate" }, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            });
            return new PagedList<AccessToken>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/invalidate-access-tokens
        /// </summary>
        public AccessToken InvalidateAccessToken(string token, int? page = null, int? pageSize = null, string filter = null)
        {
            return InvalidateAccessTokens(new string[] { token }, page, pageSize, filter).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public IPagedList<AccessToken> ReadAccessTokens(IEnumerable<string> tokens, int? page = null, int? pageSize = null, string filter = null)
        {
            var response = MakeRequest<AccessToken>("access-tokens", new string[] { tokens.Vectorize(), "read" }, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            });
            return new PagedList<AccessToken>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/read-access-tokens
        /// </summary>
        public AccessToken ReadAccessToken(string token, int? page = null, int? pageSize = null, string filter = null)
        {
            return ReadAccessTokens(new string[] { token }, page, pageSize, filter).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/create-filter
        /// </summary>
        public Filter CreateFilter(IEnumerable<string> include, IEnumerable<string> exclude, string baseFilter = null, bool? isUnsafe = null)
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
        public IEnumerable<Filter> GetFilters(IEnumerable<string> filters, string filter = null)
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
            return GetFilters(new string[] { filter }).FirstOrDefault();
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/sites
        /// </summary>
        public IPagedList<Site> GetSites(int? page = null, int? pageSize = null, string filter = null)
        {
            var response = MakeRequest<Site>("sites", null, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            });
            return new PagedList<Site>(response);
        }

        public IPagedList<NetworkUser> GetAssociatedUsers(IEnumerable<int> ids, int? page = null, int? pageSize = null, string filter = null)
        {
            var response = MakeRequest<NetworkUser>("users", new string[] { ids.Vectorize(), "associated" }, new
            {
                page = page,
                pagesize = pageSize,
                filter = filter
            });
            return new PagedList<NetworkUser>(response);
        }

        public IPagedList<NetworkUser> GetAssociatedUsers(int id, string filter = null)
        {
            return GetAssociatedUsers(id.ToArray(), filter: filter);
        }
    }
}