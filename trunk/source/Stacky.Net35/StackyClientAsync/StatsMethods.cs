using System;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public virtual void GetSiteStats(Action<SiteStats> onSuccess, Action<ApiException> onError)
        {
            MakeRequest<SiteStats>("stats", null, new
            {
                site = this.SiteUrlName
            }, results => onSuccess(results.Items.FirstOrDefault()), onError);
        }
    }
}