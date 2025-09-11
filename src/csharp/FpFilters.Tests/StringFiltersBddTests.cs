namespace FpFilters.StringFilters.BddTests
{
    [FeatureDescription("StringFilters: BDD scenarios for string filter functions.")]
    public class StringFiltersFeature : FeatureFixture
    {
        private string? arg;
        private string? comparison;
        private bool result;

        private void GivenString(string value) => arg = value;
        private void GivenComparison(string value) => comparison = value;
        private void WhenStartsWith() => result = FpFilters.StringFilters.StringFilters.StartsWith(arg, comparison!);
        private void WhenEndsWith() => result = FpFilters.StringFilters.StringFilters.EndsWith(arg, comparison!);
        private void WhenIncludes() => result = FpFilters.StringFilters.StringFilters.Includes(arg, comparison!);
        private void WhenIsEmptyString() => result = FpFilters.StringFilters.StringFilters.IsEmptyString(arg);
        private void WhenIsEmptyStringTrim() => result = FpFilters.StringFilters.StringFilters.IsEmptyStringTrim(arg);
        private void WhenIsLowerCase() => result = FpFilters.StringFilters.StringFilters.IsLowerCase(arg);
        private void WhenIsUpperCase() => result = FpFilters.StringFilters.StringFilters.IsUpperCase(arg);
        private void WhenIsMixedCase() => result = FpFilters.StringFilters.StringFilters.IsMixedCase(arg);
        private void WhenIsUniformCase() => result = FpFilters.StringFilters.StringFilters.IsUniformCase(arg);
        private void WhenIsTrimmable() => result = FpFilters.StringFilters.StringFilters.IsTrimmable(arg);
        private void WhenIsPalindrome() => result = FpFilters.StringFilters.StringFilters.IsPalindrome(arg);
        private void WhenMatches(string pattern) => result = FpFilters.StringFilters.StringFilters.Matches(arg, pattern);
        private void WhenDoesNotMatch(string pattern) => result = FpFilters.StringFilters.StringFilters.DoesNotMatch(arg, pattern);
        private void WhenIsEmail() => result = FpFilters.StringFilters.StringFilters.IsEmail(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_string_starts_with_substring()
        {
            Runner.RunScenario(
                _ => GivenString("hello world"),
                _ => GivenComparison("hello"),
                _ => WhenStartsWith(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenComparison("world"),
                _ => WhenStartsWith(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_ends_with_substring()
        {
            Runner.RunScenario(
                _ => GivenString("hello world"),
                _ => GivenComparison("world"),
                _ => WhenEndsWith(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenComparison("hello"),
                _ => WhenEndsWith(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_includes_substring()
        {
            Runner.RunScenario(
                _ => GivenString("hello world"),
                _ => GivenComparison("lo wo"),
                _ => WhenIncludes(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenComparison("test"),
                _ => WhenIncludes(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_empty()
        {
            Runner.RunScenario(
                _ => GivenString(""),
                _ => WhenIsEmptyString(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("not empty"),
                _ => WhenIsEmptyString(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_trimmed_string_is_empty()
        {
            Runner.RunScenario(
                _ => GivenString("   "),
                _ => WhenIsEmptyStringTrim(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("not empty"),
                _ => WhenIsEmptyStringTrim(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_lower_case()
        {
            Runner.RunScenario(
                _ => GivenString("abc"),
                _ => WhenIsLowerCase(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("Abc"),
                _ => WhenIsLowerCase(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_upper_case()
        {
            Runner.RunScenario(
                _ => GivenString("ABC"),
                _ => WhenIsUpperCase(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("Abc"),
                _ => WhenIsUpperCase(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_mixed_case()
        {
            Runner.RunScenario(
                _ => GivenString("Abc"),
                _ => WhenIsMixedCase(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenIsMixedCase(),
                _ => ThenResultShouldBeFalse(),
                _ => GivenString("ABC"),
                _ => WhenIsMixedCase(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_uniform_case()
        {
            Runner.RunScenario(
                _ => GivenString("abc"),
                _ => WhenIsUniformCase(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("ABC"),
                _ => WhenIsUniformCase(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("Abc"),
                _ => WhenIsUniformCase(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_trimmable()
        {
            Runner.RunScenario(
                _ => GivenString(" abc "),
                _ => WhenIsTrimmable(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenIsTrimmable(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_palindrome()
        {
            Runner.RunScenario(
                _ => GivenString("madam"),
                _ => WhenIsPalindrome(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("hello"),
                _ => WhenIsPalindrome(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_matches_pattern()
        {
            Runner.RunScenario(
                _ => GivenString("abc123"),
                _ => WhenMatches("[a-z]+[0-9]+"),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenMatches("[0-9]+"),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_does_not_match_pattern()
        {
            Runner.RunScenario(
                _ => GivenString("abc"),
                _ => WhenDoesNotMatch("[0-9]+"),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc123"),
                _ => WhenDoesNotMatch("[a-z]+[0-9]+"),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_is_email()
        {
            Runner.RunScenario(
                _ => GivenString("test@example.com"),
                _ => WhenIsEmail(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("not-an-email"),
                _ => WhenIsEmail(),
                _ => ThenResultShouldBeFalse()
            );
        }

        private void WhenStartsWithLinq(string substring) => result = FpFilters.StringFilters.StringFilters.StartsWith(substring)(arg);
        private void WhenEndsWithLinq(string substring) => result = FpFilters.StringFilters.StringFilters.EndsWith(substring)(arg);
        private void WhenIncludesLinq(string substring) => result = FpFilters.StringFilters.StringFilters.Includes(substring)(arg);
        private void WhenMatchesLinq(string pattern, string value) => result = FpFilters.StringFilters.StringFilters.Matches(pattern)(value);
        private void WhenDoesNotMatchLinq(string pattern, string value) => result = FpFilters.StringFilters.StringFilters.DoesNotMatch(pattern)(value);

        [Scenario]
        public void Should_support_linq_overloads_for_two_arg_functions()
        {
            Runner.RunScenario(
                _ => GivenString("hello world"),
                _ => WhenStartsWithLinq("hello"),
                _ => ThenResultShouldBeTrue(),
                _ => WhenEndsWithLinq("world"),
                _ => ThenResultShouldBeTrue(),
                _ => WhenIncludesLinq("lo wo"),
                _ => ThenResultShouldBeTrue(),
                _ => WhenMatchesLinq("[a-z]+[0-9]+", "abc123"),
                _ => ThenResultShouldBeTrue(),
                _ => WhenDoesNotMatchLinq("[0-9]+", "abc"),
                _ => ThenResultShouldBeTrue()
            );
        }
    }
}
