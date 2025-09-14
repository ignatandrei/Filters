namespace FpFilters.Tests
{
    public class TypeFiltersTests
    {
        [Fact]
        public void IsUndefined_ReturnsTrueForNull()
        {
            Assert.True(FpFilters.TypeFilters.IsUndefined(null));
        }

        [Fact]
        public void IsString_ReturnsTrueForString()
        {
            Assert.True(FpFilters.TypeFilters.IsString("hello"));
            Assert.False(FpFilters.TypeFilters.IsString(123));
        }

        [Fact]
        public void IsNumber_ReturnsTrueForNumbers()
        {
            Assert.True(FpFilters.TypeFilters.IsNumber(123));
            Assert.True(FpFilters.TypeFilters.IsNumber(123.45));
            Assert.False(FpFilters.TypeFilters.IsNumber("123"));
        }

        [Fact]
        public void IsObject_ReturnsTrueForObject()
        {
            Assert.True(FpFilters.TypeFilters.IsObject(new object()));
            Assert.False(FpFilters.TypeFilters.IsObject(123));
            Assert.False(FpFilters.TypeFilters.IsObject("string"));
        }

        [Fact]
        public void IsNull_ReturnsTrueForNull()
        {
            Assert.True(FpFilters.TypeFilters.IsNull(null));
            Assert.False(FpFilters.TypeFilters.IsNull("not null"));
        }

        [Fact]
        public void IsBoolean_ReturnsTrueForBool()
        {
            Assert.True(FpFilters.TypeFilters.IsBoolean(true));
            Assert.True(FpFilters.TypeFilters.IsBoolean(false));
            Assert.False(FpFilters.TypeFilters.IsBoolean("true"));
        }

        [Fact]
        public void IsDate_ReturnsTrueForDateTime()
        {
            Assert.True(FpFilters.TypeFilters.IsDate(System.DateTime.Now));
            Assert.False(FpFilters.TypeFilters.IsDate("2025-09-07"));
        }

        [Fact]
        public void IsArray_ReturnsTrueForArray()
        {
            Assert.True(FpFilters.TypeFilters.IsArray(new int[] { 1, 2, 3 }));
            Assert.False(FpFilters.TypeFilters.IsArray("array"));
        }

        [Fact]
        public void IsNotMethods_Coverage()
        {
            Assert.False(FpFilters.TypeFilters.IsNotUndefined(null));
            Assert.True(FpFilters.TypeFilters.IsNotUndefined("abc"));
            Assert.False(FpFilters.TypeFilters.IsNotString("abc"));
            Assert.True(FpFilters.TypeFilters.IsNotString(123));
            Assert.False(FpFilters.TypeFilters.IsNotNumber(123));
            Assert.True(FpFilters.TypeFilters.IsNotNumber("abc"));
            Assert.False(FpFilters.TypeFilters.IsNotObject(new object()));
            Assert.True(FpFilters.TypeFilters.IsNotObject(123));
            Assert.True(FpFilters.TypeFilters.IsNotNull("abc"));
            Assert.False(FpFilters.TypeFilters.IsNotNull(null));
            Assert.False(FpFilters.TypeFilters.IsNotBoolean(true));
            Assert.True(FpFilters.TypeFilters.IsNotBoolean("abc"));
            Assert.False(FpFilters.TypeFilters.IsNotDate(System.DateTime.Now));
            Assert.True(FpFilters.TypeFilters.IsNotDate("abc"));
            Assert.False(FpFilters.TypeFilters.IsNotArray(new int[] { 1 }));
            Assert.True(FpFilters.TypeFilters.IsNotArray("abc"));
        }

        [Fact]
        public void IsSameTypeAs_And_NotSameTypeAs_Coverage()
        {
            Assert.True(FpFilters.TypeFilters.IsSameTypeAs("abc", "def"));
            Assert.False(FpFilters.TypeFilters.IsSameTypeAs("abc", 123));
            Assert.True(FpFilters.TypeFilters.IsNotSameTypeAs("abc", 123));
            Assert.False(FpFilters.TypeFilters.IsNotSameTypeAs("abc", "def"));
            Assert.False(FpFilters.TypeFilters.IsSameTypeAs(null, "def"));
            Assert.True(FpFilters.TypeFilters.IsNotSameTypeAs(null, "def"));
        }

        [Fact]
        public void IsOfType_And_IsNotOfType_Coverage()
        {
            Assert.True(FpFilters.TypeFilters.IsOfType("abc", typeof(string)));
            Assert.False(FpFilters.TypeFilters.IsOfType(123, typeof(string)));
            Assert.False(FpFilters.TypeFilters.IsOfType(null, typeof(string)));
            Assert.False(FpFilters.TypeFilters.IsNotOfType("abc", typeof(string)));
            Assert.True(FpFilters.TypeFilters.IsNotOfType(123, typeof(string)));
            Assert.True(FpFilters.TypeFilters.IsNotOfType(null, typeof(string)));
        }

        [Fact]
        public void IsInstanceOf_Coverage()
        {
            Assert.True(FpFilters.TypeFilters.IsInstanceOf<string>("abc"));
            Assert.False(FpFilters.TypeFilters.IsInstanceOf<int>("abc"));
            Assert.False(FpFilters.TypeFilters.IsInstanceOf<string>(null));
        }

        // Additional tests for Not* and SameTypeAs, etc. can be added similarly
    }
}
