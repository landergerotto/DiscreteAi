using System.Collections.Generic;


namespace Artin.Collections.GraphML;

public class GraphMlNode
{
    public string                     Id          { get; set; }
    public Dictionary<string, string> Data        { get; set; }
    public IEnumerable<GraphMlEdge>   Neighbours  { get; set; } = new List<GraphMlEdge>();

    public GraphMlNode(
        string id = null!,
        Dictionary<string, string> data = null!
    )
    {
        Id = id;
        Data = data;
    }

    public GraphMlNode(
        GraphMlNode node
    )
    {
        Id = node.Id;
        Data = node.Data;
    }

    public GraphMlNode Clone()
       => this;
}