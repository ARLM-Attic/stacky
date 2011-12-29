using System.Collections.Generic;
using System;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/tags
        /// </summary>
        public IPagedList<Tag> GetTags()
        {
            return GetTags(null);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/tags
        /// </summary>
        public IPagedList<Tag> GetTags(TagOptions options)
        {
            var response = MakeRequest<Tag>("tags", null, new
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
            });
            return new PagedList<Tag>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/tag-synonyms
        /// </summary>
        public IPagedList<TagSynonym> GetTagSynonyms(Options<TagSynonymSort> options)
        {
            return Execute<TagSynonym>("tags", new string[] { "synonyms" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public IPagedList<TagSynonym> GetTagSynonyms(IEnumerable<string> tags, Options<TagSynonymSort> options)
        {
            return Execute<TagSynonym>("tags", new string[] { tags.Vectorize(), "synonyms" }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public IPagedList<TagSynonym> GetTagSynonyms(string tag, Options<TagSynonymSort> options)
        {
            return GetTagSynonyms(new string[] { tag }, options);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answerers-on-tags
        /// </summary>
        public IPagedList<TagScore> GetTagTopAnswerers(string tag, TopAnswerOptions options)
        {
            var response = MakeRequest<TagScore>("tags", new string[] { tag, "top-answerers", GetEnumValue(options.Period) }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<TagScore>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-askers-on-tags
        /// </summary>
        public IPagedList<TagScore> GetTagTopAskers(string tag, TopAnswerOptions options)
        {
            var response = MakeRequest<TagScore>("tags", new string[] { tag, "top-askers", GetEnumValue(options.Period) }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<TagScore>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public IPagedList<TagWiki> GetTagWikis(IEnumerable<string> tags, Options options)
        {
            var response = MakeRequest<TagWiki>("tags", new string[] { tags.Vectorize(), "wikis" }, new
            {
                site = this.SiteUrlName,
                page = options.Page ?? null,
                pagesize = options.Page ?? null,
                filter = options.Filter
            });
            return new PagedList<TagWiki>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public IPagedList<TagWiki> GetTagWikis(string tag, Options options)
        {
            return GetTagWikis(new string[] { tag }, options);
        }
    }
}