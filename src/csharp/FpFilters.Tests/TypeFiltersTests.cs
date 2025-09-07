using Xunit;

namespace FpFilters.TypeFilters.Tests
{
    public class TypeFiltersTests
    {
        [Fact]
        public void IsUndefined_ReturnsTrueForNull()
        {
            Assert.True(TypeFilters.IsUndefined(null));
        }

        [Fact]
        public void IsString_ReturnsTrueForString()
        {
            Assert.True(TypeFilters.IsString("hello"));
            Assert.False(TypeFilters.IsString(123));
        }

        [Fact]
        public void IsNumber_ReturnsTrueForNumbers()
        {
            Assert.True(TypeFilters.IsNumber(123));
            Assert.True(TypeFilters.IsNumber(123.45));
            Assert.False(TypeFilters.IsNumber("123"));
        }

        [Fact]
        public void IsObject_ReturnsTrueForObject()
        {
            Assert.True(TypeFilters.IsObject(new object()));
            Assert.False(TypeFilters.IsObject(123));
            Assert.False(TypeFilters.IsObject("string"));
        }

        [Fact]
        public void IsNull_ReturnsTrueForNull()
        {
            Assert.True(TypeFilters.IsNull(null));
            Assert.False(TypeFilters.IsNull("not null"));
        }

        [Fact]
        public void IsBoolean_ReturnsTrueForBool()
        {
            Assert.True(TypeFilters.IsBoolean(true));
            Assert.True(TypeFilters.IsBoolean(false));
            Assert.False(TypeFilters.IsBoolean("true"));
        }

        [Fact]
        public void IsDate_ReturnsTrueForDateTime()
        {
            Assert.True(TypeFilters.IsDate(System.DateTime.Now));
            Assert.False(TypeFilters.IsDate("2025-09-07"));
        }

        [Fact]
        public void IsArray_ReturnsTrueForArray()
        {
            Assert.True(TypeFilters.IsArray(new int[] { 1, 2, 3 }));
            Assert.False(TypeFilters.IsArray("array"));
        }

        // Additional tests for Not* and SameTypeAs, etc. can be added similarly
    }
}
