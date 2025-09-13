namespace FpFilters.DateFilters
{
    public static class DateFilters
    {
        /// <summary>
        /// Determines whether the year of the specified date is a leap year.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the year is a leap year; otherwise, false.</returns>
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
        /// <returns>True if the date is in the future; otherwise, false.</returns>
        public static bool IsFutureDate(DateTime date, DateTime comparison) => date > comparison;

        /// <summary>
        /// Returns a function that determines whether a date is in the future compared to the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>A function that checks if a date is in the future.</returns>
        public static Func<DateTime, bool> IsFutureDate(DateTime comparison) => date => IsFutureDate(date, comparison);

        /// <summary>
        /// Determines whether the specified date is in the past compared to the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>True if the date is in the past; otherwise, false.</returns>
        public static bool IsPastDate(DateTime date, DateTime comparison) => date < comparison;

        /// <summary>
        /// Returns a function that determines whether a date is in the past compared to the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>A function that checks if a date is in the past.</returns>
        public static Func<DateTime, bool> IsPastDate(DateTime comparison) => date => IsPastDate(date, comparison);

        /// <summary>
        /// Determines whether the specified date is the same as the comparison date (ignoring time).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>True if the dates are the same; otherwise, false.</returns>
        public static bool IsSameDate(DateTime date, DateTime comparison) => date.Date == comparison.Date;

        /// <summary>
        /// Returns a function that determines whether a date is the same as the specified comparison date (ignoring time).
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>A function that checks if a date is the same.</returns>
        public static Func<DateTime, bool> IsSameDate(DateTime comparison) => date => IsSameDate(date, comparison);

        /// <summary>
        /// Determines whether the specified date is on the same day of the month as the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>True if the days are the same; otherwise, false.</returns>
        public static bool IsSameDay(DateTime date, DateTime comparison) => date.Day == comparison.Day;

        /// <summary>
        /// Returns a function that determines whether a date is on the same day of the month as the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>A function that checks if a date is on the same day.</returns>
        public static Func<DateTime, bool> IsSameDay(DateTime comparison) => date => IsSameDay(date, comparison);

        /// <summary>
        /// Determines whether the specified date is in the same month as the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>True if the months are the same; otherwise, false.</returns>
        public static bool IsSameMonth(DateTime date, DateTime comparison) => date.Month == comparison.Month;

        /// <summary>
        /// Returns a function that determines whether a date is in the same month as the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>A function that checks if a date is in the same month.</returns>
        public static Func<DateTime, bool> IsSameMonth(DateTime comparison) => date => IsSameMonth(date, comparison);

        /// <summary>
        /// Determines whether the specified date is in the same year as the comparison date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>True if the years are the same; otherwise, false.</returns>
        public static bool IsSameYear(DateTime date, DateTime comparison) => date.Year == comparison.Year;

        /// <summary>
        /// Returns a function that determines whether a date is in the same year as the specified comparison date.
        /// </summary>
        /// <param name="comparison">The date to compare against.</param>
        /// <returns>A function that checks if a date is in the same year.</returns>
        public static Func<DateTime, bool> IsSameYear(DateTime comparison) => date => IsSameYear(date, comparison);

        /// <summary>
        /// Determines whether the specified date falls on a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a weekend; otherwise, false.</returns>
        public static bool IsWeekend(DateTime date)
        {
            var day = date.DayOfWeek;
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether the specified date falls on a working week day (Monday to Friday).
        /// </summary>
        /// <param name="date">The date to check.</param>
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
        /// <returns>True if the date is a Monday; otherwise, false.</returns>
        public static bool IsMonday(DateTime date) => date.DayOfWeek == DayOfWeek.Monday;

        /// <summary>
        /// Determines whether the specified date is a Tuesday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a Tuesday; otherwise, false.</returns>
        public static bool IsTuesday(DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;

        /// <summary>
        /// Determines whether the specified date is a Wednesday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a Wednesday; otherwise, false.</returns>
        public static bool IsWednesday(DateTime date) => date.DayOfWeek == DayOfWeek.Wednesday;

        /// <summary>
        /// Determines whether the specified date is a Thursday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a Thursday; otherwise, false.</returns>
        public static bool IsThursday(DateTime date) => date.DayOfWeek == DayOfWeek.Thursday;

        /// <summary>
        /// Determines whether the specified date is a Friday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a Friday; otherwise, false.</returns>
        public static bool IsFriday(DateTime date) => date.DayOfWeek == DayOfWeek.Friday;

        /// <summary>
        /// Determines whether the specified date is a Saturday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a Saturday; otherwise, false.</returns>
        public static bool IsSaturday(DateTime date) => date.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        /// Determines whether the specified date is a Sunday.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is a Sunday; otherwise, false.</returns>
        public static bool IsSunday(DateTime date) => date.DayOfWeek == DayOfWeek.Sunday;
    }
}
