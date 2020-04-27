using CircuitSimulator.Domain.Models;
using CircuitSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.FileStrategies
{
    public class TxtFileStrategy : IFileStrategy
    {
        public List<NodeDefinition> ReadFile(string fileName)
        {
            // TODO: TxtFileStrategy logic
            throw new NotImplementedException();
        }
    }
}
