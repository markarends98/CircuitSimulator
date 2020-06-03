using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach(Type key in keys)
            {
                List<NodeDefinition> definitions = new List<NodeDefinition>(nodeDefinitions);
                if(key != typeof(INode))
                    definitions = definitions.Where(def => typeCheck(_nodeFactory.GetRegisteredNodeType(def), key)).ToList();

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

        private bool typeCheck(Type defType, Type validationType)
        {
            if(defType == validationType)
                return true;

            if (validationType.IsAssignableFrom(defType))
                return true;

            return false;
        }
    }
}
