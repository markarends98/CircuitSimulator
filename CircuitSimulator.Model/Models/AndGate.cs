using System;

namespace CircuitSimulator.Domain.Models
{
    public class AndGate : Gate
    {
        public override string Type { get => "AND";  }

        public override bool Result()
        {
            // TODO: AndGate Logic
            throw new NotImplementedException();
        }
    }
}
