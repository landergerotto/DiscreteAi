using System.Collections.Generic;
using System.Linq;


namespace Artin.Collections.GraphML;

public class GraphMlGraph
{
    public List<GraphMlNode>          Nodes       { get; set; }

    public GraphMlGraph(
        List<GraphMlNode> nodes = null,
        List<GraphMlEdge> edges = null
    )
    {
        this.Nodes = nodes ?? new List<GraphMlNode>();
        
        foreach (var edge in edges)
        {
            var q = 
                from n in this.Nodes
                where n.Id == edge.SourceNode
                select n;

            var node = q.FirstOrDefault();
            // System.Console.WriteLine(node.Id);
            node.Neighbours = node.Neighbours.Append(edge);
        }
    }
}