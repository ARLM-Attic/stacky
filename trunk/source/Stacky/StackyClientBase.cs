using System;
using System.Collections.Generic;

namespace Stacky
{
    public abstract class StackyClientBase
    {
        public IProtocol Protocol { get; set; }
        public string SiteUrlName { get; set; }

        public int RemainingRequests { get; internal set; }
        public int MaxRequests { get; internal set; }

        protected string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        protected string GetSortDirection(SortDirection? direction)
        {
            if (direction.HasValue)
                return GetSortDirection(direction.Value);
            return null;
        }

        protected static string GetEnumValue(object sort)
        {
            return EnumHelper.GetQueryStringValue((Enum)sort);
        }

        protected long? GetDateValue(DateTime? date)
        {
            if (date.HasValue)
                return UnixDateTime.UnixTimeFromDate(date.Value);
            return null;
        }
    }
}