namespace FpFilters.ArrayFilters
{
    public static class ArrayFilters
    {
        /// <summary>
        /// Checks if the argument is included in the comparison array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparisonArray">The array to search.</param>
        /// <summary>
        /// Returns true when <paramref name="comparisonArray"/> is non-null and contains <paramref name="arg"/>; otherwise false.
        /// </summary>
        /// <typeparam name="T">Type of the value and array elements.</typeparam>
        /// <param name="comparisonArray">Array to search; treated as empty if null.</param>
        /// <returns>True if <paramref name="arg"/> is present in <paramref name="comparisonArray"/>; otherwise false.</returns>
        public static bool IsIncludedIn<T>(T arg, T[] comparisonArray)
        {
            return comparisonArray != null && comparisonArray.Contains(arg);
        }

        /// <summary>
        /// Returns a function that checks if a value is included in the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="comparisonArray">The array to search.</param>
        /// <summary>
/// Creates a predicate that returns whether a given value is contained in the provided array.
/// </summary>
/// <typeparam name="T">The element type of the array and values to test.</typeparam>
/// <param name="comparisonArray">The array to check membership against. If null, the predicate always returns false.</param>
/// <returns>A function that accepts a value of type <typeparamref name="T"/> and returns true if that value is contained in <paramref name="comparisonArray"/>, otherwise false.</returns>
        public static Func<T, bool> IsIncludedIn<T>(T[] comparisonArray) => arg => IsIncludedIn(arg, comparisonArray);

        /// <summary>
        /// Checks if the argument is NOT included in the comparison array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparisonArray">The array to search.</param>
        /// <summary>
        /// Determines whether <paramref name="arg"/> is not present in <paramref name="comparisonArray"/>.
        /// </summary>
        /// <typeparam name="T">Type of the value and array elements.</typeparam>
        /// <param name="arg">Value to check for absence in the array.</param>
        /// <param name="comparisonArray">
        /// Array to search; if null, the method returns <c>true</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="comparisonArray"/> is null or does not contain <paramref name="arg"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Element membership is determined using the default equality comparer for <typeparamref name="T"/>.
        — 
        /// </remarks>
        public static bool IsNotIncludedIn<T>(T arg, T[] comparisonArray)
        {
            return comparisonArray == null || !comparisonArray.Contains(arg);
        }

        /// <summary>
        /// Returns a function that checks if a value is NOT included in the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="comparisonArray">The array to search.</param>
        /// <summary>
/// Returns a function that determines whether a given value is not contained in the specified comparison array.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
/// <param name="comparisonArray">Array to check membership against.</param>
/// <returns>A function that returns true when its argument is not present in <paramref name="comparisonArray"/>; otherwise false.</returns>
        public static Func<T, bool> IsNotIncludedIn<T>(T[] comparisonArray) => arg => IsNotIncludedIn(arg, comparisonArray);

        /// <summary>
        /// Returns true if all elements in the array pass the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="array">The array to check.</param>
        /// <param name="condition">The condition to test each element.</param>
        /// <summary>
        /// Determines whether every element in <paramref name="array"/> satisfies the given <paramref name="condition"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements in the array.</typeparam>
        /// <param name="array">The array whose elements will be tested. If null, the method returns <c>false</c>.</param>
        /// <param name="condition">Predicate that each element must satisfy.</param>
        /// <returns><c>true</c> if <paramref name="array"/> is not null and every element makes <paramref name="condition"/> return <c>true</c>; otherwise <c>false</c>.</returns>
        public static bool EveryElement<T>(T[] array, Func<T, bool> condition)
        {
            return array != null && array.All(condition);
        }

        /// <summary>
        /// Returns a function that checks if all elements in an array pass the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="condition">The condition to test each element.</param>
        /// <summary>
/// Returns a function that determines whether every element in a provided array satisfies the given predicate.
/// </summary>
/// <typeparam name="T">The element type of the array.</typeparam>
/// <param name="condition">Predicate to test each element.</param>
/// <returns>
/// A function that returns true when the supplied array is non-null and every element satisfies <paramref name="condition"/>; otherwise false.
/// </returns>
        public static Func<T[], bool> EveryElement<T>(Func<T, bool> condition) => array => EveryElement(array, condition);
    }
}
