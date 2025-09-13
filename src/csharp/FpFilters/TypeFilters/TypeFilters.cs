namespace FpFilters.TypeFilters
{
    public static class TypeFilters
    {
        /// <summary>
        /// Returns true if the argument is undefined (null in C#).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is undefined; otherwise, false.</returns>
        public static bool IsUndefined(object? arg) => arg == null;

        /// <summary>
        /// Returns true if the argument is a string.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is a string; otherwise, false.</returns>
        public static bool IsString(object? arg) => arg is string;

        /// <summary>
        /// Returns true if the argument is a number.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is a number; otherwise, false.</returns>
        public static bool IsNumber(object? arg) => arg is int || arg is double || arg is float || arg is decimal || arg is long || arg is short || arg is byte;

        /// <summary>
        /// Returns true if the argument is an object.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is an object; otherwise, false.</returns>
        public static bool IsObject(object? arg) => arg != null && !(arg is ValueType) && !(arg is string);

        /// <summary>
        /// Returns true if the argument is null.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is null; otherwise, false.</returns>
        public static bool IsNull(object? arg) => arg == null;

        /// <summary>
        /// Returns true if the argument is a boolean.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is a boolean; otherwise, false.</returns>
        public static bool IsBoolean(object? arg) => arg is bool;

        /// <summary>
        /// Returns true if the argument is a date.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is a date; otherwise, false.</returns>
        public static bool IsDate(object? arg) => arg is DateTime;

        /// <summary>
        /// Returns true if the argument is an array.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is an array; otherwise, false.</returns>
        public static bool IsArray(object? arg) => arg is Array;

        /// <summary>
        /// Returns true if the argument is not undefined (not null).
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not undefined; otherwise, false.</returns>
        public static bool IsNotUndefined(object? arg) => arg != null;

        /// <summary>
        /// Returns true if the argument is not a string.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not a string; otherwise, false.</returns>
        public static bool IsNotString(object? arg) => !(arg is string);

        /// <summary>
        /// Returns true if the argument is not a number.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not a number; otherwise, false.</returns>
        public static bool IsNotNumber(object? arg) => !(arg is int || arg is double || arg is float || arg is decimal || arg is long || arg is short || arg is byte);

        /// <summary>
        /// Returns true if the argument is not an object.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not an object; otherwise, false.</returns>
        public static bool IsNotObject(object? arg) => arg == null || arg is ValueType || arg is string;

        /// <summary>
        /// Returns true if the argument is not null.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not null; otherwise, false.</returns>
        public static bool IsNotNull(object? arg) => arg != null;

        /// <summary>
        /// Returns true if the argument is not a boolean.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not a boolean; otherwise, false.</returns>
        public static bool IsNotBoolean(object? arg) => !(arg is bool);

        /// <summary>
        /// Returns true if the argument is not a date.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not a date; otherwise, false.</returns>
        public static bool IsNotDate(object? arg) => !(arg is DateTime);

        /// <summary>
        /// Returns true if the argument is not an array.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is not an array; otherwise, false.</returns>
        public static bool IsNotArray(object? arg) => !(arg is Array);

        /// <summary>
        /// Returns true if the argument is of the same type as comparison.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The comparison value.</param>
        /// <returns>True if the types are the same; otherwise, false.</returns>
        public static bool IsSameTypeAs<T>(object? arg, T comparison) => arg?.GetType() == comparison?.GetType();
        /// <summary>
        /// Returns a function that checks if a value is of the same type as the comparison value.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="comparison">The comparison value.</param>
        /// <returns>A function that checks if a value is of the same type.</returns>
        public static Func<object?, bool> IsSameTypeAs<T>(T comparison) => arg => IsSameTypeAs(arg, comparison);

        /// <summary>
        /// Returns true if the argument is not of the same type as comparison.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The comparison value.</param>
        /// <returns>True if the types are not the same; otherwise, false.</returns>
        public static bool IsNotSameTypeAs<T>(object? arg, T comparison) => arg?.GetType() != comparison?.GetType();
        /// <summary>
        /// Returns a function that checks if a value is not of the same type as the comparison value.
        /// </summary>
        /// <typeparam name="T">The type to compare against.</typeparam>
        /// <param name="comparison">The comparison value.</param>
        /// <returns>A function that checks if a value is not of the same type.</returns>
        public static Func<object?, bool> IsNotSameTypeAs<T>(T comparison) => arg => IsNotSameTypeAs(arg, comparison);

        /// <summary>
        /// Returns true if the argument is of the specified type.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="type">The type to compare against.</param>
        /// <returns>True if the value is of the specified type; otherwise, false.</returns>
        public static bool IsOfType(object? arg, Type type) => arg != null && arg.GetType() == type;
        /// <summary>
        /// Returns a function that checks if a value is of the specified type.
        /// </summary>
        /// <param name="type">The type to compare against.</param>
        /// <returns>A function that checks if a value is of the specified type.</returns>
        public static Func<object?, bool> IsOfType(Type type) => arg => IsOfType(arg, type);

        /// <summary>
        /// Returns true if the argument is not of the specified type.
        /// </summary>
        /// <param name="arg">The value to check.</param>
        /// <param name="type">The type to compare against.</param>
        /// <returns>True if the value is not of the specified type; otherwise, false.</returns>
        public static bool IsNotOfType(object? arg, Type type) => arg == null || arg.GetType() != type;
        /// <summary>
        /// Returns a function that checks if a value is not of the specified type.
        /// </summary>
        /// <param name="type">The type to compare against.</param>
        /// <returns>A function that checks if a value is not of the specified type.</returns>
        public static Func<object?, bool> IsNotOfType(Type type) => arg => IsNotOfType(arg, type);

        /// <summary>
        /// Returns true if the argument is an instance of the specified class.
        /// </summary>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <returns>True if the value is an instance of the specified class; otherwise, false.</returns>
        public static bool IsInstanceOf<T>(object? arg) => arg is T;
    }
}
