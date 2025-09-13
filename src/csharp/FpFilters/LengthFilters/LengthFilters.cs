namespace FpFilters.LengthFilters
{
    public static class LengthFilters
    {
        /// <summary>
        /// Determines whether the argument is empty (string, ICollection, or has Length property).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is empty; otherwise, false.</returns>
        public static bool IsEmpty(object? arg)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length == 0;
            if (arg is ICollection c) return c.Count == 0;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) == 0;
            return false;
        }

        /// <summary>
        /// Determines whether the argument is not empty.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not empty; otherwise, false.</returns>
        public static bool IsNotEmpty(object arg) => !IsEmpty(arg);

        /// <summary>
        /// Determines whether the argument has the specified length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="len">The length to compare.</param>
        /// <returns>True if the value has the specified length; otherwise, false.</returns>
        public static bool HasLength(object? arg, int len)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length == len;
            if (arg is ICollection c) return c.Count == len;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) == len;
            return false;
        }

        /// <summary>
        /// Returns a function that checks if a value has the specified length.
        /// </summary>
        /// <param name="len">The length to compare.</param>
        /// <returns>A function that checks if a value has the specified length.</returns>
        public static Func<object?, bool> HasLength(int len) => arg => HasLength(arg, len);

        /// <summary>
        /// Determines whether the argument has at least the specified minimum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <returns>True if the value has at least the minimum length; otherwise, false.</returns>
        public static bool HasLengthMin(object? arg, int min)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length >= min;
            if (arg is ICollection c) return c.Count >= min;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) >= min;
            return false;
        }

        /// <summary>
        /// Returns a function that checks if a value has at least the specified minimum length.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <returns>A function that checks if a value has at least the minimum length.</returns>
        public static Func<object?, bool> HasLengthMin(int min) => arg => HasLengthMin(arg, min);

        /// <summary>
        /// Determines whether the argument has at most the specified maximum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="max">The maximum length.</param>
        /// <returns>True if the value has at most the maximum length; otherwise, false.</returns>
        public static bool HasLengthMax(object? arg, int max)
        {
            if (arg == null) return false;
            if (arg is string s) return s.Length <= max;
            if (arg is ICollection c) return c.Count <= max;
            var prop = arg.GetType().GetProperty("Length");
            if (prop != null) return Convert.ToInt32(prop.GetValue(arg)) <= max;
            return false;
        }

        /// <summary>
        /// Returns a function that checks if a value has at most the specified maximum length.
        /// </summary>
        /// <param name="max">The maximum length.</param>
        /// <returns>A function that checks if a value has at most the maximum length.</returns>
        public static Func<object?, bool> HasLengthMax(int max) => arg => HasLengthMax(arg, max);

        /// <summary>
        /// Determines whether the argument has a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <returns>True if the value has a length between min and max; otherwise, false.</returns>
        public static bool HasLengthBetween(object? arg, int min, int max)
        {
            return HasLengthMin(arg, min) && HasLengthMax(arg, max);
        }

        /// <summary>
        /// Returns a function that checks if a value has a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <returns>A function that checks if a value has a length between min and max.</returns>
        public static Func<object?, bool> HasLengthBetween(int min, int max) => arg => HasLengthBetween(arg, min, max);

        /// <summary>
        /// Determines whether the argument does NOT have the specified length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="len">The length to compare.</param>
        /// <returns>True if the value does not have the specified length; otherwise, false.</returns>
        public static bool HasNotLength(object? arg, int len) => !HasLength(arg, len);

        /// <summary>
        /// Returns a function that checks if a value does NOT have the specified length.
        /// </summary>
        /// <param name="len">The length to compare.</param>
        /// <returns>A function that checks if a value does not have the specified length.</returns>
        public static Func<object?, bool> HasNotLength(int len) => arg => HasNotLength(arg, len);

        /// <summary>
        /// Determines whether the argument does NOT have at least the specified minimum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <returns>True if the value does not have at least the minimum length; otherwise, false.</returns>
        public static bool HasNotLengthMin(object? arg, int min) => !HasLengthMin(arg, min);

        /// <summary>
        /// Returns a function that checks if a value does NOT have at least the specified minimum length.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <returns>A function that checks if a value does not have at least the minimum length.</returns>
        public static Func<object?, bool> HasNotLengthMin(int min) => arg => HasNotLengthMin(arg, min);

        /// <summary>
        /// Determines whether the argument does NOT have at most the specified maximum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="max">The maximum length.</param>
        /// <returns>True if the value does not have at most the maximum length; otherwise, false.</returns>
        public static bool HasNotLengthMax(object? arg, int max) => !HasLengthMax(arg, max);

        /// <summary>
        /// Returns a function that checks if a value does NOT have at most the specified maximum length.
        /// </summary>
        /// <param name="max">The maximum length.</param>
        /// <returns>A function that checks if a value does not have at most the maximum length.</returns>
        public static Func<object?, bool> HasNotLengthMax(int max) => arg => HasNotLengthMax(arg, max);

        /// <summary>
        /// Determines whether the argument does NOT have a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <returns>True if the value does not have a length between min and max; otherwise, false.</returns>
        public static bool HasNotLengthBetween(object? arg, int min, int max) => !HasLengthBetween(arg, min, max);

        /// <summary>
        /// Returns a function that checks if a value does NOT have a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <returns>A function that checks if a value does not have a length between min and max.</returns>
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
