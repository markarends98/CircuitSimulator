using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ValidationStrategies
{
    public class LoopValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        public NodeFactory _nodeFactory;

        public LoopValidation()
        {
            Logger = Logger.Instance;
            _nodeFactory = NodeFactory.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            List<List<string>> Paths = new List<List<string>>();

            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                string currentNode = nodeDefinition.Name;

            }
            return true;
        }
    }
}
