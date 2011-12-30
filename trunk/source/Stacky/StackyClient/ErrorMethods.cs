using System;
using System.Linq;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Error> GetErrors(int? page = null, int? pageSize = null)
        {
            return Execute<Error>("errors", null, new
            {
                page = page ?? null,
                pagesize = pageSize ?? null
            });
        }

        /// <summary>
        /// https://api.stackexchange.com/docs/simulate-error
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Error SimulateError(int id)
        {
            return Execute<Error>("errors", new string[] { id.ToString() }, null).FirstOrDefault();
        }
    }
}