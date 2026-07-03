![Icon](https://raw.githubusercontent.com/DeadMoon0/Axiom/refs/heads/main/Assets/Icon.svg)

# Axiom.State

**A predictable, type-safe State Management System for C# built on the Observable Pattern.**

Axiom.State provides a robust state store that manages application state and lets you listen to updates through a declarative, reactive architecture. The state management flow uses StateActions, Reducers, Effects, and Selectors to make state changes predictable and consistent.

## Features

- **Observable-based reactivity** – Bind to state changes using `System.Reactive`
- **Type-safe actions** – Generic StateActions enforce type safety for all parameters
- **Reducer pattern** – Predictable state mutations through pure functions
- **Effects system** – Handle async operations (API calls, etc.) elegantly
- **Selector chains** – Easily navigate and transform complex state hierarchies
- **Default store pattern** – Use a singleton store or maintain multiple instances

## Table of Contents

- [Installation](#installation)
- [Requirements](#requirements)
- [Quick Start](#quick-start)
- [Core Concepts](#core-concepts)
  - [State](#state)
  - [Actions](#actions)
  - [Reducers](#reducers)
  - [Binding & Dispatching](#binding--dispatching)
- [Advanced Systems](#advanced-systems)
  - [Effects](#effects)
  - [Selectors](#selectors)

---

## Installation

### NuGet Package Manager

```
Install-Package Axiom.State
```

### .NET CLI

```bash
dotnet add package Axiom.State
```

---

## Quick Start

Here's the essentials to get a state store up and running:

```cs
// 1. Define your state
public record struct MainState()
{
    public string StringField = "Hello, Axiom!";
    public bool IsLoading = false;
}

// 2. Create actions
public static class MainActions
{
    public static readonly StateAction<string> SetStringField = 
        new(nameof(MainActions), nameof(SetStringField));
}

// 3. Create a reducer
public class MainReducer : Reducer<MainState>
{
    public MainReducer()
    {
        On(MainActions.SetStringField, (state, value) =>
        {
            return state with { StringField = value };
        });
    }
}

// 4. Build the store
StateStore<MainState>.Create()
    .AddReducer(new MainReducer())
    .BuildAndMakeDefault();

// 5. Bind and dispatch
StateStore<MainState>.Default
    .Bind(x => x.StringField)
    .Subscribe(value => Console.WriteLine($"New value: {value}"));

StateStore<MainState>.Default.Dispatch(MainActions.SetStringField, "Updated!");
```

---

## Core Concepts

### State

Your state is the single source of truth for your application. It should be a **struct** (preferably a `record struct`) and contain sensible default values. Since state should be immutable, using record structs is recommended.

```cs
public record struct MainState()
{
    public string StringField = "Axiom Sample State";
    public bool IsLoading = false;
    public int[] SomeInts = [];
    public SubState SubState = default;
}
```

---

### Actions

Actions describe *what* happened. They are defined as static readonly instances of `StateAction` (or `StateAction<T>` for actions with parameters). It's good practice to group them in a dedicated static class like `{TState}Actions`.

StateActions are **fully type-safe** - all parameters become generic type arguments, so the compiler catches mismatches at build time.

```cs
public static class MainActions
{
    public static readonly StateAction<string> SetStringField = 
        new(nameof(MainActions), nameof(SetStringField));
}
```

---

### Reducers

For every action, there must be a reducer that specifies *how* the state changes. Reducers inherit from `Reducer<TState>` and use the `On(StateAction, ReducerFunc)` method to bind actions to state transformations.

It's good practice to return a new instance (using the `with` expression for records), though it's not strictly required.

```cs
public class MainReducer : Reducer<MainState>
{
    public MainReducer()
    {
        On(MainActions.SetStringField, (state, value) =>
        {
            return state with { StringField = value };
        });
    }
}
```

---

### Binding & Dispatching

**Binding** to state changes returns an `IObservable<T>` that you can subscribe to using the Reactive Extensions library (LINQ to Rx is recommended).

```cs
StateStore<MainState>.Default
    .Bind(x => x.StringField)
    .Subscribe(value => { /* Do something */ });
```

**Dispatching** an action triggers the associated reducer, sends an update notification, and resolves any effects. You must provide the action and all its required arguments.

```cs
StateStore<MainState>.Default.Dispatch(MainActions.SetStringField, "Some new String");
```

---

## Advanced Systems

### Effects

Effects handle side effects - operations that take time and shouldn't block your app flow, like API calls. Effects are organized in an Effects collection and respond to dispatched actions.

Effects typically use three actions: a **begin** action, a **success** action, and a **failure** action.

```cs
public static class SomeIntsActions
{
    public static readonly StateAction LoadSomeIntsAction = 
        new(nameof(SomeIntsActions), nameof(LoadSomeIntsAction));
    
    public static readonly StateAction<int[]> LoadSomeIntsSuccessAction = 
        new(nameof(SomeIntsActions), nameof(LoadSomeIntsSuccessAction));
    
    public static readonly StateAction<Exception> LoadSomeIntsFailedAction = 
        new(nameof(SomeIntsActions), nameof(LoadSomeIntsFailedAction));
}
```

Now create the effect:

```cs
public class SomeIntsEffects : Effects<MainState>
{
    public SomeIntsEffects()
    {
        On(SomeIntsActions.LoadSomeIntsAction, Effect(
            (state) => API.LoadSomeInts(),
            (ints) => Do(SomeIntsActions.LoadSomeIntsSuccessAction, ints),
            (error) => Do(SomeIntsActions.LoadSomeIntsFailedAction, error)
        ));
    }
}
```

Every time `LoadSomeIntsAction` is dispatched, the effect will call `API.LoadSomeInts()`, and on success or failure, it will dispatch the appropriate action with the result.

---

### Selectors

Selectors solve the problem of deeply nested or complex states by providing a template structure to **safely navigate and transform** values. They encapsulate the knowledge of how to get and set values within your state, making it easy to reuse complex paths.

Selectors support three modes:
- **Property accessor** – Get/set a simple property
- **Index accessor** – Get/set via array/collection index
- **Custom accessor** – Define your own get/set logic

Here's an example with multiple selectors:

```cs
public record struct MainState()
{
    public UserState[] Users = [];
    public int SelectedUser = -1;
}

public record struct UserState()
{
    public int Id = 0;
    public string UserName = "NAME";
    public Dictionary<int, MessageState> Messages = [];
}

public static class UserSelectors
{
    // Selector for a user by ID (ID provided at call time)
    public static Selector<MainState, UserState> SelectUserViaId(int id) => 
        Selector.Index(
            (MainState state) => state.Users, 
            (MainState state) => Array.FindIndex(state.Users, (u) => u.Id == id)
        );
    
    // Selector for the currently selected user (index fetched from state)
    public static Selector<MainState, UserState> SelectSelectedUser { get; } = 
        Selector.Index(
            (MainState state) => state.Users, 
            (MainState state) => Array.FindIndex(state.Users, (u) => u.Id == state.SelectedUser)
        );

    // Selector for just the user's name
    public static Selector<UserState, string> SelectUserName { get; } = 
        Selector.Property((UserState user) => user.UserName);
}
```

Note that `SelectUserName` uses `UserState` as its base type, not `MainState`. This allows you to **chain selectors** later.

#### Using Selectors with Binding

You can select a specific value when binding:

```cs
StateStore<MainState>.Default
    .Bind(UserSelectors.SelectUserViaId(userId))
    .Subscribe(/* handle user */);
```

You can also **chain selectors** using `.Then()`:

```cs
StateStore<MainState>.Default
    .Bind(UserSelectors.SelectUserViaId(userId)
        .Then(UserSelectors.SelectUserName))
    .Subscribe(userName => { /* handle username */ });
```

#### Using Selectors in Reducers

Selectors are especially powerful in reducers when dealing with complex nested state. Instead of manually navigating the structure, pass a selector callback to the second argument of `On()`:

```cs
On(MessageActions.SetMessage,
    (userId, msgId, message) => 
        UserSelectors.SelectUserViaId(userId)
            .Then(MessageSelectors.SelectMessageViaId(msgId)),
    (msg, userId, msgId, message) =>
    {
        return msg with { Message = message };
    }
);
```

This keeps your reducers clean and reusable, especially for deeply nested state.