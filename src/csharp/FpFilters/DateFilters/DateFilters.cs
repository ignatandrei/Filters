using System;

namespace FpFilters.DateFilters
{
    public static class DateFilters
    {
        public static bool IsLeapYear(DateTime date)
        {
            int year = date.Year;
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public static bool IsFutureDate(DateTime date, DateTime comparison) => date > comparison;
        public static bool IsPastDate(DateTime date, DateTime comparison) => date < comparison;
        public static bool IsSameDate(DateTime date, DateTime comparison) => date.Date == comparison.Date;
        public static bool IsSameDay(DateTime date, DateTime comparison) => date.Day == comparison.Day;
        public static bool IsSameMonth(DateTime date, DateTime comparison) => date.Month == comparison.Month;
        public static bool IsSameYear(DateTime date, DateTime comparison) => date.Year == comparison.Year;

        public static bool IsWeekend(DateTime date)
        {
            var day = date.DayOfWeek;
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        public static bool IsWorkingWeek(DateTime date)
        {
            var day = date.DayOfWeek;
            return day >= DayOfWeek.Monday && day <= DayOfWeek.Friday;
        }

        public static bool IsMonday(DateTime date) => date.DayOfWeek == DayOfWeek.Monday;
        public static bool IsTuesday(DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;
        public static bool IsWednesday(DateTime date) => date.DayOfWeek == DayOfWeek.Wednesday;
        public static bool IsThursday(DateTime date) => date.DayOfWeek == DayOfWeek.Thursday;
        public static bool IsFriday(DateTime date) => date.DayOfWeek == DayOfWeek.Friday;
        public static bool IsSaturday(DateTime date) => date.DayOfWeek == DayOfWeek.Saturday;
        public static bool IsSunday(DateTime date) => date.DayOfWeek == DayOfWeek.Sunday;
    }
}
