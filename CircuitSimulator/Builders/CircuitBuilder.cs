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
        private Logger _logger;
        private NodeFactory _nodeFactory;

        public CircuitBuilder()
        {
            _nodeFactory = NodeFactory.Instance;
            _logger = Logger.Instance;
        }

        public Circuit Build(List<NodeDefinition> nodeDefinitions)
        {
            _logger.Log("Building circuit...");

            ObservableCollection<INode> nodes = new ObservableCollection<INode>();

            nodeDefinitions.ForEach(nodeDefinition =>
            {
                nodes.Add(_nodeFactory.CreateNode(nodeDefinition));
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

            _logger.LogSuccess("Circuit building successful");

            return new Circuit(nodes);
        }
    }
}
