using System.Collections.Generic;

namespace Artin.Collections.GraphML;

public class GraphMlEdge
{
    public string                     SourceNode { get; set; }
    public string                     TargetNode { get; set; }
    public GraphMlNode                DestinyNode{ get; set;}
    public Dictionary<string, string> Data       { get; set; }

    public GraphMlEdge(
        string sourceNode = null!,
        string targetNode = null!,
        Dictionary<string, string> data = null!
    )
    {
        SourceNode = sourceNode;
        TargetNode = targetNode;
        Data = data;
    }

    public GraphMlEdge(
        string sourceNode = null!,
        string targetNode = null!,
        GraphMlNode destinyNode = null!,
        Dictionary<string, string> data = null!
    )
    {
        SourceNode = sourceNode;
        TargetNode = targetNode;
        this.DestinyNode = destinyNode;
        Data = data;
    }
}