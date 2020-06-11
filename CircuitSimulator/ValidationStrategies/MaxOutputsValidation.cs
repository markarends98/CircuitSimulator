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
    public class MaxOutputsValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        private int _maxOutputs;

        public MaxOutputsValidation(int maxOutputs)
        {
            Logger = Logger.Instance;
            _maxOutputs = maxOutputs;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                if(nodeDefinition.Outputs == null || nodeDefinition.Outputs.Count > _maxOutputs)
                {
                    Logger.LogError(String.Format("node '{0}' of type '{1}'  should have a maximum of {2} outputs", nodeDefinition.Name, nodeDefinition.Type, _maxOutputs));
                    return false;
                }
            }
            return true;
        }
    }
}
