namespace FpFilters.BddTests
{
    [FeatureDescription("LengthFilters: BDD scenarios for length filter functions.")]
    public class LengthFiltersFeature : FeatureFixture
    {
        private string? arg;
        private int comparison;
        private bool result;
        private Func<object?, bool>? linqFilter;
        private Func<string?, bool>? linqStringFilter;

        private void GivenString(string value) => arg = value;
        private void GivenComparison(int value) => comparison = value;
        private void WhenIsLengthEqualTo() => result = FpFilters.LengthFilters.IsLengthEqualTo(arg, comparison);
        private void WhenIsLengthGreaterThan() => result = FpFilters.LengthFilters.IsLengthGreaterThan(arg, comparison);
        private void WhenIsLengthLessThan() => result = FpFilters.LengthFilters.IsLengthLessThan(arg, comparison);
        private void WhenIsLengthZero() => result = FpFilters.LengthFilters.IsLengthZero(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        private void GivenLinqFilter(Func<object?, bool> filter) => linqFilter = filter;
        private void GivenLinqStringFilter(Func<string?, bool> filter) => linqStringFilter = filter;
        private void WhenApplyLinqFilter() => result = linqFilter!(arg);
        private void WhenApplyLinqStringFilter() => result = linqStringFilter!(arg);

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
            Xunit.Assert.True(FpFilters.LengthFilters.IsEmpty(""));
            Xunit.Assert.False(FpFilters.LengthFilters.IsEmpty("abc"));
            Xunit.Assert.True(FpFilters.LengthFilters.IsEmpty(new int[] {}));
            Xunit.Assert.False(FpFilters.LengthFilters.IsEmpty(new int[] { 1, 2 }));
            Xunit.Assert.True(FpFilters.LengthFilters.IsEmpty(new System.Collections.Generic.List<int>()));
            Xunit.Assert.False(FpFilters.LengthFilters.IsEmpty(new System.Collections.Generic.List<int> { 1 }));
            Xunit.Assert.False(FpFilters.LengthFilters.IsEmpty(null));
            Xunit.Assert.False(FpFilters.LengthFilters.IsNotEmpty(""));
            Xunit.Assert.True(FpFilters.LengthFilters.IsNotEmpty("abc"));
        }

        [Scenario]
        public void Should_check_has_length_and_variants_for_various_types()
        {
            Xunit.Assert.True(FpFilters.LengthFilters.HasLength("abc", 3));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLength("abc", 2));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLength(new int[] { 1, 2 }, 2));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMin("abc", 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMin("a", 2));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax("abc", 3));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax("abcd", 3));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthBetween("abc", 2, 3));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthBetween("abc", 4, 5));
        }

        [Scenario]
        public void Should_check_has_not_length_and_variants()
        {
            Xunit.Assert.True(FpFilters.LengthFilters.HasNotLength("abc", 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasNotLength("abc", 3));
            Xunit.Assert.True(FpFilters.LengthFilters.HasNotLengthMin("a", 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasNotLengthMin("abc", 2));
            Xunit.Assert.True(FpFilters.LengthFilters.HasNotLengthMax("abcd", 3));
            Xunit.Assert.False(FpFilters.LengthFilters.HasNotLengthMax("abc", 3));
            Xunit.Assert.True(FpFilters.LengthFilters.HasNotLengthBetween("abc", 4, 5));
            Xunit.Assert.False(FpFilters.LengthFilters.HasNotLengthBetween("abc", 2, 3));
        }

        [Scenario]
        public void Should_check_length_property_on_custom_object()
        {
            var custom = new { Length = 5 };
            Xunit.Assert.True(FpFilters.LengthFilters.HasLength(custom, 5));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLength(custom, 4));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMin(custom, 5));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax(custom, 5));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthBetween(custom, 5, 5));
        }

        [Scenario]
        public void Should_check_null_and_missing_length_property_cases()
        {
            object? nullObj = null;
            object noLength = new { Value = 42 };
            Xunit.Assert.False(FpFilters.LengthFilters.HasLength(nullObj, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMin(nullObj, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax(nullObj, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthBetween(nullObj, 1, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLength(noLength, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMin(noLength, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax(noLength, 1));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthBetween(noLength, 1, 2));
        }

        [Scenario]
        public void Should_check_length_methods_with_null_string()
        {
            string? nullStr = null;
            Xunit.Assert.False(FpFilters.LengthFilters.IsLengthEqualTo(nullStr, 0));
            Xunit.Assert.False(FpFilters.LengthFilters.IsLengthGreaterThan(nullStr, 0));
            Xunit.Assert.False(FpFilters.LengthFilters.IsLengthLessThan(nullStr, 0));
            Xunit.Assert.False(FpFilters.LengthFilters.IsLengthZero(nullStr));
        }

        [Scenario]
        public void Should_check_objects_with_length_property_via_reflection()
        {
            // Test reflection paths that were not covered
            var customEmptyLength = new { Length = 0 };
            var customNonZeroLength = new { Length = 3 };
            var objectWithoutLength = new { Name = "test" };
            
            // Test IsEmpty with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.IsEmpty(customEmptyLength));
            Xunit.Assert.False(FpFilters.LengthFilters.IsEmpty(customNonZeroLength));
            Xunit.Assert.False(FpFilters.LengthFilters.IsEmpty(objectWithoutLength));
            
            // Test HasLength with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.HasLength(customNonZeroLength, 3));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLength(customNonZeroLength, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLength(objectWithoutLength, 1));
            
            // Test HasLengthMin with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMin(customNonZeroLength, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMin(customNonZeroLength, 4));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMin(objectWithoutLength, 1));
            
            // Test HasLengthMax with reflection path
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax(customNonZeroLength, 4));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax(customNonZeroLength, 2));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax(objectWithoutLength, 5));
        }

        [Scenario]
        public void Should_check_has_length_max_with_icollection_types()
        {
            // Test the ICollection path for HasLengthMax that wasn't covered
            var list = new System.Collections.Generic.List<int> { 1, 2, 3 };
            var array = new int[] { 1, 2, 3, 4 };
            
            // Test HasLengthMax with ICollection (List)
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax(list, 3));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax(list, 5));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax(list, 2));
            
            // Test HasLengthMax with ICollection (Array)
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax(array, 4));
            Xunit.Assert.True(FpFilters.LengthFilters.HasLengthMax(array, 6));
            Xunit.Assert.False(FpFilters.LengthFilters.HasLengthMax(array, 3));
        }

        [Scenario]
        public void Should_check_HasLength_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasLength(3)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("ab"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasLengthMin_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasLengthMin(2)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("a"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasLengthMax_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasLengthMax(3)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abcd"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasLengthBetween_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasLengthBetween(2, 3)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("a"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse(),
                _ => GivenString("abcd"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasNotLength_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasNotLength(2)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("ab"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasNotLengthMin_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasNotLengthMin(2)),
                _ => GivenString("a"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasNotLengthMax_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasNotLengthMax(3)),
                _ => GivenString("abcd"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasNotLengthBetween_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.LengthFilters.HasNotLengthBetween(2, 3)),
                _ => GivenString("a"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_IsLengthEqualTo_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqStringFilter(FpFilters.LengthFilters.IsLengthEqualTo(3)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqStringFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("ab"),
                _ => WhenApplyLinqStringFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_IsLengthGreaterThan_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqStringFilter(FpFilters.LengthFilters.IsLengthGreaterThan(2)),
                _ => GivenString("abc"),
                _ => WhenApplyLinqStringFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("ab"),
                _ => WhenApplyLinqStringFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_IsLengthLessThan_linq()
        {
            Runner.RunScenario(
                _ => GivenLinqStringFilter(FpFilters.LengthFilters.IsLengthLessThan(3)),
                _ => GivenString("ab"),
                _ => WhenApplyLinqStringFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenString("abc"),
                _ => WhenApplyLinqStringFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
