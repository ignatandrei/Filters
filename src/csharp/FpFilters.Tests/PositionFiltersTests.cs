namespace FpFilters.PositionFilters.Tests
{
    public class PositionFiltersTests
    {
        [Fact]
        public void IsOddIndex_WorksCorrectly()
        {
            Assert.True(PositionFilters.IsOddIndex(1));
            Assert.False(PositionFilters.IsOddIndex(0));
            Assert.True(PositionFilters.IsOddIndex(3));
        }

        [Fact]
        public void IsEvenIndex_WorksCorrectly()
        {
            Assert.True(PositionFilters.IsEvenIndex(0));
            Assert.False(PositionFilters.IsEvenIndex(1));
            Assert.True(PositionFilters.IsEvenIndex(2));
        }

        [Fact]
        public void IsEveryNthIndex_WorksCorrectly()
        {
            Assert.True(PositionFilters.IsEveryNthIndex(0, 3));
            Assert.False(PositionFilters.IsEveryNthIndex(1, 3));
            Assert.True(PositionFilters.IsEveryNthIndex(3, 3));
            Assert.True(PositionFilters.IsEveryNthIndex(4, 2));
            Assert.True(PositionFilters.IsEveryNthIndex(2, 2));
            Assert.True(PositionFilters.IsEveryNthIndex(5, 5));
            Assert.True(PositionFilters.IsEveryNthIndex(2, 3, 2));
            Assert.False(PositionFilters.IsEveryNthIndex(1, 3, 2));
        }
    }
}
