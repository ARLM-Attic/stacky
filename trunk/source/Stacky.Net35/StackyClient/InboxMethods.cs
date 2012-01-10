using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See: http://api.stackexchange.com/docs/inbox
        /// </summary>
        public IPagedList<InboxItem> GetGlobalInbox(string accessToken, Options options)
        {
            var response = MakeRequest<InboxItem>("inbox", null, new
            {
                access_token = accessToken,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter
            });
            return new PagedList<InboxItem>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/inbox
        /// </summary>
        public IPagedList<InboxItem> GetUnreadGlobalInbox(string accessToken, DateTime? since, Options options)
        {
            var response = MakeRequest<InboxItem>("inbox", new string[] { "unread" }, new
            {
                access_token = accessToken,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                since = GetDateValue(since),
                filter = options.Filter
            });
            return new PagedList<InboxItem>(response);
        }
    }
}