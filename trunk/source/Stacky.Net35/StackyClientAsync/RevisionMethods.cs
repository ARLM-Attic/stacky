using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevisions(IEnumerable<string> ids, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            Execute<Revision>("revisions", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevisions(IEnumerable<Guid> ids, Action<IPagedList<Revision>> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetRevisions(ids.Select(i => i.ToString()), onSuccess, onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevision(string id, Action<Revision> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetRevisions(new string[] { id }, items => onSuccess(items.FirstOrDefault()), onError, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public void GetRevision(Guid id, Action<Revision> onSuccess, Action<ApiException> onError, OptionsWithDates options)
        {
            GetRevisions(new string[] { id.ToString() }, items => onSuccess(items.FirstOrDefault()), onError, options);
        }
    }
}