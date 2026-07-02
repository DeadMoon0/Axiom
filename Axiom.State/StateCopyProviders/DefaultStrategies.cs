using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Axiom.State.StateCopyProviders;

internal sealed class PrimitiveCloneStrategy : StateCloneStrategy
{
    private static readonly HashSet<Type> PrimitiveTypes = new()
        {
            typeof(byte), typeof(sbyte), typeof(short), typeof(ushort),
            typeof(int), typeof(uint), typeof(long), typeof(ulong),
            typeof(float), typeof(double), typeof(decimal),
            typeof(bool), typeof(char), typeof(Guid),
            typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan),
            typeof(Version)
        };

    public override bool CanHandle(Type type)
    {
        return type.IsPrimitive || PrimitiveTypes.Contains(type);
    }

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        // Primitives are copied by value
        return value;
    }
}

internal sealed class StringCloneStrategy : StateCloneStrategy
{
    public override bool CanHandle(Type type) => type == typeof(string);

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        // Strings are immutable; return as-is
        return value;
    }
}

internal sealed class ArrayCloneStrategy : StateCloneStrategy
{
    public override bool CanHandle(Type type) => type.IsArray;

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        if (value == null)
            return null!;

        var array = (Array)value;
        var elementType = array.GetType().GetElementType()!;
        var cloned = Array.CreateInstance(elementType, array.Length);
        var elementStrategy = cloner.GetStrategy(elementType);

        for (int i = 0; i < array.Length; i++)
        {
            cloned.SetValue(elementStrategy.Clone(array.GetValue(i)!, visited, cloner), i);
        }

        return cloned;
    }
}

internal sealed class ListCloneStrategy : StateCloneStrategy
{
    public override bool CanHandle(Type type)
    {
        if (!type.IsGenericType)
            return false;

        return type.GetGenericTypeDefinition() == typeof(List<>);
    }

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        if (value == null)
            return null!;

        // Prevent infinite recursion
        if (visited.TryGetValue(value, out var cached))
            return cached;

        var listType = value.GetType();
        var elementType = listType.GetGenericArguments()[0];
        var list = (IList)value;

        var cloned = (IList)Activator.CreateInstance(listType)!;
        visited[value] = cloned;

        var elementStrategy = cloner.GetStrategy(elementType);

        foreach (var item in list)
        {
            cloned.Add(elementStrategy.Clone(item, visited, cloner));
        }

        return cloned;
    }
}

internal sealed class DictionaryCloneStrategy : StateCloneStrategy
{
    public override bool CanHandle(Type type)
    {
        if (!type.IsGenericType)
            return false;

        return type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
    }

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        if (value == null)
            return null!;

        // Prevent infinite recursion
        if (visited.TryGetValue(value, out var cached))
            return cached;

        var dictType = value.GetType();
        var args = dictType.GetGenericArguments();
        var keyType = args[0];
        var valueType = args[1];
        var dict = (IDictionary)value;

        var cloned = (IDictionary)Activator.CreateInstance(dictType)!;
        visited[value] = cloned;

        var keyStrategy = cloner.GetStrategy(keyType);
        var valueStrategy = cloner.GetStrategy(valueType);

        foreach (DictionaryEntry entry in dict)
        {
            var clonedKey = keyStrategy.Clone(entry.Key, visited, cloner);
            var clonedValue = valueStrategy.Clone(entry.Value!, visited, cloner);
            cloned[clonedKey] = clonedValue;
        }

        return cloned;
    }
}

internal sealed class StructCloneStrategy : StateCloneStrategy
{
    public override bool CanHandle(Type type)
    {
        return type.IsValueType && !type.IsPrimitive && type != typeof(string);
    }

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        if (value == null)
            return null!;

        var structType = value.GetType();

        // No constructor call — create uninitialized instance
        var cloned = RuntimeHelpers.GetUninitializedObject(structType);

        var fields = structType.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in fields)
        {
            var fieldValue = field.GetValue(value);
            var fieldStrategy = cloner.GetStrategy(field.FieldType);
            var clonedFieldValue = fieldStrategy.Clone(fieldValue!, visited, cloner);
            field.SetValue(cloned, clonedFieldValue);
        }

        return cloned;
    }
}

internal sealed class ReferencePreserveStrategy : StateCloneStrategy
{
    public override bool CanHandle(Type type)
    {
        // Catch-all: handles any type not matched by other strategies
        return true;
    }

    public override object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner)
    {
        // Objects/classes are never cloned; preserve reference
        return value;
    }
}