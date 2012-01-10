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
        /// See: http://api.stackexchange.com/docs/inbox
        /// </summary>
        public void GetGlobalInbox(string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError = null,
            int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<InboxItem>("inbox", null, new
            {
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/inbox
        /// </summary>
        public void GetUnreadGlobalInbox(string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError = null,
            DateTime? since = null, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<InboxItem>("inbox", new string[] { "unread" }, new
            {
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                since = GetDateValue(since),
                filter = filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }
    }
}