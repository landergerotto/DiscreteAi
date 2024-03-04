using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulasAI.Collections;

public class Graph<T> : Node<T>
{
    public Graph(
        T value = default,
        IEnumerable<Node<T>> Neighbours = null
    ) : base (value, Neighbours) { }
}