using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual SiteInfo GetSiteStats()
        {
            return MakeRequest<SiteInfo>("info", null, new
            {
                site = this.SiteUrlName
            }).Items.FirstOrDefault();
        }
    }
}