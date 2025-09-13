namespace FpFilters.ObjectFilters
{
    public static class ObjectFilters
    {
        /// <summary>
        /// Checks if the object has the specified property, optionally with a value or predicate.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyName">The property name to look for.</param>
        /// <param name="valueOrPredicate">Optional value or predicate to match.</param>
        /// <summary>
        /// Determines whether the specified object has a property with the given name and that the property's value
        /// satisfies the provided expectation.
        /// </summary>
        /// <param name="obj">The object to inspect. Returns <c>false</c> if <paramref name="obj"/> is <c>null</c>.</param>
        /// <param name="propertyName">The name of the property to look up. Returns <c>false</c> if the property does not exist.</param>
        /// <param name="valueOrPredicate">
        /// Optional expectation for the property's value:
        /// - If <c>null</c>, the method returns <c>true</c> when the property exists and its value is not <c>null</c>.
        /// - If a <see cref="Func{Object,Boolean}"/>, the predicate is invoked with the property's value and its result is returned.
        /// - Otherwise, the property's value is compared to this argument using <see cref="object.Equals(object?, object?)"/>.
        /// </param>
        /// <returns><c>true</c> if the property exists and matches the expectation; otherwise, <c>false</c>.</returns>
        public static bool HasProp(object obj, string propertyName, object? valueOrPredicate = null)
        {
            if (obj == null) return false;
            var prop = obj.GetType().GetProperty(propertyName);
            if (prop == null) return false;
            var propertyValue = prop.GetValue(obj);
            if (valueOrPredicate == null) return propertyValue != null;
            if (valueOrPredicate is Func<object, bool> predicate)
                return predicate(propertyValue!);
            return Equals(propertyValue, valueOrPredicate);
        }

        /// <summary>
        /// Returns a function that checks if an object has the specified property, optionally with a value or predicate.
        /// </summary>
        /// <param name="propertyName">The property name to look for.</param>
        /// <param name="valueOrPredicate">Optional value or predicate to match.</param>
        /// <summary>
/// Returns a predicate that tests whether a target object has a named property and (optionally) that the property's value matches a given expectation.
/// </summary>
/// <param name="propertyName">Name of the property to check on the target object.</param>
/// <param name="valueOrPredicate">
/// Optional expectation for the property's value:
/// - If null, the predicate returns true when the property exists and its value is not null.
/// - If a <c>Func&lt;object, bool&gt;</c>, the predicate is invoked with the property value and its result is returned.
/// - Otherwise, the property's value is compared for equality with this argument.
/// </param>
/// <returns>A <c>Func&lt;object, bool&gt;</c> that applies <c>HasProp(object, string, object?)</c> to its input.</returns>
        public static Func<object, bool> HasProp(string propertyName, object? valueOrPredicate = null) => obj => HasProp(obj, propertyName, valueOrPredicate);

        /// <summary>
        /// Checks if the object has all the specified properties, optionally with values.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <summary>
        /// Determines whether the provided object has all specified properties and that each property's value satisfies the corresponding expected value or predicate.
        /// </summary>
        /// <param name="obj">The object to inspect. If null, the method returns <c>false</c>.</param>
        /// <param name="propertyNames">An array of property names to check. All names must exist on <paramref name="obj"/>.</param>
        /// <param name="values">
        /// Optional array of expected values or predicates corresponding to <paramref name="propertyNames"/>. For each index:
        /// - If the entry is <c>null</c> or the array has no entry for that index, the check only requires the property to exist and be non-null.
        /// - If the entry is a <c>Func&lt;object, bool&gt;</c>, it is invoked with the property's value and its boolean result is used.
        /// - Otherwise the property's value is compared for equality with the entry.
        /// </param>
        /// <returns><c>true</c> if every named property exists on <paramref name="obj"/> and matches its corresponding value or predicate; otherwise, <c>false</c>.</returns>
        public static bool HasProps(object obj, string[] propertyNames, object?[]? values = null)
        {
            if (obj == null) return false;
            for (int i = 0; i < propertyNames.Length; i++)
            {
                var value = values != null && i < values.Length ? values[i] : null;
                if (!HasProp(obj, propertyNames[i], value)) return false;
            }
            return true;
        }

        /// <summary>
        /// Returns a function that checks if an object has all the specified properties, optionally with values.
        /// </summary>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <summary>
/// Returns a predicate that checks whether a target object contains all specified properties and (optionally) that each property's value matches the corresponding entry in <paramref name="values"/>.
/// </summary>
/// <param name="propertyNames">Names of properties to verify on the target object.</param>
/// <param name="values">
/// Optional array of expected values or predicates corresponding to <paramref name="propertyNames"/>. If provided, each entry is used with the same rules as HasProps(object, string[], object?[]):
/// - null verifies only that the property exists and is non-null;
/// - a Func&lt;object, bool&gt; entry is invoked with the property value;
/// - otherwise the entry is compared for equality with the property value.
/// If <c>values</c> is shorter than <paramref name="propertyNames"/>, remaining properties are checked for presence only.
/// </param>
/// <returns>A function that accepts an object and returns true if all specified properties exist on that object and match the corresponding expectations.</returns>
        public static Func<object, bool> HasProps(string[] propertyNames, object?[]? values = null) => obj => HasProps(obj, propertyNames, values);

        /// <summary>
        /// Checks if the object has the same property value as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <summary>
        /// Determines whether the named property exists on both objects and their values are equal.
        /// </summary>
        /// <param name="obj">The first object whose property will be read. If null, the method returns false.</param>
        /// <param name="comparisonObject">The second object whose property will be read and compared. If null, the method returns false.</param>
        /// <param name="propertyName">The name of the property to compare on both objects.</param>
        /// <returns>True if both objects have the named property and the property values are equal; otherwise, false.</returns>
        public static bool HasSameProp(object obj, object comparisonObject, string propertyName)
        {
            if (obj == null || comparisonObject == null) return false;
            var prop = obj.GetType().GetProperty(propertyName);
            var compProp = comparisonObject.GetType().GetProperty(propertyName);
            if (prop == null || compProp == null) return false;
            return Equals(prop.GetValue(obj), compProp.GetValue(comparisonObject));
        }

        /// <summary>
        /// Returns a function that checks if an object has the same property value as a comparison object.
        /// </summary>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <summary>
/// Returns a predicate that tests whether a given object's named property equals the same property value on <paramref name="comparisonObject"/>.
/// </summary>
/// <param name="comparisonObject">The object whose property value will be used for comparison.</param>
/// <param name="propertyName">The name of the property to compare on both objects.</param>
/// <returns>A function that returns true when the input object's <paramref name="propertyName"/> exists and is equal to the corresponding property value on <paramref name="comparisonObject"/>; otherwise false.</returns>
        public static Func<object, bool> HasSameProp(object comparisonObject, string propertyName) => obj => HasSameProp(obj, comparisonObject, propertyName);

        /// <summary>
        /// Checks if the object has all the same property values as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <summary>
        /// Determines whether all specified properties exist on both objects and have equal values.
        /// </summary>
        /// <param name="obj">The object whose properties will be compared.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">An array of property names to check on both objects.</param>
        /// <returns>
        /// True if every named property exists on both objects and their values are equal; otherwise false.
        /// Returns false if either object is null or any named property is missing or not equal.
        /// </returns>
        public static bool HasSameProps(object obj, object comparisonObject, string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                if (!HasSameProp(obj, comparisonObject, propertyName)) return false;
            }
            return true;
        }

        /// <summary>
        /// Returns a function that checks if an object has all the same property values as a comparison object.
        /// </summary>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <summary>
/// Returns a predicate that checks whether a given object's specified properties have the same values as those on a reference object.
/// </summary>
/// <param name="comparisonObject">The reference object whose property values will be compared against.</param>
/// <param name="propertyNames">An array of property names to compare on both objects.</param>
/// <returns>A function that accepts an object and returns true if all named properties exist on both objects and are equal according to HasSameProps; otherwise false.</returns>
        public static Func<object, bool> HasSameProps(object comparisonObject, string[] propertyNames) => obj => HasSameProps(obj, comparisonObject, propertyNames);

        /// <summary>
        /// Checks if the object does NOT have the specified property, value, or predicate.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyName">The property name to look for.</param>
        /// <param name="valueOrPredicate">Optional value or predicate to match.</param>
        /// <summary>
/// Returns true when the specified property is missing or its value does not satisfy the given expectation.
/// This is the logical negation of <see cref="HasProp(object, string, object?)"/>.
/// </summary>
/// <param name="obj">The object to inspect; may be null.</param>
/// <param name="propertyName">The name of the property to check.</param>
/// <param name="valueOrPredicate">
/// Optional expectation for the property's value. If a Func<object, bool> is provided it will be invoked as a predicate;
/// otherwise the property's value is compared for equality with this argument. If omitted, the check verifies that the property is present and non-null.
/// </param>
/// <returns>True if the property is absent or does not match the expectation; otherwise false.</returns>
        public static bool HasNotProp(object obj, string propertyName, object? valueOrPredicate = null) => !HasProp(obj, propertyName, valueOrPredicate);

        /// <summary>
        /// Returns a function that checks if an object does NOT have the specified property, value, or predicate.
        /// </summary>
        /// <param name="propertyName">The property name to look for.</param>
        /// <param name="valueOrPredicate">Optional value or predicate to match.</param>
        /// <summary>
/// Returns a curried predicate that evaluates to the negation of HasProp for a given object.
/// </summary>
/// <param name="propertyName">The name of the property to check on the target object.</param>
/// <param name="valueOrPredicate">
/// Optional: if null the predicate returns true when the property is missing or its value is null;
/// if a Func&lt;object,bool&gt; it negates that predicate applied to the property's value;
/// otherwise it negates equality comparison between the property's value and this argument.
/// </param>
/// <returns>A Func&lt;object,bool&gt; that returns true when the target object does not satisfy the specified property condition.</returns>
        public static Func<object, bool> HasNotProp(string propertyName, object? valueOrPredicate = null) => obj => HasNotProp(obj, propertyName, valueOrPredicate);

        /// <summary>
        /// Checks if the object does NOT have all the specified properties, optionally with values.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <summary>
/// Negation of <see cref="HasProps(object,string[],object?[]?)"/>:
/// returns true when at least one named property is missing or does not match its expected value/predicate.
/// </summary>
/// <param name="obj">The object to inspect. If <c>null</c>, the method returns <c>true</c>.</param>
/// <param name="propertyNames">Array of property names to check.</param>
/// <param name="values">
/// Optional array of expected values or predicates (by index) corresponding to <paramref name="propertyNames"/>.
/// If omitted or an element is <c>null</c>, the check only requires the property to be present and non-<c>null</c>.
/// </param>
/// <returns><c>true</c> if any property is missing or does not match; otherwise, <c>false</c>.</returns>
        public static bool HasNotProps(object obj, string[] propertyNames, object?[]? values = null) => !HasProps(obj, propertyNames, values);

        /// <summary>
        /// Returns a function that checks if an object does NOT have all the specified properties, optionally with values.
        /// </summary>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <summary>
/// Returns a predicate that evaluates to true when the target object does not satisfy
/// all of the specified property checks (existence or value/predicate match).
/// </summary>
/// <param name="propertyNames">Names of properties to check on the target object.</param>
/// <param name="values">
/// Optional parallel array of expected values or predicates (Func&lt;object, bool&gt;) for each property.
/// If omitted or an entry is null, that property is treated as a presence check (non-null value).
/// </param>
/// <returns>A function that accepts an object and returns true if any specified property is missing or fails its corresponding check.</returns>
        public static Func<object, bool> HasNotProps(string[] propertyNames, object?[]? values = null) => obj => HasNotProps(obj, propertyNames, values);

        /// <summary>
        /// Checks if the object does NOT have the same property value as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <summary>
/// Returns true when the value of the specified property differs between two objects.
/// </summary>
/// <param name="obj">First object whose property will be inspected. If null, the method returns false.</param>
/// <param name="comparisonObject">Second object to compare against. If null, the method returns false.</param>
/// <param name="propertyName">Name of the property to compare on both objects. If the property is not present on either object, the method returns false.</param>
/// <returns>True if the two objects do not have the same value for the named property; otherwise, false.</returns>
        public static bool HasNotSameProp(object obj, object comparisonObject, string propertyName) => !HasSameProp(obj, comparisonObject, propertyName);

        /// <summary>
        /// Returns a function that checks if an object does NOT have the same property value as a comparison object.
        /// </summary>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <summary>
/// Returns a predicate that verifies the specified object's named property is not equal to the same property on <paramref name="comparisonObject"/>.
/// </summary>
/// <param name="comparisonObject">The object whose property value will be compared against.</param>
/// <param name="propertyName">The name of the property to compare.</param>
/// <returns>
/// A function that takes an object and returns true when the object's <paramref name="propertyName"/> value is not equal to the value of the same property on <paramref name="comparisonObject"/>.
/// If either object is null or the property is missing on either object, the predicate will return true (the logical negation of the corresponding equality check).
/// </returns>
        public static Func<object, bool> HasNotSameProp(object comparisonObject, string propertyName) => obj => HasNotSameProp(obj, comparisonObject, propertyName);

        /// <summary>
        /// Checks if the object does NOT have all the same property values as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <summary>
/// Returns true when at least one of the specified properties differs between <paramref name="obj"/> and <paramref name="comparisonObject"/>.
/// </summary>
/// <param name="obj">The object whose properties will be compared.</param>
/// <param name="comparisonObject">The object to compare against.</param>
/// <param name="propertyNames">An array of property names to compare on both objects.</param>
/// <returns>True if any named property values are not equal (or if comparison cannot be performed); otherwise false.</returns>
        public static bool HasNotSameProps(object obj, object comparisonObject, string[] propertyNames) => !HasSameProps(obj, comparisonObject, propertyNames);

        /// <summary>
        /// Returns a function that checks if an object does NOT have all the same property values as a comparison object.
        /// </summary>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <summary>
/// Returns a predicate that tests whether a target object does not have the same values for all specified properties as <paramref name="comparisonObject"/>.
/// </summary>
/// <param name="comparisonObject">The object to compare property values against.</param>
/// <param name="propertyNames">The names of the properties to compare.</param>
/// <returns>A <see cref="Func{T, TResult}"/> that accepts an object and returns true when at least one named property is missing or has a different value than on <paramref name="comparisonObject"/>; otherwise false.</returns>
        public static Func<object, bool> HasNotSameProps(object comparisonObject, string[] propertyNames) => obj => HasNotSameProps(obj, comparisonObject, propertyNames);

        /// <summary>
        /// Checks if the object is null.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <summary>
/// Returns true when the provided object reference is null.
/// </summary>
/// <param name="obj">The object to test for null.</param>
/// <returns>True if <paramref name="obj"/> is null; otherwise false.</returns>
        public static bool IsNull(object? obj) => obj == null;

        /// <summary>
        /// Checks if the object is not null.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <summary>
/// Returns true when the provided object is not null.
/// </summary>
/// <param name="obj">The object to test for non-nullity.</param>
/// <returns>True if <paramref name="obj"/> is not null; otherwise, false.</returns>
        public static bool IsNotNull(object? obj) => obj != null;

        /// <summary>
        /// Checks if the object is equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Determines whether the specified object is equal to the provided comparison value using <see cref="object.Equals(object?, object?)"/>.
/// </summary>
/// <param name="obj">The first value to compare (may be null).</param>
/// <param name="comparison">The second value to compare against (may be null).</param>
/// <returns>True if the two values are equal; otherwise, false.</returns>
        public static bool IsEqualTo(object? obj, object? comparison) => Equals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether its input is equal to the provided comparison value using object equality.
/// </summary>
/// <param name="comparison">The value to compare against.</param>
/// <returns>A function that returns true when its argument is equal to <paramref name="comparison"/>; otherwise false.</returns>
        public static Func<object?, bool> IsEqualTo(object? comparison) => obj => IsEqualTo(obj, comparison);

        /// <summary>
        /// Checks if the object is not equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Determines whether two objects are not equal using <see cref="object.Equals(object?, object?)"/> semantics.
/// </summary>
/// <param name="obj">The first object to compare; may be null.</param>
/// <param name="comparison">The object to compare against; may be null.</param>
/// <returns>true if the two objects are not equal; otherwise, false.</returns>
        public static bool IsNotEqualTo(object? obj, object? comparison) => !Equals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is not equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Creates a predicate that returns true when its input is not equal to the provided comparison value.
/// </summary>
/// <param name="comparison">Value to compare against.</param>
/// <returns>A function that returns true if the argument is not equal to <paramref name="comparison"/>.</returns>
        public static Func<object?, bool> IsNotEqualTo(object? comparison) => obj => IsNotEqualTo(obj, comparison);

        /// <summary>
        /// Checks if the object is reference equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Determines whether two object references refer to the same instance.
/// </summary>
/// <param name="obj">First object to compare (may be null).</param>
/// <param name="comparison">Second object to compare (may be null).</param>
/// <returns><c>true</c> if both references refer to the exact same object (or both are null); otherwise, <c>false</c>.</returns>
        public static bool IsReferenceEqual(object? obj, object? comparison) => ReferenceEquals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is reference equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Returns a function that tests whether its input is the same object reference as the provided <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The object to compare references against (may be null).</param>
/// <returns>A function that returns <c>true</c> when its argument is reference-equal to <paramref name="comparison"/>, otherwise <c>false</c>.</returns>
        public static Func<object?, bool> IsReferenceEqual(object? comparison) => obj => IsReferenceEqual(obj, comparison);

        /// <summary>
        /// Checks if the object is reference not equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Determines whether two object references are not the same instance.
/// </summary>
/// <param name="obj">The first object reference to compare.</param>
/// <param name="comparison">The second object reference to compare against.</param>
/// <returns>True if the references are different; otherwise, false.</returns>
        public static bool IsReferenceNotEqual(object? obj, object? comparison) => !ReferenceEquals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is reference not equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <summary>
/// Returns a predicate that tests whether a given object is not the same reference as <paramref name="comparison"/>.
/// </summary>
/// <param name="comparison">The object to compare references against; may be null.</param>
/// <returns>A function that accepts an object and returns true if that object is not reference-equal to <paramref name="comparison"/>.</returns>
        public static Func<object?, bool> IsReferenceNotEqual(object? comparison) => obj => IsReferenceNotEqual(obj, comparison);
    }
}
