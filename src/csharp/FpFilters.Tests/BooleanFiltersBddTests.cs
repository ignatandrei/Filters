using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System;

namespace FpFilters.BooleanFilters.BddTests
{
    [FeatureDescription("BooleanFilters: BDD scenarios for boolean filter functions.")]
    public class BooleanFiltersFeature : FeatureFixture
    {
        private bool arg;
        private bool result;

        private void GivenBool(bool value) => arg = value;
        private void WhenIsTrue() => result = FpFilters.BooleanFilters.BooleanFilters.IsTrue(arg);
        private void WhenIsFalse() => result = FpFilters.BooleanFilters.BooleanFilters.IsFalse(arg);
        private void WhenIsTruthy() => result = FpFilters.BooleanFilters.BooleanFilters.IsTruthy(arg);
        private void WhenIsFalsey() => result = FpFilters.BooleanFilters.BooleanFilters.IsFalsey(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_value_is_true()
        {
            Runner.RunScenario(
                _ => GivenBool(true),
                _ => WhenIsTrue(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenBool(false),
                _ => WhenIsTrue(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_value_is_false()
        {
            Runner.RunScenario(
                _ => GivenBool(false),
                _ => WhenIsFalse(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenBool(true),
                _ => WhenIsFalse(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_value_is_truthy()
        {
            Runner.RunScenario(
                _ => GivenBool(true),
                _ => WhenIsTruthy(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenBool(false),
                _ => WhenIsTruthy(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_value_is_falsey()
        {
            Runner.RunScenario(
                _ => GivenBool(false),
                _ => WhenIsFalsey(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenBool(true),
                _ => WhenIsFalsey(),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
