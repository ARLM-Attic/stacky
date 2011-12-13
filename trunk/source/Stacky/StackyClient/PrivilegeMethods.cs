using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// Get a list of all the Privileges
        /// </summary>
        /// <returns></returns>
        public IPagedList<Privilege> GetPrivileges()
        {
            var response = MakeRequest<Privilege>("privileges", null, new
            {
                site = this.SiteUrlName
            });
            return new PagedList<Privilege>(response);
        }
    }
}
