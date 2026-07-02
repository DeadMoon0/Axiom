using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Axiom.State.Selectors;

public delegate TSelected SelectorGetter<TState, TSelected>(TState state);
public delegate TState SelectorSetter<TState, TSelected>(TState state, TSelected selected);

public class Selector<TState, TSelected>
{
    private readonly SelectorGetter<TState, TSelected> _getter;
    private readonly SelectorSetter<TState, TSelected> _setter;

    internal Selector(SelectorGetter<TState, TSelected> getter, SelectorSetter<TState, TSelected> setter)
    {
        this._getter = getter;
        this._setter = setter;
    }

    public Selector<TState, TNextSelected> Then<TNextSelected>(Selector<TSelected, TNextSelected> subSelector) => this.Compose(subSelector);

    internal TSelected GetSelected(TState state)
    {
        try
        {
            return _getter(state);
        }
        catch (Exception)
        {
            return default!;
        }
    }
    internal TState SetSelected(TState state, TSelected selected) => _setter(state, selected);

    internal Selector<TState, TNextSelected> Compose<TNextSelected>(Selector<TSelected, TNextSelected> subSelector)
    {
        SelectorGetter<TState, TNextSelected> getter = (TState state) =>
        {
            var baseValue = this.GetSelected(state);
            return subSelector.GetSelected(baseValue);
        };
        SelectorSetter<TState, TNextSelected> setter = (TState state, TNextSelected selected) =>
        {
            var baseValue = this.GetSelected(state);
            var updatedBase = subSelector.SetSelected(baseValue, selected);
            return this.SetSelected(state, updatedBase);
        };
        return Selector.Custom(getter, setter);
    }
}

public static class Selector
{
    public static Selector<TState, TSelected> Property<TState, TSelected>(Expression<Func<TState, TSelected>> exprGetter)
    {
        return new Selector<TState, TSelected>((state) => exprGetter.Compile()(state), CompSetterFromPropertyGetter(exprGetter));
    }

    public static Selector<TState, TItem?> Index<TState, TItem>(Func<TState, TItem[]> collection, Func<TState, int> index)
    {
        static TItem? GetValueOrDefault(TItem[] items, int index)
        {
            if (index >= 0 && index < items.Length) return items[index];
            return default;
        }

        return new Selector<TState, TItem?>((state) => GetValueOrDefault(collection(state), index(state)), (state, value) =>
        {
            collection(state)[index(state)] = value!;
            return state;
        });
    }

    public static Selector<TState, TItem?> Index<TState, TItem>(Func<TState, IList<TItem>> collection, Func<TState, int> index)
    {
        return new Selector<TState, TItem?>((state) => collection(state).ElementAtOrDefault(index(state)), (state, value) =>
        {
            collection(state)[index(state)] = value!;
            return state;
        });
    }

    public static Selector<TState, TItem?> Index<TState, TItem, TKey>(Func<TState, IDictionary<TKey, TItem>> collection, Func<TState, TKey> index) where TKey : notnull
    {
        return new Selector<TState, TItem?>((state) => collection(state).TryGetValue(index(state), out TItem? value) ? value : default, (state, value) =>
        {
            collection(state)[index(state)] = value!;
            return state;
        });
    }

    public static Selector<TState, TSelected> Property<TState, TBaseSelected, TSelected>(Selector<TState, TBaseSelected> baseSelector, Expression<Func<TBaseSelected, TSelected>> exprGetter)
    {
        var subSelector = new Selector<TBaseSelected, TSelected>((SelectorGetter<TBaseSelected, TSelected>)(object)exprGetter.Compile(), CompSetterFromPropertyGetter(exprGetter));
        return baseSelector.Compose(subSelector);
    }

    public static Selector<TState, TItem?> Index<TState, TBaseSelected, TItem>(Selector<TState, TBaseSelected> baseSelector, Func<TBaseSelected, TItem[]> collection, Func<TBaseSelected, int> index)
    {
        var subSelector = Selector.Index(collection, index);
        return baseSelector.Compose(subSelector);
    }

    public static Selector<TState, TItem?> Index<TState, TBaseSelected, TItem>(Selector<TState, TBaseSelected> baseSelector, Func<TBaseSelected, IList<TItem>> collection, Func<TBaseSelected, int> index)
    {
        var subSelector = Selector.Index(collection, index);
        return baseSelector.Compose(subSelector);
    }

    public static Selector<TState, TItem?> Index<TState, TBaseSelected, TItem, TKey>(Selector<TState, TBaseSelected> baseSelector, Func<TBaseSelected, IDictionary<TKey, TItem>> collection, Func<TBaseSelected, TKey> index) where TKey : notnull
    {
        var subSelector = Selector.Index(collection, index);
        return baseSelector.Compose(subSelector);
    }

    public static Selector<TState, TSelected> Custom<TState, TSelected>(SelectorGetter<TState, TSelected> getter, SelectorSetter<TState, TSelected> setter) => new Selector<TState, TSelected>(getter, setter);
    public static Selector<TState, TSelected> Custom<TState, TBaseSelected, TSelected>(Selector<TState, TBaseSelected> baseSelector, SelectorGetter<TBaseSelected, TSelected> getter, SelectorSetter<TBaseSelected, TSelected> setter)
        => baseSelector.Compose(new Selector<TBaseSelected, TSelected>(getter, setter));

    private static SelectorSetter<TState, TSelected> CompSetterFromPropertyGetter<TState, TSelected>(Expression<Func<TState, TSelected>> expression)
    {
        var stateParam = expression.Parameters[0];
        var valueParam = Expression.Parameter(typeof(TSelected), "value");

        // Create: (state, value) => { state.Property = value; return state; }
        var assignment = Expression.Assign(expression.Body, valueParam);
        var block = Expression.Block(assignment, stateParam);

        var setterLambda = Expression.Lambda<SelectorSetter<TState, TSelected>>(
            block, stateParam, valueParam);

        return setterLambda.Compile();
    }
}