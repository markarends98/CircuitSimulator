using CircuitSimulator.Domain.Interfaces;

namespace CircuitSimulator.Domain.Models
{
    public class Probe : INode
    {
        public string Name { get; set; }
        public bool Output { get => Result(); }
        public INode Input { get; private set; }

        public void ConnectTo(INode node)
        {
            Input = node;
        }

        public void Init(string name, int ins, int outs)
        {
            Name = name;
        }

        public bool Result()
        {
            return Input.Output;
        }
    }
}
