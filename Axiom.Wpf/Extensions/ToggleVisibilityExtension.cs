using System;
using System.Windows;

namespace Axiom.Wpf.Extensions;

public static class ToggleVisibilityExtension
{
    public static IDisposable ToggleVisibility(this IObservable<bool> observable, UIElement whenTrue, UIElement whenFalse)
    {
        return observable.Subscribe(next =>
        {
            if (next)
            {
                whenFalse.Visibility = Visibility.Collapsed;
                whenTrue.Visibility = Visibility.Visible;
            }
            else
            {
                whenTrue.Visibility = Visibility.Collapsed;
                whenFalse.Visibility = Visibility.Visible;
            }
        });
    }
}
