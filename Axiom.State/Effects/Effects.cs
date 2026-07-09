using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public abstract partial class Effects<TState> where TState : struct
{
    internal readonly List<EffectActionHandler<TState>> _handers = [];

    protected void On(Actions.StateActionGeneric action, Effect<TState> effect) => _handers.Add(effect.GetHandler(action));

    protected EffectResult<TState> DoNothing() => new EffectResult<TState>(null, []);

    protected Effect<TState> Effect<T>(Func<TState, Task<T>> action, Func<T, EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return new ActionEffect<TState>(async (s) => (await action(s))!, (o) => onSuccess((T)o), onError);
    }

    protected Effect<TState> Effect(Func<TState, Task> action, Func<EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return new ActionEffect<TState>(async (s) => (await action(s).ContinueWith(t => (object?)null))!, (o) => onSuccess(), onError);
    }

    protected Effect<TState> Orchestrate(Func<TState, InvokeOrchestratorResult<TState>>[] actions, Func<TState, EffectResult<TState>> onSuccess, Func<TState, EffectResult<TState>> onError)
    {
        return new OrchestratorEffect<TState>(actions, onSuccess, onError);
    }
}