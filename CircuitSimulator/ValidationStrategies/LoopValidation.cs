using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using CircuitSimulator.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CircuitSimulator.ValidationStrategies
{
    public class LoopValidation : IValidationStrategy
    {
        public Logger Logger { get; }
        public NodeFactory _nodeFactory;

        public LoopValidation()
        {
            Logger = Logger.Instance;
            _nodeFactory = NodeFactory.Instance;
        }

        public bool Validate(List<NodeDefinition> allNodes)
        {
            List<NodeDefinition> startPoints = allNodes.Where(def => Util.TypeCheck(_nodeFactory.GetRegisteredNodeType(def), typeof(StartPoint))).ToList();

            List<List<string>> Paths = new List<List<string>>();
            foreach(NodeDefinition startPoint in startPoints)
            {
                List<string> path = new List<string>();
                bool valid = FindPath(allNodes, startPoint, Paths, path);
                if (!valid)
                {
                    Logger.LogError("infinite loop");
                    return false;
                }
            }
            return true;
        }

        public bool FindPath(List<NodeDefinition> nodeDefinitions, NodeDefinition currentNode, List<List<string>> Paths, List<string> path)
        {
            // If node exists then loop is detected
            if(path.Contains(currentNode.Name)) {
                return false;
            }

            // Add current node
            path.Add(currentNode.Name);

            // Output probe reached
            if (currentNode.Outputs == null || currentNode.Outputs.Count == 0)
            {
                Paths.Add(path);
                return true;
            }

            // Loop find path for all outputs
            foreach(string nodeOutput in currentNode.Outputs)
            {
                NodeDefinition nextNode = nodeDefinitions.FirstOrDefault(def => def.Name == nodeOutput);
                if(nextNode != null)
                {
                    List<string> tempPath = new List<string>(path);
                    bool valid = FindPath(nodeDefinitions, nextNode, Paths, tempPath);
                    if(!valid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
