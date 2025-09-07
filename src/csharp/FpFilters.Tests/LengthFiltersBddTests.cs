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

        [Scenario]
        public void Should_check_empty_and_not_empty_for_various_types()
        {
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.IsEmpty(""));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsEmpty("abc"));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.IsEmpty(new int[] {}));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsEmpty(new int[] { 1, 2 }));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.IsEmpty(new System.Collections.Generic.List<int>()));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsEmpty(new System.Collections.Generic.List<int> { 1 }));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsEmpty(null));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsNotEmpty(""));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.IsNotEmpty("abc"));
        }

        [Scenario]
        public void Should_check_has_length_and_variants_for_various_types()
        {
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLength("abc", 3));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLength("abc", 2));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLength(new int[] { 1, 2 }, 2));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMin("abc", 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMin("a", 2));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax("abc", 3));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax("abcd", 3));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthBetween("abc", 2, 3));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthBetween("abc", 4, 5));
        }

        [Scenario]
        public void Should_check_has_not_length_and_variants()
        {
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasNotLength("abc", 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasNotLength("abc", 3));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasNotLengthMin("a", 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasNotLengthMin("abc", 2));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasNotLengthMax("abcd", 3));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasNotLengthMax("abc", 3));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasNotLengthBetween("abc", 4, 5));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasNotLengthBetween("abc", 2, 3));
        }

        [Scenario]
        public void Should_check_length_property_on_custom_object()
        {
            var custom = new { Length = 5 };
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLength(custom, 5));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLength(custom, 4));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMin(custom, 5));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax(custom, 5));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthBetween(custom, 5, 5));
        }

        [Scenario]
        public void Should_check_null_and_missing_length_property_cases()
        {
            object nullObj = null;
            object noLength = new { Value = 42 };
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLength(nullObj, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMin(nullObj, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax(nullObj, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthBetween(nullObj, 1, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLength(noLength, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMin(noLength, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax(noLength, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthBetween(noLength, 1, 2));
        }

        [Scenario]
        public void Should_check_length_methods_with_null_string()
        {
            string? nullStr = null;
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsLengthEqualTo(nullStr, 0));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsLengthGreaterThan(nullStr, 0));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsLengthLessThan(nullStr, 0));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsLengthZero(nullStr));
        }

        [Scenario]
        public void Should_check_objects_with_length_property_via_reflection()
        {
            // Test reflection paths that were not covered
            var customEmptyLength = new { Length = 0 };
            var customNonZeroLength = new { Length = 3 };
            var objectWithoutLength = new { Name = "test" };
            
            // Test IsEmpty with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.IsEmpty(customEmptyLength));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsEmpty(customNonZeroLength));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.IsEmpty(objectWithoutLength));
            
            // Test HasLength with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLength(customNonZeroLength, 3));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLength(customNonZeroLength, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLength(objectWithoutLength, 1));
            
            // Test HasLengthMin with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMin(customNonZeroLength, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMin(customNonZeroLength, 4));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMin(objectWithoutLength, 1));
            
            // Test HasLengthMax with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax(customNonZeroLength, 4));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax(customNonZeroLength, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax(objectWithoutLength, 5));
        }

        [Scenario]
        public void Should_check_has_length_max_with_icollection_types()
        {
            // Test the ICollection path for HasLengthMax that wasn't covered
            var list = new System.Collections.Generic.List<int> { 1, 2, 3 };
            var array = new int[] { 1, 2, 3, 4 };
            
            // Test HasLengthMax with ICollection (List)
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax(list, 3));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax(list, 5));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax(list, 2));
            
            // Test HasLengthMax with ICollection (Array)
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax(array, 4));
            Xunit.Assert.True(FpFilters.LengthFilters.LengthFilters.HasLengthMax(array, 6));
            Xunit.Assert.False(FpFilters.LengthFilters.LengthFilters.HasLengthMax(array, 3));
        }
    }
}
