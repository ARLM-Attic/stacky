using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky
{
    public static class GenerateValue
    {
        private static Random Random = new Random();

        private static bool IsNull
        {
            get { return Random.Next(2) == 1; }
        }

        private static int GetIndex(int max)
        {
            return Random.Next(max);
        }

        public static int? NullableInt32(int min, int max)
        {
            if (IsNull)
            {
                return null;
            }
            return Int32(min, max);
        }

        public static int Int32(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static DateTime? NullableDateTime()
        {
            if (IsNull)
            {
                return null;
            }
            return DateTime();
        }

        public static DateTime DateTime()
        {
            return UnixDateTime.DateFromUnixTime(UnixDateTime.UnixTimeFromDate(UnixDateTime.UnixEpoch) + (long)Random.Next());
        }

        public static T Enum<T>()
            where T : struct
        {
            if (!EnumHelper.IsEnum(typeof(T)))
                throw new ArgumentOutOfRangeException("T", "Type must be enum");

            Array values = System.Enum.GetValues(typeof(T));
            int index = GetIndex(values.Length);
            return (T)values.GetValue(index);
        }

        public static T? NullableEnum<T>()
            where T : struct
        {
            if (IsNull)
            {
                return null;
            }
            return Enum<T>();
        }
    }
}
