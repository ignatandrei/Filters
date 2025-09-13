namespace FpFilters.ObjectFilters.BddTests
{
    [FeatureDescription("ObjectFilters: BDD scenarios for object filter functions.")]
    public class ObjectFiltersFeature : FeatureFixture
    {
        private object? arg;
        private object? comparison;
        private bool result;

        private void GivenObject(object? value) => arg = value;
        private void GivenComparison(object value) => comparison = value;
        private void WhenIsNull() => result = FpFilters.ObjectFilters.ObjectFilters.IsNull(arg);
        private void WhenIsNotNull() => result = FpFilters.ObjectFilters.ObjectFilters.IsNotNull(arg);
        private void WhenIsEqualTo() => result = FpFilters.ObjectFilters.ObjectFilters.IsEqualTo(arg, comparison);
        private void WhenIsNotEqualTo() => result = FpFilters.ObjectFilters.ObjectFilters.IsNotEqualTo(arg, comparison);
        private void WhenIsReferenceEqual() => result = FpFilters.ObjectFilters.ObjectFilters.IsReferenceEqual(arg, comparison);
        private void WhenIsReferenceNotEqual() => result = FpFilters.ObjectFilters.ObjectFilters.IsReferenceNotEqual(arg, comparison);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_object_is_null()
        {
            Runner.RunScenario(
                _ => GivenObject(null),
                _ => WhenIsNull(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject("not null"),
                _ => WhenIsNull(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_object_is_not_null()
        {
            Runner.RunScenario(
                _ => GivenObject("not null"),
                _ => WhenIsNotNull(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(null),
                _ => WhenIsNotNull(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_equal()
        {
            Runner.RunScenario(
                _ => GivenObject(5),
                _ => GivenComparison(5),
                _ => WhenIsEqualTo(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(5),
                _ => GivenComparison(6),
                _ => WhenIsEqualTo(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_not_equal()
        {
            Runner.RunScenario(
                _ => GivenObject(5),
                _ => GivenComparison(6),
                _ => WhenIsNotEqualTo(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(5),
                _ => GivenComparison(5),
                _ => WhenIsNotEqualTo(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_reference_equal()
        {
            var obj = new object();
            Runner.RunScenario(
                _ => GivenObject(obj),
                _ => GivenComparison(obj),
                _ => WhenIsReferenceEqual(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(new object()),
                _ => GivenComparison(new object()),
                _ => WhenIsReferenceEqual(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_objects_are_reference_not_equal()
        {
            var obj = new object();
            Runner.RunScenario(
                _ => GivenObject(new object()),
                _ => GivenComparison(new object()),
                _ => WhenIsReferenceNotEqual(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenObject(obj),
                _ => GivenComparison(obj),
                _ => WhenIsReferenceNotEqual(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_HasProp_linq()
        {
            var obj = new { Name = "Test", Value = 42 };
            var hasName = FpFilters.ObjectFilters.ObjectFilters.HasProp("Name");
            Xunit.Assert.True(hasName(obj));
            var hasValue42 = FpFilters.ObjectFilters.ObjectFilters.HasProp("Value", 42);
            Xunit.Assert.True(hasValue42(obj));
            var hasValue43 = FpFilters.ObjectFilters.ObjectFilters.HasProp("Value", 43);
            Xunit.Assert.False(hasValue43(obj));
        }

        [Scenario]
        public void Should_check_HasProps_linq()
        {
            var obj = new { Name = "Test", Value = 42 };
            var hasBoth = FpFilters.ObjectFilters.ObjectFilters.HasProps(new[] { "Name", "Value" });
            Xunit.Assert.True(hasBoth(obj));
            var hasBothWithValues = FpFilters.ObjectFilters.ObjectFilters.HasProps(new[] { "Name", "Value" }, new object?[] { "Test", 42 });
            Xunit.Assert.True(hasBothWithValues(obj));
            var hasBothWithWrongValues = FpFilters.ObjectFilters.ObjectFilters.HasProps(new[] { "Name", "Value" }, new object?[] { "Test", 43 });
            Xunit.Assert.False(hasBothWithWrongValues(obj));
        }

        [Scenario]
        public void Should_check_HasSameProp_linq()
        {
            var obj1 = new { Name = "Test" };
            var obj2 = new { Name = "Test" };
            var obj3 = new { Name = "Other" };
            var hasSameName = FpFilters.ObjectFilters.ObjectFilters.HasSameProp(obj2, "Name");
            Xunit.Assert.True(hasSameName(obj1));
            Xunit.Assert.False(hasSameName(obj3));
        }

        [Scenario]
        public void Should_check_HasSameProps_linq()
        {
            var obj1 = new { Name = "Test", Value = 42 };
            var obj2 = new { Name = "Test", Value = 42 };
            var obj3 = new { Name = "Test", Value = 43 };
            var hasSameBoth = FpFilters.ObjectFilters.ObjectFilters.HasSameProps(obj2, new[] { "Name", "Value" });
            Xunit.Assert.True(hasSameBoth(obj1));
            Xunit.Assert.False(hasSameBoth(obj3));
        }

        [Scenario]
        public void Should_check_HasNotProp_linq()
        {
            var obj = new { Name = "Test", Value = 42 };
            var hasNotName = FpFilters.ObjectFilters.ObjectFilters.HasNotProp("Name");
            Xunit.Assert.False(hasNotName(obj));
            var hasNotValue43 = FpFilters.ObjectFilters.ObjectFilters.HasNotProp("Value", 43);
            Xunit.Assert.True(hasNotValue43(obj));
        }

        [Scenario]
        public void Should_check_HasNotProps_linq()
        {
            var obj = new { Name = "Test", Value = 42 };
            var hasNotBoth = FpFilters.ObjectFilters.ObjectFilters.HasNotProps(new[] { "Name", "Value" });
            Xunit.Assert.False(hasNotBoth(obj));
            var hasNotBothWithWrongValues = FpFilters.ObjectFilters.ObjectFilters.HasNotProps(new[] { "Name", "Value" }, new object?[] { "Test", 43 });
            Xunit.Assert.True(hasNotBothWithWrongValues(obj));
        }

        [Scenario]
        public void Should_check_HasNotSameProp_linq()
        {
            var obj1 = new { Name = "Test" };
            var obj2 = new { Name = "Test" };
            var obj3 = new { Name = "Other" };
            var hasNotSameName = FpFilters.ObjectFilters.ObjectFilters.HasNotSameProp(obj2, "Name");
            Xunit.Assert.False(hasNotSameName(obj1));
            Xunit.Assert.True(hasNotSameName(obj3));
        }

        [Scenario]
        public void Should_check_HasNotSameProps_linq()
        {
            var obj1 = new { Name = "Test", Value = 42 };
            var obj2 = new { Name = "Test", Value = 42 };
            var obj3 = new { Name = "Test", Value = 43 };
            var hasNotSameBoth = FpFilters.ObjectFilters.ObjectFilters.HasNotSameProps(obj2, new[] { "Name", "Value" });
            Xunit.Assert.False(hasNotSameBoth(obj1));
            Xunit.Assert.True(hasNotSameBoth(obj3));
        }

        [Scenario]
        public void Should_check_IsEqualTo_linq()
        {
            var is42 = FpFilters.ObjectFilters.ObjectFilters.IsEqualTo(42);
            Xunit.Assert.True(is42(42));
            Xunit.Assert.False(is42(43));
            var isStr = FpFilters.ObjectFilters.ObjectFilters.IsEqualTo("abc");
            Xunit.Assert.True(isStr("abc"));
            Xunit.Assert.False(isStr("def"));
        }

        [Scenario]
        public void Should_check_IsNotEqualTo_linq()
        {
            var isNot42 = FpFilters.ObjectFilters.ObjectFilters.IsNotEqualTo(42);
            Xunit.Assert.True(isNot42(43));
            Xunit.Assert.False(isNot42(42));
            var isNotStr = FpFilters.ObjectFilters.ObjectFilters.IsNotEqualTo("abc");
            Xunit.Assert.True(isNotStr("def"));
            Xunit.Assert.False(isNotStr("abc"));
        }

        [Scenario]
        public void Should_check_IsReferenceEqual_linq()
        {
            var obj = new object();
            var isRefEq = FpFilters.ObjectFilters.ObjectFilters.IsReferenceEqual(obj);
            Xunit.Assert.True(isRefEq(obj));
            Xunit.Assert.False(isRefEq(new object()));
        }

        [Scenario]
        public void Should_check_IsReferenceNotEqual_linq()
        {
            var obj = new object();
            var isRefNotEq = FpFilters.ObjectFilters.ObjectFilters.IsReferenceNotEqual(obj);
            Xunit.Assert.False(isRefNotEq(obj));
            Xunit.Assert.True(isRefNotEq(new object()));
        }
    }
}
