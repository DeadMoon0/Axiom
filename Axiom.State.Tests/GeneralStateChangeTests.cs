using Axiom.State.Actions;
using Axiom.State.Reducers;
using System.Diagnostics;
using System.Reactive.Disposables.Fluent;

namespace Axiom.State.Tests;

public class GeneralStateChangeTests
{
    private record struct SimpleState()
    {
        public int A = 1;
        public int B = 2;
        public int C = 3;
    }

    private static StateAction<int> AddToAAction = new ("[SimpleState] Add to A");
    private static StateAction<int> AddToBAction = new ("[SimpleState] Add to B");
    private static StateAction<int> AddToCAction = new ("[SimpleState] Add to C");

    private class SimpleStateReducer : Reducer<SimpleState>
    {
        public SimpleStateReducer()
        {
            On(AddToAAction, (state, n) =>
            {
                return state with 
                { 
                    A = state.A + n 
                };
            });
            On(AddToBAction, (state, n) =>
            {
                return state with 
                { 
                    B = state.B + n 
                };
            });
            On(AddToCAction, (state, n) =>
            {
                return state with 
                { 
                    C = state.C + n 
                };
            });
        }
    }

    [Fact]
    public void SingleStateChange()
    {
        StateStore<SimpleState> store = StateStore<SimpleState>.Create()
            .AddReducer(new SimpleStateReducer())
            .Build();

        Debug.Equals(store.GetValue(state => state.A), 1);
        store.Dispatch(AddToAAction, 10);
        Debug.Equals(store.GetValue(state => state.A), 11);
    }

    [Fact]
    public async Task SingleStateChangeObservable()
    {
        TaskCompletionSource<int> tcsInit = new();
        TaskCompletionSource<int> tcsChange = new();
        bool hadInit = false;

        StateStore<SimpleState> store = StateStore<SimpleState>.Create()
            .AddReducer(new SimpleStateReducer())
            .Build();

        Debug.Equals(store.GetValue(state => state.A), 1);
        store.Bind((state) => state.A).Subscribe(n =>
        {
            if (hadInit) tcsChange.SetResult(n);
            else tcsInit.SetResult(n);
            hadInit = true;
        }, (e) => throw e, () => { });
        store.Dispatch(AddToAAction, 10);

        Debug.Equals(await tcsInit.Task, 1);
        Debug.Equals(await tcsChange.Task, 11);
    }

    [Fact]
    public async Task SingleStateChangeObservableMulti()
    {
        TaskCompletionSource<int> tcs1Init = new();
        TaskCompletionSource<int> tcs1Change = new();
        TaskCompletionSource<int> tcs2Init = new();
        TaskCompletionSource<int> tcs2Change = new();
        bool hadInit1 = false;
        bool hadInit2 = false;

        StateStore<SimpleState> store = StateStore<SimpleState>.Create()
            .AddReducer(new SimpleStateReducer())
            .Build();

        Debug.Equals(store.GetValue(state => state.A), 1);
        store.Bind((state) => state.A).Subscribe(n =>
        {
            Debug.WriteLine("1: " + n);
            if (hadInit1) tcs1Change.SetResult(n);
            else tcs1Init.SetResult(n);
            hadInit1 = true;
        }, (e) => throw e, () => { });
        store.Bind((state) => state.A).Subscribe(n =>
        {
            Debug.WriteLine("2: " + n);
            if (hadInit2) tcs2Change.SetResult(n);
            else tcs2Init.SetResult(n);
            hadInit2 = true;
        }, (e) => throw e, () => { });
        store.Dispatch(AddToAAction, 10);

        Debug.Equals(await tcs1Init.Task, 1);
        Debug.Equals(await tcs2Init.Task, 1);
        Debug.Equals(await tcs1Change.Task, 11);
        Debug.Equals(await tcs2Change.Task, 11);
    }
}