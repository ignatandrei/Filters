namespace FpFilters.PositionFilters
{
    public static class PositionFilters
    {
        /// <summary>
        /// Determines whether the specified index is odd.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is odd; otherwise, false.</returns>
        public static bool IsOddIndex(int index) => index % 2 == 1;

        /// <summary>
        /// Determines whether the specified index is even.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is even; otherwise, false.</returns>
        public static bool IsEvenIndex(int index) => index % 2 == 0;

        /// <summary>
        /// Determines whether the specified index is every Nth index, with an optional starting offset.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <param name="n">The interval for Nth index.</param>
        /// <param name="start">The starting offset (default is 0).</param>
        /// <returns>True if the index is every Nth index from the start; otherwise, false.</returns>
        public static bool IsEveryNthIndex(int index, int n, int start = 0)
        {
            return (index - start) % n == 0;
        }

        /// <summary>
        /// Determines whether the specified index is the first element.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is the first element; otherwise, false.</returns>
        public static bool IsFirst(int index) => index == 0;

        /// <summary>
        /// Determines whether the specified index is the last element in a collection of the given length.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <param name="length">The length of the collection.</param>
        /// <returns>True if the index is the last element; otherwise, false.</returns>
        public static bool IsLast(int index, int length) => index == length - 1;

        /// <summary>
        /// Determines whether the specified index is a middle element in a collection of the given length.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <param name="length">The length of the collection.</param>
        /// <returns>True if the index is a middle element; otherwise, false.</returns>
        public static bool IsMiddle(int index, int length) => length > 2 && index > 0 && index < length - 1;
    }
}
