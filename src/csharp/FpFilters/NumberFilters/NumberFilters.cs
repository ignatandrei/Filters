namespace FpFilters.NumberFilters
{
    public static class NumberFilters
    {
        public static bool IsZero(double arg) => arg == 0;
        public static bool IsRound(double arg) => System.Math.Round(arg) == arg;
        public static bool IsPositiveOrZero(double arg) => arg >= 0;
        public static bool IsPositive(double arg) => arg > 0;
        public static bool IsOdd(int arg) => arg % 2 != 0;
        public static bool IsNotZero(double arg) => arg != 0;
        public static bool IsNotNaN(double arg) => !double.IsNaN(arg);
        public static bool IsNegativeOrZero(double arg) => arg <= 0;
        public static bool IsNegative(double arg) => arg < 0;
        public static bool IsMultipleOf(int n, int m) => n % m == 0;
        public static Func<int, bool> IsMultipleOf(int m)
        {
            if (m == 0) throw new System.ArgumentOutOfRangeException(nameof(m), "m must be non-zero.");
            return n => IsMultipleOf(n, m);
        }
        public static bool IsLowerThan(double arg, double comparison) => arg < comparison;
        public static Func<double, bool> IsLowerThan(double comparison) => arg => IsLowerThan(arg, comparison);
        public static bool IsLowerOrEqualTo(double arg, double comparison) => arg <= comparison;
        public static Func<double, bool> IsLowerOrEqualTo(double comparison) => arg => IsLowerOrEqualTo(arg, comparison);
        public static bool IsInteger(double arg) => (int)arg == arg;
        public static bool IsGreaterThan(double arg, double comparison) => arg > comparison;
        public static Func<double, bool> IsGreaterThan(double comparison) => arg => IsGreaterThan(arg, comparison);
        public static bool IsGreaterOrEqualTo(double arg, double comparison) => arg >= comparison;
        public static Func<double, bool> IsGreaterOrEqualTo(double comparison) => arg => IsGreaterOrEqualTo(arg, comparison);
        public static bool IsEven(int arg) => arg % 2 == 0;
        public static bool IsBetweenExcludingMin(double arg, double min, double max) => arg > min && arg <= max;
        public static Func<double, bool> IsBetweenExcludingMin(double min, double max) => arg => IsBetweenExcludingMin(arg, min, max);
        public static bool IsBetweenExcludingMax(double arg, double min, double max) => arg >= min && arg < max;
        public static Func<double, bool> IsBetweenExcludingMax(double min, double max) => arg => IsBetweenExcludingMax(arg, min, max);
        public static bool IsBetweenExcludingBoundaries(double arg, double min, double max) => arg > min && arg < max;
        public static Func<double, bool> IsBetweenExcludingBoundaries(double min, double max) => arg => IsBetweenExcludingBoundaries(arg, min, max);
        public static bool IsBetween(double arg, double min, double max) => arg >= min && arg <= max;
        public static Func<double, bool> IsBetween(double min, double max) => arg => IsBetween(arg, min, max);
    }
}
