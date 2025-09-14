namespace FpFilters.Tests
{
    public class BooleanFiltersTests
    {
        [Fact]
        public void IsTrue_ReturnsTrueForTrue()
        {
            Assert.True(FpFilters.BooleanFilters.IsTrue(true));
            Assert.False(FpFilters.BooleanFilters.IsTrue(false));
        }

        [Fact]
        public void IsFalse_ReturnsTrueForFalse()
        {
            Assert.True(FpFilters.BooleanFilters.IsFalse(false));
            Assert.False(FpFilters.BooleanFilters.IsFalse(true));
        }

        [Fact]
        public void IsTruthy_WorksForVariousTypes()
        {
            Assert.True(FpFilters.BooleanFilters.IsTruthy(true));
            Assert.False(FpFilters.BooleanFilters.IsTruthy(false));
            Assert.True(FpFilters.BooleanFilters.IsTruthy("abc"));
            Assert.False(FpFilters.BooleanFilters.IsTruthy(""));
            Assert.True(FpFilters.BooleanFilters.IsTruthy(1));
            Assert.False(FpFilters.BooleanFilters.IsTruthy(0));
            Assert.True(FpFilters.BooleanFilters.IsTruthy(1.0));
            Assert.False(FpFilters.BooleanFilters.IsTruthy(0.0));
            Assert.True(FpFilters.BooleanFilters.IsTruthy(new List<int> { 1 }));
            Assert.False(FpFilters.BooleanFilters.IsTruthy(new List<int>()));
        }

        [Fact]
        public void IsFalsey_WorksForVariousTypes()
        {
            Assert.False(FpFilters.BooleanFilters.IsFalsey(true));
            Assert.True(FpFilters.BooleanFilters.IsFalsey(false));
            Assert.False(FpFilters.BooleanFilters.IsFalsey("abc"));
            Assert.True(FpFilters.BooleanFilters.IsFalsey(""));
            Assert.False(FpFilters.BooleanFilters.IsFalsey(1));
            Assert.True(FpFilters.BooleanFilters.IsFalsey(0));
            Assert.False(FpFilters.BooleanFilters.IsFalsey(1.0));
            Assert.True(FpFilters.BooleanFilters.IsFalsey(0.0));
            Assert.False(FpFilters.BooleanFilters.IsFalsey(new List<int> { 1 }));
            Assert.True(FpFilters.BooleanFilters.IsFalsey(new List<int>()));
        }
    }
}
