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
    }
}