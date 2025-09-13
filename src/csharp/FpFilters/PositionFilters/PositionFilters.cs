namespace FpFilters.PositionFilters
{
    public static class PositionFilters
    {
        /// <summary>
        /// Determines whether the specified index is odd.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <summary>
/// Determines whether a zero-based index is odd.
/// </summary>
/// <param name="index">Zero-based position to test.</param>
/// <returns><see langword="true"/> if <paramref name="index"/> is odd; otherwise <see langword="false"/>.</returns>
        public static bool IsOddIndex(int index) => index % 2 == 1;

        /// <summary>
        /// Determines whether the specified index is even.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <summary>
/// Determines whether a zero-based index is even.
/// </summary>
/// <param name="index">Zero-based element index to test.</param>
/// <returns>true if the index is even; otherwise, false.</returns>
        public static bool IsEvenIndex(int index) => index % 2 == 0;

        /// <summary>
        /// Determines whether the specified index is every Nth index, with an optional starting offset.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <param name="n">The interval for Nth index.</param>
        /// <param name="start">The starting offset (default is 0).</param>
        /// <summary>
        /// Returns true when the given index falls on every Nth position counting from <paramref name="start"/>.
        /// </summary>
        /// <param name="index">The zero-based index to test.</param>
        /// <param name="n">The step interval. A positive value selects every Nth index forward from <paramref name="start"/>.</param>
        /// <param name="start">The starting index offset from which to count (default is 0).</param>
        /// <returns>True if (index - start) is divisible by n; otherwise, false.</returns>
        /// <exception cref="System.DivideByZeroException">Thrown if <paramref name="n"/> is zero.</exception>
        public static bool IsEveryNthIndex(int index, int n, int start = 0)
        {
            return (index - start) % n == 0;
        }

        /// <summary>
        /// Determines whether the specified index is the first element.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <summary>
/// Determines whether the provided zero-based index refers to the first element.
/// </summary>
/// <param name="index">Zero-based element index to test.</param>
/// <returns><c>true</c> if <paramref name="index"/> is 0; otherwise, <c>false</c>.</returns>
        public static bool IsFirst(int index) => index == 0;

        /// <summary>
        /// Determines whether the specified index is the last element in a collection of the given length.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <param name="length">The length of the collection.</param>
        /// <summary>
/// Determines whether the given index refers to the last element of a sequence of the specified length.
/// </summary>
/// <param name="index">Zero-based index to test.</param>
/// <param name="length">Total number of elements in the sequence.</param>
/// <returns>True if <paramref name="index"/> equals <paramref name="length"/> - 1; otherwise, false.</returns>
        public static bool IsLast(int index, int length) => index == length - 1;

        /// <summary>
        /// Determines whether the specified index is a middle element in a collection of the given length.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <param name="length">The length of the collection.</param>
        /// <summary>
/// Returns true when the given zero-based index refers to an element strictly between the first and last elements of a collection with the specified length.
/// </summary>
/// <param name="index">Zero-based position to test.</param>
/// <param name="length">Total number of elements in the collection.</param>
/// <returns>True if <paramref name="length"/> is greater than 2 and <paramref name="index"/> is greater than 0 and less than <c>length - 1</c>; otherwise, false.</returns>
        public static bool IsMiddle(int index, int length) => length > 2 && index > 0 && index < length - 1;
    }
}
