namespace FpFilters.Tests
{
    public class StringFiltersTests
    {
        [Fact]
        public void StartsWith_ReturnsTrueForPrefix()
        {
            Assert.True(FpFilters.StringFilters.StartsWith("hello world", "hello"));
            Assert.False(FpFilters.StringFilters.StartsWith("hello world", "world"));
        }

        [Fact]
        public void EndsWith_ReturnsTrueForSuffix()
        {
            Assert.True(FpFilters.StringFilters.EndsWith("hello world", "world"));
            Assert.False(FpFilters.StringFilters.EndsWith("hello world", "hello"));
        }

        [Fact]
        public void Includes_ReturnsTrueForSubstring()
        {
            Assert.True(FpFilters.StringFilters.Includes("hello world", "lo wo"));
            Assert.False(FpFilters.StringFilters.Includes("hello world", "test"));
        }

        [Fact]
        public void IsEmptyString_ReturnsTrueForEmpty()
        {
            Assert.True(FpFilters.StringFilters.IsEmptyString(""));
            Assert.False(FpFilters.StringFilters.IsEmptyString("not empty"));
        }

        [Fact]
        public void IsEmptyStringTrim_ReturnsTrueForWhitespace()
        {
            Assert.True(FpFilters.StringFilters.IsEmptyStringTrim("   "));
            Assert.False(FpFilters.StringFilters.IsEmptyStringTrim("not empty"));
        }

        [Fact]
        public void IsLowerCase_ReturnsTrueForLower()
        {
            Assert.True(FpFilters.StringFilters.IsLowerCase("abc"));
            Assert.False(FpFilters.StringFilters.IsLowerCase("Abc"));
        }

        [Fact]
        public void IsUpperCase_ReturnsTrueForUpper()
        {
            Assert.True(FpFilters.StringFilters.IsUpperCase("ABC"));
            Assert.False(FpFilters.StringFilters.IsUpperCase("Abc"));
        }

        [Fact]
        public void IsMixedCase_ReturnsTrueForMixed()
        {
            Assert.True(FpFilters.StringFilters.IsMixedCase("Abc"));
            Assert.False(FpFilters.StringFilters.IsMixedCase("abc"));
            Assert.False(FpFilters.StringFilters.IsMixedCase("ABC"));
        }

        [Fact]
        public void IsUniformCase_ReturnsTrueForUniform()
        {
            Assert.True(FpFilters.StringFilters.IsUniformCase("abc"));
            Assert.True(FpFilters.StringFilters.IsUniformCase("ABC"));
            Assert.False(FpFilters.StringFilters.IsUniformCase("Abc"));
        }

        [Fact]
        public void IsTrimmable_ReturnsTrueForTrimmable()
        {
            Assert.True(FpFilters.StringFilters.IsTrimmable(" abc "));
            Assert.False(FpFilters.StringFilters.IsTrimmable("abc"));
        }

        [Fact]
        public void IsPalindrome_ReturnsTrueForPalindrome()
        {
            Assert.True(FpFilters.StringFilters.IsPalindrome("madam"));
            Assert.False(FpFilters.StringFilters.IsPalindrome("hello"));
        }

        [Fact]
        public void Matches_ReturnsTrueForPattern()
        {
            Assert.True(FpFilters.StringFilters.Matches("abc123", "[a-z]+[0-9]+"));
            Assert.False(FpFilters.StringFilters.Matches("abc", "[0-9]+"));
        }

        [Fact]
        public void DoesNotMatch_ReturnsTrueForNonMatch()
        {
            Assert.True(FpFilters.StringFilters.DoesNotMatch("abc", "[0-9]+"));
            Assert.False(FpFilters.StringFilters.DoesNotMatch("abc123", "[a-z]+[0-9]+"));
        }

        [Fact]
        public void IsEmail_ReturnsTrueForValidEmail()
        {
            Assert.True(FpFilters.StringFilters.IsEmail("test@example.com"));
            Assert.False(FpFilters.StringFilters.IsEmail("not-an-email"));
        }

        [Fact]
        public void AllMethods_HandleNullInput()
        {
            Assert.False(FpFilters.StringFilters.StartsWith(null, "x"));
            Assert.False(FpFilters.StringFilters.EndsWith(null, "x"));
            Assert.False(FpFilters.StringFilters.Includes(null, "x"));
            Assert.False(FpFilters.StringFilters.IsEmptyString(null));
            Assert.False(FpFilters.StringFilters.IsEmptyStringTrim(null));
            Assert.False(FpFilters.StringFilters.IsLowerCase(null));
            Assert.False(FpFilters.StringFilters.IsUpperCase(null));
            Assert.False(FpFilters.StringFilters.IsMixedCase(null));
            Assert.False(FpFilters.StringFilters.IsUniformCase(null));
            Assert.False(FpFilters.StringFilters.IsTrimmable(null));
            Assert.False(FpFilters.StringFilters.IsTrimmableStart(null));
            Assert.False(FpFilters.StringFilters.IsTrimmableEnd(null));
            Assert.False(FpFilters.StringFilters.IsPalindrome(null));
            Assert.False(FpFilters.StringFilters.Matches(null, "x"));
            Assert.True(FpFilters.StringFilters.DoesNotMatch(null, "x"));
            Assert.False(FpFilters.StringFilters.IsEmail(null));
        }

        [Fact]
        public void IsTrimmableStartAndEnd_Tests()
        {
            Assert.True(FpFilters.StringFilters.IsTrimmableStart(" abc"));
            Assert.False(FpFilters.StringFilters.IsTrimmableStart("abc "));
            Assert.False(FpFilters.StringFilters.IsTrimmableStart("abc"));
            Assert.True(FpFilters.StringFilters.IsTrimmableEnd("abc "));
            Assert.False(FpFilters.StringFilters.IsTrimmableEnd(" abc"));
            Assert.False(FpFilters.StringFilters.IsTrimmableEnd("abc"));
            Assert.False(FpFilters.StringFilters.IsTrimmableStart(""));
            Assert.False(FpFilters.StringFilters.IsTrimmableEnd(""));
            Assert.True(FpFilters.StringFilters.IsTrimmableStart("   "));
            Assert.True(FpFilters.StringFilters.IsTrimmableEnd("   "));
        }
    }
}
