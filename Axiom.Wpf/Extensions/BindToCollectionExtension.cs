using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Axiom.Wpf.Extensions;

public static class BindToCollectionExtension
{
    private record TrackEntry<TTrack>(TTrack Key, UIElement Element) where TTrack : notnull;

    public static IDisposable BindToCollection<TItem, TTrack>(this IObservable<IEnumerable<TItem>> observable, UIElementCollection collection, Func<TItem, TTrack> trackBy, Func<TItem, UIElement> elementFactory) where TTrack : notnull
    {
        //TODO: Maybe fix this naive approche
        List<TrackEntry<TTrack>> tracking = [];
        return observable.Subscribe((IEnumerable<TItem> values) =>
        {
            TItem[] items = [.. values];
            for (int i = 0; i < items.Length; i++)
            {
                TTrack key = trackBy(items[i]);
                if (tracking.Count > i && tracking[i].Key.Equals(key)) continue;
                if (tracking.Count > i)
                {
                    collection.Remove(tracking[i].Element);
                    tracking.RemoveAt(i);
                }
                var element = elementFactory(items[i]);
                collection.Insert(i, element);
                tracking.Insert(i, new TrackEntry<TTrack>(key, element));
            }
        });
    }
}