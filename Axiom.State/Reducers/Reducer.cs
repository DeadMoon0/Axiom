using Axiom.State.Actions;
using Axiom.State.Selectors;
using System;
using System.Collections.Generic;

namespace Axiom.State.Reducers;

public abstract partial class Reducer<TState> where TState : struct
{
    internal readonly List<ReducerActionHander<TState>> _handers = [];

    private void OnInner(StateActionGeneric action, Func<TState, object?[], TState> transformer)
    {
        _handers.Add(new ReducerActionHander<TState>(action, transformer));
    }

    private void OnInner<TSelected>(StateActionGeneric action, Func<object?[], Selector<TState, TSelected>> selector, Func<TSelected, object?[], TSelected> transformer)
    {
        _handers.Add(new ReducerActionHander<TState>(action, (state, args) => 
        {
            var _selector = selector(args);
            var selected = _selector.GetSelected(state);
            if (selected is null) return state;
            return _selector.SetSelected(state, transformer(selected, args));
        }));
    }
}