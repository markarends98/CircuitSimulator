using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using CircuitSimulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ValidationStrategies
{
    public class MinNodeValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        public NodeFactory _nodeFactory;

        public MinNodeValidation()
        {
            Logger = Logger.Instance;
            _nodeFactory = NodeFactory.Instance;
        }
         
        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            bool hasOneStartPoint = nodeDefinitions.Any(node => Util.TypeCheck(_nodeFactory.GetRegisteredNodeType(node), typeof(StartPoint)));
            bool hasOneNode = nodeDefinitions.Any(node => Util.TypeCheck(_nodeFactory.GetRegisteredNodeType(node), typeof(Gate)));
            bool hasOneProbe = nodeDefinitions.Any(node => Util.TypeCheck(_nodeFactory.GetRegisteredNodeType(node), typeof(Probe)));

            if (!hasOneStartPoint || !hasOneNode || !hasOneProbe)
            {
                Logger.LogError("Circuit requires at least 1 startpoint, gate and probe");
                return false;
            }

            return true;
        }
    }
}
