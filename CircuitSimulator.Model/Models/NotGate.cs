using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    public class NotGate : Gate
    {
        public override string Type { get => "NOT"; }

        public override bool Result()
        {
            // TODO: NotGate Logic
            throw new NotImplementedException();
        }
    }
}
