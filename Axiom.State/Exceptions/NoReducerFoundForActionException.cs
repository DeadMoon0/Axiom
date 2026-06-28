using Axiom.State.Actions;
using System;

namespace Axiom.State.Exceptions;

public class NoReducerFoundForActionException(StateActionGeneric action, Exception? innerException = null) : Exception($"No reducer registered for Action: {action.Name}", innerException);