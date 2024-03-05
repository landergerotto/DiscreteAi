using System;
using AulasAI.Collections;
using AulasAi.Search;
using System.Collections.Generic;


var tree5 = BuildTree();
var graph = BuildGraph();
var start = graph.Nodes[3];
var end = graph.Nodes[3];

System.Console.WriteLine(start.Value.ToString());
System.Console.WriteLine(end.Value.ToString());

var found = Search.DepthFirstSearch
(
    new SearchGraphNode<string>(start),
    end.Value
);

System.Console.WriteLine(found ? "Goal Found" : "Goal Not Found");

Tree<int> BuildTree()
{
    // TREE 1 (root: 50)
    var node = new TreeNode<int>(6);
    node = new TreeNode<int>
    (
        21,
        children: new List<TreeNode<int>>() { node }
    );

    var node2 = new TreeNode<int>(45);
    node = new TreeNode<int>(
        12,
        children: new List<TreeNode<int>>()
        {
        node, node2
        }
    );
    node = new TreeNode<int>(50, children: new List<TreeNode<int>>() { node });

    var tree1 = new Tree<int>(node);

    // Tree 2 (root: 1)
    var root = new TreeNode<int>(1)
        .AddChild(new TreeNode<int>(70))
        .AddChild(new TreeNode<int>(61));

    var tree2 = new Tree<int>(root);

    // Tree 3 (root: 30)
    root = new TreeNode<int>(30)
        .AddChild(new TreeNode<int>(96))
        .AddChild(new TreeNode<int>(9));

    var tree3 = new Tree<int>(root);

    // Tree 4 (root: 150)
    root = new TreeNode<int>(150)
        .AddChild(tree3.Root)
        .AddChild(new TreeNode<int>(5))
        .AddChild(new TreeNode<int>(11));

    var tree4 = new Tree<int>(root);

    // Tree 5 (root: 100)
    root = new TreeNode<int>(150)
        .AddChild(tree1.Root)
        .AddChild(tree2.Root)
        .AddChild(tree4.Root);

    var tree5 = new Tree<int>(root);

    return tree5;
}
Graph<string> BuildGraph()
{
    var nodeBaltimore = new GraphNode<string>("Baltimore");
    var nodeBoston = new GraphNode<string>("Boston");
    var nodeBuffalo = new GraphNode<string>("Buffalo");
    var nodeChicago = new GraphNode<string>("Chicago");
    var nodeCleveland = new GraphNode<string>("Cleveland");
    var nodeColumbus = new GraphNode<string>("Columbus");
    var nodeDetroit = new GraphNode<string>("Detroit");
    var nodeIndianapolis = new GraphNode<string>("Indianapolis");
    var nodeNewYork = new GraphNode<string>("New York");
    var nodePhiladelphia = new GraphNode<string>("Philadelphia");
    var nodePittsburgh = new GraphNode<string>("Pittsburgh");
    var nodePortland = new GraphNode<string>("Portland");
    var nodeProvidence = new GraphNode<string>("Providence");
    var nodeSyracuse = new GraphNode<string>("Syracuse");

    nodeBaltimore.AddNode(nodePhiladelphia)
                 .AddNode(nodePittsburgh);

    nodeBoston.AddNode(nodeNewYork)
              .AddNode(nodePortland)
              .AddNode(nodeProvidence)
              .AddNode(nodeSyracuse);

    nodeBuffalo.AddNode(nodeCleveland)
               .AddNode(nodeDetroit)
               .AddNode(nodePittsburgh)
               .AddNode(nodeSyracuse);

    nodeChicago.AddNode(nodeCleveland)
               .AddNode(nodeDetroit)
               .AddNode(nodeIndianapolis);

    nodeCleveland.AddNode(nodeBuffalo)
                 .AddNode(nodeChicago)
                 .AddNode(nodeColumbus)
                 .AddNode(nodeDetroit)
                 .AddNode(nodePittsburgh);

    nodeColumbus.AddNode(nodeCleveland)
                .AddNode(nodeIndianapolis)
                .AddNode(nodePittsburgh);

    nodeDetroit.AddNode(nodeBuffalo)
               .AddNode(nodeChicago)
               .AddNode(nodeCleveland);

    nodeIndianapolis.AddNode(nodeChicago)
                    .AddNode(nodeColumbus);

    nodeNewYork.AddNode(nodeBoston)
               .AddNode(nodePhiladelphia)
               .AddNode(nodeProvidence)
               .AddNode(nodeSyracuse);

    nodePhiladelphia.AddNode(nodeBaltimore)
                    .AddNode(nodeNewYork)
                    .AddNode(nodeSyracuse);

    nodePittsburgh.AddNode(nodeBaltimore)
                  .AddNode(nodeBuffalo)
                  .AddNode(nodeCleveland)
                  .AddNode(nodeColumbus)
                  .AddNode(nodePhiladelphia);

    nodePortland.AddNode(nodeBoston);

    nodeProvidence.AddNode(nodeBoston)
                  .AddNode(nodeNewYork);

    nodeSyracuse.AddNode(nodeBoston)
                .AddNode(nodeBuffalo)
                .AddNode(nodeNewYork)
                .AddNode(nodePhiladelphia);

    var buildGraph = new Graph<string>(new List<GraphNode<string>>
    {
        nodeBaltimore,
        nodeBoston,
        nodeBuffalo,
        nodeChicago,
        nodeCleveland,
        nodeColumbus,
        nodeDetroit,
        nodeIndianapolis,
        nodeNewYork,
        nodePhiladelphia,
        nodePittsburgh,
        nodePortland,
        nodeProvidence,
        nodeSyracuse,
    });

    return buildGraph;
}
