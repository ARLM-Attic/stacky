using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/tags
        /// </summary>
        public void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError = null,
            TagSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string inName = null, string filter = null)
        {
            MakeRequest<Tag>("tags", null, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
                sort = GetEnumValue(sortBy),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                inname = inName,
                filter = filter
            }, response => onSuccess(new PagedList<Tag>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/tag-synonyms
        /// </summary>
        public void GetTagSynonyms(Action<IPagedList<TagSynonym>> onSuccess, Action<ApiException> onError = null,
            TagSynonymSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<TagSynonym>("tags", new string[] { "synonyms" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public void GetTagSynonyms(IEnumerable<string> tags, Action<IPagedList<TagSynonym>> onSuccess, Action<ApiException> onError = null,
            TagSynonymSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            Execute<TagSynonym>("tags", new string[] { tags.Vectorize(), "synonyms" },
                onSuccess, onError,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public void GetTagSynonyms(string tag, Action<IPagedList<TagSynonym>> onSuccess, Action<ApiException> onError = null, 
            TagSynonymSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            GetTagSynonyms(new string[] { tag }, onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answerers-on-tags
        /// </summary>
        public void GetTagTopAnswerers(string tag, Action<IPagedList<TagScore>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, AnswerTimePeriod period = AnswerTimePeriod.AllTime, string filter = null)
        {
            MakeRequest<TagScore>("tags", new string[] { tag, "top-answerers", GetEnumValue(period) }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, response => onSuccess(new PagedList<TagScore>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-askers-on-tags
        /// </summary>
        public void GetTagTopAskers(string tag, Action<IPagedList<TagScore>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, AnswerTimePeriod period = AnswerTimePeriod.AllTime, string filter = null)
        {
            MakeRequest<TagScore>("tags", new string[] { tag, "top-askers", GetEnumValue(period) }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, response => onSuccess(new PagedList<TagScore>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public void GetTagWikis(IEnumerable<string> tags, Action<IPagedList<TagWiki>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = 0, string filter = null)
        {
            MakeRequest<TagWiki>("tags", new string[] { tags.Vectorize(), "wikis" }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, response => onSuccess(new PagedList<TagWiki>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public void GetTagWikis(string tag, Action<IPagedList<TagWiki>> onSuccess, Action<ApiException> onError = null, 
            int? page = null, int? pageSize = 0, string filter = null)
        {
            GetTagWikis(new string[] { tag }, onSuccess, onError, page, pageSize, filter);
        }
    }
}