using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    public class NodeDefinition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Inputs { get; set; }
        public List<string> Outputs { get; set; }

        public NodeDefinition()
        {
            Name = null;
            Type = null;
            Inputs = new List<string>();
            Outputs = new List<string>();
        }
    }
}
