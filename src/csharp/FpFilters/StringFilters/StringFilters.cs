namespace FpFilters.StringFilters
{
    public static class StringFilters
    {
        /// <summary>
        /// Returns true if the string starts with the specified substring.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <summary>
/// Determines whether <paramref name="arg"/> starts with the specified <paramref name="substring"/>.
/// </summary>
/// <param name="arg">The string to test; if null, the method returns false.</param>
/// <param name="substring">The substring to compare at the start of <paramref name="arg"/>.</param>
/// <returns>true if <paramref name="arg"/> starts with <paramref name="substring"/>; otherwise, false.</returns>
        public static bool StartsWith(string? arg, string substring) => arg?.StartsWith(substring) ?? false;

        /// <summary>
        /// Returns a function that checks if a string starts with the specified substring.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <summary>
/// Returns a predicate that checks whether its input string starts with the specified substring.
/// </summary>
/// <param name="substring">The substring to test for at the start of the input.</param>
/// <returns>A function that takes a string? and returns true if that string starts with <paramref name="substring"/>; returns false for null input.</returns>
        public static Func<string?, bool> StartsWith(string substring) => arg => StartsWith(arg, substring);

        /// <summary>
        /// Returns true if the string starts with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> starts with <paramref name="substring"/> using the specified <see cref="StringComparison"/>; otherwise false.
/// </summary>
/// <param name="arg">The string to test. If null, the method returns false.</param>
/// <param name="substring">The prefix to compare against <paramref name="arg"/>.</param>
/// <param name="comparison">The rules for the comparison (culture, case, etc.).</param>
/// <returns>True if <paramref name="arg"/> starts with <paramref name="substring"/> under the given comparison; otherwise false.</returns>
        public static bool StartsWith(string? arg, string substring, StringComparison comparison) => arg?.StartsWith(substring, comparison) ?? false;

        /// <summary>
        /// Returns a function that checks if a string starts with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <summary>
/// Returns a function that tests whether its input string starts with the specified substring using the given StringComparison.
/// </summary>
/// <param name="substring">The substring to compare at the start of the input string.</param>
/// <param name="comparison">The StringComparison to use for the comparison.</param>
/// <returns>A function that takes a nullable string and returns true if it starts with <paramref name="substring"/> according to <paramref name="comparison"/>, otherwise false.</returns>
        public static Func<string?, bool> StartsWith(string substring, StringComparison comparison) => arg => StartsWith(arg, substring, comparison);

        /// <summary>
        /// Returns true if the string ends with the specified substring.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <summary>
/// Determines whether the specified string starts with the given substring.
/// </summary>
/// <param name="arg">The string to test; returns <c>false</c> if <c>null</c>.</param>
/// <param name="substring">The substring to compare at the end of <paramref name="arg"/>.</param>
/// <returns><c>true</c> if <paramref name="arg"/> ends with <paramref name="substring"/>; otherwise <c>false</c>.</returns>
        public static bool EndsWith(string? arg, string substring) => arg?.EndsWith(substring) ?? false;

        /// <summary>
        /// Returns a function that checks if a string ends with the specified substring.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <summary>
/// Returns a function that tests whether its input string ends with the given substring.
/// The returned predicate returns false if the input is null.
/// </summary>
/// <param name="substring">The substring to test for at the end of the input string.</param>
/// <returns>A <see cref="Func{String,Boolean}"/> that returns true when the input ends with <paramref name="substring"/>.</returns>
        public static Func<string?, bool> EndsWith(string substring) => arg => EndsWith(arg, substring);

        /// <summary>
        /// Returns true if the string ends with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <summary>
/// Returns true if <paramref name="arg"/> ends with the specified <paramref name="substring"/> using the provided <paramref name="comparison"/>; returns false if <paramref name="arg"/> is null.
/// </summary>
/// <param name="arg">The input string to test; may be null.</param>
/// <param name="substring">The substring to compare against the end of <paramref name="arg"/>.</param>
/// <param name="comparison">The <see cref="StringComparison"/> to use for the comparison.</param>
/// <returns>True when <paramref name="arg"/> ends with <paramref name="substring"/> according to <paramref name="comparison"/>; otherwise, false.</returns>
        public static bool EndsWith(string? arg, string substring, StringComparison comparison) => arg?.EndsWith(substring, comparison) ?? false;

        /// <summary>
        /// Returns a function that checks if a string ends with the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <summary>
/// Returns a function that tests whether its input string ends with the specified substring using the given StringComparison.
/// The produced function returns false for a null input.
/// </summary>
/// <param name="substring">The substring to test for at the end of the input string.</param>
/// <param name="comparison">The StringComparison to use when comparing the input and the substring.</param>
/// <returns>A function that takes a string? and returns true if it ends with <paramref name="substring"/> per <paramref name="comparison"/>; false for null input.</returns>
        public static Func<string?, bool> EndsWith(string substring, StringComparison comparison) => arg => EndsWith(arg, substring, comparison);

        /// <summary>
        /// Returns true if the string includes the specified substring.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <summary>
/// Returns true if <paramref name="arg"/> contains the specified <paramref name="substring"/>; returns false if <paramref name="arg"/> is null or the substring is not found.
/// </summary>
/// <param name="arg">The string to search (may be null).</param>
/// <param name="substring">The substring to locate within <paramref name="arg"/>.</param>
/// <returns>True when <paramref name="arg"/> contains <paramref name="substring"/>; otherwise false.</returns>
        public static bool Includes(string? arg, string substring) => arg?.Contains(substring) ?? false;

        /// <summary>
        /// Returns a function that checks if a string includes the specified substring.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <summary>
/// Returns a function that tests whether its string argument contains the specified substring.
/// </summary>
/// <param name="substring">The substring to search for in the input string.</param>
/// <returns>A function that returns true when the input contains <paramref name="substring"/>; returns false if the input is null.</returns>
        public static Func<string?, bool> Includes(string substring) => arg => Includes(arg, substring);

        /// <summary>
        /// Returns true if the string includes the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <summary>
/// Determines whether <paramref name="arg"/> contains the specified <paramref name="substring"/> using the given <see cref="StringComparison"/>.
/// </summary>
/// <param name="substring">The substring to search for.</param>
/// <param name="comparison">The comparison rules to use (culture, case, etc.).</param>
/// <returns>
/// <c>true</c> if <paramref name="arg"/> contains <paramref name="substring"/> according to <paramref name="comparison"/>; <c>false</c> if <paramref name="arg"/> is null or the substring is not found.
/// </returns>
        public static bool Includes(string? arg, string substring, StringComparison comparison) => arg?.IndexOf(substring, comparison) >= 0;

        /// <summary>
        /// Returns a function that checks if a string includes the specified substring, using the given StringComparison.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <param name="comparison">The string comparison option.</param>
        /// <summary>
/// Returns a function that tests whether a given string contains <paramref name="substring"/> using the specified <paramref name="comparison"/>.
/// </summary>
/// <param name="substring">The substring to search for.</param>
/// <param name="comparison">The StringComparison to use for the search.</param>
/// <returns>A function that returns true if its input contains <paramref name="substring"/> per <paramref name="comparison"/>; returns false if the input is null.</returns>
        public static Func<string?, bool> Includes(string substring, StringComparison comparison) => arg => Includes(arg, substring, comparison);

        /// <summary>
        /// Returns true if the argument is an empty string ('').
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Returns true if the given string is exactly the empty string (""); otherwise false.
/// </summary>
/// <param name="arg">The string to test; may be null.</param>
/// <returns>True when <paramref name="arg"/> is "", otherwise false.</returns>
        public static bool IsEmptyString(string? arg) => arg == "";

        /// <summary>
        /// Returns true if the trimmed string is empty ('').
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether the provided string, after trimming whitespace from both ends, is empty.
/// </summary>
/// <param name="arg">The string to test; may be null.</param>
/// <returns>True if <paramref name="arg"/> is non-null and <c>arg.Trim()</c> is the empty string; otherwise false.</returns>
        public static bool IsEmptyStringTrim(string? arg) => arg?.Trim() == "";

        /// <summary>
        /// Returns true if the string is all lower-case.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> is non-null and every letter in the string is lowercase.
/// </summary>
/// <param name="arg">The string to test; may be null.</param>
/// <returns>True if <paramref name="arg"/> is non-null and equals its lowercase form; otherwise, false.</returns>
        public static bool IsLowerCase(string? arg) => arg != null && arg.ToLower() == arg;

        /// <summary>
        /// Returns true if the string is all upper-case.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether the provided string is entirely upper-case.
/// </summary>
/// <param name="arg">The string to evaluate; null returns false.</param>
/// <returns>True if <paramref name="arg"/> is non-null and equals its upper-case form; otherwise false.</returns>
        public static bool IsUpperCase(string? arg) => arg != null && arg.ToUpper() == arg;

        /// <summary>
        /// Returns true if the string is using a mixed case (not lower or upper).
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether the given string contains a mix of upper- and lower-case characters.
/// </summary>
/// <param name="arg">The string to check. If null, the method returns false.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is not null and is neither all lower-case nor all upper-case; otherwise, <c>false</c>.</returns>
        public static bool IsMixedCase(string? arg) => arg != null && !(IsLowerCase(arg) || IsUpperCase(arg));

        /// <summary>
        /// Returns true if the string is using a uniform case (lower or upper).
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether a string is uniformly cased (all lower-case or all upper-case).
/// </summary>
/// <param name="arg">The string to test; null returns <c>false</c>.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is all lower-case or all upper-case; otherwise <c>false</c>.</returns>
        public static bool IsUniformCase(string? arg) => IsLowerCase(arg) || IsUpperCase(arg);

        /// <summary>
        /// Returns true if the string could be trimmed.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether the input string has removable leading or trailing whitespace.
/// </summary>
/// <param name="arg">The string to check; returns false if null.</param>
/// <returns><c>true</c> if trimming <paramref name="arg"/> would change it (i.e., it has leading or trailing whitespace); otherwise <c>false</c>.</returns>
        public static bool IsTrimmable(string? arg) => arg != null && arg.Trim() != arg;

        /// <summary>
        /// Returns true if the string could be trimmed at the start.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether the given string has removable leading whitespace.
/// </summary>
/// <param name="arg">The string to check. If null, the method returns false.</param>
/// <returns>True if <paramref name="arg"/> is non-null and trimming its start would change it; otherwise false.</returns>
        public static bool IsTrimmableStart(string? arg) => arg != null && arg.TrimStart() != arg;

        /// <summary>
        /// Returns true if the string could be trimmed at the end.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
/// Determines whether the provided string has removable trailing whitespace.
/// </summary>
/// <param name="arg">The string to check. If null, the method returns false.</param>
/// <returns>true if <paramref name="arg"/> contains one or more trailing whitespace characters; otherwise, false.</returns>
        public static bool IsTrimmableEnd(string? arg) => arg != null && arg.TrimEnd() != arg;

        /// <summary>
        /// Returns true if a string is palindrome.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
        /// Determines whether the provided string is a palindrome (reads the same forwards and backwards).
        /// </summary>
        /// <param name="arg">The string to test. Null returns false. Comparison is case-sensitive and includes all characters (whitespace and punctuation).</param>
        /// <returns>True if <paramref name="arg"/> is a palindrome; otherwise, false.</returns>
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
        /// <summary>
        /// Determines whether the input string matches the given regular expression pattern.
        /// </summary>
        /// <param name="arg">The string to test. If null, the method returns <c>false</c>.</param>
        /// <param name="pattern">A regular expression pattern to match against <paramref name="arg"/>.</param>
        /// <returns><c>true</c> if <paramref name="arg"/> matches <paramref name="pattern"/>; otherwise, <c>false</c>.</returns>
        public static bool Matches(string? arg, string pattern)
        {
            if (arg == null) return false;
            return Regex.IsMatch(arg, pattern);
        }

        /// <summary>
        /// Returns a function that checks if a string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <summary>
/// Creates a predicate that tests whether an input string matches the specified regular expression pattern.
/// </summary>
/// <param name="pattern">The regular expression pattern to match against.</param>
/// <returns>A function that returns true when its input matches <paramref name="pattern"/>; returns false for null input.</returns>
        public static Func<string?, bool> Matches(string pattern) => arg => Matches(arg, pattern);

        /// <summary>
        /// Returns false if the string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <summary>
        /// Determines whether the input string does not match the given regular expression pattern.
        /// </summary>
        /// <param name="arg">The input string to test; may be <c>null</c>.</param>
        /// <param name="pattern">The regular expression pattern to test against.</param>
        /// <returns><c>true</c> if <paramref name="arg"/> is <c>null</c> or does not match <paramref name="pattern"/>; otherwise <c>false</c>.</returns>
        public static bool DoesNotMatch(string? arg, string pattern)
        {
            if (arg == null) return true;
            return !Regex.IsMatch(arg, pattern);
        }

        /// <summary>
        /// Returns a function that checks if a string does not match the specified regular expression pattern.
        /// </summary>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <summary>
/// Returns a predicate that tests whether an input string does not match the given regular expression pattern.
/// </summary>
/// <param name="pattern">A regular expression pattern passed to <see cref="Regex.IsMatch(string, string)"/>.</param>
/// <returns>A function that returns true when its string argument is null or does not match <paramref name="pattern"/>.</returns>
        public static Func<string?, bool> DoesNotMatch(string pattern) => arg => DoesNotMatch(arg, pattern);

        /// <summary>
        /// Returns true if the string is a valid email address.
        /// </summary>
        /// <param name="arg">The string to check.</param>
        /// <summary>
        /// Determines whether the provided string is a valid email address.
        /// </summary>
        /// <param name="arg">The string to validate; may be null.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="arg"/> is a non-null string that matches the email pattern; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsEmail(string? arg)
        {
            if (arg == null) return false;
            var pattern = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            return Regex.IsMatch(arg, pattern);
        }
    }
}
