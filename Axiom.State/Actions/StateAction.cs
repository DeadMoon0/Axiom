namespace Axiom.State.Actions;

public record StateAction(string name) : StateActionGeneric(name);
public record StateAction<T1>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string name) : StateActionGeneric(name);
public record StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string name) : StateActionGeneric(name);
//public record Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string name) : ActionGeneric(name); // We cannot Support this cus of the Func<...> it would need T17 with TState

public record StateActionGeneric(string name);