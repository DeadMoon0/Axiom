using Axiom.State.Actions;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public class InvokeOrchestratorResult<TState> where TState : struct
{
    private readonly StateActionGeneric _action;
    private readonly object?[] _args;
    internal readonly StateActionGeneric _successfulAction;
    internal readonly StateActionGeneric _errorAction;
    internal readonly bool _isSuccessRequired;

    public InvokeOrchestratorResult(StateActionGeneric action, object?[] args, StateActionGeneric successfulAction, StateActionGeneric errorAction, bool isSuccessRequired)
    {
        _action = action;
        _args = args;
        _successfulAction = successfulAction;
        _errorAction = errorAction;
        _isSuccessRequired = isSuccessRequired;
    }

    internal void Dispatch(StateStore<TState> store)
    {
        store.DispatchInner(_action, _args);
    }
}