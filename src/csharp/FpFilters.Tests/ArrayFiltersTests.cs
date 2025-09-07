namespace FpFilters.ArrayFilters.Tests
{
    public class ArrayFiltersTests
    {
        [Fact]
        public void IsIncludedIn_ReturnsTrueIfIncluded()
        {
            int[] arr = { 1, 2, 3 };
            Assert.True(ArrayFilters.IsIncludedIn(2, arr));
            Assert.False(ArrayFilters.IsIncludedIn(4, arr));
        }

        [Fact]
        public void IsNotIncludedIn_ReturnsTrueIfNotIncluded()
        {
            int[] arr = { 1, 2, 3 };
            Assert.True(ArrayFilters.IsNotIncludedIn(4, arr));
            Assert.False(ArrayFilters.IsNotIncludedIn(2, arr));
        }

        [Fact]
        public void EveryElement_ReturnsTrueIfAllPassCondition()
        {
            int[] arr = { 2, 4, 6 };
            Assert.True(ArrayFilters.EveryElement(arr, x => x % 2 == 0));
            Assert.False(ArrayFilters.EveryElement(arr, x => x > 4));
        }
    }
}
