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

        [Fact]
        public void IsZero_LinqFilter_ReturnsOnlyZero()
        {
            IEnumerable<double> numbers = new[] { 0.0, 1.0, -1.0 };
            var result = numbers.Where(NumberFilters.IsZero).ToArray();
            Assert.Single(result);
            Assert.Equal(0.0, result[0]);
        }

        [Fact]
        public void IsRound_LinqFilter_ReturnsOnlyRoundNumbers()
        {
            IEnumerable<double> numbers = new[] { 5.0, 5.1, 6.0 };
            var result = numbers.Where(NumberFilters.IsRound).ToArray();
            Assert.Equal(new[] { 5.0, 6.0 }, result);
        }

        [Fact]
        public void IsPositiveOrZero_LinqFilter_ReturnsPositiveOrZero()
        {
            IEnumerable<double> numbers = new[] { -1.0, 0.0, 5.0 };
            var result = numbers.Where(NumberFilters.IsPositiveOrZero).ToArray();
            Assert.Equal(new[] { 0.0, 5.0 }, result);
        }

        [Fact]
        public void IsPositive_LinqFilter_ReturnsOnlyPositive()
        {
            IEnumerable<double> numbers = new[] { -1.0, 0.0, 5.0 };
            var result = numbers.Where(NumberFilters.IsPositive).ToArray();
            Assert.Single(result);
            Assert.Equal(5.0, result[0]);
        }

        [Fact]
        public void IsOdd_LinqFilter_ReturnsOnlyOdd()
        {
            IEnumerable<int> numbers = new[] { 3, 4, 5 };
            var result = numbers.Where(NumberFilters.IsOdd).ToArray();
            Assert.Equal(new[] { 3, 5 }, result);
        }

        [Fact]
        public void IsNotZero_LinqFilter_ReturnsNonZero()
        {
            IEnumerable<double> numbers = new[] { 0.0, 1.0, -1.0 };
            var result = numbers.Where(NumberFilters.IsNotZero).ToArray();
            Assert.Equal(new[] { 1.0, -1.0 }, result);
        }

        [Fact]
        public void IsNotNaN_LinqFilter_ReturnsNumbers()
        {
            IEnumerable<double> numbers = new[] { 1.0, double.NaN, 2.0 };
            var result = numbers.Where(NumberFilters.IsNotNaN).ToArray();
            Assert.Equal(new[] { 1.0, 2.0 }, result);
        }

        [Fact]
        public void IsNegativeOrZero_LinqFilter_ReturnsNegativeOrZero()
        {
            IEnumerable<double> numbers = new[] { -1.0, 0.0, 1.0 };
            var result = numbers.Where(NumberFilters.IsNegativeOrZero).ToArray();
            Assert.Equal(new[] { -1.0, 0.0 }, result);
        }

        [Fact]
        public void IsNegative_LinqFilter_ReturnsOnlyNegative()
        {
            IEnumerable<double> numbers = new[] { -1.0, 0.0, 1.0 };
            var result = numbers.Where(NumberFilters.IsNegative).ToArray();
            Assert.Single(result);
            Assert.Equal(-1.0, result[0]);
        }

        [Fact]
        public void IsMultipleOf_LinqFilter_ReturnsMultiples()
        {
            IEnumerable<int> numbers = new[] { 6, 7, 9 };
            var result = numbers.Where(x => NumberFilters.IsMultipleOf(x, 3)).ToArray();
            Assert.Equal(new[] { 6, 9 }, result);
        }

        [Fact]
        public void IsLowerThan_LinqFilter_ReturnsLower()
        {
            IEnumerable<int> numbers = new[] { 2, 3, 4 };
            var result = numbers.Where(x => NumberFilters.IsLowerThan(x, 3)).ToArray();
            Assert.Single(result);
            Assert.Equal(2, result[0]);
        }

        [Fact]
        public void IsLowerOrEqualTo_LinqFilter_ReturnsLowerOrEqual()
        {
            IEnumerable<int> numbers = new[] { 2, 3, 4 };
            var result = numbers.Where(x => NumberFilters.IsLowerOrEqualTo(x, 3)).ToArray();
            Assert.Equal(new[] { 2, 3 }, result);
        }

        [Fact]
        public void IsInteger_LinqFilter_ReturnsIntegers()
        {
            IEnumerable<double> numbers = new[] { 5.0, 5.1, 6.0 };
            var result = numbers.Where(NumberFilters.IsInteger).ToArray();
            Assert.Equal(new[] { 5.0, 6.0 }, result);
        }

        [Fact]
        public void IsGreaterThan_LinqFilter_ReturnsGreater()
        {
            IEnumerable<int> numbers = new[] { 2, 3, 4 };
            var result = numbers.Where(x => NumberFilters.IsGreaterThan(x, 3)).ToArray();
            Assert.Single(result);
            Assert.Equal(4, result[0]);
        }

        [Fact]
        public void IsGreaterOrEqualTo_LinqFilter_ReturnsGreaterOrEqual()
        {
            IEnumerable<int> numbers = new[] { 2, 3, 4 };
            var result = numbers.Where(x => NumberFilters.IsGreaterOrEqualTo(x, 3)).ToArray();
            Assert.Equal(new[] { 3, 4 }, result);
        }

        [Fact]
        public void IsEven_LinqFilter_ReturnsOnlyEvenNumbers()
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };
            var result = numbers.Where(NumberFilters.IsEven).ToArray();
            Assert.Single(result);
            Assert.Equal(2, result[0]);
        }

        [Fact]
        public void IsBetweenExcludingMin_LinqFilter_ReturnsRange()
        {
            IEnumerable<int> numbers = new[] { 3, 4, 5 };
            var result = numbers.Where(x => NumberFilters.IsBetweenExcludingMin(x, 3, 5)).ToArray();
            Assert.Equal(new[] { 4, 5 }, result);
        }

        [Fact]
        public void IsBetweenExcludingMax_LinqFilter_ReturnsRange()
        {
            IEnumerable<int> numbers = new[] { 3, 4, 5 };
            var result = numbers.Where(x => NumberFilters.IsBetweenExcludingMax(x, 3, 5)).ToArray();
            Assert.Equal(new[] { 3, 4 }, result);
        }

        [Fact]
        public void IsBetweenExcludingBoundaries_LinqFilter_ReturnsRange()
        {
            IEnumerable<int> numbers = new[] { 3, 4, 5 };
            var result = numbers.Where(x => NumberFilters.IsBetweenExcludingBoundaries(x, 3, 5)).ToArray();
            Assert.Single(result);
            Assert.Equal(4, result[0]);
        }

        [Fact]
        public void IsBetween_LinqFilter_ReturnsInclusiveRange()
        {
            IEnumerable<int> numbers = new[] { 2, 3, 4, 5, 6 };
            var result = numbers.Where(x => NumberFilters.IsBetween(x, 3, 5)).ToArray();
            Assert.Equal(new[] { 3, 4, 5 }, result);
        }
    }
}
