namespace FpFilters.Tests
{
    public class PositionFiltersTests
    {
        [Fact]
        public void IsOddIndex_WorksCorrectly()
        {
            Assert.True(FpFilters.PositionFilters.IsOddIndex(1));
            Assert.False(FpFilters.PositionFilters.IsOddIndex(0));
            Assert.True(FpFilters.PositionFilters.IsOddIndex(3));
        }

        [Fact]
        public void IsEvenIndex_WorksCorrectly()
        {
            Assert.True(FpFilters.PositionFilters.IsEvenIndex(0));
            Assert.False(FpFilters.PositionFilters.IsEvenIndex(1));
            Assert.True(FpFilters.PositionFilters.IsEvenIndex(2));
        }

        [Fact]
        public void IsEveryNthIndex_WorksCorrectly()
        {
            Assert.True(FpFilters.PositionFilters.IsEveryNthIndex(0, 3));
            Assert.False(FpFilters.PositionFilters.IsEveryNthIndex(1, 3));
            Assert.True(FpFilters.PositionFilters.IsEveryNthIndex(3, 3));
            Assert.True(FpFilters.PositionFilters.IsEveryNthIndex(4, 2));
            Assert.True(FpFilters.PositionFilters.IsEveryNthIndex(2, 2));
            Assert.True(FpFilters.PositionFilters.IsEveryNthIndex(5, 5));
            Assert.True(FpFilters.PositionFilters.IsEveryNthIndex(2, 3, 2));
            Assert.False(FpFilters.PositionFilters.IsEveryNthIndex(1, 3, 2));
        }
    }
}
