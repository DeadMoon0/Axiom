using Axiom.State.Actions;
using Axiom.State.Selectors;
using System;
using System.Collections.Generic;

namespace Axiom.State.Reducers;

public partial class ReducerScope<TState, TBase> where TState : struct where TBase : struct
{
    internal readonly List<ReducerActionHander<TBase>> _handers;

    private readonly Selector<TBase, TState> _selector;

    internal ReducerScope(Selector<TBase, TState> selector, List<ReducerActionHander<TBase>> handers)
    {
        _selector = selector;
        _handers = handers;
    }

    public ReducerScope<TSelected, TBase> Scope<TSelected>(Selector<TState, TSelected> selector) where TSelected : struct
    {
        return new ReducerScope<TSelected, TBase>(_selector.Then(selector), _handers);
    }

    internal ReducerScope<TState, TBase> OnInner(StateActionGeneric action, Func<TState, object?[], TState> transformer)
    {
        _handers.Add(new ReducerActionHander<TBase>(action, (state, args) =>
        {
            var selected = _selector.GetSelected(state);
            return _selector.SetSelected(state, transformer(selected, args));
        }));
        return this;
    }

    internal ReducerScope<TState, TBase> OnInner<TSelected>(StateActionGeneric action, Func<object?[], Selector<TState, TSelected>> selector, Func<TSelected, object?[], TSelected> transformer)
    {
        _handers.Add(new ReducerActionHander<TBase>(action, (state, args) =>
        {
            var __selector = _selector.Then(selector(args));
            var selected = __selector.GetSelected(state);
            if (selected is null) return state;
            return __selector.SetSelected(state, transformer(selected, args));
        }));
        return this;
    }
}