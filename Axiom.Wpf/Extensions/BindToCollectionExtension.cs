using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Axiom.Wpf.Extensions;

public static class BindToCollectionExtension
{
    private record TrackEntry<TTrack>(TTrack Key, UIElement Element) where TTrack : notnull;

    public static IDisposable BindToCollection<TItem, TTrack>(this IObservable<IEnumerable<TItem>> observable, UIElementCollection collection, Func<TItem, TTrack> trackBy, Func<TItem, UIElement> elementFactory) where TTrack : notnull
    {
        var current = new List<Entry<TTrack>>();
        return observable.Subscribe(items =>
        {
            var newItems = items?.ToList() ?? [];
            var oldMap = new Dictionary<TTrack, Entry<TTrack>>();

            for (int i = 0; i < current.Count; i++)
                oldMap[current[i].Key] = current[i];

            var next = new List<Entry<TTrack>>(newItems.Count);

            for (int newIndex = 0; newIndex < newItems.Count; newIndex++)
            {
                var item = newItems[newIndex];
                var key = trackBy(item);

                if (oldMap.TryGetValue(key, out var entry))
                {
                    oldMap.Remove(key);

                    var oldIndex = collection.IndexOf(entry.Element);
                    if (oldIndex != newIndex)
                    {
                        collection.RemoveAt(oldIndex);
                        InsertAt(collection, entry.Element, newIndex);
                    }

                    next.Add(entry);
                }
                else
                {
                    var element = elementFactory(item);
                    InsertAt(collection, element, newIndex);
                    next.Add(new Entry<TTrack>(key, element));
                }
            }

            foreach (var leftover in oldMap.Values)
            {
                collection.Remove(leftover.Element);
            }

            current = next;
        });
    }

    private sealed class Entry<TTrack> where TTrack : notnull
    {
        public Entry(TTrack key, UIElement element)
        {
            Key = key;
            Element = element;
        }

        public TTrack Key { get; }
        public UIElement Element { get; }
    }

    private static void InsertAt(UIElementCollection collection, UIElement element, int index)
    {
        if (index >= collection.Count)
            collection.Add(element);
        else
            collection.Insert(index, element);
    }
}