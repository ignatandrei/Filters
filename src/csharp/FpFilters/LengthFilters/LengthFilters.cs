namespace FpFilters.LengthFilters
{
    public static class LengthFilters
    {
        public static bool IsEmpty(object arg)
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

        public static bool HasLengthMin(object? arg, int min)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length >= min;
            if (arg is ICollection c) return c.Count >= min;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) >= min;
            return false;
        }

        public static bool HasLengthMax(object? arg, int max)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length <= max;
            if (arg is ICollection c) return c.Count <= max;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) <= max;
            return false;
        }

        public static bool HasLengthBetween(object? arg, int min, int max)
        {
            return HasLengthMin(arg, min) && HasLengthMax(arg, max);
        }

        public static bool HasNotLength(object arg, int len) => !HasLength(arg, len);
        public static bool HasNotLengthMin(object arg, int min) => !HasLengthMin(arg, min);
        public static bool HasNotLengthMax(object arg, int max) => !HasLengthMax(arg, max);
        public static bool HasNotLengthBetween(object arg, int min, int max) => !HasLengthBetween(arg, min, max);
        // BDD test support methods
        public static bool IsLengthEqualTo(string? arg, int comparison) => arg != null && arg.Length == comparison;
        public static bool IsLengthGreaterThan(string? arg, int comparison) => arg != null && arg.Length > comparison;
        public static bool IsLengthLessThan(string? arg, int comparison) => arg != null && arg.Length < comparison;
        public static bool IsLengthZero(string? arg) => arg != null && arg.Length == 0;
    }
}
