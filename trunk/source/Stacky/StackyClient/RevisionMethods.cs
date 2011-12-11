﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IEnumerable<Revision> GetRevisions(IEnumerable<int> ids, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<Revision>("revisions", new string[] { ids.Vectorize() }, new
            {
                site = this.SiteUrlName,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }).Items;
        }

        public virtual IEnumerable<Revision> GetRevisions(int id, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetRevisions(id.ToArray(), fromDate, toDate);
        }

        public virtual Revision GetRevision(int id, Guid revision)
        {
            return MakeRequest<Revision>("revisions", new string[] { id.ToString(), revision.ToString() }, new
            {
                site = this.SiteUrlName,
            }).Items.FirstOrDefault();
        }
    }
}