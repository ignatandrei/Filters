using System;

namespace FpFilters.TypeFilters
{
    public static class TypeFilters
    {
        // Returns true if the argument is undefined (null in C#)
        public static bool IsUndefined(object? arg) => arg == null;

        // Returns true if the argument is a string
        public static bool IsString(object? arg) => arg is string;

        // Returns true if the argument is a number
        public static bool IsNumber(object? arg) => arg is int || arg is double || arg is float || arg is decimal || arg is long || arg is short || arg is byte;

        // Returns true if the argument is an object
        public static bool IsObject(object? arg) => arg != null && !(arg is ValueType) && !(arg is string);

        // Returns true if the argument is null
        public static bool IsNull(object? arg) => arg == null;

        // Returns true if the argument is a boolean
        public static bool IsBoolean(object? arg) => arg is bool;

        // Returns true if the argument is a date
        public static bool IsDate(object? arg) => arg is DateTime;

        // Returns true if the argument is an array
        public static bool IsArray(object? arg) => arg is Array;

        // Returns true if the argument is not undefined (not null)
        public static bool IsNotUndefined(object? arg) => arg != null;

        // Returns true if the argument is not a string
        public static bool IsNotString(object? arg) => !(arg is string);

        // Returns true if the argument is not a number
        public static bool IsNotNumber(object? arg) => !(arg is int || arg is double || arg is float || arg is decimal || arg is long || arg is short || arg is byte);

        // Returns true if the argument is not an object
        public static bool IsNotObject(object? arg) => arg == null || arg is ValueType || arg is string;

        // Returns true if the argument is not null
        public static bool IsNotNull(object? arg) => arg != null;

        // Returns true if the argument is not a boolean
        public static bool IsNotBoolean(object? arg) => !(arg is bool);

        // Returns true if the argument is not a date
        public static bool IsNotDate(object? arg) => !(arg is DateTime);

        // Returns true if the argument is not an array
        public static bool IsNotArray(object? arg) => !(arg is Array);

        // Returns true if the argument is of the same type as comparison
        public static bool IsSameTypeAs<T>(object? arg, T comparison) => arg?.GetType() == comparison?.GetType();

        // Returns true if the argument is not of the same type as comparison
        public static bool IsNotSameTypeAs<T>(object? arg, T comparison) => arg?.GetType() != comparison?.GetType();

        // Returns true if the argument is of the specified type
        public static bool IsOfType(object? arg, Type type) => arg != null && arg.GetType() == type;

        // Returns true if the argument is not of the specified type
        public static bool IsNotOfType(object? arg, Type type) => arg == null || arg.GetType() != type;

        // Returns true if the argument is an instance of the specified class
        public static bool IsInstanceOf<T>(object? arg) => arg is T;
    }
}
