using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class XorGate : Gate
    {
        public override string Type { get => "XOR"; }

        public override bool Result()
        {
            return (In.Count(node => node.Output == true) % 2) != 0;
        }
    }
}
