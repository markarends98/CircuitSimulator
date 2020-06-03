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
    public class DuplicateGateValidation : IValidationStrategy
    {
        public Logger Logger { get; }

        public DuplicateGateValidation()
        {
            Logger = Logger.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            bool hasDuplicateGates = nodeDefinitions.GroupBy(x => x.Name)
              .Where(g => g.Count() > 1)
              .Any();
            if (hasDuplicateGates)
            {
                Logger.LogError("circuit has gates with duplicate names.");
                return false;
            }
            return true;
        }
    }
}
