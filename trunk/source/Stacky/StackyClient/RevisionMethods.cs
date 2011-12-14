using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public IPagedList<Revision> GetRevisions(IEnumerable<string> ids, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return Execute<Revision>("revisions", new string[] { ids.Vectorize() },
                null, null, page, pageSize, fromDate, toDate, null, null, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public IPagedList<Revision> GetRevisions(IEnumerable<Guid> ids, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetRevisions(ids.Select(i => i.ToString()), page, pageSize, fromDate, toDate, filter);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public Revision GetRevision(string id, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetRevisions(new string[] { id }, page, pageSize, fromDate, toDate, filter).FirstOrDefault();
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public Revision GetRevision(Guid id, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, string filter = null)
        {
            return GetRevisions(new string[] { id.ToString() }, page, pageSize, fromDate, toDate, filter).FirstOrDefault();
        }
    }
}