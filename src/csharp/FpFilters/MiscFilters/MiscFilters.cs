namespace FpFilters.MiscFilters
{
    public static class MiscFilters
    {
        // Returns true if the argument is equal to the comparison parameter
        public static bool Is<T>(T arg, T comparison) => Equals(arg, comparison);

        // Returns true if the argument is different from the comparison parameter
        public static bool IsNot<T>(T arg, T comparison) => !Equals(arg, comparison);

        // Returns true for all elements (identity function for filter)
        public static bool All() => true;

        // Returns false for all elements
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
