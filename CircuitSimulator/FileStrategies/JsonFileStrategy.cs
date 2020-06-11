using CircuitSimulator.Domain.Models;
using CircuitSimulator.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace CircuitSimulator.FileStrategies
{
    [ExcludeFromCodeCoverage]
    public class JsonFileStrategy : IFileStrategy
    {
        public List<NodeDefinition> ReadFile(Stream fileStream)
        {
            List<NodeDefinition> nodeDefinitions = new List<NodeDefinition>();
            using (StreamReader sr = new StreamReader(fileStream))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
               JToken data = JToken.ReadFrom(reader);
                if(data is JArray dataArray)
                {
                   List<JObject> dataList = dataArray.Select(t => (JObject)t).ToList();

                    // parse descriptions
                    foreach (JObject jsonObject in dataList)
                    {
                        NodeDefinition nodeDefinition = new NodeDefinition();
                        JToken nameToken = jsonObject.SelectToken("name");
                        
                        if(nameToken != null && nameToken.Type == JTokenType.String)
                        {
                            string name = (string)nameToken;
                            if (name.Length > 0)
                            {
                                nodeDefinition.Name = name.Trim();
                            }
                        }

                        JToken typeToken = jsonObject.SelectToken("type");
                        if (typeToken != null && typeToken.Type == JTokenType.String)
                        {
                            string type = (string)typeToken;
                            if (type.Length > 0)
                            {
                                nodeDefinition.Type = type.Trim();
                            }
                        }
                        nodeDefinitions.Add(nodeDefinition);
                    };

                    // parse edges
                    foreach(JObject jsonObject in dataList)
                    {
                        string nodeName = jsonObject.Value<string>("name");
                        if (nodeName == null)
                            continue;

                        NodeDefinition node = nodeDefinitions.FirstOrDefault(nodeDefinition => nodeDefinition.Name == nodeName);
                        JToken edgesToken = jsonObject.SelectToken("edges");
                        if (node == null || edgesToken == null || edgesToken.Type != JTokenType.Array)
                            continue;

                        JArray edgesArray = (JArray)edgesToken;
                        List<string> edges = edgesArray.Where(t => t.Type == JTokenType.String).Select(t => (string)t).ToList();
                        foreach(string edgeName in edges)
                        {
                            NodeDefinition edge = nodeDefinitions.FirstOrDefault(nodeDefinition => nodeDefinition.Name == edgeName);
                            if (edge == null)
                                continue;
                            edge.Inputs.Add(node.Name);
                            node.Outputs.Add(edge.Name);
                        };
                    };
                }
            }
            return nodeDefinitions;
        }
    }
}
