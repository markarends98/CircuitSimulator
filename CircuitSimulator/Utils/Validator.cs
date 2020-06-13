using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CircuitSimulator.Utils
{
    public class Validator
    {
        private ValidationStrategyFactory _validationStrategyFactory;
        private NodeFactory _nodeFactory;

        public Validator()
        {
            _validationStrategyFactory = ValidationStrategyFactory.Instance;
            _nodeFactory = NodeFactory.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            Dictionary<Type, List<IValidationStrategy>> strategies = _validationStrategyFactory.GetStrategies();
            List<Type> keys = new List<Type>(strategies.Keys);

            // Execute validation methods for each registered type
            foreach(Type key in keys)
            {
                List<NodeDefinition> definitions = new List<NodeDefinition>(nodeDefinitions);

                // Filter nodes by type
                if(key != typeof(INode))
                    definitions = definitions.Where(def => Util.TypeCheck(_nodeFactory.GetRegisteredNodeType(def), key)).ToList();

                List<IValidationStrategy> validationStrategies = strategies[key];
                foreach(IValidationStrategy validationStrategy in validationStrategies)
                {
                    bool valid = validationStrategy.Validate(definitions);
                    if(!valid)
                        return false;
                }
            }
            return true;
        }
    }
}
