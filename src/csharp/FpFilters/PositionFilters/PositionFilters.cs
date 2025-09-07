namespace FpFilters.PositionFilters
{
    public static class PositionFilters
    {
        // Returns true for elements with an odd index
        public static bool IsOddIndex(int index) => index % 2 == 1;

        // Returns true for elements with an even index
        public static bool IsEvenIndex(int index) => index % 2 == 0;

        // Returns true for every Nth index (with optional offset)
        public static bool IsEveryNthIndex(int index, int n, int start = 0)
        {
            return (index - start) % n == 0;
        }
        // BDD test support methods
        public static bool IsFirst(int index) => index == 0;
        public static bool IsLast(int index, int length) => index == length - 1;
        public static bool IsMiddle(int index, int length) => length > 2 && index > 0 && index < length - 1;
    }
}
