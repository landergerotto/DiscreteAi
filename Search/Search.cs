namespace AulasAi.Search;

using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;

public static class Search
{
    public static int BinarySearch<T>(IEnumerable<T> collection, T query, bool sorted = false)
    {
        if (!sorted)
        {
            collection = (IEnumerable<T>)collection.ToArray().Clone();
            collection = Sort(collection);
        }

        int begin = 0;
        int end = collection.Count() - 1;

        var comparer = Comparer<T>.Default;

        while (end - begin >= 0)
        {
            int mid = begin + (end - begin) / 2;
            var midValue = collection.ElementAt(mid);
            
            var comparison = comparer.Compare(query, midValue);

            if (comparison == 0)
                return mid;

            if (comparison > 0)
                begin = mid + 1;
            else
                end = mid - 1;
        }

        return -1; 
    }

    public static IEnumerable<T> Sort<T>(IEnumerable<T> collection)
        =>collection.OrderBy(s => s);
}