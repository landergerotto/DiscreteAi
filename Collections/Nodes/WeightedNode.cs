using System.Collections.Generic;
using System.Linq;

namespace AulasAI.Collections;

public class WeightedNode<T> : INode<T>
{
    public T Value { get; set; }
    public IEnumerable<Edge<T>> Neighbours { get; set; }
    public int Connections => Neighbours.Count();

    public WeightedNode(T value)
    {
        this.Value = value;
        this.Neighbours = Enumerable.Empty<Edge<T>>();
    }

    public WeightedNode
    (
        T value = default,
        IEnumerable<Edge<T>> children = null!
    )
    {
        this.Value = value;
        this.Neighbours = children ?? Enumerable.Empty<Edge<T>>();

        // foreach (var neighbour in this.Neighbours)
        // {
        //     bool flag = false;
        //     foreach (var edle in neighbour.DestinyNode.Neighbours)
        //     {
        //         if (edle.DestinyNode != this)
        //             flag |= true;
        //     }
        //     if (!neighbour.DestinyNode.Neighbours.Contains(this))
        //         neighbour.DestinyNode.Neighbours.Append(this);
        // }
    }

    public WeightedNode<T> AddNode(Edge<T> node)
    {
        if (!Neighbours.Contains(node))
            this.Neighbours = this.Neighbours.Append(node);

        return this;
    }

    public WeightedNode<T> AddNode(WeightedNode<T> node, float weight)
    {
        this.Neighbours.Append(new Edge<T>(node, weight));

        return this;
    }

    public WeightedNode<T> RemoveNode(Edge<T> node)
    {
        this.Neighbours = this.Neighbours.Where(x => x != node);

        return this;
    }

    public WeightedNode<T> RemoveNode(WeightedNode<T> node)
    {
        foreach (var edge in this.Neighbours)
        {
            if (edge.DestinyNode == node)
                this.Neighbours.Where(x => x != edge);
        }

        return this;
    }
    public void ClearConnections()
        => this.Neighbours = Enumerable.Empty<Edge<T>>();


    public override string ToString()
    {
        return ToString("", true, true);
    }

    private string ToString(string indent, bool isLast, bool isRoot)
    {
        return this.Value.ToString();
    }
}