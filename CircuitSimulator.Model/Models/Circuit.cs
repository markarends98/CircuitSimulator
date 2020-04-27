using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CircuitSimulator.Domain.Models
{
    public class Circuit
    {
        public Circuit(Collection<INode> nodes)
        {
            Elements = new ObservableCollection<INode>(nodes);
        }

        public ObservableCollection<INode> Elements { get; }
    }
}
