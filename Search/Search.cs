namespace AulasAi.Search;

using System;
using System.Collections.Generic;
using System.Collections;

public static class Search
{
    public static int BinarySearch<T>(IEnumerable<T> collection, T query)
    {
        var comparer = Comparer<T>.Default; // 0: equal, > 0

        int low = 0;
        int high = collection.Count() - 1;

        while (high - low > 1)
        {
            var mid = low + (high - low) / 2;
            var midValue = collection.ElementAt(mid);
            
            var comparison = comparer.Compare(query, midValue);

            if (comparison > 0)
                low = mid;
            
            else
                high = mid;
            
        }

        return high; 

        return 0;
    }

    public static IEnumerable<T> Sort<T>(IEnumerable<T> collection)
        =>collection.OrderBy(s => s);
}