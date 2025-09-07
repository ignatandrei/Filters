namespace FpFilters.PositionFilters.BddTests
{
    [FeatureDescription("PositionFilters: BDD scenarios for position filter functions.")]
    public class PositionFiltersFeature : FeatureFixture
    {
        private int arg;
        private int comparison;
        private bool result;

        private void GivenPosition(int value) => arg = value;
        private void GivenComparison(int value) => comparison = value;
        private void WhenIsFirst() => result = FpFilters.PositionFilters.PositionFilters.IsFirst(arg);
        private void WhenIsLast(int length) => result = FpFilters.PositionFilters.PositionFilters.IsLast(arg, length);
        private void WhenIsMiddle(int length) => result = FpFilters.PositionFilters.PositionFilters.IsMiddle(arg, length);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_position_is_first()
        {
            Runner.RunScenario(
                _ => GivenPosition(0),
                _ => WhenIsFirst(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenPosition(1),
                _ => WhenIsFirst(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_position_is_last()
        {
            Runner.RunScenario(
                _ => GivenPosition(4),
                _ => WhenIsLast(5),
                _ => ThenResultShouldBeTrue(),
                _ => GivenPosition(3),
                _ => WhenIsLast(5),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_position_is_middle()
        {
            Runner.RunScenario(
                _ => GivenPosition(2),
                _ => WhenIsMiddle(5),
                _ => ThenResultShouldBeTrue(),
                _ => GivenPosition(0),
                _ => WhenIsMiddle(5),
                _ => ThenResultShouldBeFalse(),
                _ => GivenPosition(4),
                _ => WhenIsMiddle(5),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
