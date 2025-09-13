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
        /// <returns>True if the value is included in the array; otherwise, false.</returns>
        public static bool IsIncludedIn<T>(T arg, T[] comparisonArray)
        {
            return comparisonArray != null && comparisonArray.Contains(arg);
        }

        /// <summary>
        /// Returns a function that checks if a value is included in the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="comparisonArray">The array to search.</param>
        /// <returns>A function that checks if a value is included in the array.</returns>
        public static Func<T, bool> IsIncludedIn<T>(T[] comparisonArray) => arg => IsIncludedIn(arg, comparisonArray);

        /// <summary>
        /// Checks if the argument is NOT included in the comparison array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="arg">The value to check.</param>
        /// <param name="comparisonArray">The array to search.</param>
        /// <returns>True if the value is not included in the array; otherwise, false.</returns>
        public static bool IsNotIncludedIn<T>(T arg, T[] comparisonArray)
        {
            return comparisonArray == null || !comparisonArray.Contains(arg);
        }

        /// <summary>
        /// Returns a function that checks if a value is NOT included in the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="comparisonArray">The array to search.</param>
        /// <returns>A function that checks if a value is not included in the array.</returns>
        public static Func<T, bool> IsNotIncludedIn<T>(T[] comparisonArray) => arg => IsNotIncludedIn(arg, comparisonArray);

        /// <summary>
        /// Returns true if all elements in the array pass the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="array">The array to check.</param>
        /// <param name="condition">The condition to test each element.</param>
        /// <returns>True if all elements pass the condition; otherwise, false.</returns>
        public static bool EveryElement<T>(T[] array, Func<T, bool> condition)
        {
            return array != null && array.All(condition);
        }

        /// <summary>
        /// Returns a function that checks if all elements in an array pass the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="condition">The condition to test each element.</param>
        /// <returns>A function that checks if all elements pass the condition.</returns>
        public static Func<T[], bool> EveryElement<T>(Func<T, bool> condition) => array => EveryElement(array, condition);
    }
}
