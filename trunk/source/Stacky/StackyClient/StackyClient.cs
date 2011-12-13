#if !SILVERLIGHT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Stacky
{
    public partial class StackyClient : StackyClientBase
    {
        private string version;

        public StackyClient(string version, Site site, IUrlClient client, IProtocol protocol)
            : this(version, site.ApiSiteParameter, client, protocol)
        {
        }

        public StackyClient(string version, string siteUrlName, IUrlClient client, IProtocol protocol)
        {
            Require.NotNullOrEmpty(version, "version");
            Require.NotNullOrEmpty(siteUrlName, "baseUrl");
            Require.NotNull(client, "client");

            this.version = version;
            SiteUrlName = siteUrlName;
            WebClient = client;
            Protocol = protocol;
        }

        #region Methods

        public Response<T> MakeRequest<T>(string method, string[] urlArguments, object queryStringArguments)
            where T : new()
        {
            return MakeRequest<T>(method, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments));
        }

        public Response<T> MakeRequest<T>(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
             where T : new()
        {
            var httpResponse = GetResponse(method, urlArguments, queryStringArguments);
            return ParseResponse<T>(httpResponse);
        }

        public Response<T> ParseResponse<T>(HttpResponse httpResponse)
            where T : new()
        {
            if (httpResponse.Error != null && String.IsNullOrEmpty(httpResponse.Body))
                throw new ApiException("Error retrieving url", null, httpResponse.Error, httpResponse.Url);

            RemainingRequests = httpResponse.RemainingRequests;
            MaxRequests = httpResponse.MaxRequests;

            var response = Protocol.GetResponse<T>(httpResponse.Body);
            if (response.Error != null)
                throw new ApiException(response.Error);

            return response.Data;
        }

        public HttpResponse GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            Uri url = UrlHelper.BuildUrl(method, version, urlArguments, queryStringArguments);
            return WebClient.MakeRequest(url);
        }

        protected IPagedList<TEntity> Execute<TEntity, TSort, TMinMax>(string methodName, string[] urlArguments, TSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, TMinMax? min = null, TMinMax? max = null, string filter = null)
            where TEntity : Entity, new()
            where TSort : struct
            where TMinMax : struct
        {
            var response = MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = min.HasValue ? min : null,
                max = max.HasValue ? max : null,
                filter = filter
            });
            return new PagedList<TEntity>(response);
        }

        protected IPagedList<TEntity> Execute<TEntity, TSort>(string methodName, string[] urlArguments, TSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
            where TEntity : Entity, new()
            where TSort : struct
        {
            var response = MakeRequest<TEntity>(methodName, urlArguments, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = GetDateValue(min),
                max = GetDateValue(max),
                filter = filter
            });
            return new PagedList<TEntity>(response);
        }

        #endregion

        #region Properties

        public IUrlClient WebClient { get; set; }

        #endregion
    }
}
#endif