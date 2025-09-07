using Xunit;

namespace FpFilters.NumberFilters.Tests
{
    public class NumberFiltersTests
    {
        [Fact]
        public void IsZero_ReturnsTrueForZero()
        {
            Assert.True(NumberFilters.IsZero(0));
            Assert.False(NumberFilters.IsZero(1));
        }

        [Fact]
        public void IsRound_ReturnsTrueForRoundNumbers()
        {
            Assert.True(NumberFilters.IsRound(5));
            Assert.False(NumberFilters.IsRound(5.1));
        }

        [Fact]
        public void IsPositiveOrZero_ReturnsTrueForPositiveOrZero()
        {
            Assert.True(NumberFilters.IsPositiveOrZero(0));
            Assert.True(NumberFilters.IsPositiveOrZero(5));
            Assert.False(NumberFilters.IsPositiveOrZero(-1));
        }

        [Fact]
        public void IsPositive_ReturnsTrueForPositive()
        {
            Assert.True(NumberFilters.IsPositive(5));
            Assert.False(NumberFilters.IsPositive(0));
            Assert.False(NumberFilters.IsPositive(-1));
        }

        [Fact]
        public void IsOdd_ReturnsTrueForOdd()
        {
            Assert.True(NumberFilters.IsOdd(3));
            Assert.False(NumberFilters.IsOdd(4));
        }

        [Fact]
        public void IsNotZero_ReturnsTrueForNonZero()
        {
            Assert.True(NumberFilters.IsNotZero(1));
            Assert.False(NumberFilters.IsNotZero(0));
        }

        [Fact]
        public void IsNotNaN_ReturnsTrueForNumbers()
        {
            Assert.True(NumberFilters.IsNotNaN(1));
            Assert.False(NumberFilters.IsNotNaN(double.NaN));
        }

        [Fact]
        public void IsNegativeOrZero_ReturnsTrueForNegativeOrZero()
        {
            Assert.True(NumberFilters.IsNegativeOrZero(-1));
            Assert.True(NumberFilters.IsNegativeOrZero(0));
            Assert.False(NumberFilters.IsNegativeOrZero(1));
        }

        [Fact]
        public void IsNegative_ReturnsTrueForNegative()
        {
            Assert.True(NumberFilters.IsNegative(-1));
            Assert.False(NumberFilters.IsNegative(0));
            Assert.False(NumberFilters.IsNegative(1));
        }

        [Fact]
        public void IsMultipleOf_ReturnsTrueForMultiples()
        {
            Assert.True(NumberFilters.IsMultipleOf(6, 3));
            Assert.False(NumberFilters.IsMultipleOf(7, 3));
        }

        [Fact]
        public void IsLowerThan_ReturnsTrueForLower()
        {
            Assert.True(NumberFilters.IsLowerThan(2, 3));
            Assert.False(NumberFilters.IsLowerThan(3, 2));
        }

        [Fact]
        public void IsLowerOrEqualTo_ReturnsTrueForLowerOrEqual()
        {
            Assert.True(NumberFilters.IsLowerOrEqualTo(2, 3));
            Assert.True(NumberFilters.IsLowerOrEqualTo(3, 3));
            Assert.False(NumberFilters.IsLowerOrEqualTo(4, 3));
        }

        [Fact]
        public void IsInteger_ReturnsTrueForIntegers()
        {
            Assert.True(NumberFilters.IsInteger(5));
            Assert.False(NumberFilters.IsInteger(5.1));
        }

        [Fact]
        public void IsGreaterThan_ReturnsTrueForGreater()
        {
            Assert.True(NumberFilters.IsGreaterThan(4, 3));
            Assert.False(NumberFilters.IsGreaterThan(3, 4));
        }

        [Fact]
        public void IsGreaterOrEqualTo_ReturnsTrueForGreaterOrEqual()
        {
            Assert.True(NumberFilters.IsGreaterOrEqualTo(4, 3));
            Assert.True(NumberFilters.IsGreaterOrEqualTo(3, 3));
            Assert.False(NumberFilters.IsGreaterOrEqualTo(2, 3));
        }

        [Fact]
        public void IsEven_ReturnsTrueForEven()
        {
            Assert.True(NumberFilters.IsEven(4));
            Assert.False(NumberFilters.IsEven(3));
        }

        [Fact]
        public void IsBetweenExcludingMin_ReturnsTrueForRange()
        {
            Assert.True(NumberFilters.IsBetweenExcludingMin(5, 3, 5));
            Assert.False(NumberFilters.IsBetweenExcludingMin(3, 3, 5));
        }

        [Fact]
        public void IsBetweenExcludingMax_ReturnsTrueForRange()
        {
            Assert.True(NumberFilters.IsBetweenExcludingMax(3, 3, 5));
            Assert.False(NumberFilters.IsBetweenExcludingMax(5, 3, 5));
        }

        [Fact]
        public void IsBetweenExcludingBoundaries_ReturnsTrueForRange()
        {
            Assert.True(NumberFilters.IsBetweenExcludingBoundaries(4, 3, 5));
            Assert.False(NumberFilters.IsBetweenExcludingBoundaries(3, 3, 5));
            Assert.False(NumberFilters.IsBetweenExcludingBoundaries(5, 3, 5));
        }

        [Fact]
        public void IsBetween_ReturnsTrueForInclusiveRange()
        {
            Assert.True(NumberFilters.IsBetween(3, 3, 5));
            Assert.True(NumberFilters.IsBetween(5, 3, 5));
            Assert.False(NumberFilters.IsBetween(2, 3, 5));
            Assert.False(NumberFilters.IsBetween(6, 3, 5));
        }
    }
}
