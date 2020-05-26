using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    public class OrGate : Gate
    {
        public override string Type { get => "OR"; }

        public override bool Result()
        {
            // TODO: OrGate Logic
            throw new NotImplementedException();
        }
    }
}
