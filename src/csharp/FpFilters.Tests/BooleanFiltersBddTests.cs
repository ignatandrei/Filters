namespace FpFilters.BddTests
{
    [FeatureDescription("BooleanFilters: BDD scenarios for boolean filter functions.")]
    public class BooleanFiltersFeature : FeatureFixture
    {
        private bool arg;
        private bool result;

        private void GivenBool(bool value) => arg = value;
        private void WhenIsTrue() => result = FpFilters.BooleanFilters.IsTrue(arg);
        private void WhenIsFalse() => result = FpFilters.BooleanFilters.IsFalse(arg);
        private void WhenIsTruthy() => result = FpFilters.BooleanFilters.IsTruthy(arg);
        private void WhenIsFalsey() => result = FpFilters.BooleanFilters.IsFalsey(arg);
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

        [Scenario]
        public void Should_check_various_types_for_truthy_and_falsey()
        {
            Xunit.Assert.False(FpFilters.BooleanFilters.IsTruthy(null));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsTruthy(""));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsTruthy("abc"));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsTruthy(0));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsTruthy(42));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsTruthy(0.0));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsTruthy(3.14));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsTruthy(new int[] {}));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsTruthy(new int[] { 1 }));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsTruthy(new System.Collections.Generic.List<int>()));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsTruthy(new System.Collections.Generic.List<int> { 1 }));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsTruthy(new object()));

            Xunit.Assert.True(FpFilters.BooleanFilters.IsFalsey(null));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsFalsey(""));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsFalsey("abc"));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsFalsey(0));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsFalsey(42));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsFalsey(0.0));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsFalsey(3.14));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsFalsey(new int[] {}));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsFalsey(new int[] { 1 }));
            Xunit.Assert.True(FpFilters.BooleanFilters.IsFalsey(new System.Collections.Generic.List<int>()));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsFalsey(new System.Collections.Generic.List<int> { 1 }));
            Xunit.Assert.False(FpFilters.BooleanFilters.IsFalsey(new object()));
        }
    }
}
