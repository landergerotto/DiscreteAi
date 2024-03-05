using System.Collections;
using System.Collections.Generic;

namespace AulasAI.Collections;

public abstract class SearchNode<T, TNode> 
    where TNode : INode<T>
{
    public TNode Node { get; set; }
    public bool IsSolution { get; set; } = false;
    public bool WasVisited { get; set; } = false;
    
    public SearchNode(TNode node)
        => this.Node = node;

    public abstract IEnumerable<SearchNode<T, TNode>> Connections();

    public void Reset()
    {
        this.IsSolution = false;
        this.WasVisited = false;
    }
}