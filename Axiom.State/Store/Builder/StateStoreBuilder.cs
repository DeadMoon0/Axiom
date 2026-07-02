using Axiom.State.Effects;
using Axiom.State.Reducers;
using Axiom.State.StateCopyProviders;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Axiom.State.Store.Builder;

internal class StateStoreBuilder<TState> : IStateStoreBuilder<TState> where TState : struct
{
    private readonly List<Reducer<TState>> _reducers = new List<Reducer<TState>>();
    private readonly List<Effects<TState>> _effects = new List<Effects<TState>>();
    private SynchronizationContext? synchronizationContext = null;
    private StateCloneStrategy[] strategies = [];

    public IStateStoreBuilder<TState> AddCopyStrategies(params StateCloneStrategy[] strategies)
    {
        this.strategies = strategies;
        return this;
    }

    public IStateStoreBuilder<TState> AddEffects(Effects<TState> effects)
    {
        _effects.Add(effects);
        return this;
    }

    public IStateStoreBuilder<TState> AddReducer(Reducer<TState> reducer)
    {
        _reducers.Add(reducer);
        return this;
    }

    public StateStore<TState> Build()
    {
        return Build(false);
    }

    public StateStore<TState> BuildAndMakeDefault()
    {
        return Build(true);
    }

    public IStateStoreBuilder<TState> UseSynchronizationContext(SynchronizationContext context)
    {
        synchronizationContext = context;
        return this;
    }

    private StateStore<TState> Build(bool makeDefault)
    {
        return new StateStore<TState>(
            _reducers.SelectMany(x => x._handers).ToImmutableDictionary((r) => r.Action), 
            _effects.SelectMany(x => x._handers).GroupBy(x => x.Action).ToImmutableDictionary((e) => e.Key, 
            (e) => e.ToArray()), 
            synchronizationContext,
            strategies,
            makeDefault
        );
    }
}