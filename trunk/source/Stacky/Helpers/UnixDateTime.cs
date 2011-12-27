namespace Stacky
{
    using System;

    public struct UnixDateTime : 
        IEquatable<UnixDateTime>, 
        IEquatable<long>, 
        IEquatable<DateTime>,
        IComparable<UnixDateTime>,
        IComparable<long>,
        IComparable<DateTime>
    {
        private DateTime value;
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);

        #region Constructor

        public UnixDateTime(DateTime value)
        {
            this.value = value;
        }

        public UnixDateTime(long value)
        {
            this.value = UnixDateTime.DateFromUnixTime(value);
        }

        #endregion

        #region Properties

        public long UnixValue
        {
            get { return UnixDateTime.UnixTimeFromDate(value); }
        }

        public DateTime DateValue
        {
            get { return value; }
        }

        #endregion

        #region Conversion

        public static DateTime DateFromUnixTime(long value)
        {
            return UnixEpoch.AddSeconds(value);
        }

        public static Int64 UnixTimeFromDate(DateTime value)
        {
            var delta = value - UnixEpoch;

            if (delta.TotalSeconds < 0) throw new ArgumentOutOfRangeException("self", "Unix epoch starts January 1st, 1970");

            return (long)delta.TotalSeconds;
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return UnixValue.ToString();
        }

        public override int GetHashCode()
        {
            return UnixValue.GetHashCode();
        }

        #endregion

        #region Equals

        public bool Equals(DateTime other)
        {
            if (Object.Equals(other, null))
                return false;
            return DateValue == other;
        }

        public bool Equals(long other)
        {
            return UnixValue == other;
        }

        public bool Equals(UnixDateTime other)
        {
            if (Object.Equals(other, null))
            {
                return false;
            }
            return other.DateValue == DateValue;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((UnixDateTime)obj);
        }

        #endregion

        #region Operators

        public static implicit operator DateTime(UnixDateTime value)
        {
            return value.DateValue;
        }

        public static implicit operator long(UnixDateTime value)
        {
            return value.UnixValue;
        }

        public static implicit operator UnixDateTime(long value)
        {
            return new UnixDateTime(value);
        }

        public static implicit operator UnixDateTime(DateTime value)
        {
            return new UnixDateTime(value);
        }

        public static bool operator ==(UnixDateTime d1, UnixDateTime d2)
        {
            if (Object.Equals(d1, null))
            {
                return false;
            }
            return d1.Equals(d2);
        }

        public static bool operator !=(UnixDateTime d1, UnixDateTime d2)
        {
            if (Object.Equals(d1, null))
            {
                return false;
            }
            return !d1.Equals(d2);
        }

        public static bool operator <(UnixDateTime d1, UnixDateTime d2)
        {
            if (Object.Equals(d1, null) || Object.Equals(d2, null))
            {
                return false;
            }
            return d1.DateValue < d2.DateValue;
        }

        public static bool operator <=(UnixDateTime d1, UnixDateTime d2)
        {
            if (Object.Equals(d1, null) || Object.Equals(d2, null))
            {
                return false;
            }
            return d1.DateValue <= d2.DateValue;
        }

        public static bool operator >(UnixDateTime d1, UnixDateTime d2)
        {
            if (Object.Equals(d1, null) || Object.Equals(d2, null))
            {
                return false;
            }
            return d1.DateValue > d2.DateValue;
        }

        public static bool operator >=(UnixDateTime d1, UnixDateTime d2)
        {
            if (Object.Equals(d1, null) || Object.Equals(d2, null))
            {
                return false;
            }
            return d1.DateValue >= d2.DateValue;
        }

        #endregion

        #region CompareTo

        public int CompareTo(UnixDateTime other)
        {
            if (Object.Equals(other, null))
            {
                throw new ArgumentNullException("other");
            }
            return DateValue.CompareTo(other.DateValue);
        }

        public int CompareTo(long other)
        {
            if (Object.Equals(other, null))
            {
                throw new ArgumentNullException("other");
            }
            return UnixValue.CompareTo(other);
        }

        public int CompareTo(DateTime other)
        {
            if (Object.Equals(other, null))
            {
                throw new ArgumentNullException("other");
            }
            return DateValue.CompareTo(other);
        }

        #endregion
    }
}