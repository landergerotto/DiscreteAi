using System.Collections.Generic;
using System.Linq;
namespace AulasAI.Collections;

public class SearchTreeNode<T> : SearchNode<T, TreeNode<T>>
{
    public SearchTreeNode(TreeNode<T> node) : base(node) { }

    public override IEnumerable<SearchNode<T, TreeNode<T>>> Connections()
    {
        var connections = new List<SearchNode<T, TreeNode<T>>>();
        foreach (var child in Node.Children)
        {
            connections.AddRange(
                Node.Children.Select(child => new SearchTreeNode<T>(child))
            );
        }
        return connections;
    }
    
}