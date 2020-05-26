using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
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
        private NodeFactory nodeFactory;

        public CircuitBuilder()
        {
            nodeFactory = NodeFactory.Instance;
        }

        public Circuit Parse(List<NodeDefinition> nodeDefinitions = null)
        {
            nodeDefinitions = new List<NodeDefinition>()
            {
                new NodeDefinition() {
                    Name = "A",
                    Type = "INPUT_HIGH",
                    Outputs = new List<string>() { "NODE1" }
                    },
                new NodeDefinition() {
                    Name = "B",
                    Type = "INPUT_HIGH",
                    Outputs = new List<string>() { "NODE1" }
                    },
                new NodeDefinition() {
                    Name = "NODE1",
                    Type = "AND",
                    Inputs = new List<string>() { "A", "B" },
                    Outputs = new List<string>() { "Cout" }
                    },
                new NodeDefinition() {
                    Name = "Cout",
                    Type = "PROBE",
                    Inputs = new List<string>() { "NODE1" }
                    }
            };

            ObservableCollection<INode> nodes = new ObservableCollection<INode>();

            nodeDefinitions.ForEach(node =>
            {
                nodes.Add(nodeFactory.CreateNode(node));
            });

            return new Circuit(nodes);
        }
    }
}
