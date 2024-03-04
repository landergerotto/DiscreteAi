using System;
using System.Collections.Generic;
using System.Linq;
using AulasAI;
using AulasAI.Collections;

namespace AulasAi.Search;

public static partial class Search
{
    public static bool DepthFirstSearch<T>(TreeNode<T> node, T goal)
    {
        if (EqualityComparer<T>.Default.Equals(node.Value, goal))
            return true;

        foreach (var currNode in node.Children)
            if (DepthFirstSearch(currNode, goal))
                return true;
        
    
        return false;
    }
}