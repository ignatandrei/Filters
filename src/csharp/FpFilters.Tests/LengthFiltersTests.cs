namespace FpFilters.LengthFilters.Tests
{
    public class LengthFiltersTests
    {
        [Fact]
        public void IsEmpty_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.IsEmpty(""));
            Assert.False(LengthFilters.IsEmpty("abc"));
            Assert.True(LengthFilters.IsEmpty(new List<int>()));
            Assert.False(LengthFilters.IsEmpty(new List<int> { 1 }));
        }

        [Fact]
        public void IsNotEmpty_WorksForStringAndCollection()
        {
            Assert.False(LengthFilters.IsNotEmpty(""));
            Assert.True(LengthFilters.IsNotEmpty("abc"));
            Assert.False(LengthFilters.IsNotEmpty(new List<int>()));
            Assert.True(LengthFilters.IsNotEmpty(new List<int> { 1 }));
        }

        [Fact]
        public void HasLength_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasLength("abc", 3));
            Assert.False(LengthFilters.HasLength("abc", 2));
            Assert.True(LengthFilters.HasLength(new List<int> { 1, 2 }, 2));
            Assert.False(LengthFilters.HasLength(new List<int> { 1, 2 }, 3));
        }

        [Fact]
        public void HasLengthMin_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasLengthMin("abc", 2));
            Assert.False(LengthFilters.HasLengthMin("abc", 4));
            Assert.True(LengthFilters.HasLengthMin(new List<int> { 1, 2 }, 2));
            Assert.False(LengthFilters.HasLengthMin(new List<int> { 1, 2 }, 3));
        }

        [Fact]
        public void HasLengthMax_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasLengthMax("abc", 3));
            Assert.True(LengthFilters.HasLengthMax("abc", 4));
            Assert.False(LengthFilters.HasLengthMax("abc", 2));
        }

        [Fact]
        public void HasLengthBetween_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasLengthBetween("abc", 2, 3));
            Assert.False(LengthFilters.HasLengthBetween("abc", 4, 5));
        }

        [Fact]
        public void HasNotLength_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasNotLength("abc", 2));
            Assert.False(LengthFilters.HasNotLength("abc", 3));
        }

        [Fact]
        public void HasNotLengthMin_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasNotLengthMin("abc", 4));
            Assert.False(LengthFilters.HasNotLengthMin("abc", 2));
        }

        [Fact]
        public void HasNotLengthMax_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasNotLengthMax("abc", 2));
            Assert.False(LengthFilters.HasNotLengthMax("abc", 3));
        }

        [Fact]
        public void HasNotLengthBetween_WorksForStringAndCollection()
        {
            Assert.True(LengthFilters.HasNotLengthBetween("abc", 4, 5));
            Assert.False(LengthFilters.HasNotLengthBetween("abc", 2, 3));
        }
    }
}
