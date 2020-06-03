using CircuitSimulator.Exceptions;
using CircuitSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Factories
{
    public class ValidationStrategyFactory
    {
        private static ValidationStrategyFactory instance = null;

        public static ValidationStrategyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ValidationStrategyFactory();
                }
                return instance;
            }
        }

        private ValidationStrategyFactory() 
        {
            Strategies = new Dictionary<Type, List<IValidationStrategy>>();
        }

        private readonly Dictionary<Type, List<IValidationStrategy>> Strategies;

        public void RegisterStrategy<T>(IValidationStrategy strategy)
        {
            if (strategy == null)
            {
                throw new ArgumentException();
            }

            Type type = typeof(T);
            if (Strategies.ContainsKey(type))
            {
                if (Strategies[type].Any(str => str.GetType() == strategy.GetType()))
                {
                    throw new DuplicateStrategyException();
                }
            }else
            {
                Strategies.Add(type, new List<IValidationStrategy>());
            }
            Strategies[type].Add(strategy);
        }

        public Dictionary<Type, List<IValidationStrategy>> GetStrategies()
        {
            return new Dictionary<Type, List<IValidationStrategy>>(Strategies);
        }
    }
}