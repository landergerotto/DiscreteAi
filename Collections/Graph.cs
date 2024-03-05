using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulasAI.Collections;

public class Graph<T, TNode>
{
    public List<TNode> Nodes { get; set; }
    public Graph(List<TNode> nodes = null)
    { 
        this.Nodes = nodes ?? new List<TNode>();
    }

    public Graph<T, TNode> AddNode(TNode node)
    {
        if (!this.Nodes.Any(anyNode => 
            EqualityComparer<TNode>.Default.Equals(anyNode, node))
           )
            this.Nodes.Add(node);

        return this;
    }
}