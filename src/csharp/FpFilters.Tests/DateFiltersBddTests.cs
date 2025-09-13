namespace FpFilters.DateFilters.BddTests
{
    [FeatureDescription("DateFilters: BDD scenarios for date filter functions.")]
    public class DateFiltersFeature : FeatureFixture
    {
        private DateTime arg;
        private DateTime comparison;
        private bool result;
        private Func<DateTime, bool> linqFilter;

        private void GivenDate(DateTime value) => arg = value;
        private void GivenComparison(DateTime value) => comparison = value;
        private void WhenIsFutureDate() => result = FpFilters.DateFilters.DateFilters.IsFutureDate(arg, comparison);
        private void WhenIsPastDate() => result = FpFilters.DateFilters.DateFilters.IsPastDate(arg, comparison);
        private void WhenIsSameDate() => result = FpFilters.DateFilters.DateFilters.IsSameDate(arg, comparison);
        private void WhenIsLeapYear() => result = FpFilters.DateFilters.DateFilters.IsLeapYear(arg);
        private void WhenIsMonday() => result = FpFilters.DateFilters.DateFilters.IsMonday(arg);
        private void WhenIsFriday() => result = FpFilters.DateFilters.DateFilters.IsFriday(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        private void GivenLinqFilter(Func<DateTime, bool> filter) => linqFilter = filter;
        private void WhenApplyLinqFilter() => result = linqFilter(arg);

        [Scenario]
        public void Should_check_if_date_is_in_the_future()
        {
            Runner.RunScenario(
                _ => GivenDate(DateTime.Now.AddDays(1)),
                _ => GivenComparison(DateTime.Now),
                _ => WhenIsFutureDate(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(DateTime.Now.AddDays(-1)),
                _ => GivenComparison(DateTime.Now),
                _ => WhenIsFutureDate(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_date_is_in_the_future_linq()
        {
            var comparisonDate = DateTime.Now;
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.DateFilters.DateFilters.IsFutureDate(comparisonDate)),
                _ => GivenDate(comparisonDate.AddDays(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(comparisonDate.AddDays(-1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_date_is_in_the_past()
        {
            Runner.RunScenario(
                _ => GivenDate(DateTime.Now.AddDays(-1)),
                _ => GivenComparison(DateTime.Now),
                _ => WhenIsPastDate(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(DateTime.Now.AddDays(1)),
                _ => GivenComparison(DateTime.Now),
                _ => WhenIsPastDate(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_date_is_in_the_past_linq()
        {
            var comparisonDate = DateTime.Now;
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.DateFilters.DateFilters.IsPastDate(comparisonDate)),
                _ => GivenDate(comparisonDate.AddDays(-1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(comparisonDate.AddDays(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_dates_are_the_same()
        {
            var now = DateTime.Now;
            Runner.RunScenario(
                _ => GivenDate(now),
                _ => GivenComparison(now),
                _ => WhenIsSameDate(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(now),
                _ => GivenComparison(now.AddDays(1)),
                _ => WhenIsSameDate(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_dates_are_the_same_linq()
        {
            var now = DateTime.Now;
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.DateFilters.DateFilters.IsSameDate(now)),
                _ => GivenDate(now),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(now.AddDays(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_days_are_the_same_linq()
        {
            var now = DateTime.Now;
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.DateFilters.DateFilters.IsSameDay(now)),
                _ => GivenDate(now),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(now.AddMonths(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(now.AddDays(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_months_are_the_same_linq()
        {
            var now = DateTime.Now;
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.DateFilters.DateFilters.IsSameMonth(now)),
                _ => GivenDate(now),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(now.AddMonths(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_years_are_the_same_linq()
        {
            var now = DateTime.Now;
            Runner.RunScenario(
                _ => GivenLinqFilter(FpFilters.DateFilters.DateFilters.IsSameYear(now)),
                _ => GivenDate(now),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(now.AddYears(1)),
                _ => WhenApplyLinqFilter(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_date_is_leap_year()
        {
            Runner.RunScenario(
                _ => GivenDate(new DateTime(2024, 2, 29)),
                _ => WhenIsLeapYear(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(new DateTime(2023, 2, 28)),
                _ => WhenIsLeapYear(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_date_is_monday()
        {
            Runner.RunScenario(
                _ => GivenDate(new DateTime(2024, 4, 15)), // Monday
                _ => WhenIsMonday(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(new DateTime(2024, 4, 16)), // Tuesday
                _ => WhenIsMonday(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_date_is_friday()
        {
            Runner.RunScenario(
                _ => GivenDate(new DateTime(2024, 4, 19)), // Friday
                _ => WhenIsFriday(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenDate(new DateTime(2024, 4, 18)), // Thursday
                _ => WhenIsFriday(),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
