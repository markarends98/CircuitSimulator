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
    public class MinOutputsValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        private int _minOutputs;

        public MinOutputsValidation(int minOutputs)
        {
            Logger = Logger.Instance;
            _minOutputs = minOutputs;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                if(nodeDefinition.Outputs == null || nodeDefinition.Outputs.Count < _minOutputs)
                {
                    Logger.LogError(String.Format("node '{0}' of type '{1}' should have at least {2} outputs", nodeDefinition.Name, nodeDefinition.Type, _minOutputs));
                    return false;
                }
            }
            return true;
        }
    }
}
