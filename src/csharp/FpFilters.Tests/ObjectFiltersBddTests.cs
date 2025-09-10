namespace FpFilters.ObjectFilters.BddTests
{
    [FeatureDescription("ObjectFilters: BDD scenarios for object filter functions.")]
    public class ObjectFiltersFeature : FeatureFixture
    {
        private object? arg;
        private object? comparison;
        private bool result;

        private void GivenObject(object? value) => arg = value;
        private void GivenComparison(object value) => comparison = value;
        private void WhenIsNull() => result = FpFilters.ObjectFilters.ObjectFilters.IsNull(arg);
        private void WhenIsNotNull() => result = FpFilters.ObjectFilters.ObjectFilters.IsNotNull(arg);
        private void WhenIsEqualTo() => result = FpFilters.ObjectFilters.ObjectFilters.IsEqualTo(arg, comparison);
        private void WhenIsNotEqualTo() => result = FpFilters.ObjectFilters.ObjectFilters.IsNotEqualTo(arg, comparison);
        private void WhenIsReferenceEqual() => result = FpFilters.ObjectFilters.ObjectFilters.IsReferenceEqual(arg, comparison);
        private void WhenIsReferenceNotEqual() => result = FpFilters.ObjectFilters.ObjectFilters.IsReferenceNotEqual(arg, comparison);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_object_is_null()
        {
            Runner.RunScenario(
                _ => GivenObject(null),
                _ => WhenIsNull(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject("not null"),
                _ => WhenIsNull(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_object_is_not_null()
        {
            Runner.RunScenario(
                _ => GivenObject("not null"),
                _ => WhenIsNotNull(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(null),
                _ => WhenIsNotNull(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_equal()
        {
            Runner.RunScenario(
                _ => GivenObject(5),
                _ => GivenComparison(5),
                _ => WhenIsEqualTo(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(5),
                _ => GivenComparison(6),
                _ => WhenIsEqualTo(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_not_equal()
        {
            Runner.RunScenario(
                _ => GivenObject(5),
                _ => GivenComparison(6),
                _ => WhenIsNotEqualTo(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(5),
                _ => GivenComparison(5),
                _ => WhenIsNotEqualTo(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_reference_equal()
        {
            var obj = new object();
            Runner.RunScenario(
                _ => GivenObject(obj),
                _ => GivenComparison(obj),
                _ => WhenIsReferenceEqual(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(new object()),
                _ => GivenComparison(new object()),
                _ => WhenIsReferenceEqual(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_reference_not_equal()
        {
            var obj = new object();
            Runner.RunScenario(
                _ => GivenObject(new object()),
                _ => GivenComparison(new object()),
                _ => WhenIsReferenceNotEqual(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(obj),
                _ => GivenComparison(obj),
                _ => WhenIsReferenceNotEqual(),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
