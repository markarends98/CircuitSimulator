using CircuitSimulator.Domain.Interfaces;
using System.Collections.Generic;

namespace CircuitSimulator.Domain.Models
{
    public abstract class Gate : INode
    {
        public string Name { get; set; }
        public bool Output { get => Result(); }
        public INode[] In { get; set; }
        public INode[] Out { get; set; }

        public virtual void ConnectTo(INode node)
        {
            for (int i = 0; i < Out.Length; i++)
            {
                if (Out[i] == null)
                {
                    Out[i] = node;
                    return;
                }
            }
        }

        public abstract bool Result();

        public void Init(string name, int ins, int outs)
        {
            Name = name;
            In = new INode[ins];
            Out = new INode[outs];
        }
    }
}
