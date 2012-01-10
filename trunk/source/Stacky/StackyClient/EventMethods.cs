using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Event> GetEvents(string accessToken, DateTime? since = null, int? page = null, int? pageSize = null)
        {
            var response = MakeRequest<Event>("events", null, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                since = GetDateValue(since)
            });
            return new PagedList<Event>(response);
        }
    }
}