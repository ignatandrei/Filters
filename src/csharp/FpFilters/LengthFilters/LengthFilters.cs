namespace FpFilters.LengthFilters
{
    public static class LengthFilters
    {
        /// <summary>
        /// Determines whether the argument is empty (string, ICollection, or has Length property).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
        /// Determines whether the provided value is considered "empty".
        /// </summary>
        /// <param name="arg">The value to check. Supported types: <see cref="string"/>, <see cref="ICollection"/>, or any object exposing an integer `Length` property. A <c>null</c> value is not considered empty.</param>
        /// <returns><c>true</c> if the value is empty (string length == 0, collection count == 0, or `Length` == 0); otherwise <c>false</c>.</returns>
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
        /// <summary>
/// Returns true when the given value is not considered empty.
/// </summary>
/// <param name="arg">The value to check for emptiness (may be null).</param>
/// <returns>True if <see cref="IsEmpty(object?)"/> would return false for the value; otherwise, false.</returns>
        public static bool IsNotEmpty(object arg) => !IsEmpty(arg);

        /// <summary>
        /// Determines whether the argument has the specified length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="len">The length to compare.</param>
        /// <summary>
        /// Checks whether the provided object has a length equal to the specified value.
        /// </summary>
        /// <remarks>
        /// Supports strings (string.Length), collections (ICollection.Count), and objects exposing a public integer `Length` property.
        /// Returns false if <paramref name="arg"/> is null or does not expose a supported length measurement.
        /// </remarks>
        /// <param name="arg">The value to inspect (string, ICollection, or an object with a public `Length` property).</param>
        /// <param name="len">The length to compare against.</param>
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
        /// <summary>
/// Creates a predicate that returns true when the supplied value has a length equal to <paramref name="len"/>.
/// </summary>
/// <param name="len">Target length to compare against.</param>
/// <returns>A function that accepts an object? and returns true if that object's length equals <paramref name="len"/> (supports strings, ICollection implementations, or objects exposing a Length property); returns false for null or unsupported types.</returns>
        public static Func<object?, bool> HasLength(int len) => arg => HasLength(arg, len);

        /// <summary>
        /// Determines whether the argument has at least the specified minimum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <summary>
        /// Determines whether the given value has a length greater than or equal to the specified minimum.
        /// </summary>
        /// <param name="arg">The value to check. Supported types: string, ICollection, or any object exposing an integer `Length` property.</param>
        /// <param name="min">The minimum length to test for.</param>
        /// <returns>True if <paramref name="arg"/> is non-null and its length is >= <paramref name="min"/>; otherwise, false.</returns>
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
        /// <summary>
/// Creates a predicate that returns true when an object's length is greater than or equal to <paramref name="min"/>.
/// </summary>
/// <param name="min">The minimum length (inclusive) to check for.</param>
/// <returns>A function that accepts an object (string, ICollection, or an object exposing a Length property) and returns true if its length is at least <paramref name="min"/>; returns false for null or unsupported types.</returns>
        public static Func<object?, bool> HasLengthMin(int min) => arg => HasLengthMin(arg, min);

        /// <summary>
        /// Determines whether the argument has at most the specified maximum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="max">The maximum length.</param>
        /// <summary>
        /// Determines whether the provided value's length is less than or equal to the specified maximum.
        /// </summary>
        /// <param name="arg">The value to check. Supported types: string (uses Length), ICollection (uses Count), or any object exposing an integer `Length` property. If null or unsupported, the method returns false.</param>
        /// <param name="max">The maximum allowed length (inclusive).</param>
        /// <returns>True if <paramref name="arg"/>'s length is less than or equal to <paramref name="max"/>; otherwise, false.</returns>
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
        /// <summary>
/// Returns a predicate that tests whether an object (string, ICollection, or object with a Length property) has length less than or equal to <paramref name="max"/>.
/// </summary>
/// <param name="max">Maximum allowed length (inclusive) used by the returned predicate.</param>
/// <returns>A function that returns true when the supplied value's length is ≤ <paramref name="max"/>; returns false for null or unsupported types.</returns>
        public static Func<object?, bool> HasLengthMax(int max) => arg => HasLengthMax(arg, max);

        /// <summary>
        /// Determines whether the argument has a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <summary>
        /// Determines whether the given value's length is between <paramref name="min"/> and <paramref name="max"/>, inclusive.
        /// </summary>
        /// <param name="arg">The value to check. Supported inputs are strings, collections (ICollection) and objects exposing an integer `Length` property; returns false for null or unsupported types.</param>
        /// <param name="min">The inclusive minimum length.</param>
        /// <param name="max">The inclusive maximum length.</param>
        /// <returns>True if the value's length is &gt;= <paramref name="min"/> and &lt;= <paramref name="max"/>; otherwise, false.</returns>
        public static bool HasLengthBetween(object? arg, int min, int max)
        {
            return HasLengthMin(arg, min) && HasLengthMax(arg, max);
        }

        /// <summary>
        /// Returns a function that checks if a value has a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <summary>
/// Returns a predicate that checks whether an object's length is between <paramref name="min"/> and <paramref name="max"/> (inclusive).
/// The predicate supports strings (Length), ICollection (Count), or objects exposing a Length property; it returns false for null or unsupported types.
/// </summary>
/// <param name="min">Minimum inclusive length to check for.</param>
/// <param name="max">Maximum inclusive length to check for.</param>
/// <returns>A function that takes an object? and returns true if its length is between <paramref name="min"/> and <paramref name="max"/>.</returns>
        public static Func<object?, bool> HasLengthBetween(int min, int max) => arg => HasLengthBetween(arg, min, max);

        /// <summary>
        /// Determines whether the argument does NOT have the specified length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="len">The length to compare.</param>
        /// <summary>
/// Returns true when the provided value does not have the specified length.
/// </summary>
/// <param name="arg">Value to check. Supported types: string (Length), ICollection (Count), or any object exposing an integer `Length` property. If <c>null</c> or an unsupported type, it is treated as not having the specified length.</param>
/// <param name="len">Expected length to compare against.</param>
/// <returns><c>true</c> if the value's length is not equal to <paramref name="len"/> (or the value is <c>null</c> or unsupported); otherwise <c>false</c>.</returns>
        public static bool HasNotLength(object? arg, int len) => !HasLength(arg, len);

        /// <summary>
        /// Returns a function that checks if a value does NOT have the specified length.
        /// </summary>
        /// <param name="len">The length to compare.</param>
        /// <summary>
/// Returns a predicate that checks whether an object's length is not equal to <paramref name="len"/>.
/// The predicate supports strings (Length), collections implementing <see cref="System.Collections.ICollection"/> (Count),
/// or objects exposing an integer `Length` property via reflection. For null or unsupported types the predicate returns true
/// (since they do not have the specified length).
/// </summary>
/// <param name="len">The length value to compare against.</param>
/// <returns>A function that returns true when the provided object's length is not equal to <paramref name="len"/>.</returns>
        public static Func<object?, bool> HasNotLength(int len) => arg => HasNotLength(arg, len);

        /// <summary>
        /// Determines whether the argument does NOT have at least the specified minimum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> does not have a length of at least <paramref name="min"/>.
/// </summary>
/// <param name="arg">The value to check; may be a string, an ICollection, or an object exposing a Length property. If null or of an unsupported type, it is treated as not meeting the minimum.</param>
/// <param name="min">The minimum required length.</param>
/// <returns>True if <paramref name="arg"/> has length less than <paramref name="min"/> or is null/unsupported; otherwise false.</returns>
        public static bool HasNotLengthMin(object? arg, int min) => !HasLengthMin(arg, min);

        /// <summary>
        /// Returns a function that checks if a value does NOT have at least the specified minimum length.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <summary>
/// Returns a function that checks whether an object's length is less than the specified minimum (the logical negation of <see cref="HasLengthMin(object?,int)"/>).
/// </summary>
/// <param name="min">Minimum length to compare against.</param>
/// <returns>A function that returns true when the object's length is not at least <paramref name="min"/>.</returns>
        public static Func<object?, bool> HasNotLengthMin(int min) => arg => HasNotLengthMin(arg, min);

        /// <summary>
        /// Determines whether the argument does NOT have at most the specified maximum length.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="max">The maximum length.</param>
        /// <summary>
/// Returns the logical negation of HasLengthMax: determines whether <paramref name="arg"/> does not satisfy a maximum length of <paramref name="max"/>.
/// </summary>
/// <param name="arg">The value to check (commonly a string, an ICollection, or an object exposing a `Length` property).</param>
/// <param name="max">The maximum allowed length.</param>
/// <returns>True if <paramref name="arg"/> does not have length ≤ <paramref name="max"/> (including when <paramref name="arg"/> is null or of an unsupported type); otherwise false.</returns>
        public static bool HasNotLengthMax(object? arg, int max) => !HasLengthMax(arg, max);

        /// <summary>
        /// Returns a function that checks if a value does NOT have at most the specified maximum length.
        /// </summary>
        /// <param name="max">The maximum length.</param>
        /// <summary>
/// Returns a predicate that is the logical negation of <see cref="HasLengthMax(object?,int)"/> for the given maximum.
/// </summary>
/// <param name="max">Maximum length to compare against.</param>
/// <returns>A function that returns true when <see cref="HasLengthMax(object?,int)"/> would return false for the same arguments.</returns>
        public static Func<object?, bool> HasNotLengthMax(int max) => arg => HasNotLengthMax(arg, max);

        /// <summary>
        /// Determines whether the argument does NOT have a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <summary>
/// Returns true when the provided object's length is NOT between <paramref name="min"/> and <paramref name="max"/> (inclusive).
/// </summary>
/// <param name="arg">The value to check. Supported: string, types implementing ICollection (Count), or any object exposing an integer Length property. Passing null or an unsupported type yields true.</param>
/// <param name="min">Inclusive minimum length.</param>
/// <param name="max">Inclusive maximum length.</param>
/// <returns>True if the value's length is outside the inclusive [min, max] range or if <paramref name="arg"/> is null/unsupported; otherwise false.</returns>
        public static bool HasNotLengthBetween(object? arg, int min, int max) => !HasLengthBetween(arg, min, max);

        /// <summary>
        /// Returns a function that checks if a value does NOT have a length between the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum length.</param>
        /// <param name="max">The maximum length.</param>
        /// <summary>
/// Returns a function that evaluates whether an object's length is NOT between the specified inclusive bounds.
/// </summary>
/// <param name="min">Inclusive lower bound for the length comparison.</param>
/// <param name="max">Inclusive upper bound for the length comparison.</param>
/// <returns>A function that takes an object? and returns true if its length is not between <paramref name="min"/> and <paramref name="max"/>.</returns>
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
