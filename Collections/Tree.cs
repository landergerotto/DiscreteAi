using System.Collections.Generic;

namespace AulasAI.Collections;

public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
    public IEnumerable<TreeNode<T>> Children => Root.Children;

    public Tree(TreeNode<T> root) => this.Root = root;
    public Tree(T value) => this.Root = new TreeNode<T>(value);
    
    public Tree<T> AddBranch(Tree<T> branch)
    {
        this.Root.AddChild(branch.Root);
        return this;
    }

    public Tree<T> AddBranch(TreeNode<T> branch)    
    {
        this.Root.AddChild(branch);
        return this;
    }

    public Tree<T> RemoveBranch(Tree<T> branch) 
    {
        this.Root.RemoveChild(branch.Root);
        return this;
    }

    public Tree<T> RemoveBranch(TreeNode<T> branch)    
    {
        this.Root.RemoveChild(branch);
        return this;
    }
    
    public override string ToString()
    {
        return Root.ToString();
    }
}