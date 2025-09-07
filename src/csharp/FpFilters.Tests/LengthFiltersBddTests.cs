using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System;

namespace FpFilters.LengthFilters.BddTests
{
    [FeatureDescription("LengthFilters: BDD scenarios for length filter functions.")]
    public class LengthFiltersFeature : FeatureFixture
    {
        private string? arg;
        private int comparison;
        private bool result;

        private void GivenString(string value) => arg = value;
        private void GivenComparison(int value) => comparison = value;
        private void WhenIsLengthEqualTo() => result = FpFilters.LengthFilters.LengthFilters.IsLengthEqualTo(arg, comparison);
        private void WhenIsLengthGreaterThan() => result = FpFilters.LengthFilters.LengthFilters.IsLengthGreaterThan(arg, comparison);
        private void WhenIsLengthLessThan() => result = FpFilters.LengthFilters.LengthFilters.IsLengthLessThan(arg, comparison);
        private void WhenIsLengthZero() => result = FpFilters.LengthFilters.LengthFilters.IsLengthZero(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_string_length_is_equal_to_comparison()
        {
            Runner.RunScenario(
                _ => GivenString("abc"),
                _ => GivenComparison(3),
                _ => WhenIsLengthEqualTo(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenComparison(2),
                _ => WhenIsLengthEqualTo(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_length_is_greater_than_comparison()
        {
            Runner.RunScenario(
                _ => GivenString("abcd"),
                _ => GivenComparison(3),
                _ => WhenIsLengthGreaterThan(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenComparison(4),
                _ => WhenIsLengthGreaterThan(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_length_is_less_than_comparison()
        {
            Runner.RunScenario(
                _ => GivenString("ab"),
                _ => GivenComparison(3),
                _ => WhenIsLengthLessThan(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenComparison(2),
                _ => WhenIsLengthLessThan(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_string_length_is_zero()
        {
            Runner.RunScenario(
                _ => GivenString(""),
                _ => WhenIsLengthZero(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenIsLengthZero(),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
