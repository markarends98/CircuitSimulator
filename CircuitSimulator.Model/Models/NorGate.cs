using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    public class NorGate : Gate
    {
        public override string Type { get => "NOR"; }

        public override bool Result()
        {
            // TODO: NorGate Logic
            throw new NotImplementedException();
        }
    }
}
