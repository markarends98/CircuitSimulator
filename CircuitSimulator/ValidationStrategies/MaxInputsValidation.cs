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
    public class MaxInputsValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        private int _maxInputs;

        public MaxInputsValidation(int maxInputs)
        {
            Logger = Logger.Instance;
            _maxInputs = maxInputs;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                if(nodeDefinition.Inputs == null || nodeDefinition.Inputs.Count > _maxInputs)
                {
                    Logger.LogError(String.Format("node '{0}' of type '{1}' should have a maximum of {2} inputs", nodeDefinition.Name, nodeDefinition.Type, _maxInputs));
                    return false;
                }
            }
            return true;
        }
    }
}
