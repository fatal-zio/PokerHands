using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Extensions
    {
        public static bool IsUpperCase(this string @this)
        {
            return @this != null && @this.All(t => !char.IsLetter(t) || char.IsUpper(t));
        }

        public static bool IsNotUpperCase(this string @this)
        {
            return !IsUpperCase(@this);
        }

        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        public static IEnumerable<T> GetValues<T>(this IEnumerable<Enum> @this)
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<TEnum> Values<TEnum>()
        where TEnum : struct,  IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);

            // Optional runtime check for completeness
            if(!enumType.IsEnum)
            {
                throw new ArgumentException();
            }

            return Enum.GetValues(enumType).Cast<TEnum>();
        }
    }
}