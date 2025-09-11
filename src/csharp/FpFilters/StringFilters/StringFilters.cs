namespace FpFilters.StringFilters
{
    public static class StringFilters
    {
        // Returns true if the string starts with the specified substring
        public static bool StartsWith(string? arg, string substring) => arg?.StartsWith(substring) ?? false;
        public static Func<string?, bool> StartsWith(string substring) => arg => StartsWith(arg, substring);

        // Returns true if the string starts with the specified substring, with StringComparison
        public static bool StartsWith(string? arg, string substring, StringComparison comparison) => arg?.StartsWith(substring, comparison) ?? false;
        public static Func<string?, bool> StartsWith(string substring, StringComparison comparison) => arg => StartsWith(arg, substring, comparison);

        // Returns true if the string ends with the specified substring
        public static bool EndsWith(string? arg, string substring) => arg?.EndsWith(substring) ?? false;
        public static Func<string?, bool> EndsWith(string substring) => arg => EndsWith(arg, substring);

        // Returns true if the string ends with the specified substring, with StringComparison
        public static bool EndsWith(string? arg, string substring, StringComparison comparison) => arg?.EndsWith(substring, comparison) ?? false;
        public static Func<string?, bool> EndsWith(string substring, StringComparison comparison) => arg => EndsWith(arg, substring, comparison);

        // Returns true if the string includes the specified substring
        public static bool Includes(string? arg, string substring) => arg?.Contains(substring) ?? false;
        public static Func<string?, bool> Includes(string substring) => arg => Includes(arg, substring);

        // Returns true if the argument is an empty string ('')
        public static bool IsEmptyString(string? arg) => arg == "";

        // Returns true if the trimmed string is empty ('')
        public static bool IsEmptyStringTrim(string? arg) => arg?.Trim() == "";

        // Returns true if the string is all lower-case
        public static bool IsLowerCase(string? arg) => arg != null && arg.ToLower() == arg;

        // Returns true if the string is all upper-case
        public static bool IsUpperCase(string? arg) => arg != null && arg.ToUpper() == arg;

        // Returns true if the string is using a mixed case (not lower or upper)
        public static bool IsMixedCase(string? arg) => arg != null && !(IsLowerCase(arg) || IsUpperCase(arg));

        // Returns true if the string is using a uniform case (lower or upper)
        public static bool IsUniformCase(string? arg) => IsLowerCase(arg) || IsUpperCase(arg);

        // Returns true if the string could be trimmed
        public static bool IsTrimmable(string? arg) => arg != null && arg.Trim() != arg;

        // Returns true if the string could be trimmed at the start
        public static bool IsTrimmableStart(string? arg) => arg != null && arg.TrimStart() != arg;

        // Returns true if the string could be trimmed at the end
        public static bool IsTrimmableEnd(string? arg) => arg != null && arg.TrimEnd() != arg;

        // Returns true if a string is palindrome
        public static bool IsPalindrome(string? arg)
        {
            if (arg == null) return false;
            for (int i = 0; i < arg.Length / 2; i++)
            {
                if (arg[i] != arg[arg.Length - i - 1])
                    return false;
            }
            return true;
        }

        // Returns true if the string matches the specified regexp
        public static bool Matches(string? arg, string pattern)
        {
            if (arg == null) return false;
            return Regex.IsMatch(arg, pattern);
        }
        public static Func<string?, bool> Matches(string pattern) => arg => Matches(arg, pattern);

        // Returns false if the string matches the specified regexp
        public static bool DoesNotMatch(string? arg, string pattern)
        {
            if (arg == null) return true;
            return !Regex.IsMatch(arg, pattern);
        }
        public static Func<string?, bool> DoesNotMatch(string pattern) => arg => DoesNotMatch(arg, pattern);

        // Returns true if the string is a valid email address
        public static bool IsEmail(string? arg)
        {
            if (arg == null) return false;
            var pattern = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            return Regex.IsMatch(arg, pattern);
        }
    }
}
