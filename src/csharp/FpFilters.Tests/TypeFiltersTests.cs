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

        [Fact]
        public void IsNotMethods_Coverage()
        {
            Assert.False(TypeFilters.IsNotUndefined(null));
            Assert.True(TypeFilters.IsNotUndefined("abc"));
            Assert.False(TypeFilters.IsNotString("abc"));
            Assert.True(TypeFilters.IsNotString(123));
            Assert.False(TypeFilters.IsNotNumber(123));
            Assert.True(TypeFilters.IsNotNumber("abc"));
            Assert.False(TypeFilters.IsNotObject(new object()));
            Assert.True(TypeFilters.IsNotObject(123));
            Assert.True(TypeFilters.IsNotNull("abc"));
            Assert.False(TypeFilters.IsNotNull(null));
            Assert.False(TypeFilters.IsNotBoolean(true));
            Assert.True(TypeFilters.IsNotBoolean("abc"));
            Assert.False(TypeFilters.IsNotDate(System.DateTime.Now));
            Assert.True(TypeFilters.IsNotDate("abc"));
            Assert.False(TypeFilters.IsNotArray(new int[] { 1 }));
            Assert.True(TypeFilters.IsNotArray("abc"));
        }

        [Fact]
        public void IsSameTypeAs_And_NotSameTypeAs_Coverage()
        {
            Assert.True(TypeFilters.IsSameTypeAs("abc", "def"));
            Assert.False(TypeFilters.IsSameTypeAs("abc", 123));
            Assert.True(TypeFilters.IsNotSameTypeAs("abc", 123));
            Assert.False(TypeFilters.IsNotSameTypeAs("abc", "def"));
            Assert.False(TypeFilters.IsSameTypeAs(null, "def"));
            Assert.True(TypeFilters.IsNotSameTypeAs(null, "def"));
        }

        [Fact]
        public void IsOfType_And_IsNotOfType_Coverage()
        {
            Assert.True(TypeFilters.IsOfType("abc", typeof(string)));
            Assert.False(TypeFilters.IsOfType(123, typeof(string)));
            Assert.False(TypeFilters.IsOfType(null, typeof(string)));
            Assert.False(TypeFilters.IsNotOfType("abc", typeof(string)));
            Assert.True(TypeFilters.IsNotOfType(123, typeof(string)));
            Assert.True(TypeFilters.IsNotOfType(null, typeof(string)));
        }

        [Fact]
        public void IsInstanceOf_Coverage()
        {
            Assert.True(TypeFilters.IsInstanceOf<string>("abc"));
            Assert.False(TypeFilters.IsInstanceOf<int>("abc"));
            Assert.False(TypeFilters.IsInstanceOf<string>(null));
        }

        // Additional tests for Not* and SameTypeAs, etc. can be added similarly
    }
}
