![Icon](https://raw.githubusercontent.com/DeadMoon0/Axiom/refs/heads/main/Assets/Icon.svg)
[![NuGet Version](https://img.shields.io/nuget/v/Axiom.Wpf?label=nuget%20Axiom.Wpf)](https://www.nuget.org/packages/Axiom.Wpf)

# Axiom.Wpf

Reactive state bindings for WPF. Connect Axiom state directly to UI elements with minimal code.

This works closely with `Axiom.State` but has no requirement.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Core Extensions](#core-extensions)
  - [BindToDependencyProperty](#bindtodependencyproperty)
  - [BindToCollection](#bindtocollection)
  - [ToggleVisibility](#togglevisibility)
- [Real-World Example](#real-world-example)

---

## Features

- **Zero ViewModel Boilerplate** — Bind state selectors directly to UI controls without implementing `INotifyPropertyChanged`
- **Automatic UI Synchronization** — Leverages `SynchronizationContext` to ensure all binding updates occur on the UI thread
- **Reactive Bindings** — Built on top of `System.Reactive` for predictable state subscriptions

---

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Axiom.Wpf
```

Or via the NuGet Package Manager Console:

```powershell
Install-Package Axiom.Wpf
```

---

## Quick Start

### 1. Initialize Your State Store (with UI Synchronization)

```csharp
using Axiom;

// In your App.xaml.cs or MainWindow.xaml.cs
StateStore<AppState>.Create()
    // Add you normal State init stuff there
    .UseSynchronizationContext(SynchronizationContext.Current!)
    .BuildAndMakeDefault();
```

### 2. Bind a Selector to a TextBlock

```csharp
// In your code-behind or ViewModel
var store = StateStore<AppState>.Default;
store
    .Select(state => state.Counter)
    .BindToDependencyProperty(CounterTextBlock, TextBlock.TextProperty);
```

That's it! The TextBlock now updates automatically whenever `state.Counter` changes.

---

## Core Extensions

### BindToDependencyProperty

Directly sets a dependency property value whenever the observable emits, without using the XAML binding system.

```csharp
store
    .Select(state => state.IsLoading)
    .BindToDependencyProperty(LoadingPanel, Panel.BackgroundProperty);
```

**Returns:** `IDisposable` subscription that can be disposed to stop updates.

**When to use:** Direct imperative binding to dependency properties.

---

### BindToCollection

Binds a state selector that emits a collection to a `UIElementCollection` (like `Panel.Children`). Uses a **diffing algorithm** with a `trackBy` function to efficiently add, remove, and reorder UI elements.

```csharp
store
    .Select(state => state.Items)
    .BindToCollection(
        collection: MyPanel.Children,
        trackBy: item => item.Id,  // Unique key for each item
        elementFactory: item => new TextBlock { Text = item.Name }
    );
```

The `trackBy` function returns a unique key for each item. The extension uses these keys to determine which items are new, which have been removed, and which have moved. Elements are created via the `elementFactory` function.

**Key features:**
- Reuses existing elements when items are reordered
- Only adds new elements for new items
- Only removes elements for deleted items
- Maintains correct order in the collection

**Returns:** `IDisposable` subscription that can be disposed to stop tracking changes.

**When to use:** Binding collections to a `Panel.Children`, `StackPanel.Children`, or any other `UIElementCollection` when you need fine-grained control over element creation and lifecycle.

---

### ToggleVisibility

Binds a boolean state selector to control the visibility of two UI elements: shows one element and hides the other based on the boolean value.

```csharp
store
    .Select(state => state.IsUserLoggedIn)
    .ToggleVisibility(
        whenTrue: LoginSuccessPanel,   // Visible when true
        whenFalse: LoginFailurePanel   // Visible when false
    );
```

When the boolean is `true`, `whenTrue` is set to `Visibility.Visible` and `whenFalse` is set to `Visibility.Collapsed`. When `false`, the visibility states are reversed.

**Returns:** `IDisposable` subscription that can be disposed to stop updates.

**When to use:** Show/hide paired UI sections based on boolean state (success/error panels, logged-in/logged-out views, etc.).

---

## Real-World Example

Here's a complete example of a login form that uses all four extensions:

**ViewModel/State Definition:**

```csharp
public record LoginState
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public bool IsLoading { get; init; }
    public string? ErrorMessage { get; init; }
    public bool IsLoginButtonEnabled { get; init; } = true;
    public List<string> RecentLogins { get; init; } = new();
}
```

**Code-Behind (LoginView.xaml.cs):**

```csharp
public partial class LoginView : Window
{
    private List<IDisposable> _bindings = new();

    public LoginView()
    {
        InitializeComponent();
        BindStateToUI();
    }

    private void BindStateToUI()
    {
        var store = StateStore<LoginState>.Default;

        // Bind username input
        _bindings.Add(store
            .Select(state => state.Username)
            .BindToDependencyProperty(UsernameTextBox, TextBox.TextProperty));

        // Bind password input
        _bindings.Add(store
            .Select(state => state.Password)
            .BindToDependencyProperty(PasswordBox, PasswordBoxHelper.PasswordProperty));

        // Toggle error/success panels
        _bindings.Add(store
            .Select(state => string.IsNullOrEmpty(state.ErrorMessage))
            .ToggleVisibility(SuccessPanel, ErrorBanner));

        // Bind error message text
        _bindings.Add(store
            .Select(state => state.ErrorMessage ?? string.Empty)
            .BindToDependencyProperty(ErrorTextBlock, TextBlock.TextProperty));

        // Bind loading spinner visibility (via dependency property)
        _bindings.Add(store
            .Select(state => state.IsLoading)
            .BindToDependencyProperty(LoadingSpinner, UIElement.VisibilityProperty));

        // Bind login button enabled state
        _bindings.Add(store
            .Select(state => state.IsLoginButtonEnabled)
            .BindToDependencyProperty(LoginButton, Button.IsEnabledProperty));

        // Bind recent logins collection
        _bindings.Add(store
            .Select(state => state.RecentLogins)
            .BindToCollection(
                RecentLoginsPanel.Children,
                trackBy: login => login,  // String is already unique
                elementFactory: login => new TextBlock 
                { 
                    Text = login, 
                    Padding = new Thickness(5),
                    Margin = new Thickness(0, 2, 0, 2)
                }
            ));
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var store = StateStore<LoginState>.Default;
        store.Dispatch(new LoginAction(UsernameTextBox.Text, PasswordBox.Password));
    }

    // Clean up subscriptions when window closes
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        foreach (var binding in _bindings)
            binding.Dispose();
    }
}
```

**XAML (LoginView.xaml):**

```xaml
<Window x:Class="MyApp.LoginView" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
    <StackPanel Padding="20">
        <TextBlock Text="Login" FontSize="24" FontWeight="Bold" Margin="0,0,0,20" />

        <!-- Username -->
        <TextBlock Text="Username" Margin="0,0,0,5" />
        <TextBox x:Name="UsernameTextBox" Padding="10" Margin="0,0,0,15" />

        <!-- Password -->
        <TextBlock Text="Password" Margin="0,0,0,5" />
        <PasswordBox x:Name="PasswordBox" Padding="10" Margin="0,0,0,15" />

        <!-- Success Panel -->
        <Border x:Name="SuccessPanel" Background="Green" Padding="10" Margin="0,0,0,15" Visibility="Visible">
            <TextBlock Foreground="White" Text="Login successful!" />
        </Border>

        <!-- Error Banner -->
        <Border x:Name="ErrorBanner" Background="Red" Padding="10" Margin="0,0,0,15" Visibility="Collapsed">
            <TextBlock x:Name="ErrorTextBlock" Foreground="White" TextWrapping="Wrap" />
        </Border>

        <!-- Loading Spinner -->
        <ProgressBar x:Name="LoadingSpinner" Height="4" Margin="0,0,0,15" Visibility="Collapsed" IsIndeterminate="True" />

        <!-- Recent Logins -->
        <TextBlock Text="Recent Logins" FontWeight="Bold" Margin="0,0,0,10" />
        <StackPanel x:Name="RecentLoginsPanel" Background="#F0F0F0" Padding="10" Margin="0,0,0,15" />

        <!-- Login Button -->
        <Button x:Name="LoginButton" Content="Login" Padding="10" Click="LoginButton_Click" />
    </StackPanel>
</Window>
```