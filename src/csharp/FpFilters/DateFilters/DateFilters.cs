namespace FpFilters.DateFilters
{
    public static class DateFilters
    {
        /// <summary>
        /// Determines whether the year of the specified date is a leap year.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
        /// Determines whether the year of the provided date is a leap year (Gregorian rule).
        /// </summary>
        /// <param name="date">The date whose year will be evaluated; only the Year component is used.</param>
        /// <returns><c>true</c> if the year is a leap year (divisible by 4, not by 100 unless also divisible by 400); otherwise <c>false</c>.</returns>
        public static bool IsLeapYear(DateTime date)
        {
            int year = date.Year;
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        /// <summary>
        /// Determines whether the specified date is in the future compared to the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Determines whether the specified date occurs after the comparison date.
/// </summary>
/// <param name="date">The date to test.</param>
/// <param name="comparison">The date to compare against; returns true only if <paramref name="date"/> is strictly later than this value.</param>
/// <returns><c>true</c> if <paramref name="date"/> is after <paramref name="comparison"/>; otherwise, <c>false</c>.</returns>
        public static bool IsFutureDate(DateTime date, DateTime comparison) => date > comparison;

        /// <summary>
        /// Returns a function that determines whether a date is in the future compared to the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a given <see cref="DateTime"/> occurs after the specified comparison date.
/// </summary>
/// <param name="comparison">The date to compare against; the returned predicate returns true for dates strictly greater than this value.</param>
/// <returns>A <see cref="Func{DateTime,Boolean}"/> that returns true when its input is later than <paramref name="comparison"/>.</returns>
        public static Func<DateTime, bool> IsFutureDate(DateTime comparison) => date => IsFutureDate(date, comparison);

        /// <summary>
        /// Determines whether the specified date is in the past compared to the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Determines whether the specified date occurs before the given comparison date.
/// </summary>
/// <param name="date">The date to test.</param>
/// <param name="comparison">The reference date to compare against.</param>
/// <returns><c>true</c> if <paramref name="date"/> is earlier than <paramref name="comparison"/>; otherwise, <c>false</c>.</returns>
        public static bool IsPastDate(DateTime date, DateTime comparison) => date < comparison;

        /// <summary>
        /// Returns a function that determines whether a date is in the past compared to the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Returns a predicate that evaluates whether a given <see cref="DateTime"/> is strictly earlier than the specified comparison date.
/// </summary>
/// <param name="comparison">The date to compare against.</param>
/// <returns>A function that returns <c>true</c> when its input is before <paramref name="comparison"/>.</returns>
        public static Func<DateTime, bool> IsPastDate(DateTime comparison) => date => IsPastDate(date, comparison);

        /// <summary>
        /// Determines whether the specified date is the same as the comparison date (ignoring time).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Determines whether two DateTime values represent the same calendar date (ignores time-of-day).
/// </summary>
/// <param name="date">The first DateTime to compare.</param>
/// <param name="comparison">The second DateTime to compare against.</param>
/// <returns><c>true</c> if both values share the same date component; otherwise, <c>false</c>.</returns>
        public static bool IsSameDate(DateTime date, DateTime comparison) => date.Date == comparison.Date;

        /// <summary>
        /// Returns a function that determines whether a date is the same as the specified comparison date (ignoring time).
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a given DateTime has the same calendar date (ignoring time) as <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The reference date whose date portion is used for equality comparison (time component ignored).</param>
/// <returns>A function that returns true when its input's Date equals <paramref name="comparison"/.Date>.</returns>
        public static Func<DateTime, bool> IsSameDate(DateTime comparison) => date => IsSameDate(date, comparison);

        /// <summary>
        /// Determines whether the specified date is on the same day of the month as the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Determines whether the Day component (day of month) of two DateTime values are equal.
/// This compares only the Day property and does not consider month or year.
/// </summary>
/// <param name="date">The first date to compare.</param>
/// <param name="comparison">The second date to compare.</param>
/// <returns>True if the day-of-month values are equal; otherwise, false.</returns>
        public static bool IsSameDay(DateTime date, DateTime comparison) => date.Day == comparison.Day;

        /// <summary>
        /// Returns a function that determines whether a date is on the same day of the month as the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a given date has the same day-of-month as <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The date whose Day component is used for comparison.</param>
/// <returns>A function that takes a <see cref="DateTime"/> and returns true if its Day equals <paramref name="comparison"/>'s Day.</returns>
        public static Func<DateTime, bool> IsSameDay(DateTime comparison) => date => IsSameDay(date, comparison);

        /// <summary>
        /// Determines whether the specified date is in the same month as the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Determines whether two dates share the same month.
/// </summary>
/// <param name="date">The date to test.</param>
/// <param name="comparison">The date to compare against.</param>
/// <returns><c>true</c> if both dates have the same month value; otherwise, <c>false</c>. This comparison only checks the month component and does not consider year, day, or time.</returns>
        public static bool IsSameMonth(DateTime date, DateTime comparison) => date.Month == comparison.Month;

        /// <summary>
        /// Returns a function that determines whether a date is in the same month as the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a DateTime falls in the same month as the specified comparison date.
/// </summary>
/// <param name="comparison">The date whose month will be used for comparison.</param>
/// <returns>A function that returns true when the input date's Month equals <paramref name="comparison"/>.Month.</returns>
        public static Func<DateTime, bool> IsSameMonth(DateTime comparison) => date => IsSameMonth(date, comparison);

        /// <summary>
        /// Determines whether the specified date is in the same year as the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Determines whether two DateTime values share the same calendar year.
/// </summary>
/// <returns>True if the Year components are equal; otherwise, false.</returns>
        public static bool IsSameYear(DateTime date, DateTime comparison) => date.Year == comparison.Year;

        /// <summary>
        /// Returns a function that determines whether a date is in the same year as the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a given <see cref="DateTime"/> falls in the same year as <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The date whose year is used for comparison.</param>
/// <returns>A function that returns true when its <see cref="DateTime"/> argument has the same <see cref="DateTime.Year"/> as <paramref name="comparison"/>.</returns>
        public static Func<DateTime, bool> IsSameYear(DateTime comparison) => date => IsSameYear(date, comparison);

        /// <summary>
        /// Determines whether the specified date falls on a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
        /// Determines whether the specified date falls on a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="date">The date to evaluate.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is Saturday or Sunday; otherwise, <c>false</c>.</returns>
        public static bool IsWeekend(DateTime date)
        {
            var day = date.DayOfWeek;
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether the specified date falls on a working week day (Monday to Friday).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
        /// Returns true when the specified date falls on a weekday (Monday through Friday).
        /// </summary>
        /// <param name="date">The date to evaluate; only its day-of-week is considered (time component is ignored).</param>
        /// <returns>True if the date is a working week day; otherwise, false.</returns>
        public static bool IsWorkingWeek(DateTime date)
        {
            var day = date.DayOfWeek;
            return day >= DayOfWeek.Monday && day <= DayOfWeek.Friday;
        }

        /// <summary>
        /// Determines whether the specified date is a Monday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Returns true if the specified date falls on a Monday.
/// </summary>
/// <param name="date">The date to evaluate.</param>
/// <returns>True if the date is Monday; otherwise, false.</returns>
        public static bool IsMonday(DateTime date) => date.DayOfWeek == DayOfWeek.Monday;

        /// <summary>
        /// Determines whether the specified date is a Tuesday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Determines whether the specified date falls on a Tuesday.
/// </summary>
/// <param name="date">The date to evaluate.</param>
/// <returns>True if the date is a Tuesday; otherwise, false.</returns>
        public static bool IsTuesday(DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;

        /// <summary>
        /// Determines whether the specified date is a Wednesday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Determines whether the specified date falls on a Wednesday.
/// </summary>
/// <param name="date">The date to evaluate.</param>
/// <returns>True if the date falls on a Wednesday; otherwise, false.</returns>
        public static bool IsWednesday(DateTime date) => date.DayOfWeek == DayOfWeek.Wednesday;

        /// <summary>
        /// Determines whether the specified date is a Thursday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Returns true if the specified date falls on a Thursday.
/// </summary>
/// <returns>True if the date is a Thursday; otherwise, false.</returns>
        public static bool IsThursday(DateTime date) => date.DayOfWeek == DayOfWeek.Thursday;

        /// <summary>
        /// Determines whether the specified date is a Friday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Returns true if the specified date falls on a Friday.
/// </summary>
/// <returns>True if the date falls on a Friday; otherwise, false.</returns>
        public static bool IsFriday(DateTime date) => date.DayOfWeek == DayOfWeek.Friday;

        /// <summary>
        /// Determines whether the specified date is a Saturday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Determines whether the specified date falls on a Saturday.
/// </summary>
/// <param name="date">The date to evaluate.</param>
/// <returns><c>true</c> if <paramref name="date"/> is a Saturday; otherwise, <c>false</c>.</returns>
        public static bool IsSaturday(DateTime date) => date.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Determines whether the specified date is a Sunday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <summary>
/// Determines whether the specified <see cref="DateTime"/> falls on a Sunday.
/// </summary>
/// <param name="date">The date to evaluate.</param>
/// <returns><c>true</c> if <paramref name="date"/> is a Sunday; otherwise, <c>false</c>.</returns>
        public static bool IsSunday(DateTime date) => date.DayOfWeek == DayOfWeek.Sunday;
    }
}
