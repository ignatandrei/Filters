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
        /// <summary>
/// Returns true when <paramref name="arg"/> equals <paramref name="comparison"/> using object equality semantics.
/// </summary>
/// <param name="arg">First value to compare.</param>
/// <param name="comparison">Value to compare against.</param>
/// <returns>True if the two values are equal; otherwise, false.</returns>
        public static bool Is<T>(T arg, T comparison) => Equals(arg, comparison);

        /// <summary>
        /// Returns a function that checks if a value is equal to the specified comparison value.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Creates a predicate that returns true when its input equals the specified comparison value.
/// </summary>
/// <param name="comparison">The value to compare against; equality is determined by <c>Equals</c> semantics.</param>
/// <returns>A function that takes a value of type <typeparamref name="T"/> and returns true if it equals <paramref name="comparison"/>.</returns>
        public static Func<T, bool> Is<T>(T comparison) => arg => Is(arg, comparison);

        /// <summary>
        /// Returns true if the argument is different from the comparison parameter.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Returns true when <paramref name="arg"/> is not equal to <paramref name="comparison"/> using object equality semantics; otherwise false.
/// </summary>
/// <param name="arg">Value to compare.</param>
/// <param name="comparison">Value to compare against.</param>
/// <returns>True if the values are different; otherwise, false.</returns>
        public static bool IsNot<T>(T arg, T comparison) => !Equals(arg, comparison);

        /// <summary>
        /// Returns a function that checks if a value is different from the specified comparison value.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="comparison">The value to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether its input is not equal to the provided comparison value.
/// </summary>
/// <param name="comparison">The value to compare against.</param>
/// <returns>A function that returns true when its argument is not equal to <paramref name="comparison"/>.</returns>
        public static Func<T, bool> IsNot<T>(T comparison) => arg => IsNot(arg, comparison);

        /// <summary>
        /// Returns true for all elements (identity function for filter).
        /// </summary>
        /// <summary>
/// A filter that always passes; returns true unconditionally.
/// </summary>
/// <returns>Always returns <c>true</c>.</returns>
        public static bool All() => true;

        /// <summary>
        /// Returns false for all elements.
        /// </summary>
        /// <summary>
/// A filter predicate that always returns false (rejects every input).
/// </summary>
/// <returns>Always <c>false</c>.</returns>
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
