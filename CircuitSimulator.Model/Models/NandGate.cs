using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    public class NandGate : Gate
    {
        public override string Type { get => "NAND"; }

        public override bool Result()
        {
            return In.Any(node => node.Output == false) ? true : false;
        }
    }
}
