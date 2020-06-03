using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ValidationStrategies
{
    public class NodeConnnectionsValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        public NodeFactory _nodeFactory;

        public NodeConnnectionsValidation()
        {
            Logger = Logger.Instance;
            _nodeFactory = NodeFactory.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            bool valid = true;
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                string nodeType = _nodeFactory.GetNodeType(nodeDefinition);
                if (nodeType == typeof(StartPoint).Name)
                {
                    valid = ValidateStartPoint(nodeDefinition);
                }
                else if (nodeType == typeof(Gate).Name)
                {
                    valid = ValidateGate(nodeDefinition);
                }
                else if (nodeType == typeof(Probe).Name)
                {
                    valid = ValidateProbe(nodeDefinition);
                }

                if(!valid)
                {
                    break;
                }
            }
            return valid;
        }

        private bool ValidateStartPoint(NodeDefinition nodeDefinition)
        {
            if(nodeDefinition.Outputs.Count == 0)
            {
                Logger.LogError(String.Format("start point '{0}' has no outputs", nodeDefinition.Name));
                return false;
            }

            if(nodeDefinition.Inputs.Count > 0)
            {
                Logger.LogError(String.Format("start point '{0}' cannot have inputs", nodeDefinition.Name));
                return false;
            }
            return true;
        }


        private bool ValidateProbe(NodeDefinition nodeDefinition)
        {
            if (nodeDefinition.Inputs.Count == 0)
            {
                Logger.LogError(String.Format("probe '{0}' has no inputs", nodeDefinition.Name));
                return false;
            }

            if (nodeDefinition.Outputs.Count > 0)
            {
                Logger.LogError(String.Format("probe '{0}' cannot have outputs", nodeDefinition.Name));
                return false;
            }
            return true;
        }

        private bool ValidateGate(NodeDefinition nodeDefinition)
        {
            if (nodeDefinition.Outputs.Count == 0)
            {
                Logger.LogError(String.Format("gate '{0}' has no outputs", nodeDefinition.Name));
                return false;
            }
            if (nodeDefinition.Inputs.Count == 0)
            {
                Logger.LogError(String.Format("gate '{0}' has no inputs", nodeDefinition.Name));
                return false;
            }
            return true;
        }
    }
}
