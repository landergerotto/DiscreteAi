using System.Linq;
using System.Text;

namespace AulasAI.Collections;

public class TreeNode<T> : INode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Parent { get; set; } // is null if it is root
    public IEnumerable<TreeNode<T>> Children { get; set; }

    public TreeNode(T value)
    {
        this.Value = value;
        this.Parent = null;
        this.Children = Enumerable.Empty<TreeNode<T>>();
    }

    public TreeNode
    (
        T value,
        TreeNode<T>? parent = null,
        IEnumerable<TreeNode<T>> children = null
    )
    {
        this.Value = value;
        this.Parent = parent;
        this.Children = children ?? Enumerable.Empty<TreeNode<T>>();
    }


    public TreeNode<T> AddChild(TreeNode<T> child)
    {
        child.Parent = this;
        if (child is null)
            return this;
        this.Children = this.Children.Append(child);

        return this;
    }

    public TreeNode<T> RemoveChild(TreeNode<T> child)
    {
        child.Parent = null;
        this.Children = this.Children.Where(x => x != child);

        return this;
    }

    public override string ToString()
    {
        return ToString("", true, true);
    }

    private string ToString(string indent, bool isLast, bool isRoot)
    {
        var result = new StringBuilder(indent);

        if (!isLast)
        {
            result.Append(Parent?.Children.LastOrDefault() == this
                              ? "\u2514\u2500\u2500\u2500"
                              : "\u251c\u2500\u2500\u2500");

            indent += "\u2502   ";
        }
        else if (!isRoot)
        {
            result.Append("\u2514\u2500\u2500\u2500");
            indent += "    ";
        }

        result.AppendLine(Value?.ToString());


        for (int i = 0; i < this.Children.Count(); i++)
            result.Append(this.Children.ElementAt(i).ToString(indent, i == Children.Count() - 1, false));

        return result.ToString();


    }
}