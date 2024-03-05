using AulasAI.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AulasAi.Search;


public static partial class Search
{
    public static bool Dijkstra<T>(WeightedNode<T> start, WeightedNode<T> end)
    {
        var toAnalise = new PriorityQueue<WeightedNode<T>, float>();
        var dist = new Dictionary<WeightedNode<T>, float>();
        var prev = new Dictionary<WeightedNode<T>, WeightedNode<T>>();

        toAnalise.Enqueue(start, 0.0f);
        dist[start] = 0.0f;

        while (toAnalise.Count > 0)
        {
            var currNode = toAnalise.Dequeue();

            foreach (var edge in currNode.Neighbours)
            {
                var newWeight = dist[currNode] + edge.Weight;

                if (!dist.ContainsKey(edge.DestinyNode))
                {
                    dist[edge.DestinyNode] = float.PositiveInfinity;
                    prev[edge.DestinyNode] = null;
                }

                if (newWeight < dist[edge.DestinyNode])
                {
                    dist[edge.DestinyNode] = newWeight;
                    prev[edge.DestinyNode] = currNode;
                    
                    toAnalise.Enqueue(edge.DestinyNode, newWeight);
                }
            }
        }

        var attempt = end;
        while ( attempt != start)
        {   
            if (!prev.ContainsKey(attempt))
                return false;
            attempt = prev[attempt];
        }

        return true;
    }
}