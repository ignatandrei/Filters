namespace FpFilters.ObjectFilters
{
    public static class ObjectFilters
    {
        // Checks if the object has the specified property, optionally with a value or predicate
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
        public static Func<object, bool> HasProp(string propertyName, object? valueOrPredicate = null) => obj => HasProp(obj, propertyName, valueOrPredicate);

        // Checks if the object has all the specified properties, optionally with values
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
        public static Func<object, bool> HasProps(string[] propertyNames, object?[]? values = null) => obj => HasProps(obj, propertyNames, values);

        // Checks if the object has the same property value as a comparison object
        public static bool HasSameProp(object obj, object comparisonObject, string propertyName)
        {
            if (obj == null || comparisonObject == null) return false;
            var prop = obj.GetType().GetProperty(propertyName);
            var compProp = comparisonObject.GetType().GetProperty(propertyName);
            if (prop == null || compProp == null) return false;
            return Equals(prop.GetValue(obj), compProp.GetValue(comparisonObject));
        }
        public static Func<object, bool> HasSameProp(object comparisonObject, string propertyName) => obj => HasSameProp(obj, comparisonObject, propertyName);

        // Checks if the object has all the same property values as a comparison object
        public static bool HasSameProps(object obj, object comparisonObject, string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                if (!HasSameProp(obj, comparisonObject, propertyName)) return false;
            }
            return true;
        }
        public static Func<object, bool> HasSameProps(object comparisonObject, string[] propertyNames) => obj => HasSameProps(obj, comparisonObject, propertyNames);

        // Negative checks
        public static bool HasNotProp(object obj, string propertyName, object? valueOrPredicate = null) => !HasProp(obj, propertyName, valueOrPredicate);
        public static Func<object, bool> HasNotProp(string propertyName, object? valueOrPredicate = null) => obj => HasNotProp(obj, propertyName, valueOrPredicate);

        public static bool HasNotProps(object obj, string[] propertyNames, object?[]? values = null) => !HasProps(obj, propertyNames, values);
        public static Func<object, bool> HasNotProps(string[] propertyNames, object?[]? values = null) => obj => HasNotProps(obj, propertyNames, values);

        public static bool HasNotSameProp(object obj, object comparisonObject, string propertyName) => !HasSameProp(obj, comparisonObject, propertyName);
        public static Func<object, bool> HasNotSameProp(object comparisonObject, string propertyName) => obj => HasNotSameProp(obj, comparisonObject, propertyName);

        public static bool HasNotSameProps(object obj, object comparisonObject, string[] propertyNames) => !HasSameProps(obj, comparisonObject, propertyNames);
        public static Func<object, bool> HasNotSameProps(object comparisonObject, string[] propertyNames) => obj => HasNotSameProps(obj, comparisonObject, propertyNames);

        // BDD test support methods
        public static bool IsNull(object? obj) => obj == null;
        public static bool IsNotNull(object? obj) => obj != null;
        public static bool IsEqualTo(object? obj, object? comparison) => Equals(obj, comparison);
        public static Func<object?, bool> IsEqualTo(object? comparison) => obj => IsEqualTo(obj, comparison);
        public static bool IsNotEqualTo(object? obj, object? comparison) => !Equals(obj, comparison);
        public static Func<object?, bool> IsNotEqualTo(object? comparison) => obj => IsNotEqualTo(obj, comparison);
        public static bool IsReferenceEqual(object? obj, object? comparison) => ReferenceEquals(obj, comparison);
        public static Func<object?, bool> IsReferenceEqual(object? comparison) => obj => IsReferenceEqual(obj, comparison);
        public static bool IsReferenceNotEqual(object? obj, object? comparison) => !ReferenceEquals(obj, comparison);
        public static Func<object?, bool> IsReferenceNotEqual(object? comparison) => obj => IsReferenceNotEqual(obj, comparison);
    }
}
