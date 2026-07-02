using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Axiom.State.StateCopyProviders;

public class StateCloneContext
{
    private readonly List<StateCloneStrategy> _strategies = new();
    private readonly ConcurrentDictionary<Type, StateCloneStrategy> _strategyCache
        = new();

    /// <summary>
    /// Creates a new StructCloner with default strategies.
    /// </summary>
    public StateCloneContext()
    {
        RegisterDefaultStrategies();
    }

    /// <summary>
    /// Creates a new StructCloner and optionally registers default strategies.
    /// </summary>
    /// <param name="includeDefaults">If false, starts with an empty strategy list.</param>
    public StateCloneContext(bool includeDefaults = true)
    {
        if (includeDefaults)
            RegisterDefaultStrategies();
    }

    /// <summary>
    /// Registers the built-in default clone strategies.
    /// </summary>
    private void RegisterDefaultStrategies()
    {
        // Order matters: more specific strategies should come first
        _strategies.Add(new PrimitiveCloneStrategy());
        _strategies.Add(new StringCloneStrategy());
        _strategies.Add(new ArrayCloneStrategy());
        _strategies.Add(new ListCloneStrategy());
        _strategies.Add(new DictionaryCloneStrategy());
        _strategies.Add(new StructCloneStrategy());
        _strategies.Add(new ReferencePreserveStrategy()); // Catch-all: last
    }

    /// <summary>
    /// Registers a custom clone strategy.
    /// Custom strategies are checked BEFORE built-in strategies.
    /// </summary>
    public void RegisterStrategy(StateCloneStrategy strategy)
    {
        if (strategy == null)
            throw new ArgumentNullException(nameof(strategy));

        // Insert custom strategies near the front (before catch-all)
        _strategies.Insert(Math.Max(0, _strategies.Count - 1), strategy);
        _strategyCache.Clear(); // Invalidate cache
    }

    /// <summary>
    /// Registers multiple custom strategies at once.
    /// </summary>
    public void RegisterStrategies(params StateCloneStrategy[] strategies)
    {
        foreach (var strategy in strategies)
            RegisterStrategy(strategy);
    }

    /// <summary>
    /// Clears all strategies and re-registers defaults.
    /// </summary>
    public void ResetToDefaults()
    {
        _strategies.Clear();
        _strategyCache.Clear();
        RegisterDefaultStrategies();
    }

    /// <summary>
    /// Deep clones a value, recursively copying collections and structs
    /// while preserving references to objects.
    /// </summary>
    public T DeepClone<T>(T value)
    {
        if (value is null)
            return default!;

        var strategy = GetStrategy(typeof(T));
        return (T)strategy.Clone(value, [], this);
    }

    internal StateCloneStrategy GetStrategy(Type type)
    {
        return _strategyCache.GetOrAdd(type, t =>
        {
            // Find first strategy that can handle this type
            var matchingStrategy = _strategies.FirstOrDefault(s => s.CanHandle(t));

            if (matchingStrategy == null)
                throw new InvalidOperationException(
                    $"No clone strategy registered for type '{t.FullName}'");

            return matchingStrategy;
        });
    }
}