using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
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

        public Circuit Parse(List<NodeDefinition> nodeDefinitions)
        {
            // TODO: parse logic
            throw new NotImplementedException();
        }
    }
}
