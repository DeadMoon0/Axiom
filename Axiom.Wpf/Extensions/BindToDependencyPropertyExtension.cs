using System;
using System.Windows;

namespace Axiom.Wpf.Extensions;

public static class BindToDependencyPropertyExtension
{
    public static IDisposable BindToDependencyProperty<T>(this IObservable<T> observable, UIElement element, DependencyProperty dependencyProperty)
    {
        return observable.Subscribe(next => element.SetValue(dependencyProperty, next));
    }
}
