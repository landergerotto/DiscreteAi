using System.Collections.Generic;
using System.Linq;
using AulasAI.Collections;

public class SearchGraphNode<T> : SearchNode<T, GraphNode<T>>
{
    public SearchGraphNode(GraphNode<T> node) : base(node) { }

    public override IEnumerable<SearchNode<T, GraphNode<T>>> Connections()
    {
        var connections = new List<SearchNode<T, GraphNode<T>>>(Node.Neighbours.Count());
        foreach (var child in Node.Neighbours)
        {
            connections.AddRange(
                Node.Neighbours.Select(child => new SearchGraphNode<T>(child))
            );
        }
        return connections;
    }
}