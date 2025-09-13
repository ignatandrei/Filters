namespace FpFilters.TypeFilters
{
    public static class TypeFilters
    {
        /// <summary>
        /// Returns true if the argument is undefined (null in C#).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Returns true when the provided value is null (treated as "undefined"); otherwise false.
/// </summary>
/// <returns>True if <c>arg</c> is null; otherwise false.</returns>
        public static bool IsUndefined(object? arg) => arg == null;

        /// <summary>
        /// Returns true if the argument is a string.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is a string.
/// </summary>
/// <param name="arg">The value to test; may be null.</param>
/// <returns>True if <paramref name="arg"/> is a <see cref="string"/>; otherwise, false.</returns>
        public static bool IsString(object? arg) => arg is string;

        /// <summary>
        /// Returns true if the argument is a number.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the given value is one of the supported numeric CLR types.
/// </summary>
/// <param name="arg">The value to test; may be null. Considered a number if it's an int, double, float, decimal, long, short, or byte.</param>
/// <returns>True if the value is a number; otherwise, false.</returns>
        public static bool IsNumber(object? arg) => arg is int || arg is double || arg is float || arg is decimal || arg is long || arg is short || arg is byte;

        /// <summary>
        /// Returns true if the argument is an object.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> is a non-null reference type that is not a <see cref="string"/>.
/// </summary>
/// <param name="arg">The value to test.</param>
/// <returns>True if <paramref name="arg"/> is a non-null, non-string reference type; otherwise false.</returns>
        public static bool IsObject(object? arg) => arg != null && !(arg is ValueType) && !(arg is string);

        /// <summary>
        /// Returns true if the argument is null.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is null.
/// </summary>
/// <param name="arg">The value to check for null.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is null; otherwise, <c>false</c>.</returns>
        public static bool IsNull(object? arg) => arg == null;

        /// <summary>
        /// Returns true if the argument is a boolean.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the specified value is a boolean.
/// </summary>
/// <param name="arg">The value to test; may be null.</param>
/// <returns>true if the value is a <see cref="bool"/>; otherwise, false.</returns>
        public static bool IsBoolean(object? arg) => arg is bool;

        /// <summary>
        /// Returns true if the argument is a date.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is a <see cref="DateTime"/>.
/// </summary>
/// <param name="arg">The value to test; may be null.</param>
/// <returns>True if <paramref name="arg"/> is a <see cref="DateTime"/>; otherwise, false.</returns>
        public static bool IsDate(object? arg) => arg is DateTime;

        /// <summary>
        /// Returns true if the argument is an array.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the supplied value is an array.
/// </summary>
/// <param name="arg">The value to test; may be <c>null</c>. Returns <c>false</c> for <c>null</c>.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is an <see cref="Array"/>; otherwise, <c>false</c>.</returns>
        public static bool IsArray(object? arg) => arg is Array;

        /// <summary>
        /// Returns true if the argument is not undefined (not null).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Returns true when the provided value is not null.
/// </summary>
/// <returns>True if <paramref name="arg"/> is not null; otherwise, false.</returns>
        public static bool IsNotUndefined(object? arg) => arg != null;

        /// <summary>
        /// Returns true if the argument is not a string.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Returns true when the provided value is not a string.
/// </summary>
/// <returns>True if the value is not a string; otherwise, false.</returns>
        public static bool IsNotString(object? arg) => !(arg is string);

        /// <summary>
        /// Returns true if the argument is not a number.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> is not one of the primitive numeric types recognized by this helper.
/// </summary>
/// <returns>True if the value is not a number (not int, double, float, decimal, long, short, or byte); otherwise, false.</returns>
        public static bool IsNotNumber(object? arg) => !(arg is int || arg is double || arg is float || arg is decimal || arg is long || arg is short || arg is byte);

        /// <summary>
        /// Returns true if the argument is not an object.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is not considered an "object" reference in the library's sense.
/// </summary>
/// <remarks>
/// Returns true for null, any value type, or a string; returns false only for non-null reference types that are not strings.
/// </remarks>
/// <returns>True if <c>arg</c> is null, a value type, or a string; otherwise false.</returns>
        public static bool IsNotObject(object? arg) => arg == null || arg is ValueType || arg is string;

        /// <summary>
        /// Returns true if the argument is not null.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Returns true when the provided value is not null.
/// </summary>
/// <returns>True if <c>arg</c> is not null; otherwise, false.</returns>
        public static bool IsNotNull(object? arg) => arg != null;

        /// <summary>
        /// Returns true if the argument is not a boolean.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is not a Boolean.
/// </summary>
/// <param name="arg">The value to test; null is considered not a boolean.</param>
/// <returns><c>true</c> if <paramref name="arg"/> is not a <see cref="bool"/>; otherwise, <c>false</c>.</returns>
        public static bool IsNotBoolean(object? arg) => !(arg is bool);

        /// <summary>
        /// Returns true if the argument is not a date.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is not a DateTime.
/// </summary>
/// <param name="arg">The value to test. A null value is considered not a date.</param>
/// <returns>True if <paramref name="arg"/> is not a <see cref="DateTime"/>; otherwise, false.</returns>
        public static bool IsNotDate(object? arg) => !(arg is DateTime);

        /// <summary>
        /// Returns true if the argument is not an array.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the provided value is not an Array.
/// </summary>
/// <returns>True if the value is not an array; otherwise, false.</returns>
        public static bool IsNotArray(object? arg) => !(arg is Array);

        /// <summary>
        /// Returns true if the argument is of the same type as comparison.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The comparison value.</param>
        /// <summary>
/// Determines whether the runtime types of two values are exactly the same.
/// </summary>
/// <param name="arg">The first value to compare; may be null.</param>
/// <param name="comparison">The second value to compare; may be null.</param>
/// <returns>True if both values have the same runtime type or both are null; otherwise false.</returns>
        public static bool IsSameTypeAs<T>(object? arg, T comparison) => arg?.GetType() == comparison?.GetType();
        /// <summary>
        /// Returns a function that checks if a value is of the same type as the comparison value.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="comparison">The comparison value.</param>
        /// <summary>
/// Returns a predicate that tests whether an object's runtime type matches the runtime type of <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">A value whose runtime type will be used as the reference type for comparisons.</param>
/// <returns>A function that returns true when its argument's runtime type equals the runtime type of <paramref name="comparison"/>.</returns>
        public static Func<object?, bool> IsSameTypeAs<T>(T comparison) => arg => IsSameTypeAs(arg, comparison);

        /// <summary>
        /// Returns true if the argument is not of the same type as comparison.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The comparison value.</param>
        /// <summary>
/// Determines whether the runtime type of <paramref name="arg"/> is not the same as the runtime type of <paramref name="comparison"/>.
/// </summary>
/// <param name="arg">The value whose runtime type is compared. May be null.</param>
/// <param name="comparison">The value to compare against. May be null.</param>
/// <returns>
/// True if the runtime types differ (including when exactly one value is null); false if both values are null or their runtime types are equal.
/// </returns>
        public static bool IsNotSameTypeAs<T>(object? arg, T comparison) => arg?.GetType() != comparison?.GetType();
        /// <summary>
        /// Returns a function that checks if a value is not of the same type as the comparison value.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="comparison">The comparison value.</param>
        /// <summary>
/// Returns a predicate that evaluates whether an input's runtime type is different from the runtime type of <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The value whose runtime type will be used for the comparison. The predicate returns true when an input's type does not match this type.</param>
/// <returns>A function that takes an object? and returns true if its runtime type is not the same as the runtime type of <paramref name="comparison"/>.</returns>
        public static Func<object?, bool> IsNotSameTypeAs<T>(T comparison) => arg => IsNotSameTypeAs(arg, comparison);

        /// <summary>
        /// Returns true if the argument is of the specified type.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="type">The type to compare against.</param>
        /// <summary>
/// Determines whether the runtime type of <paramref name="arg"/> exactly matches the specified <paramref name="type"/>.
/// </summary>
/// <param name="arg">The value to check; returns false if null.</param>
/// <param name="type">The Type to compare against (exact runtime type match, not assignability).</param>
/// <returns>True if <paramref name="arg"/> is non-null and its runtime type equals <paramref name="type"/>; otherwise, false.</returns>
        public static bool IsOfType(object? arg, Type type) => arg != null && arg.GetType() == type;
        /// <summary>
        /// Returns a function that checks if a value is of the specified type.
        /// </summary>
        /// <param name="type">The type to compare against.</param>
        /// <summary>
/// Creates a predicate that returns true when a value's runtime type exactly matches the provided <paramref name="type"/>.
/// </summary>
/// <param name="type">The Type to compare against; must not be null.</param>
/// <returns>A function that takes an object? and returns true if the object's runtime type equals <paramref name="type"/>.</returns>
        public static Func<object?, bool> IsOfType(Type type) => arg => IsOfType(arg, type);

        /// <summary>
        /// Returns true if the argument is not of the specified type.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="type">The type to compare against.</param>
        /// <summary>
/// Determines whether a value is not of the specified runtime type.
/// </summary>
/// <param name="arg">The value to check; returns true when <c>null</c>.</param>
/// <param name="type">The runtime <see cref="Type"/> to compare against. Comparison requires exact type equality (not assignability).</param>
/// <returns><c>true</c> if <paramref name="arg"/> is <c>null</c> or its runtime type is not equal to <paramref name="type"/>; otherwise <c>false</c>.</returns>
        public static bool IsNotOfType(object? arg, Type type) => arg == null || arg.GetType() != type;
        /// <summary>
        /// Returns a function that checks if a value is not of the specified type.
        /// </summary>
        /// <param name="type">The type to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a value is not of the specified runtime <paramref name="type"/>.
/// </summary>
/// <param name="type">The runtime type to compare against.</param>
/// <returns>
/// A function that returns <c>true</c> when the tested value is <c>null</c> or its runtime type is not equal to <paramref name="type"/>; otherwise <c>false</c>.
/// </returns>
        public static Func<object?, bool> IsNotOfType(Type type) => arg => IsNotOfType(arg, type);

        /// <summary>
        /// Returns true if the argument is an instance of the specified class.
        /// </summary>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <summary>
/// Determines whether the given value is an instance of the specified generic type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The target type to test against.</typeparam>
/// <param name="arg">The value to test.</param>
/// <returns>True if <paramref name="arg"/> is an instance of <typeparamref name="T"/>; otherwise, false.</returns>
        public static bool IsInstanceOf<T>(object? arg) => arg is T;
    }
}
