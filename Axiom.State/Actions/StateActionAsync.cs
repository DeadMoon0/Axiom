// Generated Output
using System;

namespace Axiom.State.Actions;

public sealed record StateActionAsync<TResult> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction(StateActionAsync<TResult> a) => a.BeginAction;

    public override StateAction BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult : StateActionAsyncGeneric
{
    public static implicit operator StateAction(StateActionAsyncNoResult a) => a.BeginAction;

    public override StateAction BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1>(StateActionAsync<TResult, T1> a) => a.BeginAction;

    public override StateAction<T1> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1>(StateActionAsyncNoResult<T1> a) => a.BeginAction;

    public override StateAction<T1> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2>(StateActionAsync<TResult, T1, T2> a) => a.BeginAction;

    public override StateAction<T1, T2> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2>(StateActionAsyncNoResult<T1, T2> a) => a.BeginAction;

    public override StateAction<T1, T2> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3>(StateActionAsync<TResult, T1, T2, T3> a) => a.BeginAction;

    public override StateAction<T1, T2, T3> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3>(StateActionAsyncNoResult<T1, T2, T3> a) => a.BeginAction;

    public override StateAction<T1, T2, T3> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4>(StateActionAsync<TResult, T1, T2, T3, T4> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4>(StateActionAsyncNoResult<T1, T2, T3, T4> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5>(StateActionAsync<TResult, T1, T2, T3, T4, T5> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5>(StateActionAsyncNoResult<T1, T2, T3, T4, T5> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

public sealed record StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : StateActionAsyncGeneric<TResult>
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(StateActionAsync<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> BeginAction { get; }
    public override StateAction<TResult> SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsync(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}
public sealed record StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : StateActionAsyncGeneric
{
    public static implicit operator StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(StateActionAsyncNoResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a) => a.BeginAction;

    public override StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> BeginAction { get; }
    public override StateAction SuccessAction { get; }
    public override StateAction<Exception> ErrorAction { get; }

    public StateActionAsyncNoResult(string area, string simpleName, bool dontReduceBegin = false, bool dontReduceSuccess = false, bool dontReduceError = false)
    { 
        string baseName = "[" + area + "] " + TrimSimpleName(simpleName);
        BeginAction = new(baseName + "Action", dontReduceBegin);
        SuccessAction = new(baseName + "SuccessAction", dontReduceSuccess);
        ErrorAction = new(baseName + "ErrorAction", dontReduceError);
    }
}

