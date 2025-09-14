namespace FpFilters.Tests
{
    public class ArrayFiltersTests
    {
        [Fact]
        public void IsIncludedIn_ReturnsTrueIfIncluded()
        {
            int[] arr = { 1, 2, 3 };
            Assert.True(FpFilters.ArrayFilters.IsIncludedIn(2, arr));
            Assert.False(FpFilters.ArrayFilters.IsIncludedIn(4, arr));
        }

        [Fact]
        public void IsNotIncludedIn_ReturnsTrueIfNotIncluded()
        {
            int[] arr = { 1, 2, 3 };
            Assert.True(FpFilters.ArrayFilters.IsNotIncludedIn(4, arr));
            Assert.False(FpFilters.ArrayFilters.IsNotIncludedIn(2, arr));
        }

        [Fact]
        public void EveryElement_ReturnsTrueIfAllPassCondition()
        {
            int[] arr = { 2, 4, 6 };
            Assert.True(FpFilters.ArrayFilters.EveryElement(arr, x => x % 2 == 0));
            Assert.False(FpFilters.ArrayFilters.EveryElement(arr, x => x > 4));
        }
    }
}
