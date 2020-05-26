 using CircuitSimulator.Domain.Interfaces;

namespace CircuitSimulator.Domain.Models
{
    public abstract class StartPoint : INode
    {
        public string Name { get; set; }
        public bool Output { get; set; }
        public INode[] Out { get; private set; }

        public void ConnectTo(INode node)
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

        public void Init(string name, int ins, int outs)
        {
            Name = name;
            Out = new INode[outs];
        }

        public abstract bool Result();
    }
}
