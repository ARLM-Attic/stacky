using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual SiteStats GetSiteStats()
        {
            return MakeRequest<SiteStats>("stats", null, new
            {
                site = this.SiteUrlName
            }).Items.FirstOrDefault();
        }
    }
}