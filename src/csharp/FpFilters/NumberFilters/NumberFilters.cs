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
        public static bool IsLowerThan(double arg, double comparison) => arg < comparison;
        public static bool IsLowerOrEqualTo(double arg, double comparison) => arg <= comparison;
        public static bool IsInteger(double arg) => (int)arg == arg;
        public static bool IsGreaterThan(double arg, double comparison) => arg > comparison;
        public static bool IsGreaterOrEqualTo(double arg, double comparison) => arg >= comparison;
        public static bool IsEven(int arg) => arg % 2 == 0;
        public static bool IsBetweenExcludingMin(double arg, double min, double max) => arg > min && arg <= max;
        public static bool IsBetweenExcludingMax(double arg, double min, double max) => arg >= min && arg < max;
        public static bool IsBetweenExcludingBoundaries(double arg, double min, double max) => arg > min && arg < max;
        public static bool IsBetween(double arg, double min, double max) => arg >= min && arg <= max;
    }
}
