using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IEnumerable<Revision> GetRevisions(IEnumerable<int> ids)
        {
            return GetRevisions(ids, null, null);
        }

        public virtual IEnumerable<Revision> GetRevisions(IEnumerable<int> ids, DateTime? fromDate, DateTime? toDate)
        {
            return MakeRequest<Revision>("revisions", new string[] { ids.Vectorize() }, new
            {
                site = this.SiteUrlName,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }).Items;
        }

        public virtual IEnumerable<Revision> GetRevisions(int id)
        {
            return GetRevisions(id.ToArray());
        }

        public virtual IEnumerable<Revision> GetRevisions(int id, DateTime? fromDate, DateTime? toDate)
        {
            return GetRevisions(id.ToArray(), fromDate, toDate);
        }

        public virtual Revision GetRevision(int id, Guid revision)
        {
            return MakeRequest<Revision>("revisions", new string[] { id.ToString(), revision.ToString() }, new
            {
                site = this.SiteUrlName
            }).Items.FirstOrDefault();
        }
    }
}