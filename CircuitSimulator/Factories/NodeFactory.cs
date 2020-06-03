using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Factories
{
    public class NodeFactory
    {
        private static NodeFactory instance = null;

        public static NodeFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NodeFactory();
                }
                return instance;
            }
        }

        private NodeFactory()
        {
            RegisteredNodes = new Dictionary<string, Type>();
        }

        private readonly Dictionary<string, Type> RegisteredNodes;

        public List<string> RegisteredTypes { get => new List<string>(RegisteredNodes.Keys); }
        public void RegisterNode<Class>(string type)
        {
            bool typeCheck = typeof(INode).IsAssignableFrom(typeof(Class));
            if (type == null || type == string.Empty || !typeCheck)
            {
                throw new ArgumentException();
            }

            if(IsNodeRegistered(type))
            {
                throw new DuplicateNodeException();
            }
            RegisteredNodes.Add(type, typeof(Class));
        }

        public INode CreateNode(NodeDefinition nodeDefinition)
        {

            if (RegisteredNodes.ContainsKey(nodeDefinition.Type) && Activator.CreateInstance(RegisteredNodes[nodeDefinition.Type]) is INode node)
            {
                node.Init(nodeDefinition.Name, nodeDefinition.Inputs.Count, nodeDefinition.Outputs.Count);
                return node;
            }

            return null;
        }

        public Type GetRegisteredNodeType(NodeDefinition nodeDefinition)
        {
            if(IsNodeRegistered(nodeDefinition.Type))
            {
                return RegisteredNodes[nodeDefinition.Type];
            }
            return null;
        }

        public bool IsNodeRegistered(string type)
        {
            return RegisteredNodes.ContainsKey(type);
        }
    }
}
