using System.Collections.Generic;
using System.Linq;

namespace AulasAI.Collections;

public class SearchWeightedNode<T> : SearchNode<T, WeightedNode<T>>
{
    public SearchWeightedNode(WeightedNode<T> node) : base(node) { }

    public override IEnumerable<SearchNode<T, WeightedNode<T>>> Connections()
    {
        var neighbours = 
            new List<SearchNode<T, WeightedNode<T>>>(Node.Neighbours.Count());

        neighbours.AddRange(
            Node.Neighbours.Select(x => new SearchWeightedNode<T>(x.DestinyNode))
        );

        return neighbours;
    }
}