using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulasAI.Collections;

public class Graph<T> : GraphNode<T>
{
    public List<GraphNode<T>> Nodes { get; set; }

    public Graph(List<GraphNode<T>> nodes = null)
    { 
        this.Nodes = nodes ?? new List<GraphNode<T>>();
    }
}