using Axiom.State.Actions;
using Axiom.State.Selectors;
using System;

namespace Axiom.State.Reducers;

internal record ReducerActionHander<TState>(StateActionGeneric Action, Func<TState, object?[], TState> Reducer);