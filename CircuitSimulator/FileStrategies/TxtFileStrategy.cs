using CircuitSimulator.Domain.Models;
using CircuitSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.FileStrategies
{
    [ExcludeFromCodeCoverage]
    public class TxtFileStrategy : IFileStrategy
    {
        public List<NodeDefinition> ReadFile(Stream fileStream)
        {
            List<NodeDefinition> nodeDefinitions = new List<NodeDefinition>();
            bool parseEdges = false;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0 && line[0] == '#')
                        continue;

                    if(line.Length == 0 && !parseEdges)
                        parseEdges = true;

                    if(!parseEdges)
                    {
                        // parse descriptions
                        NodeDefinition nodeDefinition = new NodeDefinition();
                        string nodeDescription = line;
                        if(nodeDescription.EndsWith(";"))
                            nodeDescription = nodeDescription.Substring(0, nodeDescription.LastIndexOf(';'));

                        string[] nodeData = nodeDescription.Split(':');
                        if(nodeData.Length > 0 && nodeData[0] != null && nodeData[0].Trim().Length > 0)
                            nodeDefinition.Name = nodeData[0].Trim();

                        if (nodeData.Length > 1 && nodeData[1] != null && nodeData[1].Trim().Length > 0)
                            nodeDefinition.Type = nodeData[1].Trim();
                        
                        nodeDefinitions.Add(nodeDefinition);
                    }
                    else
                    {
                        // parse edges
                        string edgeDescription = line;
                        if (edgeDescription.EndsWith(";"))
                            edgeDescription = edgeDescription.Substring(0, edgeDescription.LastIndexOf(';'));

                        string[] edgeData = edgeDescription.Split(':');

                        if (edgeData.Length <= 0)
                            continue;

                        string nodeName = edgeData[0].Trim();

                        NodeDefinition node = nodeDefinitions.FirstOrDefault(nodeDefinition => nodeDefinition.Name == nodeName);
                        if (node == null || edgeData.Length <= 1)
                            continue;

                        // connect edges
                        string[] edges = edgeData[1].Trim().Split(',');
                        foreach (string edgeName in edges)
                        {
                            NodeDefinition edge = nodeDefinitions.FirstOrDefault(nodeDefinition => nodeDefinition.Name == edgeName);
                            if (edge == null)
                                continue;
                            edge.Inputs.Add(node.Name);
                            node.Outputs.Add(edge.Name);
                        }
                    }
                }
            }
            return nodeDefinitions;
        }
    }
}
