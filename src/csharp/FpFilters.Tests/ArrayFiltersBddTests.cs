namespace FpFilters.ArrayFilters.BddTests
{
    [FeatureDescription(
        "ArrayFilters: BDD scenarios for array filter functions.")]
    public class ArrayFiltersFeature : FeatureFixture
    {
        private int[] arr = Array.Empty<int>();
        private bool result;

        private void GivenArray(params int[] values) => arr = values;
        private void WhenIsIncludedIn(int value) => result = FpFilters.ArrayFilters.ArrayFilters.IsIncludedIn(value, arr);
        private void WhenIsNotIncludedIn(int value) => result = FpFilters.ArrayFilters.ArrayFilters.IsNotIncludedIn(value, arr);
        private void WhenEveryElement(Func<int, bool> condition) => result = FpFilters.ArrayFilters.ArrayFilters.EveryElement(arr, condition);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_value_is_included_in_array()
        {
            Runner.RunScenario(
                _ => GivenArray(1, 2, 3),
                _ => WhenIsIncludedIn(2),
                _ => ThenResultShouldBeTrue(),
                _ => WhenIsIncludedIn(4),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_value_is_not_included_in_array()
        {
            Runner.RunScenario(
                _ => GivenArray(1, 2, 3),
                _ => WhenIsNotIncludedIn(4),
                _ => ThenResultShouldBeTrue(),
                _ => WhenIsNotIncludedIn(2),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_every_element_passes_condition()
        {
            Runner.RunScenario(
                _ => GivenArray(2, 4, 6),
                _ => WhenEveryElement(x => x % 2 == 0),
                _ => ThenResultShouldBeTrue(),
                _ => WhenEveryElement(x => x > 4),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
