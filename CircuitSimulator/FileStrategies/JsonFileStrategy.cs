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
    public class JsonFileStrategy : IFileStrategy
    {
        public List<NodeDefinition> ReadFile(string fileName)
        {
            // TODO: JsonFileStrategy logic
            throw new NotImplementedException();
        }
    }
}
