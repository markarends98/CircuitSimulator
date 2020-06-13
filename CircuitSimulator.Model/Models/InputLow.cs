using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class InputLow : StartPoint
    {
        public InputLow()
        {
            Output = false;
        }

        public override bool Result()
        {
            return Output;
        }
    }
}
