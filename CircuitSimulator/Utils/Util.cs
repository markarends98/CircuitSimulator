using System;
using System.Diagnostics.CodeAnalysis;

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
