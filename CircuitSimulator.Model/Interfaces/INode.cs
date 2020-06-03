namespace CircuitSimulator.Domain.Interfaces
{
    public interface INode
    {
        string Name { get; set; } 
        bool Output { get; }
        void Init(string name, int ins, int outs);
        void ConnectInput(INode node);
        void ConnectOutput(INode node);
        bool Result();
    }
}
