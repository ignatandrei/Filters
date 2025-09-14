namespace FpFilters.Tests
{
    public class ObjectFiltersTests
    {
        public class TestObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public bool Flag { get; set; }
        }

        [Fact]
        public void HasProp_ReturnsTrueForExistingProp()
        {
            var obj = new TestObj { Id = 1, Name = "Test", Flag = true };
            Assert.True(FpFilters.ObjectFilters.HasProp(obj, "Id"));
            Assert.True(FpFilters.ObjectFilters.HasProp(obj, "Name"));
            Assert.False(FpFilters.ObjectFilters.HasProp(obj, "NonExistent"));
        }

        [Fact]
        public void HasProp_ReturnsTrueForMatchingValue()
        {
            var obj = new TestObj { Id = 1, Name = "Test", Flag = true };
            Assert.True(FpFilters.ObjectFilters.HasProp(obj, "Id", 1));
            Assert.False(FpFilters.ObjectFilters.HasProp(obj, "Id", 2));
        }

        [Fact]
        public void HasProp_ReturnsTrueForPredicate()
        {
            var obj = new TestObj { Id = 1, Name = "Test", Flag = true };
            Assert.True(FpFilters.ObjectFilters.HasProp(obj, "Id", (object v) => (int)v == 1));
            Assert.False(FpFilters.ObjectFilters.HasProp(obj, "Id", (object v) => (int)v == 2));
        }

        [Fact]
        public void HasProps_ReturnsTrueForAllProps()
        {
            var obj = new TestObj { Id = 1, Name = "Test", Flag = true };
            Assert.True(FpFilters.ObjectFilters.HasProps(obj, new[] { "Id", "Name" }, new object?[] { 1, "Test" }));
            Assert.False(FpFilters.ObjectFilters.HasProps(obj, new[] { "Id", "Name" }, new object?[] { 2, "Test" }));
        }

        [Fact]
        public void HasSameProp_ReturnsTrueForSameValue()
        {
            var obj1 = new TestObj { Id = 1, Name = "Test" };
            var obj2 = new TestObj { Id = 1, Name = "Test" };
            Assert.True(FpFilters.ObjectFilters.HasSameProp(obj1, obj2, "Id"));
            Assert.True(FpFilters.ObjectFilters.HasSameProp(obj1, obj2, "Name"));
            obj2.Id = 2;
            Assert.False(FpFilters.ObjectFilters.HasSameProp(obj1, obj2, "Id"));
        }

        [Fact]
        public void HasSameProps_ReturnsTrueForAllSameValues()
        {
            var obj1 = new TestObj { Id = 1, Name = "Test" };
            var obj2 = new TestObj { Id = 1, Name = "Test" };
            Assert.True(FpFilters.ObjectFilters.HasSameProps(obj1, obj2, new[] { "Id", "Name" }));
            obj2.Id = 2;
            Assert.False(FpFilters.ObjectFilters.HasSameProps(obj1, obj2, new[] { "Id", "Name" }));
        }

        [Fact]
        public void NegativeChecks_WorkCorrectly()
        {
            var obj1 = new TestObj { Id = 1, Name = "Test" };
            var obj2 = new TestObj { Id = 2, Name = "Test2" };
            Assert.True(FpFilters.ObjectFilters.HasNotProp(obj1, "Id", 2));
            Assert.True(FpFilters.ObjectFilters.HasNotProps(obj1, new[] { "Id", "Name" }, new object?[] { 2, "Test2" }));
            Assert.True(FpFilters.ObjectFilters.HasNotSameProp(obj1, obj2, "Id"));
            Assert.True(FpFilters.ObjectFilters.HasNotSameProps(obj1, obj2, new[] { "Id", "Name" }));
        }
    }
}
