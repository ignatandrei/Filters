using System;
using Xunit;

namespace FpFilters.DateFilters.Tests
{
    public class DateFiltersTests
    {
        [Fact]
        public void IsLeapYear_WorksCorrectly()
        {
            Assert.True(DateFilters.IsLeapYear(new DateTime(2020, 1, 1)));
            Assert.False(DateFilters.IsLeapYear(new DateTime(2021, 1, 1)));
            Assert.True(DateFilters.IsLeapYear(new DateTime(2000, 1, 1)));
            Assert.False(DateFilters.IsLeapYear(new DateTime(1900, 1, 1)));
        }

        [Fact]
        public void IsFutureDate_WorksCorrectly()
        {
            var now = DateTime.Now;
            Assert.True(DateFilters.IsFutureDate(now.AddDays(1), now));
            Assert.False(DateFilters.IsFutureDate(now.AddDays(-1), now));
        }

        [Fact]
        public void IsPastDate_WorksCorrectly()
        {
            var now = DateTime.Now;
            Assert.True(DateFilters.IsPastDate(now.AddDays(-1), now));
            Assert.False(DateFilters.IsPastDate(now.AddDays(1), now));
        }

        [Fact]
        public void IsSameDate_WorksCorrectly()
        {
            var d1 = new DateTime(2025, 9, 7);
            var d2 = new DateTime(2025, 9, 7);
            var d3 = new DateTime(2025, 9, 8);
            Assert.True(DateFilters.IsSameDate(d1, d2));
            Assert.False(DateFilters.IsSameDate(d1, d3));
        }

        [Fact]
        public void IsSameDay_WorksCorrectly()
        {
            var d1 = new DateTime(2025, 9, 7);
            var d2 = new DateTime(2025, 8, 7);
            Assert.True(DateFilters.IsSameDay(d1, d2));
            Assert.False(DateFilters.IsSameDay(d1, new DateTime(2025, 9, 8)));
        }

        [Fact]
        public void IsSameMonth_WorksCorrectly()
        {
            var d1 = new DateTime(2025, 9, 7);
            var d2 = new DateTime(2025, 9, 8);
            Assert.True(DateFilters.IsSameMonth(d1, d2));
            Assert.False(DateFilters.IsSameMonth(d1, new DateTime(2025, 8, 7)));
        }

        [Fact]
        public void IsSameYear_WorksCorrectly()
        {
            var d1 = new DateTime(2025, 9, 7);
            var d2 = new DateTime(2025, 1, 1);
            Assert.True(DateFilters.IsSameYear(d1, d2));
            Assert.False(DateFilters.IsSameYear(d1, new DateTime(2024, 9, 7)));
        }

        [Fact]
        public void IsWeekend_WorksCorrectly()
        {
            Assert.True(DateFilters.IsWeekend(new DateTime(2025, 9, 6))); // Saturday
            Assert.True(DateFilters.IsWeekend(new DateTime(2025, 9, 7))); // Sunday
            Assert.False(DateFilters.IsWeekend(new DateTime(2025, 9, 8))); // Monday
        }

        [Fact]
        public void IsWorkingWeek_WorksCorrectly()
        {
            Assert.True(DateFilters.IsWorkingWeek(new DateTime(2025, 9, 8))); // Monday
            Assert.False(DateFilters.IsWorkingWeek(new DateTime(2025, 9, 7))); // Sunday
        }

        [Fact]
        public void DayOfWeekChecks_WorkCorrectly()
        {
            Assert.True(DateFilters.IsMonday(new DateTime(2025, 9, 8)));
            Assert.True(DateFilters.IsTuesday(new DateTime(2025, 9, 9)));
            Assert.True(DateFilters.IsWednesday(new DateTime(2025, 9, 10)));
            Assert.True(DateFilters.IsThursday(new DateTime(2025, 9, 11)));
            Assert.True(DateFilters.IsFriday(new DateTime(2025, 9, 12)));
            Assert.True(DateFilters.IsSaturday(new DateTime(2025, 9, 13)));
            Assert.True(DateFilters.IsSunday(new DateTime(2025, 9, 14)));
        }
    }
}
