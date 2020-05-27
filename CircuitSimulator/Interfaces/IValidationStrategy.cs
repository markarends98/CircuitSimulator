using CircuitSimulator.Domain.Models;
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
        bool Validate(List<NodeDefinition> nodeDefinitions);
    }
}
