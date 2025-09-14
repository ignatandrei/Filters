namespace FpFilters.Tests
{
    public class MiscFiltersTests
    {
        [Fact]
        public void Is_ReturnsTrueForEqual()
        {
            Assert.True(FpFilters.MiscFilters.Is(5, 5));
            Assert.True(FpFilters.MiscFilters.Is("abc", "abc"));
            Assert.False(FpFilters.MiscFilters.Is(5, 6));
        }

        [Fact]
        public void IsNot_ReturnsTrueForNotEqual()
        {
            Assert.True(FpFilters.MiscFilters.IsNot(5, 6));
            Assert.False(FpFilters.MiscFilters.IsNot(5, 5));
        }

        [Fact]
        public void All_ReturnsTrue()
        {
            Assert.True(FpFilters.MiscFilters.All());
        }

        [Fact]
        public void None_ReturnsFalse()
        {
            Assert.False(FpFilters.MiscFilters.None());
        }
    }
}
