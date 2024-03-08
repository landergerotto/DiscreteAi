using AulasAI.Collections;
using System.Collections.Generic;
using Artin.Collections.GraphML;
using System.Linq;
using System;

namespace AulasAi.Search;

public static partial class Search
{
    // public static bool Astar<T>(WeightedNode<T> start, WeightedNode<T> end)
    // {
    //     var toAnalise = new PriorityQueue<WeightedNode<T>, float>();
    //     var dist = new Dictionary<WeightedNode<T>, float>();
    //     var prev = new Dictionary<WeightedNode<T>, WeightedNode<T>>();

    //     toAnalise.Enqueue(start, 0.0f);
    //     dist[start] = 0.0f;

    //     while (toAnalise.Count > 0)
    //     {
    //         var currNode = toAnalise.Dequeue();

    //         foreach (var edge in currNode.Neighbours)
    //         {
    //             var newWeight = dist[currNode] + edge.Weight;

    //             if (!dist.ContainsKey(edge.DestinyNode))
    //             {
    //                 dist[edge.DestinyNode] = float.PositiveInfinity;
    //                 prev[edge.DestinyNode] = null;
    //             }

    //             if (newWeight < dist[edge.DestinyNode])
    //             {
    //                 dist[edge.DestinyNode] = newWeight;
    //                 prev[edge.DestinyNode] = currNode;
                    
    //                 toAnalise.Enqueue(edge.DestinyNode, newWeight);
    //             }
    //         }
    //     }

    //     var attempt = end;
    //     while ( attempt != start)
    //     {   
    //         if (!prev.ContainsKey(attempt))
    //             return false;
    //         attempt = prev[attempt];
    //     }

    //     return true;
    // }
    // d5 = x, d4 = y
    public static bool Astar(GraphMlNode start, GraphMlNode end)
    {
        var toAnalise = new PriorityQueue<GraphMlNode, float>();
        var dist = new Dictionary<GraphMlNode, float>();
        var prev = new Dictionary<GraphMlNode, GraphMlNode>();

        toAnalise.Enqueue(start, 0.0f);
        dist[start] = 0.0f;

        while (toAnalise.Count > 0)
        {
            var currNode = toAnalise.Dequeue();

            foreach (var edge in currNode.Neighbours)
            {
                var currX = float.Parse(currNode.Data["d5"]);
                var currY = float.Parse(currNode.Data["d4"]);

                var desX = float.Parse(edge.DestinyNode.Data["d5"]);
                var desY = float.Parse(edge.DestinyNode.Data["d4"]);

                var dx1 = desX - currX;
                var dy1 = desY - currY;

                var weight = MathF.Sqrt(dx1 * dx1 + dy1 * dy1);

                var dx2 = desX - float.Parse(end.Data["d5"]);
                var dy2 = desY - float.Parse(end.Data["d4"]);
                var penalty = MathF.Sqrt(dx2 * dx2 + dy2 * dy2);


                var newWeight = dist[currNode] + weight;

                if (!dist.ContainsKey(edge.DestinyNode))
                {
                    dist[edge.DestinyNode] = float.PositiveInfinity;
                    prev[edge.DestinyNode] = null;
                }

                if (newWeight < dist[edge.DestinyNode])
                {
                    dist[edge.DestinyNode] = newWeight;
                    prev[edge.DestinyNode] = currNode;
                    
                    toAnalise.Enqueue(edge.DestinyNode, newWeight + penalty);
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