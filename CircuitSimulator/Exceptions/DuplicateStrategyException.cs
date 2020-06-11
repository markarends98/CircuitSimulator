using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DuplicateStrategyException : Exception
    {
        public DuplicateStrategyException() : this("Tried to register an strategy that already exists")
        {
        }

        public DuplicateStrategyException(string message)
            : base(message)
        {
        }

        public DuplicateStrategyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
