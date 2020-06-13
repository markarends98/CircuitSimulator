using System;
using System.ComponentModel;
using CircuitSimulator.Domain.Interfaces;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public class Probe : INode
    {
        public string Name { get; set; }
        public bool Output { get => Result(); }
        public INode Input { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ConnectInput(INode node)
        {
            Input = node;
        }

        public void ConnectOutput(INode node)
        {
            return;
        }

        public void Init(string name, int ins, int outs)
        {
            Name = name;
        }

        public bool Result()
        {
            return Input.Output;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
