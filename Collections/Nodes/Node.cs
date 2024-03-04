using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulasAI.Collections;

public class Node<T> : INode<T>
{
    public T                    Value       { get; set; }
    public IEnumerable<Node<T>> Neighbours  { get; set; }
    public int                  Connections { get; set; }

    public Node(T value)
    {
        this.Value = default;
        this.Neighbours = Enumerable.Empty<Node<T>>();
    }

    public Node
    (
        T value = default,
        IEnumerable<Node<T>> children = null!
    )
    {
        this.Value = value;
        this.Neighbours = children ?? Enumerable.Empty<Node<T>>();

        foreach (var neighbour in this.Neighbours)
        {
            neighbour.Neighbours.Append(this);
        }
    }

    public Node<T> AddNode(Node<T> node)
    {
        if (node is null)
            return this;

        this.Neighbours = this.Neighbours.Append(node);
        node.Neighbours = node.Neighbours.Append(this);

        return this;
    }

    public Node<T> RemoveNode(Node<T> node)
    {
        this.Neighbours = this.Neighbours.Where(x => x != node);
        node.Neighbours = node.Neighbours.Where(x => x != this);

        return this;
    }

    public void ClearConnections()
        => this.Neighbours = Enumerable.Empty<Node<T>>();
    

    public override string ToString()
    {
        return ToString("", true, true);
    }

    private string ToString(string indent, bool isLast, bool isRoot)
    {
        return this.Value.ToString();
    }
}