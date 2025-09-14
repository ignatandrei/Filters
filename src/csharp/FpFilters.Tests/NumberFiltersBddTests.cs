using FpFilters;
namespace FpFilters.BddTests
{
	[FeatureDescription("NumberFilters: BDD scenarios for number filter functions.")]
	public class NumberFiltersFeature : FeatureFixture
	{
		private double arg;
		private double comparison;
		private int intArg;
		private bool filtered;

		private void GivenNumber(double value) => arg = value;
		private void GivenInt(int value) => intArg = value;
		private void GivenComparison(double value) => comparison = value;
		private void WhenIsEven() => filtered = NumberFilters.IsEven(intArg);
		private void WhenIsOdd() => filtered = NumberFilters.IsOdd(intArg);
		private void WhenIsPositive() => filtered = NumberFilters.IsPositive(arg);
		private void WhenIsNegative() => filtered = NumberFilters.IsNegative(arg);
		private void WhenIsZero() => filtered = NumberFilters.IsZero(arg);
		private void WhenIsGreaterThan() => filtered = NumberFilters.IsGreaterThan(arg, comparison);
		private void WhenIsLessThan() => filtered = NumberFilters.IsLowerThan(arg, comparison);
		private void WhenIsEqualTo() => filtered = NumberFilters.IsLowerOrEqualTo(arg, comparison) && NumberFilters.IsGreaterOrEqualTo(arg, comparison);
		private void WhenIsNotEqualTo() => filtered = !(NumberFilters.IsLowerOrEqualTo(arg, comparison) && NumberFilters.IsGreaterOrEqualTo(arg, comparison));
		private void WhenIsFinite() => filtered = !double.IsInfinity(arg) && !double.IsNaN(arg);
		private void WhenIsInfinite() => filtered = double.IsInfinity(arg);
		private void WhenIsNaN() => filtered = double.IsNaN(arg);
		private void ThenResultShouldBeTrue() => Xunit.Assert.True(filtered);
		private void ThenResultShouldBeFalse() => Xunit.Assert.False(filtered);
		private void WhenIsMultipleOfLinq() => filtered = NumberFilters.IsMultipleOf(3)(intArg);
		private void WhenIsLowerThanLinq() => filtered = NumberFilters.IsLowerThan(comparison)(arg);
		private void WhenIsLowerOrEqualToLinq() => filtered = NumberFilters.IsLowerOrEqualTo(comparison)(arg);
		private void WhenIsGreaterThanLinq() => filtered = NumberFilters.IsGreaterThan(comparison)(arg);
		private void WhenIsGreaterOrEqualToLinq() => filtered = NumberFilters.IsGreaterOrEqualTo(comparison)(arg);
		private void WhenIsBetweenExcludingMinLinq(double min, double max) => filtered = NumberFilters.IsBetweenExcludingMin(min, max)(arg);
		private void WhenIsBetweenExcludingMaxLinq(double min, double max) => filtered = NumberFilters.IsBetweenExcludingMax(min, max)(arg);
		private void WhenIsBetweenExcludingBoundariesLinq(double min, double max) => filtered = NumberFilters.IsBetweenExcludingBoundaries(min, max)(arg);
		private void WhenIsBetweenLinq(double min, double max) => filtered = NumberFilters.IsBetween(min, max)(arg);

		[Scenario]
		public void Should_check_if_number_is_even()
		{
			Runner.RunScenario(
				_ => GivenInt(2),
				_ => WhenIsEven(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenInt(3),
				_ => WhenIsEven(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_odd()
		{
			Runner.RunScenario(
				_ => GivenInt(3),
				_ => WhenIsOdd(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenInt(2),
				_ => WhenIsOdd(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_positive()
		{
			Runner.RunScenario(
				_ => GivenNumber(5),
				_ => WhenIsPositive(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(-1),
				_ => WhenIsPositive(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_negative()
		{
			Runner.RunScenario(
				_ => GivenNumber(-5),
				_ => WhenIsNegative(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(1),
				_ => WhenIsNegative(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_zero()
		{
			Runner.RunScenario(
				_ => GivenNumber(0),
				_ => WhenIsZero(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(1),
				_ => WhenIsZero(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_greater_than_comparison()
		{
			Runner.RunScenario(
				_ => GivenNumber(5),
				_ => GivenComparison(3),
				_ => WhenIsGreaterThan(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsGreaterThan(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_less_than_comparison()
		{
			Runner.RunScenario(
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsLessThan(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(5),
				_ => GivenComparison(3),
				_ => WhenIsLessThan(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_equal_to_comparison()
		{
			Runner.RunScenario(
				_ => GivenNumber(3),
				_ => GivenComparison(3),
				_ => WhenIsEqualTo(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsEqualTo(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_not_equal_to_comparison()
		{
			Runner.RunScenario(
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsNotEqualTo(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(3),
				_ => GivenComparison(3),
				_ => WhenIsNotEqualTo(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_finite()
		{
			Runner.RunScenario(
				_ => GivenNumber(3),
				_ => WhenIsFinite(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(double.PositiveInfinity),
				_ => WhenIsFinite(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_infinite()
		{
			Runner.RunScenario(
				_ => GivenNumber(double.PositiveInfinity),
				_ => WhenIsInfinite(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(3),
				_ => WhenIsInfinite(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_if_number_is_nan()
		{
			Runner.RunScenario(
				_ => GivenNumber(double.NaN),
				_ => WhenIsNaN(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(3),
				_ => WhenIsNaN(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsMultipleOf_Linq()
		{
			Runner.RunScenario(
				_ => GivenInt(6),
				_ => WhenIsMultipleOfLinq(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenInt(7),
				_ => WhenIsMultipleOfLinq(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsLowerThan_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsLowerThanLinq(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(4),
				_ => GivenComparison(3),
				_ => WhenIsLowerThanLinq(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsLowerOrEqualTo_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsLowerOrEqualToLinq(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(4),
				_ => GivenComparison(3),
				_ => WhenIsLowerOrEqualToLinq(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsGreaterThan_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(4),
				_ => GivenComparison(3),
				_ => WhenIsGreaterThanLinq(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsGreaterThanLinq(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsGreaterOrEqualTo_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(4),
				_ => GivenComparison(3),
				_ => WhenIsGreaterOrEqualToLinq(),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(2),
				_ => GivenComparison(3),
				_ => WhenIsGreaterOrEqualToLinq(),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsBetweenExcludingMin_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(4),
				_ => WhenIsBetweenExcludingMinLinq(3, 5),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(3),
				_ => WhenIsBetweenExcludingMinLinq(3, 5),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsBetweenExcludingMax_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(4),
				_ => WhenIsBetweenExcludingMaxLinq(3, 5),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(5),
				_ => WhenIsBetweenExcludingMaxLinq(3, 5),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsBetweenExcludingBoundaries_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(4),
				_ => WhenIsBetweenExcludingBoundariesLinq(3, 5),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(3),
				_ => WhenIsBetweenExcludingBoundariesLinq(3, 5),
				_ => ThenResultShouldBeFalse(),
				_ => GivenNumber(5),
				_ => WhenIsBetweenExcludingBoundariesLinq(3, 5),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_check_IsBetween_Linq()
		{
			Runner.RunScenario(
				_ => GivenNumber(4),
				_ => WhenIsBetweenLinq(3, 5),
				_ => ThenResultShouldBeTrue(),
				_ => GivenNumber(2),
				_ => WhenIsBetweenLinq(3, 5),
				_ => ThenResultShouldBeFalse(),
				_ => GivenNumber(6),
				_ => WhenIsBetweenLinq(3, 5),
				_ => ThenResultShouldBeFalse()
			);
		}

		[Scenario]
		public void Should_filter_collection_with_IsBetweenExcludingMin_Linq_edge_cases()
		{
			var numbers = new[] { 2.0, 3.0, 4.0, 5.0 };
			var result = numbers.Where(NumberFilters.IsBetweenExcludingMin(3.0, 5.0)).ToArray();
			Xunit.Assert.Equal(new[] { 4.0, 5.0 }, result);
		}

		[Scenario]
		public void Should_filter_collection_with_IsBetweenExcludingMax_Linq_edge_cases()
		{
			var numbers = new[] { 2.0, 3.0, 4.0, 5.0 };
			var result = numbers.Where(NumberFilters.IsBetweenExcludingMax(3.0, 5.0)).ToArray();
			Xunit.Assert.Equal(new[] { 3.0, 4.0 }, result);
		}

		[Scenario]
		public void Should_filter_collection_with_IsBetweenExcludingBoundaries_Linq_edge_cases()
		{
			var numbers = new[] { 2.0, 3.0, 4.0, 5.0 };
			var result = numbers.Where(NumberFilters.IsBetweenExcludingBoundaries(3.0, 5.0)).ToArray();
			Xunit.Assert.Equal(new[] { 4.0 }, result);
		}

		[Scenario]
		public void Should_filter_collection_with_IsBetween_Linq_edge_cases()
		{
			var numbers = new[] { 2.0, 3.0, 4.0, 5.0, 6.0 };
			var result = numbers.Where(NumberFilters.IsBetween(3.0, 5.0)).ToArray();
			Xunit.Assert.Equal(new[] { 3.0, 4.0, 5.0 }, result);
		}

		[Scenario]
		public void Should_filter_collection_with_IsLowerThan_Linq_all_false()
		{
			var numbers = new[] { 3.0, 4.0, 5.0 };
			var result = numbers.Where(NumberFilters.IsLowerThan(2.0)).ToArray();
			Xunit.Assert.Empty(result);
		}

		[Scenario]
		public void Should_filter_collection_with_IsGreaterThan_Linq_all_true()
		{
			var numbers = new[] { 4.0, 5.0, 6.0 };
			var result = numbers.Where(NumberFilters.IsGreaterThan(3.0)).ToArray();
			Xunit.Assert.Equal(new[] { 4.0, 5.0, 6.0 }, result);
		}

		[Scenario]
		public void Should_filter_collection_with_IsMultipleOf_Linq_none()
		{
			var numbers = new[] { 2, 4, 5 };
			var result = numbers.Where(NumberFilters.IsMultipleOf(3)).ToArray();
			Xunit.Assert.Empty(result);
		}
	}
}
