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
    public class ValidGatesValidation : IValidationStrategy
    {
        public Logger Logger { get; }

        public ValidGatesValidation()
        {
            Logger = Logger.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            bool hasInvalidGates = nodeDefinitions.Any(def => def.Name == null || def.Type == null);
            if(hasInvalidGates)
            { 
                Logger.LogError("circuit has gates without a name or type.");
            }
            return !hasInvalidGates;
        }
    }
}
