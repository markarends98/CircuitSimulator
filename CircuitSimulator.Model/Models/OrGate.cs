using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class OrGate : Gate
    {
        public override string Type { get => "OR"; }

        public override bool Result()
        {
            return In.Any(node => node.Output == true);
        }
    }
}
