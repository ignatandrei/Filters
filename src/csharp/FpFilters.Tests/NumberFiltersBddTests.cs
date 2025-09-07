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
	}
}
