using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
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
            NodeTypes = new Dictionary<string, string>();
        }

        private readonly Dictionary<string, Type> RegisteredNodes;
        private readonly Dictionary<string, string> NodeTypes;

        public List<string> RegisteredTypes { get => new List<string>(RegisteredNodes.Keys); }
        public void RegisterNode<Class, Type>(string type)
        {
            bool typeCheck = typeof(INode).IsAssignableFrom(typeof(Class));
            if (type == null || type == string.Empty || !typeCheck)
            {
                throw new ArgumentException();
            }
            RegisteredNodes.Add(type, typeof(Class));
            NodeTypes.Add(type, typeof(Type).Name);
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

        public string GetNodeType(NodeDefinition nodeDefinition)
        {
            if(NodeTypes.ContainsKey(nodeDefinition.Type))
            {
                return NodeTypes[nodeDefinition.Type];
            }
            return null;
        }
    }
}
