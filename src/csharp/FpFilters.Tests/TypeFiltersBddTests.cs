using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System;

namespace FpFilters.TypeFilters.BddTests
{
    [FeatureDescription("TypeFilters: BDD scenarios for type filter functions.")]
    public class TypeFiltersFeature : FeatureFixture
    {
        private object? arg;
        private object? comparison;
        private bool result;

        private void GivenArgument(object? value) => arg = value;
        private void GivenComparison(object? value) => comparison = value;
        private void WhenIsUndefined() => result = FpFilters.TypeFilters.TypeFilters.IsUndefined(arg);
        private void WhenIsString() => result = FpFilters.TypeFilters.TypeFilters.IsString(arg);
        private void WhenIsNumber() => result = FpFilters.TypeFilters.TypeFilters.IsNumber(arg);
        private void WhenIsObject() => result = FpFilters.TypeFilters.TypeFilters.IsObject(arg);
        private void WhenIsNull() => result = FpFilters.TypeFilters.TypeFilters.IsNull(arg);
        private void WhenIsBoolean() => result = FpFilters.TypeFilters.TypeFilters.IsBoolean(arg);
        private void WhenIsDate() => result = FpFilters.TypeFilters.TypeFilters.IsDate(arg);
        private void WhenIsArray() => result = FpFilters.TypeFilters.TypeFilters.IsArray(arg);
        private void ThenResultShouldBeTrue() => Xunit.Assert.True(result);
        private void ThenResultShouldBeFalse() => Xunit.Assert.False(result);

        [Scenario]
        public void Should_check_if_argument_is_undefined()
        {
            Runner.RunScenario(
                _ => GivenArgument(null),
                _ => WhenIsUndefined(),
                _ => ThenResultShouldBeTrue()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_string()
        {
            Runner.RunScenario(
                _ => GivenArgument("hello"),
                _ => WhenIsString(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument(123),
                _ => WhenIsString(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_number()
        {
            Runner.RunScenario(
                _ => GivenArgument(123),
                _ => WhenIsNumber(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument(123.45),
                _ => WhenIsNumber(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument("123"),
                _ => WhenIsNumber(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_object()
        {
            Runner.RunScenario(
                _ => GivenArgument(new object()),
                _ => WhenIsObject(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument(123),
                _ => WhenIsObject(),
                _ => ThenResultShouldBeFalse(),
                _ => GivenArgument("string"),
                _ => WhenIsObject(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_null()
        {
            Runner.RunScenario(
                _ => GivenArgument(null),
                _ => WhenIsNull(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument("not null"),
                _ => WhenIsNull(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_boolean()
        {
            Runner.RunScenario(
                _ => GivenArgument(true),
                _ => WhenIsBoolean(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument(false),
                _ => WhenIsBoolean(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument("true"),
                _ => WhenIsBoolean(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_date()
        {
            Runner.RunScenario(
                _ => GivenArgument(DateTime.Now),
                _ => WhenIsDate(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument("2025-09-07"),
                _ => WhenIsDate(),
                _ => ThenResultShouldBeFalse()
            );
        }

        [Scenario]
        public void Should_check_if_argument_is_array()
        {
            Runner.RunScenario(
                _ => GivenArgument(new int[] { 1, 2, 3 }),
                _ => WhenIsArray(),
                _ => ThenResultShouldBeTrue(),
                _ => GivenArgument("array"),
                _ => WhenIsArray(),
                _ => ThenResultShouldBeFalse()
            );
        }
    }
}
