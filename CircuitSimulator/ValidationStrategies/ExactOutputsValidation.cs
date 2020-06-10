using CircuitSimulator.Domain.Models;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ValidationStrategies
{
    public class ExactOuputsValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        private int _inputs;

        public ExactOuputsValidation(int inputs)
        {
            Logger = Logger.Instance;
            _inputs = inputs;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                if(nodeDefinition.Outputs == null || nodeDefinition.Outputs.Count != _inputs)
                {
                    Logger.LogError(String.Format("node '{0}' of type '{1}' should have exactly {2} outputs", nodeDefinition.Name, nodeDefinition.Type, _inputs));
                    return false;
                }
            }
            return true;
        }
    }
}
