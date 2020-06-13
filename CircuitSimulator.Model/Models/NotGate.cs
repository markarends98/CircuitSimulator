using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class NotGate : Gate
    {
        public override string Type { get => "NOT"; }

        public override bool Result()
        {
            return In.All(node => node.Output == true) ? false : true;
        }
    }
}
