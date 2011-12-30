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
        public void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, TagOptions options)
        {
            MakeRequest<Tag>("tags", null, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = GetDateValue(options.FromDate),
                todate = GetDateValue(options.ToDate),
                sort = GetEnumValue(options.SortBy),
                order = GetSortDirection(options.SortDirection),
                min = options.Min ?? null,
                max = options.Max ?? null,
                inname = options.InName,
                filter = options.Filter
            }, response => onSuccess(new PagedList<Tag>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/tag-synonyms
        /// </summary>
        public void GetTagSynonyms(Action<IPagedList<TagSynonym>> onSuccess, Action<ApiException> onError, Options<TagSynonymSort> options)
        {
            Execute<TagSynonym>("tags", new string[] { "synonyms" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public void GetTagSynonyms(IEnumerable<string> tags, Action<IPagedList<TagSynonym>> onSuccess, Action<ApiException> onError, Options<TagSynonymSort> options)
        {
            Execute<TagSynonym>("tags", new string[] { tags.Vectorize(), "synonyms" }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public void GetTagSynonyms(string tag, Action<IPagedList<TagSynonym>> onSuccess, Action<ApiException> onError, Options<TagSynonymSort> options)
        {
            GetTagSynonyms(new string[] { tag }, onSuccess, onError, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answerers-on-tags
        /// </summary>
        public void GetTagTopAnswerers(string tag, Action<IPagedList<TagScore>> onSuccess, Action<ApiException> onError, TopAnswerOptions options)
        {
            MakeRequest<TagScore>("tags", new string[] { tag, "top-answerers", GetEnumValue(options.Period) }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<TagScore>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-askers-on-tags
        /// </summary>
        public void GetTagTopAskers(string tag, Action<IPagedList<TagScore>> onSuccess, Action<ApiException> onError, TopAnswerOptions options)
        {
            MakeRequest<TagScore>("tags", new string[] { tag, "top-askers", GetEnumValue(options.Period) }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<TagScore>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public void GetTagWikis(IEnumerable<string> tags, Action<IPagedList<TagWiki>> onSuccess, Action<ApiException> onError, Options options)
        {
            MakeRequest<TagWiki>("tags", new string[] { tags.Vectorize(), "wikis" }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.Page ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<TagWiki>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public void GetTagWikis(string tag, Action<IPagedList<TagWiki>> onSuccess, Action<ApiException> onError, Options options)
        {
            GetTagWikis(new string[] { tag }, onSuccess, onError, options);
        }
    }
}