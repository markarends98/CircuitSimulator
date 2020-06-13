using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class InputHigh : StartPoint
    {
        public InputHigh()
        {
            Output = true;
        }

        public override bool Result()
        {
            return Output;
        }
    }
}
