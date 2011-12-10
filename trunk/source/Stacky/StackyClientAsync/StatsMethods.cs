using System;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient : StackyClientBase
#else
    public partial class StackyClientAsync : StackyClientBase
#endif
    {
        public virtual void GetSiteStats(Action<SiteStats> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<StatsResponse>("stats", null, new
            {
                site = this.SiteUrlName
            }, results => onSuccess(results.Statistics.FirstOrDefault()), onError);
        }
    }
}