namespace FpFilters.ArrayFilters
{
    public static class ArrayFilters
    {
        // Checks if the argument is included in the comparison array
        public static bool IsIncludedIn<T>(T arg, T[] comparisonArray)
        {
            return comparisonArray != null && comparisonArray.Contains(arg);
        }
        // LINQ-friendly overload
        public static Func<T, bool> IsIncludedIn<T>(T[] comparisonArray) => arg => IsIncludedIn(arg, comparisonArray);

        // Checks if the argument is NOT included in the comparison array
        public static bool IsNotIncludedIn<T>(T arg, T[] comparisonArray)
        {
            return comparisonArray == null || !comparisonArray.Contains(arg);
        }
        // LINQ-friendly overload
        public static Func<T, bool> IsNotIncludedIn<T>(T[] comparisonArray) => arg => IsNotIncludedIn(arg, comparisonArray);

        // Used on arrays of arrays (2D arrays). Returns true if all elements in the nested array pass the test
        public static bool EveryElement<T>(T[] array, Func<T, bool> condition)
        {
            return array != null && array.All(condition);
        }
        // LINQ-friendly overload
        public static Func<T[], bool> EveryElement<T>(Func<T, bool> condition) => array => EveryElement(array, condition);
    }
}
