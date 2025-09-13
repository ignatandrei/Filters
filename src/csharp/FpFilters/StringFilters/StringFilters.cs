namespace FpFilters.StringFilters
{
    public static class StringFilters
    {
        /// <summary>
        /// Returns true if the string starts with the specified substring.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <returns>True if the string starts with the substring; otherwise, false.</returns>
        public static bool StartsWith(string? arg, string substring) => arg?.StartsWith(substring) ?? false;

        /// <summary>
        /// Returns a function that checks if a string starts with the specified substring.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <returns>A function that checks if a string starts with the substring.</returns>
        public static Func<string?, bool> StartsWith(string substring) => arg => StartsWith(arg, substring);

        /// <summary>
        /// Returns true if the string starts with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <returns>True if the string starts with the substring; otherwise, false.</returns>
        public static bool StartsWith(string? arg, string substring, StringComparison comparison) => arg?.StartsWith(substring, comparison) ?? false;

        /// <summary>
        /// Returns a function that checks if a string starts with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <returns>A function that checks if a string starts with the substring.</returns>
        public static Func<string?, bool> StartsWith(string substring, StringComparison comparison) => arg => StartsWith(arg, substring, comparison);

        /// <summary>
        /// Returns true if the string ends with the specified substring.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <returns>True if the string ends with the substring; otherwise, false.</returns>
        public static bool EndsWith(string? arg, string substring) => arg?.EndsWith(substring) ?? false;

        /// <summary>
        /// Returns a function that checks if a string ends with the specified substring.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <returns>A function that checks if a string ends with the substring.</returns>
        public static Func<string?, bool> EndsWith(string substring) => arg => EndsWith(arg, substring);

        /// <summary>
        /// Returns true if the string ends with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <returns>True if the string ends with the substring; otherwise, false.</returns>
        public static bool EndsWith(string? arg, string substring, StringComparison comparison) => arg?.EndsWith(substring, comparison) ?? false;

        /// <summary>
        /// Returns a function that checks if a string ends with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <returns>A function that checks if a string ends with the substring.</returns>
        public static Func<string?, bool> EndsWith(string substring, StringComparison comparison) => arg => EndsWith(arg, substring, comparison);

        /// <summary>
        /// Returns true if the string includes the specified substring.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <returns>True if the string includes the substring; otherwise, false.</returns>
        public static bool Includes(string? arg, string substring) => arg?.Contains(substring) ?? false;

        /// <summary>
        /// Returns a function that checks if a string includes the specified substring.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <returns>A function that checks if a string includes the substring.</returns>
        public static Func<string?, bool> Includes(string substring) => arg => Includes(arg, substring);

        /// <summary>
        /// Returns true if the string includes the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <returns>True if the string includes the substring; otherwise, false.</returns>
        public static bool Includes(string? arg, string substring, StringComparison comparison) => arg?.IndexOf(substring, comparison) >= 0;

        /// <summary>
        /// Returns a function that checks if a string includes the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <returns>A function that checks if a string includes the substring.</returns>
        public static Func<string?, bool> Includes(string substring, StringComparison comparison) => arg => Includes(arg, substring, comparison);

        /// <summary>
        /// Returns true if the argument is an empty string ('').
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is empty; otherwise, false.</returns>
        public static bool IsEmptyString(string? arg) => arg == "";

        /// <summary>
        /// Returns true if the trimmed string is empty ('').
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the trimmed string is empty; otherwise, false.</returns>
        public static bool IsEmptyStringTrim(string? arg) => arg?.Trim() == "";

        /// <summary>
        /// Returns true if the string is all lower-case.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is all lower-case; otherwise, false.</returns>
        public static bool IsLowerCase(string? arg) => arg != null && arg.ToLower() == arg;

        /// <summary>
        /// Returns true if the string is all upper-case.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is all upper-case; otherwise, false.</returns>
        public static bool IsUpperCase(string? arg) => arg != null && arg.ToUpper() == arg;

        /// <summary>
        /// Returns true if the string is using a mixed case (not lower or upper).
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is mixed case; otherwise, false.</returns>
        public static bool IsMixedCase(string? arg) => arg != null && !(IsLowerCase(arg) || IsUpperCase(arg));

        /// <summary>
        /// Returns true if the string is using a uniform case (lower or upper).
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is uniform case; otherwise, false.</returns>
        public static bool IsUniformCase(string? arg) => IsLowerCase(arg) || IsUpperCase(arg);

        /// <summary>
        /// Returns true if the string could be trimmed.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string could be trimmed; otherwise, false.</returns>
        public static bool IsTrimmable(string? arg) => arg != null && arg.Trim() != arg;

        /// <summary>
        /// Returns true if the string could be trimmed at the start.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string could be trimmed at the start; otherwise, false.</returns>
        public static bool IsTrimmableStart(string? arg) => arg != null && arg.TrimStart() != arg;

        /// <summary>
        /// Returns true if the string could be trimmed at the end.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string could be trimmed at the end; otherwise, false.</returns>
        public static bool IsTrimmableEnd(string? arg) => arg != null && arg.TrimEnd() != arg;

        /// <summary>
        /// Returns true if a string is palindrome.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is a palindrome; otherwise, false.</returns>
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

        /// <summary>
        /// Returns true if the string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>True if the string matches the pattern; otherwise, false.</returns>
        public static bool Matches(string? arg, string pattern)
        {
            if (arg == null) return false;
            return Regex.IsMatch(arg, pattern);
        }

        /// <summary>
        /// Returns a function that checks if a string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>A function that checks if a string matches the pattern.</returns>
        public static Func<string?, bool> Matches(string pattern) => arg => Matches(arg, pattern);

        /// <summary>
        /// Returns false if the string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>False if the string matches the pattern; otherwise, true.</returns>
        public static bool DoesNotMatch(string? arg, string pattern)
        {
            if (arg == null) return true;
            return !Regex.IsMatch(arg, pattern);
        }

        /// <summary>
        /// Returns a function that checks if a string does not match the specified regular expression pattern.
        /// </summary>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>A function that checks if a string does not match the pattern.</returns>
        public static Func<string?, bool> DoesNotMatch(string pattern) => arg => DoesNotMatch(arg, pattern);

        /// <summary>
        /// Returns true if the string is a valid email address.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <returns>True if the string is a valid email address; otherwise, false.</returns>
        public static bool IsEmail(string? arg)
        {
            if (arg == null) return false;
            var pattern = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            return Regex.IsMatch(arg, pattern);
        }
    }
}
