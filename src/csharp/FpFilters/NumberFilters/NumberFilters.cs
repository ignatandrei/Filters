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
        /// <returns>True if the number is zero; otherwise, false.</returns>
        public static bool IsZero(double arg) => arg == 0;

        /// <summary>
        /// Determines whether the specified number is a round integer.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is round; otherwise, false.</returns>
        public static bool IsRound(double arg) => System.Math.Round(arg) == arg;

        /// <summary>
        /// Determines whether the specified number is positive or zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is positive or zero; otherwise, false.</returns>
        public static bool IsPositiveOrZero(double arg) => arg >= 0;

        /// <summary>
        /// Determines whether the specified number is positive.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is positive; otherwise, false.</returns>
        public static bool IsPositive(double arg) => arg > 0;

        /// <summary>
        /// Determines whether the specified integer is odd.
        /// </summary>
        /// <param name="arg">The integer to check.</param>
        /// <returns>True if the integer is odd; otherwise, false.</returns>
        public static bool IsOdd(int arg) => arg % 2 != 0;

        /// <summary>
        /// Determines whether the specified number is not zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is not zero; otherwise, false.</returns>
        public static bool IsNotZero(double arg) => arg != 0;

        /// <summary>
        /// Determines whether the specified number is not NaN.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is not NaN; otherwise, false.</returns>
        public static bool IsNotNaN(double arg) => !double.IsNaN(arg);

        /// <summary>
        /// Determines whether the specified number is negative or zero.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is negative or zero; otherwise, false.</returns>
        public static bool IsNegativeOrZero(double arg) => arg <= 0;

        /// <summary>
        /// Determines whether the specified number is negative.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is negative; otherwise, false.</returns>
        public static bool IsNegative(double arg) => arg < 0;

        /// <summary>
        /// Determines whether n is a multiple of m.
        /// </summary>
        /// <param name="n">The number to check.</param>
        /// <param name="m">The divisor.</param>
        /// <returns>True if n is a multiple of m; otherwise, false.</returns>
        public static bool IsMultipleOf(int n, int m) => n % m == 0;

        /// <summary>
        /// Returns a function that checks if a number is a multiple of m.
        /// </summary>
        /// <param name="m">The divisor.</param>
        /// <returns>A function that checks if a number is a multiple of m.</returns>
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
        /// <returns>True if the number is lower; otherwise, false.</returns>
        public static bool IsLowerThan(double arg, double comparison) => arg < comparison;

        /// <summary>
        /// Returns a function that checks if a number is lower than the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>A function that checks if a number is lower than the comparison value.</returns>
        public static Func<double, bool> IsLowerThan(double comparison) => arg => IsLowerThan(arg, comparison);

        /// <summary>
        /// Determines whether the specified number is lower or equal to the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>True if the number is lower or equal; otherwise, false.</returns>
        public static bool IsLowerOrEqualTo(double arg, double comparison) => arg <= comparison;

        /// <summary>
        /// Returns a function that checks if a number is lower or equal to the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>A function that checks if a number is lower or equal to the comparison value.</returns>
        public static Func<double, bool> IsLowerOrEqualTo(double comparison) => arg => IsLowerOrEqualTo(arg, comparison);

        /// <summary>
        /// Determines whether the specified number is an integer.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <returns>True if the number is an integer; otherwise, false.</returns>
        public static bool IsInteger(double arg) => (int)arg == arg;

        /// <summary>
        /// Determines whether the specified number is greater than the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>True if the number is greater; otherwise, false.</returns>
        public static bool IsGreaterThan(double arg, double comparison) => arg > comparison;

        /// <summary>
        /// Returns a function that checks if a number is greater than the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>A function that checks if a number is greater than the comparison value.</returns>
        public static Func<double, bool> IsGreaterThan(double comparison) => arg => IsGreaterThan(arg, comparison);

        /// <summary>
        /// Determines whether the specified number is greater or equal to the comparison value.
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>True if the number is greater or equal; otherwise, false.</returns>
        public static bool IsGreaterOrEqualTo(double arg, double comparison) => arg >= comparison;

        /// <summary>
        /// Returns a function that checks if a number is greater or equal to the comparison value.
        /// </summary>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>A function that checks if a number is greater or equal to the comparison value.</returns>
        public static Func<double, bool> IsGreaterOrEqualTo(double comparison) => arg => IsGreaterOrEqualTo(arg, comparison);

        /// <summary>
        /// Determines whether the specified integer is even.
        /// </summary>
        /// <param name="arg">The integer to check.</param>
        /// <returns>True if the integer is even; otherwise, false.</returns>
        public static bool IsEven(int arg) => arg % 2 == 0;

        /// <summary>
        /// Determines whether the specified number is between min (exclusive) and max (inclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <returns>True if the number is in the range; otherwise, false.</returns>
        public static bool IsBetweenExcludingMin(double arg, double min, double max) => arg > min && arg <= max;

        /// <summary>
        /// Returns a function that checks if a number is between min (exclusive) and max (inclusive).
        /// </summary>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <returns>A function that checks if a number is in the range.</returns>
        public static Func<double, bool> IsBetweenExcludingMin(double min, double max) => arg => IsBetweenExcludingMin(arg, min, max);

        /// <summary>
        /// Determines whether the specified number is between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <returns>True if the number is in the range; otherwise, false.</returns>
        public static bool IsBetweenExcludingMax(double arg, double min, double max) => arg >= min && arg < max;

        /// <summary>
        /// Returns a function that checks if a number is between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <returns>A function that checks if a number is in the range.</returns>
        public static Func<double, bool> IsBetweenExcludingMax(double min, double max) => arg => IsBetweenExcludingMax(arg, min, max);

        /// <summary>
        /// Determines whether the specified number is between min (exclusive) and max (exclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <returns>True if the number is in the range; otherwise, false.</returns>
        public static bool IsBetweenExcludingBoundaries(double arg, double min, double max) => arg > min && arg < max;

        /// <summary>
        /// Returns a function that checks if a number is between min (exclusive) and max (exclusive).
        /// </summary>
        /// <param name="min">The minimum value (exclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <returns>A function that checks if a number is in the range.</returns>
        public static Func<double, bool> IsBetweenExcludingBoundaries(double min, double max) => arg => IsBetweenExcludingBoundaries(arg, min, max);

        /// <summary>
        /// Determines whether the specified number is between min (inclusive) and max (inclusive).
        /// </summary>
        /// <param name="arg">The number to check.</param>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <returns>True if the number is in the range; otherwise, false.</returns>
        public static bool IsBetween(double arg, double min, double max) => arg >= min && arg <= max;

        /// <summary>
        /// Returns a function that checks if a number is between min (inclusive) and max (inclusive).
        /// </summary>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (inclusive).</param>
        /// <returns>A function that checks if a number is in the range.</returns>
        public static Func<double, bool> IsBetween(double min, double max) => arg => IsBetween(arg, min, max);
    }
}
