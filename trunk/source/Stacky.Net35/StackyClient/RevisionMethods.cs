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
        public IPagedList<Revision> GetRevisions(IEnumerable<string> ids, OptionsWithDates options)
        {
            return Execute<Revision>("revisions", new string[] { ids.Vectorize() }, options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public IPagedList<Revision> GetRevisions(IEnumerable<Guid> ids, OptionsWithDates options)
        {
            return GetRevisions(ids.Select(i => i.ToString()), options);
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public Revision GetRevision(string id, OptionsWithDates options)
        {
            return GetRevisions(new string[] { id }, options).FirstOrDefault();
        }

        /// <summary>
        /// See https://api.stackexchange.com/docs/revisions-by-guids
        /// </summary>
        public Revision GetRevision(Guid id, OptionsWithDates options)
        {
            return GetRevisions(new string[] { id.ToString() }, options).FirstOrDefault();
        }
    }
}