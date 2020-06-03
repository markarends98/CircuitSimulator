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
            StartPoints = new ObservableCollection<StartPoint>(Elements.Where(node => typeof(StartPoint).IsAssignableFrom(node.GetType())).Select(startPoint => (StartPoint) startPoint));
            Gates = new ObservableCollection<Gate>(Elements.Where(node => typeof(Gate).IsAssignableFrom(node.GetType())).Select(gate => (Gate) gate));
            Probes = new ObservableCollection<Probe>(Elements.Where(node => typeof(Probe).IsAssignableFrom(node.GetType())).Select(probe => (Probe) probe));
        }

        public ObservableCollection<INode> Elements { get; }
        public ObservableCollection<StartPoint> StartPoints { get; }
        public ObservableCollection<Gate> Gates { get; }
        public ObservableCollection<Probe> Probes { get; }
    }
}
