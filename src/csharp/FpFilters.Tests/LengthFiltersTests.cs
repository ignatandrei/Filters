namespace FpFilters.Tests
{
    public class LengthFiltersTests
    {
        [Fact]
        public void IsEmpty_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.IsEmpty(""));
            Assert.False(FpFilters.LengthFilters.IsEmpty("abc"));
            Assert.True(FpFilters.LengthFilters.IsEmpty(new List<int>()));
            Assert.False(FpFilters.LengthFilters.IsEmpty(new List<int> { 1 }));
        }

        [Fact]
        public void IsNotEmpty_WorksForStringAndCollection()
        {
            Assert.False(FpFilters.LengthFilters.IsNotEmpty(""));
            Assert.True(FpFilters.LengthFilters.IsNotEmpty("abc"));
            Assert.False(FpFilters.LengthFilters.IsNotEmpty(new List<int>()));
            Assert.True(FpFilters.LengthFilters.IsNotEmpty(new List<int> { 1 }));
        }

        [Fact]
        public void HasLength_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasLength("abc", 3));
            Assert.False(FpFilters.LengthFilters.HasLength("abc", 2));
            Assert.True(FpFilters.LengthFilters.HasLength(new List<int> { 1, 2 }, 2));
            Assert.False(FpFilters.LengthFilters.HasLength(new List<int> { 1, 2 }, 3));
        }

        [Fact]
        public void HasLengthMin_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasLengthMin("abc", 2));
            Assert.False(FpFilters.LengthFilters.HasLengthMin("abc", 4));
            Assert.True(FpFilters.LengthFilters.HasLengthMin(new List<int> { 1, 2 }, 2));
            Assert.False(FpFilters.LengthFilters.HasLengthMin(new List<int> { 1, 2 }, 3));
        }

        [Fact]
        public void HasLengthMax_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasLengthMax("abc", 3));
            Assert.True(FpFilters.LengthFilters.HasLengthMax("abc", 4));
            Assert.False(FpFilters.LengthFilters.HasLengthMax("abc", 2));
        }

        [Fact]
        public void HasLengthBetween_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasLengthBetween("abc", 2, 3));
            Assert.False(FpFilters.LengthFilters.HasLengthBetween("abc", 4, 5));
        }

        [Fact]
        public void HasNotLength_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasNotLength("abc", 2));
            Assert.False(FpFilters.LengthFilters.HasNotLength("abc", 3));
        }

        [Fact]
        public void HasNotLengthMin_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasNotLengthMin("abc", 4));
            Assert.False(FpFilters.LengthFilters.HasNotLengthMin("abc", 2));
        }

        [Fact]
        public void HasNotLengthMax_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasNotLengthMax("abc", 2));
            Assert.False(FpFilters.LengthFilters.HasNotLengthMax("abc", 3));
        }

        [Fact]
        public void HasNotLengthBetween_WorksForStringAndCollection()
        {
            Assert.True(FpFilters.LengthFilters.HasNotLengthBetween("abc", 4, 5));
            Assert.False(FpFilters.LengthFilters.HasNotLengthBetween("abc", 2, 3));
        }
    }
}
