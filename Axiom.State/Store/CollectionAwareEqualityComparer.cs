using System;
using System.Collections;
using System.Collections.Generic;

namespace Axiom.State.Store;

public class CollectionAwareEqualityComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T? x, T? y)
    {
        // Handle null cases
        if (x is null && y is null) return true;
        if (x is null || y is null) return false;

        // Handle IDictionary
        if (x is IDictionary dictX && y is IDictionary dictY)
        {
            return EqualsDictionary(dictX, dictY);
        }

        // Handle IList (but not string)
        if (x is IList listX && y is IList listY && !(x is string) && !(y is string))
        {
            return EqualsList(listX, listY);
        }

        // Handle arrays
        if (x is Array arrX && y is Array arrY)
        {
            return EqualsArray(arrX, arrY);
        }

        // Fall back to default equality
        return EqualityComparer<T>.Default.Equals(x, y);
    }

    public int GetHashCode(T obj)
    {
        return obj?.GetHashCode() ?? 0;
    }

    private bool EqualsDictionary(IDictionary dictX, IDictionary dictY)
    {
        if (dictX.Count != dictY.Count) return false;

        foreach (var key in dictX.Keys)
        {
            if (!dictY.Contains(key)) return false;
            if (!Equals(dictX[key], dictY[key])) return false;
        }

        return true;
    }

    private bool EqualsList(IList listX, IList listY)
    {
        if (listX.Count != listY.Count) return false;

        for (int i = 0; i < listX.Count; i++)
        {
            if (!Equals(listX[i], listY[i])) return false;
        }

        return true;
    }

    private bool EqualsArray(Array arrX, Array arrY)
    {
        if (arrX.Length != arrY.Length) return false;
        if (arrX.Rank != arrY.Rank) return false;

        for (int i = 0; i < arrX.Rank; i++)
        {
            if (arrX.GetLength(i) != arrY.GetLength(i)) return false;
        }

        var enumeratorX = arrX.GetEnumerator();
        var enumeratorY = arrY.GetEnumerator();

        while (enumeratorX.MoveNext() && enumeratorY.MoveNext())
        {
            if (!Equals(enumeratorX.Current, enumeratorY.Current)) return false;
        }

        return true;
    }
}
