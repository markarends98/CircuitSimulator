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
    public class MinInputsValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        private int _minInputs;

        public MinInputsValidation(int minInputs)
        {
            Logger = Logger.Instance;
            _minInputs = minInputs;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                if(nodeDefinition.Inputs == null || nodeDefinition.Inputs.Count < _minInputs)
                {
                    Logger.LogError(String.Format("node '{0}' of type '{1}' should have at least {2} inputs", nodeDefinition.Name, nodeDefinition.Type, _minInputs));
                    return false;
                }
            }
            return true;
        }
    }
}
