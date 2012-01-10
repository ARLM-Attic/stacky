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
        public void GetEvents(string accessToken, Action<IPagedList<Event>> onSuccess, Action<ApiException> onError,
            DateTime? since, Options options)
        {
            MakeRequest<Event>("events", null, new
            {
                site = this.SiteUrlName,
                access_token = accessToken,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                since = GetDateValue(since),
                filter = options.Filter
            }, response => onSuccess(new PagedList<Event>(response)), onError);
        }
    }
}