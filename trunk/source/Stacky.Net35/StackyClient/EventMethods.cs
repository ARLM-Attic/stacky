using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Event> GetEvents(string accessToken, DateTime? since, Options options)
        {
            var response = MakeRequest<Event>("events", null, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                since = GetDateValue(since),
                filter = options.Filter
            });
            return new PagedList<Event>(response);
        }
    }
}