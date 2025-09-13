namespace FpFilters.MiscFilters.BddTests
{
    [FeatureDescription("MiscFilters: BDD scenarios for miscellaneous filter functions.")]
    public class MiscFiltersFeature : FeatureFixture
    {
        private object? arg;
        private bool result;

        private void GivenValue(object? value) => arg = value;
        private void WhenIsNullOrDefault() => result = FpFilters.MiscFilters.MiscFilters.IsNullOrDefault(arg);
        private void WhenIsNotNullOrDefault() => result = FpFilters.MiscFilters.MiscFilters.IsNotNullOrDefault(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_value_is_null_or_default()
        {
            Runner.RunScenario(
                _ => GivenValue(null),
                _ => WhenIsNullOrDefault(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenValue(0),
                _ => WhenIsNullOrDefault(),
                _ => ThenResultShouldBeFalse(), // 0 is not null for reference types
                _ => GivenValue(1),
                _ => WhenIsNullOrDefault(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_value_is_not_null_or_default()
        {
            Runner.RunScenario(
                _ => GivenValue(1),
                _ => WhenIsNotNullOrDefault(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenValue(null),
                _ => WhenIsNotNullOrDefault(),
                _ => ThenResultShouldBeFalse(),
                _ => GivenValue(0),
                _ => WhenIsNotNullOrDefault(),
                _ => ThenResultShouldBeTrue() // 0 is not null for reference types
            );
        }

        [Scenario]
        public void Should_check_Is_linq()
        {
            // Use local variables for generic delegate and argument
            var is42 = FpFilters.MiscFilters.MiscFilters.Is(42);
            Xunit.Assert.True(is42(42));
            Xunit.Assert.False(is42(43));
            var isStr = FpFilters.MiscFilters.MiscFilters.Is("abc");
            Xunit.Assert.True(isStr("abc"));
            Xunit.Assert.False(isStr("def"));
        }

        [Scenario]
        public void Should_check_IsNot_linq()
        {
            // Use local variables for generic delegate and argument
            var isNot42 = FpFilters.MiscFilters.MiscFilters.IsNot(42);
            Xunit.Assert.True(isNot42(43));
            Xunit.Assert.False(isNot42(42));
            var isNotStr = FpFilters.MiscFilters.MiscFilters.IsNot("abc");
            Xunit.Assert.True(isNotStr("def"));
            Xunit.Assert.False(isNotStr("abc"));
        }
    }
}
