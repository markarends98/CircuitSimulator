using CircuitSimulator.Domain.Models;
using CircuitSimulator.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Interfaces
{
    public interface IValidationStrategy
    {
        Logger Logger { get; }
        bool Validate(List<NodeDefinition> nodeDefinitions);
    }
}
