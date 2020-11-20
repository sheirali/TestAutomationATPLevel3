using System;

namespace Unicorn
{
    public static class StringExtensions
    {
        public static string MakeFirstLetterToLower(this string text)
        {
            return string.IsNullOrEmpty(text) ? string.Empty : char.ToLowerInvariant(text[0]) + text.Substring(1);
        }
    }
}
