using System.CodeDom.Compiler;

namespace AulasAI.Collections;

public class Edge<T>
{
    public WeightedNode<T> DestinyNode { get; set; }
    public float Weight { get; set; }

    public Edge(WeightedNode<T> destinyNode, float weight)
    {
        this.DestinyNode = destinyNode;
        this.Weight = weight;
    }
}