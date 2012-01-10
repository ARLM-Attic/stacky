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
        public void GetEvents(string accessToken, Action<IPagedList<Event>> onSuccess, Action<ApiException> onError = null,
            DateTime? since = null, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<Event>("events", null, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                since = GetDateValue(since),
                filter = filter
            }, response => onSuccess(new PagedList<Event>(response)), onError);
        }
    }
}