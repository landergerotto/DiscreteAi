using System;
using System.Collections.Generic;
using System.Linq;
using AulasAI;
using AulasAI.Collections;

namespace AulasAi.Search;

public static partial class Search
{
    public static bool DepthFirstSearch<T, TNode>(SearchNode<T, TNode> node, T goal)
        where TNode : INode<T>
    {
        if (node.WasVisited)
            return false;

        node.WasVisited = true;

        if (EqualityComparer<T>.Default.Equals(node.Node.Value, goal))
        {
            node.IsSolution = true;
            return true;
        }

        var found = node.Connections().Any(neighbour => 
            !neighbour.WasVisited && DepthFirstSearch(neighbour, goal)
        );
            

        return found;
    }
}