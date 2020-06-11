using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Utils
{
    [ExcludeFromCodeCoverage]
    public class Util
    {
        // Valdiation type check
        public static bool TypeCheck(Type defType, Type validationType)
        {
            if (defType == validationType)
                return true;

            if (validationType.IsAssignableFrom(defType))
                return true;

            return false;
        }
    }
}
