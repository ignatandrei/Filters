namespace FpFilters.NumberFilters
{
    /// <summary>
    /// Provides a set of static methods for filtering and comparing numbers.
    /// </summary>
    public static class NumberFilters
    {
        /// <summary>
        /// Determines whether the specified number is zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the specified number is exactly zero.
/// </summary>
/// <param name="arg">The number to test.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is zero; otherwise, <c>false</c>.</returns>
        public static bool IsZero(double arg) => arg == 0;

        /// <summary>
        /// Determines whether the specified number is a round integer.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the specified value has no fractional part (is a round integer).
/// </summary>
/// <param name="arg">The value to check.</param>
/// <returns>True if <paramref name="arg"/> equals its rounded value (no fractional part); otherwise, false.</returns>
        public static bool IsRound(double arg) => System.Math.Round(arg) == arg;

        /// <summary>
        /// Determines whether the specified number is positive or zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the specified number is positive or zero.
/// </summary>
/// <returns>True if <paramref name="arg"/> is greater than or equal to zero; otherwise, false.</returns>
        public static bool IsPositiveOrZero(double arg) => arg >= 0;

        /// <summary>
        /// Determines whether the specified number is positive.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the given number is strictly greater than zero.
/// </summary>
/// <returns>True if <paramref name="arg"/> is greater than zero; otherwise, false.</returns>
        public static bool IsPositive(double arg) => arg > 0;

        /// <summary>
        /// Determines whether the specified integer is odd.
        /// </summary>
        /// <param name="arg">The integer to check.</param>
        /// <summary>
/// Determines whether the specified integer is odd.
/// </summary>
/// <param name="arg">The integer to test.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is odd; otherwise, <c>false</c>.</returns>
        public static bool IsOdd(int arg) => arg % 2 != 0;

        /// <summary>
        /// Determines whether the specified number is not zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the given number is not zero.
/// </summary>
/// <param name="arg">The number to test.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is not equal to zero; otherwise, <c>false</c>. Note: <c>double.NaN</c> is considered not zero and will return <c>true</c>.</returns>
        public static bool IsNotZero(double arg) => arg != 0;

        /// <summary>
        /// Determines whether the specified number is not NaN.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the specified double value is not NaN.
/// </summary>
/// <param name="arg">The double value to test.</param>
/// <returns>true if <paramref name="arg"/> is not NaN; otherwise, false.</returns>
        public static bool IsNotNaN(double arg) => !double.IsNaN(arg);

        /// <summary>
        /// Determines whether the specified number is negative or zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Returns true if the specified number is negative or zero.
/// </summary>
/// <param name="arg">The number to test.</param>
/// <returns>True if <paramref name="arg"/> is less than or equal to zero; otherwise, false.</returns>
        public static bool IsNegativeOrZero(double arg) => arg <= 0;

        /// <summary>
        /// Determines whether the specified number is negative.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> is strictly less than zero.
/// </summary>
/// <param name="arg">The value to test. Returns false for zero and for NaN.</param>
/// <returns>True if the number is negative; otherwise, false.</returns>
        public static bool IsNegative(double arg) => arg < 0;

        /// <summary>
        /// Determines whether n is a multiple of m.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="m">The divisor.</param>
        /// <summary>
/// Determines whether the integer <paramref name="n"/> is a multiple of <paramref name="m"/>.
/// </summary>
/// <param name="n">The value to test for multiplicity.</param>
/// <param name="m">The divisor to test against.</param>
/// <returns><c>true</c> if <paramref name="n"/> is a multiple of <paramref name="m"/>; otherwise, <c>false</c>.</returns>
        public static bool IsMultipleOf(int n, int m) => n % m == 0;

        /// <summary>
        /// Returns a function that checks if a number is a multiple of m.
        /// </summary>
        /// <param name="m">The divisor.</param>
        /// <summary>
        /// Returns a predicate that tests whether an integer is a multiple of the given divisor.
        /// </summary>
        /// <param name="m">The divisor to test against. Must be non-zero.</param>
        /// <returns>A function that returns true when its input is a multiple of <paramref name="m"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="m"/> is zero.</exception>
        public static Func<int, bool> IsMultipleOf(int m)
        {
            if (m == 0) throw new System.ArgumentOutOfRangeException(nameof(m), "m must be non-zero.");
            return n => IsMultipleOf(n, m);
        }

        /// <summary>
        /// Determines whether the specified number is lower than the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> is strictly less than <paramref name="comparison"/>.
/// </summary>
/// <param name="arg">The value to compare.</param>
/// <param name="comparison">The value to compare against.</param>
/// <returns>True if <paramref name="arg"/> is less than <paramref name="comparison"/>; otherwise, false.</returns>
        public static bool IsLowerThan(double arg, double comparison) => arg < comparison;

        /// <summary>
        /// Returns a function that checks if a number is lower than the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Returns a predicate that checks whether its input is strictly less than the specified comparison value.
/// </summary>
/// <param name="comparison">Value to compare against.</param>
/// <returns>A function that returns <c>true</c> when its argument is less than <paramref name="comparison"/>.</returns>
        public static Func<double, bool> IsLowerThan(double comparison) => arg => IsLowerThan(arg, comparison);

        /// <summary>
        /// Determines whether the specified number is lower or equal to the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Determines whether a value is less than or equal to a comparison value.
/// </summary>
/// <param name="arg">The value to test.</param>
/// <param name="comparison">The value to compare against.</param>
/// <returns>True if <paramref name="arg"/> is less than or equal to <paramref name="comparison"/>; otherwise, false.</returns>
        public static bool IsLowerOrEqualTo(double arg, double comparison) => arg <= comparison;

        /// <summary>
        /// Returns a function that checks if a number is lower or equal to the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a given double is less than or equal to the specified comparison value.
/// </summary>
/// <param name="comparison">The value to compare against; the returned predicate returns true for inputs <= this value.</param>
/// <returns>A function that takes a double and returns true if it is less than or equal to <paramref name="comparison"/>.</returns>
        public static Func<double, bool> IsLowerOrEqualTo(double comparison) => arg => IsLowerOrEqualTo(arg, comparison);

        /// <summary>
        /// Determines whether the specified number is an integer.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <summary>
/// Determines whether the specified double value represents an integer (has no fractional part).
/// </summary>
/// <param name="arg">The value to test.</param>
/// <returns>True if <paramref name="arg"/> has no fractional part; otherwise, false.</returns>
        public static bool IsInteger(double arg) => (int)arg == arg;

        /// <summary>
        /// Determines whether the specified number is greater than the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Determines whether the first value is strictly greater than the second.
/// </summary>
/// <param name="arg">The value to test.</param>
/// <param name="comparison">The value to compare against.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is greater than <paramref name="comparison"/>; otherwise, <c>false</c>.</returns>
        public static bool IsGreaterThan(double arg, double comparison) => arg > comparison;

        /// <summary>
        /// Returns a function that checks if a number is greater than the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether its input is strictly greater than the provided comparison value.
/// </summary>
/// <param name="comparison">The value to compare against.</param>
/// <returns>A function that returns <c>true</c> when its argument is greater than <paramref name="comparison"/>.</returns>
        public static Func<double, bool> IsGreaterThan(double comparison) => arg => IsGreaterThan(arg, comparison);

        /// <summary>
        /// Determines whether the specified number is greater or equal to the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Determines whether <paramref name="arg"/> is greater than or equal to <paramref name="comparison"/>.
/// </summary>
/// <param name="arg">The value to test.</param>
/// <param name="comparison">The value to compare against.</param>
/// <returns>True if <paramref name="arg"/> is greater than or equal to <paramref name="comparison"/>; otherwise, false.</returns>
        public static bool IsGreaterOrEqualTo(double arg, double comparison) => arg >= comparison;

        /// <summary>
        /// Returns a function that checks if a number is greater or equal to the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Creates a predicate that returns true when its input is greater than or equal to <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The comparison value to test inputs against.</param>
/// <returns>A function that returns true if its argument is greater than or equal to <paramref name="comparison"/>.</returns>
        public static Func<double, bool> IsGreaterOrEqualTo(double comparison) => arg => IsGreaterOrEqualTo(arg, comparison);

        /// <summary>
        /// Determines whether the specified integer is even.
        /// </summary>
        /// <param name="arg">The integer to check.</param>
        /// <summary>
/// Determines whether the specified integer is even.
/// </summary>
/// <param name="arg">The integer to test.</param>
/// <returns><see langword="true"/> if <paramref name="arg"/> is even; otherwise <see langword="false"/>.</returns>
        public static bool IsEven(int arg) => arg % 2 == 0;

        /// <summary>
        /// Determines whether the specified number is between min (exclusive) and max (inclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <summary>
/// Determines whether <paramref name="arg"/> is within the range (min, max] — greater than <paramref name="min"/> and less than or equal to <paramref name="max"/>.
/// </summary>
/// <param name="arg">Value to test.</param>
/// <param name="min">Lower bound (exclusive).</param>
/// <param name="max">Upper bound (inclusive).</param>
/// <returns>True if <paramref name="arg"/> &gt; <paramref name="min"/> and &lt;= <paramref name="max"/>; otherwise, false.</returns>
        public static bool IsBetweenExcludingMin(double arg, double min, double max) => arg > min && arg <= max;

        /// <summary>
        /// Returns a function that checks if a number is between min (exclusive) and max (inclusive).
        /// </summary>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <summary>
/// Creates a predicate that returns true when its input is greater than <paramref name="min"/> (exclusive) and less than or equal to <paramref name="max"/> (inclusive).
/// </summary>
/// <param name="min">Lower bound (exclusive).</param>
/// <param name="max">Upper bound (inclusive).</param>
/// <returns>A function that returns true for values in (min, max].</returns>
        public static Func<double, bool> IsBetweenExcludingMin(double min, double max) => arg => IsBetweenExcludingMin(arg, min, max);

        /// <summary>
        /// Determines whether the specified number is between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <summary>
/// Determines whether the given value lies within the range [min, max), i.e. greater than or equal to <paramref name="min"/> and strictly less than <paramref name="max"/>.
/// </summary>
/// <param name="arg">Value to test.</param>
/// <param name="min">Inclusive lower bound.</param>
/// <param name="max">Exclusive upper bound.</param>
/// <returns>True if <paramref name="arg"/> is in [min, max); otherwise, false.</returns>
        public static bool IsBetweenExcludingMax(double arg, double min, double max) => arg >= min && arg < max;

        /// <summary>
        /// Returns a function that checks if a number is between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <summary>
/// Returns a predicate that tests whether a value lies in [min, max) (inclusive min, exclusive max).
/// </summary>
/// <param name="min">Lower bound (inclusive).</param>
/// <param name="max">Upper bound (exclusive).</param>
/// <returns>A function that returns true when its input is greater than or equal to <paramref name="min"/> and strictly less than <paramref name="max"/>.</returns>
        public static Func<double, bool> IsBetweenExcludingMax(double min, double max) => arg => IsBetweenExcludingMax(arg, min, max);

        /// <summary>
        /// Determines whether the specified number is between min (exclusive) and max (exclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <summary>
/// Determines whether <paramref name="arg"/> is strictly between <paramref name="min"/> and <paramref name="max"/>.
/// </summary>
/// <param name="arg">The value to test.</param>
/// <param name="min">The lower bound (exclusive).</param>
/// <param name="max">The upper bound (exclusive).</param>
/// <returns><c>true</c> if <paramref name="arg"/> is greater than <paramref name="min"/> and less than <paramref name="max"/>; otherwise, <c>false</c>.</returns>
        public static bool IsBetweenExcludingBoundaries(double arg, double min, double max) => arg > min && arg < max;

        /// <summary>
        /// Returns a function that checks if a number is between min (exclusive) and max (exclusive).
        /// </summary>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <summary>
/// Returns a predicate that tests whether a value is strictly between <paramref name="min"/> and <paramref name="max"/> (both boundaries excluded).
/// </summary>
/// <param name="min">Lower bound (exclusive).</param>
/// <param name="max">Upper bound (exclusive).</param>
/// <returns>A function that returns true when its input is greater than <paramref name="min"/> and less than <paramref name="max"/>.</returns>
        public static Func<double, bool> IsBetweenExcludingBoundaries(double min, double max) => arg => IsBetweenExcludingBoundaries(arg, min, max);

        /// <summary>
        /// Determines whether the specified number is between min (inclusive) and max (inclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <summary>
/// Determines whether <paramref name="arg"/> lies within the inclusive range [<paramref name="min"/>, <paramref name="max"/>].
/// </summary>
/// <param name="arg">Value to test.</param>
/// <param name="min">Lower bound (inclusive).</param>
/// <param name="max">Upper bound (inclusive).</param>
/// <returns>True if the number is in the inclusive range; otherwise, false.</returns>
        public static bool IsBetween(double arg, double min, double max) => arg >= min && arg <= max;

        /// <summary>
        /// Returns a function that checks if a number is between min (inclusive) and max (inclusive).
        /// </summary>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <summary>
/// Returns a predicate that tests whether a value lies within the inclusive range [min, max].
/// </summary>
/// <param name="min">Lower bound of the range (inclusive).</param>
/// <param name="max">Upper bound of the range (inclusive).</param>
/// <returns>A function that returns true when its argument is between <paramref name="min"/> and <paramref name="max"/>, inclusive; otherwise false.</returns>
        public static Func<double, bool> IsBetween(double min, double max) => arg => IsBetween(arg, min, max);
    }
}
