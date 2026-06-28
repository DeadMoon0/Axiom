namespace Axiom.State.Actions;

internal record ParameterizedAction
{
    internal required StateActionGeneric Action { get; init; }
    internal required object?[] Parameters { get; init; }
}