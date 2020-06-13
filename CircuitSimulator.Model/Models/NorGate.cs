using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class NorGate : Gate
    {
        public override string Type { get => "NOR"; }

        public override bool Result()
        {
            return In.Any(node => node.Output == true) ? false : true;
        }
    }
}
