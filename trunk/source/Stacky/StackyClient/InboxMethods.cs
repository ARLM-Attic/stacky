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
        public IPagedList<InboxItem> GetGlobalInbox(string accessToken, int? page = null, int? pageSize = null)
        {
            var response = MakeRequest<InboxItem>("inbox", null, new
            {
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null
            });
            return new PagedList<InboxItem>(response);
        }

        /// <summary>
        /// See: http://api.stackexchange.com/docs/inbox
        /// </summary>
        public IPagedList<InboxItem> GetUnreadGlobalInbox(string accessToken, DateTime? since = null, int? page = null, int? pageSize = null)
        {
            var response = MakeRequest<InboxItem>("inbox", new string[] { "unread" }, new
            {
                access_token = accessToken,
                page = page ?? null,
                pagesize = pageSize ?? null,
                since = GetDateValue(since)
            });
            return new PagedList<InboxItem>(response);
        }
    }
}