namespace FpFilters.MiscFilters
{
    public static class MiscFilters
    {
        /// <summary>
        /// Returns true if the argument is equal to the comparison parameter.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>True if the values are equal; otherwise, false.</returns>
        public static bool Is<T>(T arg, T comparison) => Equals(arg, comparison);

        /// <summary>
        /// Returns a function that checks if a value is equal to the specified comparison value.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>A function that checks if a value is equal to the comparison value.</returns>
        public static Func<T, bool> Is<T>(T comparison) => arg => Is(arg, comparison);

        /// <summary>
        /// Returns true if the argument is different from the comparison parameter.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>True if the values are different; otherwise, false.</returns>
        public static bool IsNot<T>(T arg, T comparison) => !Equals(arg, comparison);

        /// <summary>
        /// Returns a function that checks if a value is different from the specified comparison value.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="comparison">The value to compare against.</param>
        /// <returns>A function that checks if a value is different from the comparison value.</returns>
        public static Func<T, bool> IsNot<T>(T comparison) => arg => IsNot(arg, comparison);

        /// <summary>
        /// Returns true for all elements (identity function for filter).
        /// </summary>
        /// <returns>True for all elements.</returns>
        public static bool All() => true;

        /// <summary>
        /// Returns false for all elements.
        /// </summary>
        /// <returns>False for all elements.</returns>
        public static bool None() => false;
        // BDD test support methods
        // Only treat reference types (classes) as 'null or default'. Value types are never null/default unless explicitly null.
        public static bool IsNullOrDefault<T>(T? arg)
            where T : class
        {
            return arg == null;
        }

        public static bool IsNotNullOrDefault<T>(T? arg)
            where T : class
        {
            return arg != null;
        }
    }
}
