using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DuplicateNodeException : Exception
    {
        public DuplicateNodeException() : this("Tried to register an node that already exists")
        {
        }

        public DuplicateNodeException(string message)
            : base(message)
        {
        }

        public DuplicateNodeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
