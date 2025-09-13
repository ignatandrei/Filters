namespace FpFilters.BooleanFilters
{
    public static class BooleanFilters
    {
        /// <summary>
        /// Returns true if the argument is exactly a boolean true.
        /// </summary>
        /// <param name="arg">The boolean value to check.</param>
        /// <summary>
/// Returns true if the provided boolean value is exactly true.
/// </summary>
/// <returns>True when <paramref name="arg"/> is true; otherwise false.</returns>
        public static bool IsTrue(bool arg) => arg == true;

        /// <summary>
        /// Returns true if the argument is exactly a boolean false.
        /// </summary>
        /// <param name="arg">The boolean value to check.</param>
        /// <summary>
/// Returns <c>true</c> when the provided boolean is <c>false</c>.
/// </summary>
/// <param name="arg">The boolean value to test.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is <c>false</c>; otherwise <c>false</c>.</returns>
        public static bool IsFalse(bool arg) => arg == false;

        /// <summary>
        /// Returns true if the argument is truthy (1, 'string', {}, [], etc.).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
        /// Determines whether an object is "truthy" using loose rules: null is false; a bool returns its value; an empty string is false; numeric zeros are false; an <see cref="System.Collections.ICollection"/> is truthy when <c>Count &gt; 0</c>; all other non-null values are true.
        /// </summary>
        /// <param name="arg">The value to evaluate for truthiness. Supported checks include bool, string, int, double, float, long, and <see cref="System.Collections.ICollection"/>; other non-null objects are treated as truthy.</param>
        /// <returns>True if the value is considered truthy; otherwise, false.</returns>
        public static bool IsTruthy(object? arg)
        {
            if (arg == null) return false;
            if (arg is bool b) return b;
            if (arg is string s) return !string.IsNullOrEmpty(s);
            if (arg is int i) return i != 0;
            if (arg is double d) return d != 0.0;
            if (arg is float f) return f != 0.0f;
            if (arg is long l) return l != 0L;
            if (arg is System.Collections.ICollection c) return c.Count > 0;
            return true;
        }

        /// <summary>
        /// Returns true if the argument is falsey (0, '', undefined, null, etc.).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the given value is falsey.
/// </summary>
/// <param name="arg">The value to evaluate; null and other values considered "falsey" by <see cref="IsTruthy(object?)"/> return true here.</param>
/// <returns>True if the value is considered falsey (the negation of <see cref="IsTruthy(object?)"/>); otherwise false.</returns>
        public static bool IsFalsey(object? arg) => !IsTruthy(arg);
    }
}
