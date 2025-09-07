namespace FpFilters.MiscFilters.Tests
{
    public class MiscFiltersTests
    {
        [Fact]
        public void Is_ReturnsTrueForEqual()
        {
            Assert.True(MiscFilters.Is(5, 5));
            Assert.True(MiscFilters.Is("abc", "abc"));
            Assert.False(MiscFilters.Is(5, 6));
        }

        [Fact]
        public void IsNot_ReturnsTrueForNotEqual()
        {
            Assert.True(MiscFilters.IsNot(5, 6));
            Assert.False(MiscFilters.IsNot(5, 5));
        }

        [Fact]
        public void All_ReturnsTrue()
        {
            Assert.True(MiscFilters.All());
        }

        [Fact]
        public void None_ReturnsFalse()
        {
            Assert.False(MiscFilters.None());
        }
    }
}
