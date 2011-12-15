using System.Collections.Generic;
using System;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/tags
        /// </summary>
        public IPagedList<Tag> GetTags(TagSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string inName = null, string filter = null)
        {
            var response = MakeRequest<Tag>("tags", null, new
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
            });
            return new PagedList<Tag>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/tag-synonyms
        /// </summary>
        public IPagedList<TagSynonym> GetTagSynonyms(TagSynonymSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<TagSynonym>("tags", new string[] { "synonyms" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public IPagedList<TagSynonym> GetTagSynonyms(IEnumerable<string> tags, TagSynonymSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<TagSynonym>("tags", new string[] { tags.Vectorize(), "synonyms" },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/synonyms-by-tags
        /// </summary>
        public IPagedList<TagSynonym> GetTagSynonyms(string tag, TagSynonymSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetTagSynonyms(new string[] { tag }, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-answerers-on-tags
        /// </summary>
        public IPagedList<TagScore> GetTagTopAnswerers(string tag, int? page = null, int? pageSize = null, AnswerTimePeriod period = AnswerTimePeriod.AllTime, string filter = null)
        {
            var response = MakeRequest<TagScore>("tags", new string[] { tag, "top-answerers", GetEnumValue(period) }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            });
            return new PagedList<TagScore>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/top-askers-on-tags
        /// </summary>
        public IPagedList<TagScore> GetTagTopAskers(string tag, int? page = null, int? pageSize = null, AnswerTimePeriod period = AnswerTimePeriod.AllTime, string filter = null)
        {
            var response = MakeRequest<TagScore>("tags", new string[] { tag, "top-askers", GetEnumValue(period) }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            });
            return new PagedList<TagScore>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public IPagedList<TagWiki> GetTagWikis(IEnumerable<string> tags, int? page = null, int? pageSize = 0, string filter = null)
        {
            var response = MakeRequest<TagWiki>("tags", new string[] { tags.Vectorize(), "wikis" }, new
            {
                site = this.SiteUrlName,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            });
            return new PagedList<TagWiki>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/wikis-by-tags
        /// </summary>
        public IPagedList<TagWiki> GetTagWikis(string tag, int? page = null, int? pageSize = 0, string filter = null)
        {
            return GetTagWikis(new string[] { tag }, page, pageSize, filter);
        }
    }
}