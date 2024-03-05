using System;
using System.Collections.Generic;
using System.Linq;
using AulasAI;
using AulasAI.Collections;

namespace AulasAi.Search;

public static partial class Search
{
    public static bool BreadthFirstSearch<T, TNode>(SearchNode<T, TNode> node, T goal)
        where TNode : INode<T>
    {
        var queue = new Queue<SearchNode<T, TNode>>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {   
            var currNode = queue.Dequeue();

            if (currNode.WasVisited)
                continue;

            currNode.WasVisited = true;

            if (EqualityComparer<T>.Default.Equals(currNode.Node.Value, goal))
            {
                currNode.IsSolution = true;
                return true;
            }

            foreach (var child in currNode.Connections())
                queue.Enqueue(child);
        }

        return false;
    }
}