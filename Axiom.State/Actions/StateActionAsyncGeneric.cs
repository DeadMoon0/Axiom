using System;

namespace Axiom.State.Actions;

public abstract record StateActionAsyncGeneric<TResult>
{
    public abstract StateActionGeneric BeginAction { get; }
    public abstract StateActionGeneric SuccessAction { get; }
    public abstract StateActionGeneric ErrorAction { get; }

    protected static string TrimSimpleName(string name)
    {
        foreach (string trim in (string[])["Action", "AsyncAction", "ActionAsync"])
        {
            if (name.EndsWith(trim))
            {
                return name[..^trim.Length];
            }
        }
        return name;
    }
}

public abstract record StateActionAsyncGeneric
{
    public abstract StateActionGeneric BeginAction { get; }
    public abstract StateActionGeneric SuccessAction { get; }
    public abstract StateActionGeneric ErrorAction { get; }

    protected static string TrimSimpleName(string name)
    {
        foreach (string trim in (string[])["Action", "AsyncAction", "ActionAsync"])
        {
            if (name.EndsWith(trim))
            {
                return name[..^trim.Length];
            }
        }
        return name;
    }
}