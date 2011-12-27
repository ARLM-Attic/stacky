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
        public virtual void GetRevisions(IEnumerable<int> ids, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError)
        {
            GetRevisions(ids, onSuccess, onError, null, null);
        }

        public virtual void GetRevisions(IEnumerable<int> ids, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError, DateTime? fromDate, DateTime? toDate)
        {
            MakeRequest<Revision>("revisions", new string[] { ids.Vectorize() }, new
            {
                site = this.SiteUrlName,
                fromdate = GetDateValue(fromDate),
                todate = GetDateValue(toDate),
            }, (items) => onSuccess(items.Items), onError);
        }

        public virtual void GetRevisions(int id, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError)
        {
            GetRevisions(id, onSuccess, onError, null, null);
        }

        public virtual void GetRevisions(int id, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError, DateTime? fromDate, DateTime? toDate)
        {
            GetRevisions(id.ToArray(), onSuccess, onError, fromDate, toDate);
        }

        public virtual void GetRevision(int id, Guid revision, Action<Revision> onSuccess, Action<ApiException> onError)
        {
            MakeRequest<Revision>("revisions", new string[] { id.ToString(), revision.ToString() }, new
            {
                site = this.SiteUrlName
            }, returnedItems => onSuccess(returnedItems.Items.FirstOrDefault()), onError);
        }
    }
}