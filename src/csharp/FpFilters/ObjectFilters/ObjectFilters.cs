using System;
using System.Collections.Generic;
using System.Reflection;

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

        // Checks if the object has the same property value as a comparison object
        public static bool HasSameProp(object obj, object comparisonObject, string propertyName)
        {
            if (obj == null || comparisonObject == null) return false;
            var prop = obj.GetType().GetProperty(propertyName);
            var compProp = comparisonObject.GetType().GetProperty(propertyName);
            if (prop == null || compProp == null) return false;
            return Equals(prop.GetValue(obj), compProp.GetValue(comparisonObject));
        }

        // Checks if the object has all the same property values as a comparison object
        public static bool HasSameProps(object obj, object comparisonObject, string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                if (!HasSameProp(obj, comparisonObject, propertyName)) return false;
            }
            return true;
        }

        // Negative checks
        public static bool HasNotProp(object obj, string propertyName, object? valueOrPredicate = null) => !HasProp(obj, propertyName, valueOrPredicate);
        public static bool HasNotProps(object obj, string[] propertyNames, object?[]? values = null) => !HasProps(obj, propertyNames, values);
        public static bool HasNotSameProp(object obj, object comparisonObject, string propertyName) => !HasSameProp(obj, comparisonObject, propertyName);
        public static bool HasNotSameProps(object obj, object comparisonObject, string[] propertyNames) => !HasSameProps(obj, comparisonObject, propertyNames);
        // BDD test support methods
        public static bool IsNull(object? obj) => obj == null;
        public static bool IsNotNull(object? obj) => obj != null;
        public static bool IsEqualTo(object? obj, object? comparison) => Equals(obj, comparison);
        public static bool IsNotEqualTo(object? obj, object? comparison) => !Equals(obj, comparison);
        public static bool IsReferenceEqual(object? obj, object? comparison) => ReferenceEquals(obj, comparison);
        public static bool IsReferenceNotEqual(object? obj, object? comparison) => !ReferenceEquals(obj, comparison);
    }
}
