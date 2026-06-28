// Generated Output
namespace Axiom.State;

public partial class StateStore<TState> where TState : struct
{
    public void Dispatch(Actions.StateAction action) => DispatchInner(action, []);

    public void Dispatch<T1>(Actions.StateAction<T1> action, T1 arg1) => DispatchInner(action, [arg1]);

    public void Dispatch<T1, T2>(Actions.StateAction<T1, T2> action, T1 arg1, T2 arg2) => DispatchInner(action, [arg1, arg2]);

    public void Dispatch<T1, T2, T3>(Actions.StateAction<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3) => DispatchInner(action, [arg1, arg2, arg3]);

    public void Dispatch<T1, T2, T3, T4>(Actions.StateAction<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => DispatchInner(action, [arg1, arg2, arg3, arg4]);

    public void Dispatch<T1, T2, T3, T4, T5>(Actions.StateAction<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5]);

    public void Dispatch<T1, T2, T3, T4, T5, T6>(Actions.StateAction<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14]);

    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) => DispatchInner(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15]);

}
