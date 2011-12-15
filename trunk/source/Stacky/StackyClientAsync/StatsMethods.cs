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
        public virtual void GetSiteStats(Action<SiteInfo> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<SiteInfo>("stats", null, new
            {
                site = this.SiteUrlName
            }, results => onSuccess(results.Items.FirstOrDefault()), onError);
        }
    }
}