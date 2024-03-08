using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Artin.Collections.GraphML;

public class GraphMlParser
{
    private XmlDocument XmlDoc { get; set; }

    public GraphMlParser(string path)
    {
        XmlDoc = new XmlDocument();
        XmlDoc.Load(path);
    }
    
    public List<GraphMlNode> ParseNodes(string path)
    {
        var nodes = XmlDoc.GetElementsByTagName("node");
        var graphNodes = new List<GraphMlNode>(nodes.Count);

        foreach (XmlNode node in nodes)
        {
            var id = node.Attributes![0].Value;

            var data = new Dictionary<string, string>();
            foreach (XmlNode child in node.ChildNodes)
            {
                var dataKey = child.Attributes![0].Value;
                data[dataKey] = child.InnerText;
            }

            graphNodes.Add(new GraphMlNode(id, data));
        }

        return graphNodes;
    }

    public List<GraphMlEdge> ParseEdges(string path)
    {
        var edges = XmlDoc.GetElementsByTagName("edge");
        var graphEdges = new List<GraphMlEdge>(edges.Count);
        
        foreach (XmlNode edge in edges)
        {
            string sourceId = null!;
            string targetId = null!;
    
            foreach (XmlAttribute attr in edge.Attributes!)
            {
                switch (attr.Name)
                {
                    case "source":
                        sourceId = attr.Value;
                        break;
                    case "target":
                        targetId = attr.Value;
                        break;
                }
            }
    
            var data = new Dictionary<string, string>();
            foreach (XmlNode child in edge.ChildNodes)
            {
                var dataKey = child.Attributes![0].Value;
                data[dataKey] = child.InnerText;
            }

            graphEdges.Add(new GraphMlEdge(sourceId, targetId, data));
        }

        return graphEdges;
    }

    public List<GraphMlEdge> ParseEdges(string path, List<GraphMlNode> nodes)
    {
        var edges = XmlDoc.GetElementsByTagName("edge");
        var graphEdges = new List<GraphMlEdge>(edges.Count);
        
        foreach (XmlNode edge in edges)
        {
            string sourceId = null!;
            string targetId = null!;
    
            foreach (XmlAttribute attr in edge.Attributes!)
            {
                switch (attr.Name)
                {
                    case "source":
                        sourceId = attr.Value;
                        break;
                    case "target":
                        targetId = attr.Value;
                        break;
                }
            }
    
            var data = new Dictionary<string, string>();
            foreach (XmlNode child in edge.ChildNodes)
            {
                var dataKey = child.Attributes![0].Value;
                data[dataKey] = child.InnerText;
            }

            var node = 
                from q in nodes
                where q.Id == targetId
                select q;

            var destinyNode = node.FirstOrDefault();

            graphEdges.Add(new GraphMlEdge(sourceId, targetId, destinyNode, data));
        }

        return graphEdges;
    }
}