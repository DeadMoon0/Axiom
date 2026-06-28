# Axiom
This file is to craft the Idea behind what should happen and wy.

## What should it be?
A System to manage the Data-layer in an App.

## What should it guarantee?
- Single-Source-Of-Truth: One place the Data lives and one place the Data gets maintained.
- Transactional: One Action - one State - one after the other
- Isolation: One Action does not interfere with another
- Roll-backable: You must be able to undo and revert to the previous state

## What should it not guarantee?
- Order of Notifications: The order in witch the Notifications are dispatched are not guaranteed (inside on change)

## What needs to be added for all guarantee to be meet?
- A Central managed place for the Data.
- The Data must be Versioned.
- A Dispatcher who must work on one Action at a time.

## What are the Implementation Resolutions?
- One Static Data Store.
- The Data must be Managed/Serialized
- All Edge-Data (every non link) cannot be versioned - cause it might be a ref
- The System must control the edge-data (strong-ref)

## What Components are needed?
- Store: The Central Place where the State is saved
- Dispatcher: The System that will look for Thread safety and the Queueing -> not via Thread Dispatch, instead use simple lock() or semaphore
- Action: This describes an Action. An Action should also hold Params for the reducer
- Reducer: This describes how the State should react on different Actions
- Effect: This describes how should be reacted on what Action. This can be used to load Data after an Action indicates a request. 
  Every Effect-Action should be Cancellable, given a Token and the same Effect-Action being triggered
- Observable: Light weight Binding Objects. With ways to get Updates and Push them. The Store can return them and Bind them to a Path.

## The Flow
```
[STATE-A] {1,2,3}
: Dispatch (Set[0]) -> 
    Action Set[0] | Value: 2
    Reducer for Set[0] -> new State( STATE-A with [0] = 2 )
    Store -> Append new State
    Store -> Notify all Observables - non Blocking / queued -\
    Effect -> Resolve every Effect - non Blocking / queued   |
[STATE-B] {2,2,3}                                            |
                                                             |
    /--------------------------------------------------------/
    V
    Notify Observable
    Enque Notification in callback queue
    Deque and Call callback
```

## API Design
``` cs
# State ##################################################################################
public record struct State()
{
    public int A = 1;
    public int B = 2;
    public int C = 3;

    public string? FetchError = null;
}

# .Actions.cs ############################################################################

puplic static readonly var IncA = new Action<int>("Increment A");
puplic static readonly var Decb = new Action<int>("Decrement B");
puplic static readonly var FetchC = new Action("Fetch C");
puplic static readonly var FetchSC = new Action<int>("Fetch C Success");
puplic static readonly var FetchFC = new Action<string>("Fetch C Failure");

# .Reducer.cs ############################################################################

public class StateReducers : Reducer<State>
{
    public StateReducer()
    {
        On(IncA, (s, n) => 
        s with 
        {
            A = s.A + n
        });
        On(Decb, (s, n) => 
        s with 
        {
            B = s.B - n
        });
        // On(FetchC, (s, n) => s); // no State change should be implicit
        On(FetchSC, (s, n) => 
        s with 
        {
            C = n
        });
        On(FetchFC, (s, error) => 
        s with 
        {
            FetchError = error
        });
    }
}

# .Effects.cs ############################################################################

public class StateEffects : Effects<State>
{
    public StateEffects()
    {
        On(FetchC,
            action: () => await Service.FetchCAsync()
            onSuccess: (n) => Do(FetchSC, n)
        )
    }
}

# Triggered ##############################################################################


```