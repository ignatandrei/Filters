namespace FpFilters.NumberFilters.BddTests
{
	[FeatureDescription("NumberFilters: BDD scenarios for number filter functions.")]
	public class NumberFiltersFeature : FeatureFixture
	{
		private double arg;
		private double comparison;
		private int intArg;
		private bool result;

		private void GivenNumber(double value) => arg = value;
		private void GivenInt(int value) => intArg = value;
		private void GivenComparison(double value) => comparison = value;
		private void WhenIsEven() => result = FpFilters.NumberFilters.NumberFilters.IsEven(intArg);
		private void WhenIsOdd() => result = FpFilters.NumberFilters.NumberFilters.IsOdd(intArg);
		private void WhenIsPositive() => result = FpFilters.NumberFilters.NumberFilters.IsPositive(arg);
		private void WhenIsNegative() => result = FpFilters.NumberFilters.NumberFilters.IsNegative(arg);
		private void WhenIsZero() => result = FpFilters.NumberFilters.NumberFilters.IsZero(arg);
		private void WhenIsGreaterThan() => result = FpFilters.NumberFilters.NumberFilters.IsGreaterThan(arg, comparison);
		private void WhenIsLessThan() => result = FpFilters.NumberFilters.NumberFilters.IsLowerThan(arg, comparison);
		private void WhenIsEqualTo() => result = FpFilters.NumberFilters.NumberFilters.IsLowerOrEqualTo(arg, comparison) && FpFilters.NumberFilters.NumberFilters.IsGreaterOrEqualTo(arg, comparison);
		private void WhenIsNotEqualTo() => result = !(FpFilters.NumberFilters.NumberFilters.IsLowerOrEqualTo(arg, comparison) && FpFilters.NumberFilters.NumberFilters.IsGreaterOrEqualTo(arg, comparison));
		private void WhenIsFinite() => result = !double.IsInfinity(arg) && !double.IsNaN(arg);
		private void WhenIsInfinite() => result = double.IsInfinity(arg);
		private void WhenIsNaN() => result = double.IsNaN(arg);
		private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
		private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);
		private void WhenIsMultipleOfLinq() => result = FpFilters.NumberFilters.NumberFilters.IsMultipleOf(3)(intArg);
		private void WhenIsLowerThanLinq() => result = FpFilters.NumberFilters.NumberFilters.IsLowerThan(comparison)(arg);
		private void WhenIsLowerOrEqualToLinq() => result = FpFilters.NumberFilters.NumberFilters.IsLowerOrEqualTo(comparison)(arg);
		private void WhenIsGreaterThanLinq() => result = FpFilters.NumberFilters.NumberFilters.IsGreaterThan(comparison)(arg);
		private void WhenIsGreaterOrEqualToLinq() => result = FpFilters.NumberFilters.NumberFilters.IsGreaterOrEqualTo(comparison)(arg);
		private void WhenIsBetweenExcludingMinLinq(double min, double max) => result = FpFilters.NumberFilters.NumberFilters.IsBetweenExcludingMin(min, max)(arg);
		private void WhenIsBetweenExcludingMaxLinq(double min, double max) => result = FpFilters.NumberFilters.NumberFilters.IsBetweenExcludingMax(min, max)(arg);
		private void WhenIsBetweenExcludingBoundariesLinq(double min, double max) => result = FpFilters.NumberFilters.NumberFilters.IsBetweenExcludingBoundaries(min, max)(arg);
		private void WhenIsBetweenLinq(double min, double max) => result = FpFilters.NumberFilters.NumberFilters.IsBetween(min, max)(arg);

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
	}
}
