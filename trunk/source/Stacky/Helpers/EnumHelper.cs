using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Stacky
{
    /// <summary>
    /// Enum helper methods.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the attribute of the specified type for the provided enum value.
        /// </summary>
        /// <typeparam name="T">The attribute type.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The attribute if it exists, otherwise null.</returns>
        public static T GetAttribute<T>(this Enum value)
            where T : Attribute
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            T[] attributes = (T[])fi.GetCustomAttributes(typeof(T), false);
            if (attributes == null)
                return null;
            return attributes.FirstOrDefault();
        }

        public static string GetQueryStringValue(this Enum value)
        {
            if (value == null)
                return null;
            List<char> result = new List<char>();
            string valueString = value.ToString();

            for (int i = 0; i < valueString.Length; i++)
            {
                char item = valueString[i];
                if (i != 0 && Char.IsUpper(item))
                {
                    result.Add('_');
                }
                result.Add(Char.ToLower(item));
            }

            return new string(result.ToArray());
        }

		public static bool IsEnum(Type type)
		{
			Type t = (EnumHelper.IsNullableType(type))
			? Nullable.GetUnderlyingType(type)
			: type;

			return t.IsEnum;
		}

		public static bool IsNullable(Type type)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			if (type.IsValueType)
				return IsNullableType(type);

			return true;
		}

		public static bool IsNullableType(Type type)
		{
			if (type == null)
				throw new ArgumentNullException("type");

			return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
		}

		// TODO: Consider removing this method and it's associated tests as it is currently not being used
		public static string ParseQueryStringValue(string value)
		{
			List<char> result = new List<char>();
			for (int i = 0; i < value.Length; i++)
			{
				char c = value[i];
				if (i == 0)
				{
					result.Add(Char.ToUpper(c));
				}
				else if (c == '_')
				{
					// skip the underscore and capitalize the next letter
					result.Add(Char.ToUpper(value[++i]));
				}
				else
				{
					result.Add(c);
				}
			}
			return new string(result.ToArray());
		}
	}
}