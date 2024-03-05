using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulasAI.Collections;

public class GraphNode<T> : INode<T>
{
    public T                    Value       { get; set; }
    public IEnumerable<GraphNode<T>> Neighbours  { get; set; }
    public int                  Connections { get; set; }

    public GraphNode(T value)
    {
        this.Value = value;
        this.Neighbours = Enumerable.Empty<GraphNode<T>>();
    }

    public GraphNode
    (
        T value = default,
        IEnumerable<GraphNode<T>> children = null!
    )
    {
        this.Value = value;
        this.Neighbours = children ?? Enumerable.Empty<GraphNode<T>>();

        foreach (var neighbour in this.Neighbours)
        {
            if (!neighbour.Neighbours.Contains(this))
                neighbour.Neighbours.Append(this);
        }
    }

    public GraphNode<T> AddNode(GraphNode<T> node)
    {
        if (!Neighbours.Contains(node))
            this.Neighbours = this.Neighbours.Append(node);

        if (!Neighbours.Contains(this))
            node.Neighbours = node.Neighbours.Append(this);

        return this;
    }

    public GraphNode<T> RemoveNode(GraphNode<T> node)
    {
        this.Neighbours = this.Neighbours.Where(x => x != node);
        node.Neighbours = node.Neighbours.Where(x => x != this);

        return this;
    }

    public void ClearConnections()
        => this.Neighbours = Enumerable.Empty<GraphNode<T>>();
    

    public override string ToString()
    {
        return ToString("", true, true);
    }

    private string ToString(string indent, bool isLast, bool isRoot)
    {
        return this.Value.ToString();
    }
}