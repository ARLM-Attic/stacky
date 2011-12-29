using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits
        /// </summary>
        public IPagedList<SuggestedEdit> GetSuggestedEdits()
        {
            return GetSuggestedEdits(null);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits
        /// </summary>
        public IPagedList<SuggestedEdit> GetSuggestedEdits(Options<SuggestedEditSort> options)
        {
            return Execute<SuggestedEdit>("suggested-edits", null, options);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public IPagedList<SuggestedEdit> GetSuggestedEdits(IEnumerable<int> ids, Options<SuggestedEditSort> options)
        {
            return Execute<SuggestedEdit>("suggested-edits", new string[] { ids.Vectorize() }, options);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public SuggestedEdit GetSuggestedEdit(int id, Options<SuggestedEditSort> options)
        {
            return GetSuggestedEdits(id.ToArray(), options).FirstOrDefault();
        }
    }
}