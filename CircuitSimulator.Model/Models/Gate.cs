using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CircuitSimulator.Domain.Models
{
    [Serializable]
    public abstract class Gate : INode
    {
        public string Name { get; set; }
        public abstract string Type { get; }
        public bool Output { get => Result(); }
        public INode[] In { get; set; }
        public INode[] Out { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ConnectInput(INode node)
        {
            for (int i = 0; i < In.Length; i++)
            {
                if (In[i] == null)
                {
                    In[i] = node;
                    return;
                }
            }
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

        public abstract bool Result();

        public void Init(string name, int ins, int outs)
        {
            Name = name;
            In = new INode[ins];
            Out = new INode[outs];
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
