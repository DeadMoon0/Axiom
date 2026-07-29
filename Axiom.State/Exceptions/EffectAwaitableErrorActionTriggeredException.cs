using System;

namespace Axiom.State.Exceptions;

public class EffectAwaitableErrorActionTriggeredException(string? message) : Exception(message)
{
}