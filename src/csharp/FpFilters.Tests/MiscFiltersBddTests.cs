namespace FpFilters.MiscFilters.BddTests
{
    [FeatureDescription("MiscFilters: BDD scenarios for miscellaneous filter functions.")]
    public class MiscFiltersFeature : FeatureFixture
    {
        private object? arg;
        private bool result;

        private void GivenValue(object value) => arg = value;
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
    }
}
