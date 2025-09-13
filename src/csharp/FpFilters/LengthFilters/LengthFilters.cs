namespace FpFilters.LengthFilters
{
    public static class LengthFilters
    {
        public static bool IsEmpty(object? arg)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length == 0;
            if (arg is ICollection c) return c.Count == 0;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) == 0;
            return false;
        }

        public static bool IsNotEmpty(object arg) => !IsEmpty(arg);

        public static bool HasLength(object? arg, int len)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length == len;
            if (arg is ICollection c) return c.Count == len;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) == len;
            return false;
        }
        public static Func<object?, bool> HasLength(int len) => arg => HasLength(arg, len);

        public static bool HasLengthMin(object? arg, int min)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length >= min;
            if (arg is ICollection c) return c.Count >= min;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) >= min;
            return false;
        }
        public static Func<object?, bool> HasLengthMin(int min) => arg => HasLengthMin(arg, min);

        public static bool HasLengthMax(object? arg, int max)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length <= max;
            if (arg is ICollection c) return c.Count <= max;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) <= max;
            return false;
        }
        public static Func<object?, bool> HasLengthMax(int max) => arg => HasLengthMax(arg, max);

        public static bool HasLengthBetween(object? arg, int min, int max)
        {
            return HasLengthMin(arg, min) && HasLengthMax(arg, max);
        }
        public static Func<object?, bool> HasLengthBetween(int min, int max) => arg => HasLengthBetween(arg, min, max);

        public static bool HasNotLength(object? arg, int len) => !HasLength(arg, len);
        public static Func<object?, bool> HasNotLength(int len) => arg => HasNotLength(arg, len);

        public static bool HasNotLengthMin(object? arg, int min) => !HasLengthMin(arg, min);
        public static Func<object?, bool> HasNotLengthMin(int min) => arg => HasNotLengthMin(arg, min);

        public static bool HasNotLengthMax(object? arg, int max) => !HasLengthMax(arg, max);
        public static Func<object?, bool> HasNotLengthMax(int max) => arg => HasNotLengthMax(arg, max);

        public static bool HasNotLengthBetween(object? arg, int min, int max) => !HasLengthBetween(arg, min, max);
        public static Func<object?, bool> HasNotLengthBetween(int min, int max) => arg => HasNotLengthBetween(arg, min, max);

        // BDD test support methods
        public static bool IsLengthEqualTo(string? arg, int comparison) => arg != null && arg.Length == comparison;
        public static Func<string?, bool> IsLengthEqualTo(int comparison) => arg => IsLengthEqualTo(arg, comparison);

        public static bool IsLengthGreaterThan(string? arg, int comparison) => arg != null && arg.Length > comparison;
        public static Func<string?, bool> IsLengthGreaterThan(int comparison) => arg => IsLengthGreaterThan(arg, comparison);

        public static bool IsLengthLessThan(string? arg, int comparison) => arg != null && arg.Length < comparison;
        public static Func<string?, bool> IsLengthLessThan(int comparison) => arg => IsLengthLessThan(arg, comparison);

        public static bool IsLengthZero(string? arg) => arg != null && arg.Length == 0;
    }
}
