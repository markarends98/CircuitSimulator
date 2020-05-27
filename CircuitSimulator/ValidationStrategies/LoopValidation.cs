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
    public class LoopValidation : IValidationStrategy
    {
        public Logger Logger { get; }

        public LoopValidation()
        {
            Logger = Logger.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            return false;
        }
    }
}
