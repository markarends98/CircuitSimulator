namespace CircuitSimulator.Domain.Interfaces
{
    public interface INode
    {
        string Name { get; set; } 
        bool Output { get; }
        void Init(string name, int ins, int outs);
        void ConnectTo(INode node);
        bool Result();
    }
}
