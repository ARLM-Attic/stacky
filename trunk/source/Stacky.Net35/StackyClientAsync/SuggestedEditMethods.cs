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
        /// See http://api.stackexchange.com/docs/suggested-edits
        /// </summary>
        public void GetSuggestedEdits(Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            Execute<SuggestedEdit>("suggested-edits", null, onSuccess, onError, options);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public void GetSuggestedEdits(IEnumerable<int> ids, Action<IPagedList<SuggestedEdit>> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            Execute<SuggestedEdit>("suggested-edits", new string[] { ids.Vectorize() }, onSuccess, onError, options);
        }

        /// <summary>
        /// See http://api.stackexchange.com/docs/suggested-edits-by-ids
        /// </summary>
        public void GetSuggestedEdit(int id, Action<SuggestedEdit> onSuccess, Action<ApiException> onError, Options<SuggestedEditSort> options)
        {
            GetSuggestedEdits(id.ToArray(), items => onSuccess(items.FirstOrDefault()), onError, options);
        }
    }
}