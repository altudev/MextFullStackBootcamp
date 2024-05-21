using System.Text.RegularExpressions;

namespace MextFullstackSaaS.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
