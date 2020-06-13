using System;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class AndGate : Gate
    {
        public override string Type { get => "AND";  }

        public override bool Result()
        {
            return In.All(node => node.Output == true);
        }
    }
}
