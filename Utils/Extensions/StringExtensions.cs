using System.Globalization;
using System.Text.RegularExpressions;

namespace Utils.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeSpacesAndCapitalize(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string normalized = textInfo.ToTitleCase(Regex.Replace(input.ToLower(), @"\s+", " ").Trim());

            return normalized;
        }
    }
}
