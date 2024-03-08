using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Artin.Collections.GraphML;
using AulasAI.Collections;

namespace Artin.Collections.GraphML;

public class GraphMlSearchNode<TNode>
where TNode : GraphMlNode
{
    public GraphMlNode Node { get; set; }
    public bool IsSolution { get; set; } = false;
    public bool WasVisited { get; set; } = false;
    
    public GraphMlSearchNode(GraphMlNode node)
        => this.Node = node;

    public IEnumerable<GraphMlSearchNode<TNode>> Connections()
    {
        var neighbours = 
            new List<GraphMlSearchNode<TNode>>(Node.Neighbours.Count());

        neighbours.AddRange(
            Node.Neighbours.Select(x => new GraphMlSearchNode<TNode>(x.DestinyNode))
        );

        return neighbours;
    }

    public void Reset()
    {
        this.IsSolution = false;
        this.WasVisited = false;
    }
}