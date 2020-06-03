using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    public class NandGate : Gate
    {
        public override string Type { get => "NAND"; }

        public override bool Result()
        {
            // TODO: NandGate Logic
            throw new NotImplementedException();
        }
    }
}
