namespace FpFilters.BooleanFilters
{
    public static class BooleanFilters
    {
        // Returns true if the argument is exactly a boolean true
        public static bool IsTrue(bool arg) => arg == true;

        // Returns true if the argument is exactly a boolean false
        public static bool IsFalse(bool arg) => arg == false;

        // Returns true if the argument is truthy (1, 'string', {}, [], etc.)
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

        // Returns true if the argument is falsey (0, '', undefined, null, etc.)
        public static bool IsFalsey(object? arg) => !IsTruthy(arg);
    }
}
