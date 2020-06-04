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
    public class ValidGatesValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        public NodeFactory _nodeFactory;

        public ValidGatesValidation()
        {
            Logger = Logger.Instance;
            _nodeFactory = NodeFactory.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            bool hasInvalidGates = nodeDefinitions.Any(def => def.Name == null || def.Type == null);
            if(hasInvalidGates)
            { 
                Logger.LogError("circuit has gates without a name or type.");
                return false;
            }

            NodeDefinition invalidDefinition = nodeDefinitions.FirstOrDefault(def => !_nodeFactory.IsNodeRegistered(def.Type));
            if(invalidDefinition != null)
            {
                Logger.LogError(String.Format("node type '{0}' for {1} is an invalid node type", invalidDefinition.Type, invalidDefinition.Name));
                return false;
            }
            return true;
        }
    }
}
