using System;
using System.ComponentModel;
using CircuitSimulator.Domain.Interfaces;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public abstract class StartPoint : INode
    {
        public string Name { get; set; }
        private bool _output;
        public bool Output {
            get { return _output; }
            set {
                _output = value;
                OnPropertyChanged("Output");
            }
        }
        public INode[] Out { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ConnectInput(INode node)
        {
            return;
        }

        public void ConnectOutput(INode node)
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
