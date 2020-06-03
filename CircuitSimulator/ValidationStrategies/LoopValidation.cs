using CircuitSimulator.Domain.Models;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ValidationStrategies
{
    public class LoopValidation : IValidationStrategy
    {
        public Logger Logger { get; }

        public LoopValidation()
        {
            Logger = Logger.Instance;
        }

        public bool Validate(List<NodeDefinition> nodeDefinitions)
        {
            foreach(NodeDefinition nodeDefinition in nodeDefinitions)
            {
                if(nodeDefinition.Visited)
                {
                    Logger.LogError("infinte loop detected");
                    return false;
                }

                foreach (string node in nodeDefinition.Outputs)
                {
                    NodeDefinition edge = nodeDefinitions.FirstOrDefault(ndf => ndf.Name == node);
                    if(edge != null)
                    {
                        if (edge.Visited)
                        {
                            Logger.LogError("infinte loop detected");
                            return false;
                        }

                        edge.Visited = true;
                    }
                }
                nodeDefinition.Visited = true;
            }
            return true;
        }
    }
}
