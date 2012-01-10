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
        public void GetGlobalInbox(string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError, Options options)
        {
            MakeRequest<InboxItem>("inbox", null, new
            {
                access_token = accessToken,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/inbox
        /// </summary>
        public void GetUnreadGlobalInbox(string accessToken, Action<IPagedList<InboxItem>> onSuccess, Action<ApiException> onError,
            DateTime? since, Options options)
        {
            MakeRequest<InboxItem>("inbox", new string[] { "unread" }, new
            {
                access_token = accessToken,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                since = GetDateValue(since),
                filter = options.Filter
            }, response => onSuccess(new PagedList<InboxItem>(response)), onError);
        }
    }
}