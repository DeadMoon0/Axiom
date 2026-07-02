using System;
using System.Collections.Generic;

namespace Axiom.State.StateCopyProviders;

public abstract class StateCloneStrategy
{
    /// <summary>
    /// Determines if this strategy can handle cloning the given type.
    /// </summary>
    public abstract bool CanHandle(Type type);

    /// <summary>
    /// Clones the value according to this strategy's rules.
    /// </summary>
    public abstract object Clone(object value, Dictionary<object, object> visited, StateCloneContext cloner);
}