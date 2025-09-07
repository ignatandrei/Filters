namespace FpFilters.StringFilters.Tests
{
    public class StringFiltersTests
    {
        [Fact]
        public void StartsWith_ReturnsTrueForPrefix()
        {
            Assert.True(StringFilters.StartsWith("hello world", "hello"));
            Assert.False(StringFilters.StartsWith("hello world", "world"));
        }

        [Fact]
        public void EndsWith_ReturnsTrueForSuffix()
        {
            Assert.True(StringFilters.EndsWith("hello world", "world"));
            Assert.False(StringFilters.EndsWith("hello world", "hello"));
        }

        [Fact]
        public void Includes_ReturnsTrueForSubstring()
        {
            Assert.True(StringFilters.Includes("hello world", "lo wo"));
            Assert.False(StringFilters.Includes("hello world", "test"));
        }

        [Fact]
        public void IsEmptyString_ReturnsTrueForEmpty()
        {
            Assert.True(StringFilters.IsEmptyString(""));
            Assert.False(StringFilters.IsEmptyString("not empty"));
        }

        [Fact]
        public void IsEmptyStringTrim_ReturnsTrueForWhitespace()
        {
            Assert.True(StringFilters.IsEmptyStringTrim("   "));
            Assert.False(StringFilters.IsEmptyStringTrim("not empty"));
        }

        [Fact]
        public void IsLowerCase_ReturnsTrueForLower()
        {
            Assert.True(StringFilters.IsLowerCase("abc"));
            Assert.False(StringFilters.IsLowerCase("Abc"));
        }

        [Fact]
        public void IsUpperCase_ReturnsTrueForUpper()
        {
            Assert.True(StringFilters.IsUpperCase("ABC"));
            Assert.False(StringFilters.IsUpperCase("Abc"));
        }

        [Fact]
        public void IsMixedCase_ReturnsTrueForMixed()
        {
            Assert.True(StringFilters.IsMixedCase("Abc"));
            Assert.False(StringFilters.IsMixedCase("abc"));
            Assert.False(StringFilters.IsMixedCase("ABC"));
        }

        [Fact]
        public void IsUniformCase_ReturnsTrueForUniform()
        {
            Assert.True(StringFilters.IsUniformCase("abc"));
            Assert.True(StringFilters.IsUniformCase("ABC"));
            Assert.False(StringFilters.IsUniformCase("Abc"));
        }

        [Fact]
        public void IsTrimmable_ReturnsTrueForTrimmable()
        {
            Assert.True(StringFilters.IsTrimmable(" abc "));
            Assert.False(StringFilters.IsTrimmable("abc"));
        }

        [Fact]
        public void IsPalindrome_ReturnsTrueForPalindrome()
        {
            Assert.True(StringFilters.IsPalindrome("madam"));
            Assert.False(StringFilters.IsPalindrome("hello"));
        }

        [Fact]
        public void Matches_ReturnsTrueForPattern()
        {
            Assert.True(StringFilters.Matches("abc123", "[a-z]+[0-9]+"));
            Assert.False(StringFilters.Matches("abc", "[0-9]+"));
        }

        [Fact]
        public void DoesNotMatch_ReturnsTrueForNonMatch()
        {
            Assert.True(StringFilters.DoesNotMatch("abc", "[0-9]+"));
            Assert.False(StringFilters.DoesNotMatch("abc123", "[a-z]+[0-9]+"));
        }

        [Fact]
        public void IsEmail_ReturnsTrueForValidEmail()
        {
            Assert.True(StringFilters.IsEmail("test@example.com"));
            Assert.False(StringFilters.IsEmail("not-an-email"));
        }

        [Fact]
        public void AllMethods_HandleNullInput()
        {
            Assert.False(StringFilters.StartsWith(null, "x"));
            Assert.False(StringFilters.EndsWith(null, "x"));
            Assert.False(StringFilters.Includes(null, "x"));
            Assert.False(StringFilters.IsEmptyString(null));
            Assert.False(StringFilters.IsEmptyStringTrim(null));
            Assert.False(StringFilters.IsLowerCase(null));
            Assert.False(StringFilters.IsUpperCase(null));
            Assert.False(StringFilters.IsMixedCase(null));
            Assert.False(StringFilters.IsUniformCase(null));
            Assert.False(StringFilters.IsTrimmable(null));
            Assert.False(StringFilters.IsTrimmableStart(null));
            Assert.False(StringFilters.IsTrimmableEnd(null));
            Assert.False(StringFilters.IsPalindrome(null));
            Assert.False(StringFilters.Matches(null, "x"));
            Assert.True(StringFilters.DoesNotMatch(null, "x"));
            Assert.False(StringFilters.IsEmail(null));
        }

        [Fact]
        public void IsTrimmableStartAndEnd_Tests()
        {
            Assert.True(StringFilters.IsTrimmableStart(" abc"));
            Assert.False(StringFilters.IsTrimmableStart("abc "));
            Assert.False(StringFilters.IsTrimmableStart("abc"));
            Assert.True(StringFilters.IsTrimmableEnd("abc "));
            Assert.False(StringFilters.IsTrimmableEnd(" abc"));
            Assert.False(StringFilters.IsTrimmableEnd("abc"));
            Assert.False(StringFilters.IsTrimmableStart(""));
            Assert.False(StringFilters.IsTrimmableEnd(""));
            Assert.True(StringFilters.IsTrimmableStart("   "));
            Assert.True(StringFilters.IsTrimmableEnd("   "));
        }
    }
}
