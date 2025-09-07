namespace FpFilters.BooleanFilters.Tests
{
    public class BooleanFiltersTests
    {
        [Fact]
        public void IsTrue_ReturnsTrueForTrue()
        {
            Assert.True(BooleanFilters.IsTrue(true));
            Assert.False(BooleanFilters.IsTrue(false));
        }

        [Fact]
        public void IsFalse_ReturnsTrueForFalse()
        {
            Assert.True(BooleanFilters.IsFalse(false));
            Assert.False(BooleanFilters.IsFalse(true));
        }

        [Fact]
        public void IsTruthy_WorksForVariousTypes()
        {
            Assert.True(BooleanFilters.IsTruthy(true));
            Assert.False(BooleanFilters.IsTruthy(false));
            Assert.True(BooleanFilters.IsTruthy("abc"));
            Assert.False(BooleanFilters.IsTruthy(""));
            Assert.True(BooleanFilters.IsTruthy(1));
            Assert.False(BooleanFilters.IsTruthy(0));
            Assert.True(BooleanFilters.IsTruthy(1.0));
            Assert.False(BooleanFilters.IsTruthy(0.0));
            Assert.True(BooleanFilters.IsTruthy(new List<int> { 1 }));
            Assert.False(BooleanFilters.IsTruthy(new List<int>()));
        }

        [Fact]
        public void IsFalsey_WorksForVariousTypes()
        {
            Assert.False(BooleanFilters.IsFalsey(true));
            Assert.True(BooleanFilters.IsFalsey(false));
            Assert.False(BooleanFilters.IsFalsey("abc"));
            Assert.True(BooleanFilters.IsFalsey(""));
            Assert.False(BooleanFilters.IsFalsey(1));
            Assert.True(BooleanFilters.IsFalsey(0));
            Assert.False(BooleanFilters.IsFalsey(1.0));
            Assert.True(BooleanFilters.IsFalsey(0.0));
            Assert.False(BooleanFilters.IsFalsey(new List<int> { 1 }));
            Assert.True(BooleanFilters.IsFalsey(new List<int>()));
        }
    }
}
