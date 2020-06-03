using System;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    public class AndGate : Gate
    {
        public override string Type { get => "AND";  }

        public override bool Result()
        {
            return In.Any(node => node.Output != true) ? false : true;
        }
    }
}
