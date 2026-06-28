using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public abstract partial class Effects<TState> where TState : struct
{
    internal readonly List<EffectActionHandler<TState>> _handers = [];

    protected void On(Actions.StateActionGeneric action, Effect<TState> effect) => _handers.Add(new EffectActionHandler<TState>(action, effect));

    protected Effect<TState> Effect<T>(Func<TState, Task<T>> action, Func<T, EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return new Effect<TState>(async (s) => (await action(s))!, (o) => onSuccess((T)o), onError);
    }
}