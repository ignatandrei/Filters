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
        /// <returns>True if the property exists and matches the value or predicate; otherwise, false.</returns>
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
        /// <returns>A function that checks if an object has the property.</returns>
        public static Func<object, bool> HasProp(string propertyName, object? valueOrPredicate = null) => obj => HasProp(obj, propertyName, valueOrPredicate);

        /// <summary>
        /// Checks if the object has all the specified properties, optionally with values.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <returns>True if all properties exist and match the values; otherwise, false.</returns>
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
        /// <returns>A function that checks if an object has all the properties.</returns>
        public static Func<object, bool> HasProps(string[] propertyNames, object?[]? values = null) => obj => HasProps(obj, propertyNames, values);

        /// <summary>
        /// Checks if the object has the same property value as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <returns>True if the property values are the same; otherwise, false.</returns>
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
        /// <returns>A function that checks if an object has the same property value.</returns>
        public static Func<object, bool> HasSameProp(object comparisonObject, string propertyName) => obj => HasSameProp(obj, comparisonObject, propertyName);

        /// <summary>
        /// Checks if the object has all the same property values as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <returns>True if all property values are the same; otherwise, false.</returns>
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
        /// <returns>A function that checks if an object has all the same property values.</returns>
        public static Func<object, bool> HasSameProps(object comparisonObject, string[] propertyNames) => obj => HasSameProps(obj, comparisonObject, propertyNames);

        /// <summary>
        /// Checks if the object does NOT have the specified property, value, or predicate.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyName">The property name to look for.</param>
        /// <param name="valueOrPredicate">Optional value or predicate to match.</param>
        /// <returns>True if the property does not exist or does not match; otherwise, false.</returns>
        public static bool HasNotProp(object obj, string propertyName, object? valueOrPredicate = null) => !HasProp(obj, propertyName, valueOrPredicate);

        /// <summary>
        /// Returns a function that checks if an object does NOT have the specified property, value, or predicate.
        /// </summary>
        /// <param name="propertyName">The property name to look for.</param>
        /// <param name="valueOrPredicate">Optional value or predicate to match.</param>
        /// <returns>A function that checks if an object does not have the property.</returns>
        public static Func<object, bool> HasNotProp(string propertyName, object? valueOrPredicate = null) => obj => HasNotProp(obj, propertyName, valueOrPredicate);

        /// <summary>
        /// Checks if the object does NOT have all the specified properties, optionally with values.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <returns>True if any property does not exist or does not match; otherwise, false.</returns>
        public static bool HasNotProps(object obj, string[] propertyNames, object?[]? values = null) => !HasProps(obj, propertyNames, values);

        /// <summary>
        /// Returns a function that checks if an object does NOT have all the specified properties, optionally with values.
        /// </summary>
        /// <param name="propertyNames">The property names to look for.</param>
        /// <param name="values">Optional values to match for each property.</param>
        /// <returns>A function that checks if an object does not have all the properties.</returns>
        public static Func<object, bool> HasNotProps(string[] propertyNames, object?[]? values = null) => obj => HasNotProps(obj, propertyNames, values);

        /// <summary>
        /// Checks if the object does NOT have the same property value as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <returns>True if the property values are not the same; otherwise, false.</returns>
        public static bool HasNotSameProp(object obj, object comparisonObject, string propertyName) => !HasSameProp(obj, comparisonObject, propertyName);

        /// <summary>
        /// Returns a function that checks if an object does NOT have the same property value as a comparison object.
        /// </summary>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyName">The property name to compare.</param>
        /// <returns>A function that checks if an object does not have the same property value.</returns>
        public static Func<object, bool> HasNotSameProp(object comparisonObject, string propertyName) => obj => HasNotSameProp(obj, comparisonObject, propertyName);

        /// <summary>
        /// Checks if the object does NOT have all the same property values as a comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <returns>True if any property value is not the same; otherwise, false.</returns>
        public static bool HasNotSameProps(object obj, object comparisonObject, string[] propertyNames) => !HasSameProps(obj, comparisonObject, propertyNames);

        /// <summary>
        /// Returns a function that checks if an object does NOT have all the same property values as a comparison object.
        /// </summary>
        /// <param name="comparisonObject">The object to compare against.</param>
        /// <param name="propertyNames">The property names to compare.</param>
        /// <returns>A function that checks if an object does not have all the same property values.</returns>
        public static Func<object, bool> HasNotSameProps(object comparisonObject, string[] propertyNames) => obj => HasNotSameProps(obj, comparisonObject, propertyNames);

        /// <summary>
        /// Checks if the object is null.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>True if the object is null; otherwise, false.</returns>
        public static bool IsNull(object? obj) => obj == null;

        /// <summary>
        /// Checks if the object is not null.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>True if the object is not null; otherwise, false.</returns>
        public static bool IsNotNull(object? obj) => obj != null;

        /// <summary>
        /// Checks if the object is equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public static bool IsEqualTo(object? obj, object? comparison) => Equals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>A function that checks if an object is equal to the comparison object.</returns>
        public static Func<object?, bool> IsEqualTo(object? comparison) => obj => IsEqualTo(obj, comparison);

        /// <summary>
        /// Checks if the object is not equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>True if the objects are not equal; otherwise, false.</returns>
        public static bool IsNotEqualTo(object? obj, object? comparison) => !Equals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is not equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>A function that checks if an object is not equal to the comparison object.</returns>
        public static Func<object?, bool> IsNotEqualTo(object? comparison) => obj => IsNotEqualTo(obj, comparison);

        /// <summary>
        /// Checks if the object is reference equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>True if the objects are reference equal; otherwise, false.</returns>
        public static bool IsReferenceEqual(object? obj, object? comparison) => ReferenceEquals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is reference equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>A function that checks if an object is reference equal to the comparison object.</returns>
        public static Func<object?, bool> IsReferenceEqual(object? comparison) => obj => IsReferenceEqual(obj, comparison);

        /// <summary>
        /// Checks if the object is reference not equal to the comparison object.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>True if the objects are not reference equal; otherwise, false.</returns>
        public static bool IsReferenceNotEqual(object? obj, object? comparison) => !ReferenceEquals(obj, comparison);

        /// <summary>
        /// Returns a function that checks if an object is reference not equal to the comparison object.
        /// </summary>
        /// <param name="comparison">The object to compare against.</param>
        /// <returns>A function that checks if an object is not reference equal to the comparison object.</returns>
        public static Func<object?, bool> IsReferenceNotEqual(object? comparison) => obj => IsReferenceNotEqual(obj, comparison);
    }
}
