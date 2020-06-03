using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Logs;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Builders
{
    public class CircuitBuilder
    {
        public Logger Logger { get; }
        private NodeFactory nodeFactory;

        public CircuitBuilder()
        {
            nodeFactory = NodeFactory.Instance;
            Logger = Logger.Instance;
        }

        public Circuit Parse(List<NodeDefinition> nodeDefinitions)
        {
            Logger.Log("Parsing file...");

            ObservableCollection<INode> nodes = new ObservableCollection<INode>();

            nodeDefinitions.ForEach(nodeDefinition =>
            {
                nodes.Add(nodeFactory.CreateNode(nodeDefinition));
            });

            foreach(INode node in nodes)
            {
                NodeDefinition nodeDefinition = nodeDefinitions.FirstOrDefault(tempNodeDefinition => tempNodeDefinition.Name.Equals(node.Name));

                if (nodeDefinition != null)
                {
                    nodeDefinition.Inputs.ForEach(inputName =>
                    {
                        node.ConnectInput(nodes.FirstOrDefault(inputNode => inputNode.Name.Equals(inputName)));
                    });

                    nodeDefinition.Outputs.ForEach(outputName =>
                    {
                        node.ConnectOutput(nodes.FirstOrDefault(outputNode => outputNode.Name.Equals(outputName)));
                    });
                }
            }

            Logger.LogSuccess("Parsing file successful");

            return new Circuit(nodes);
        }
    }
}
