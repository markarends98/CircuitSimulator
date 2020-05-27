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
            NodeTypes = new Dictionary<string, Type>();
        }

        private readonly Dictionary<string, Type> NodeTypes;
        public List<string> RegisteredTypes { get => new List<string>(NodeTypes.Keys); }
        public void RegisterNode<T>(string type)
        {
            bool typeCheck = typeof(INode).IsAssignableFrom(typeof(T));
            if (type == null || type == string.Empty || !typeCheck)
            {
                throw new ArgumentException();
            }
            NodeTypes.Add(type, typeof(T));
        }

        public INode CreateNode(NodeDefinition nodeDefinition)
        {
            if(Activator.CreateInstance(NodeTypes[nodeDefinition.Type]) is INode node)
            {
                node.Init(nodeDefinition.Name, nodeDefinition.Inputs.Count, nodeDefinition.Outputs.Count);
                return node;
            }

            return null;
        }
    }
}
