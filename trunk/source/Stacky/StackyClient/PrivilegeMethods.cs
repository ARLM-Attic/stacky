﻿using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        /// <summary>
        /// Get a list of all the Privileges
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Privilege> GetPrivileges()
        {
            return MakeRequest<Privilege>("privileges", null, new
            {
                site = this.SiteUrlName
            }).Items;
        }
    }
}
