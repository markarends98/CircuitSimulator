using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace CircuitSimulator.Domain.Models
{
    public class Circuit
    {
        public Circuit(Collection<INode> nodes)
        {
            Elements = new ObservableCollection<INode>(nodes);
            StartPoints = new ObservableCollection<INode>(Elements.Where(node => typeof(StartPoint).IsAssignableFrom(node.GetType())));
            Gates = new ObservableCollection<INode>(Elements.Where(node => typeof(Gate).IsAssignableFrom(node.GetType())));
            Probes = new ObservableCollection<INode>(Elements.Where(node => typeof(Probe).IsAssignableFrom(node.GetType())));
        }

        public ObservableCollection<INode> Elements { get; }
        public ObservableCollection<INode> StartPoints { get; }
        public ObservableCollection<INode> Gates { get; }
        public ObservableCollection<INode> Probes { get; }
    }
}
