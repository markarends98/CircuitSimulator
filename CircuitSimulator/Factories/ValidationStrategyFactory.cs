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
            Strategies = new List<IValidationStrategy>();
        }

        private readonly List<IValidationStrategy> Strategies;

        public void RegisterStrategy(IValidationStrategy strategy)
        {
            if (strategy == null)
            {
                throw new ArgumentException();
            }

            if (Strategies.Any(t => t.GetType() == strategy.GetType()))
            {
                throw new DuplicateStrategyException();
            }
            Strategies.Add(strategy);
        }

        public List<IValidationStrategy> GetStrategies()
        {
            return new List<IValidationStrategy>(Strategies);
        }
    }
}