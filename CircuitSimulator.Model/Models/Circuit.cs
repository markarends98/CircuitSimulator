using CircuitSimulator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace CircuitSimulator.Domain.Models
{
    public class Circuit : INotifyPropertyChanged
    {
        private ObservableCollection<INode> _elements;
        private ObservableCollection<StartPoint> _startPoints;
        public ObservableCollection<Gate> _gates;
        public ObservableCollection<Probe> _probes;
        public ObservableCollection<INode> Elements {
            get { return _elements; }
            set {
                _elements = value;
                OnPropertyChanged("Elements");
            }
        }
        public ObservableCollection<StartPoint> StartPoints
        {
            get { return _startPoints; }
            set
            {
                _startPoints = value;
                OnPropertyChanged("StartPoints");
            }
        }
        public ObservableCollection<Gate> Gates
        {
            get { return _gates; }
            set
            {
                _gates = value;
                OnPropertyChanged("Gates");
            }
        }
        public ObservableCollection<Probe> Probes
        {
            get { return _probes; }
            set
            {
                _probes = value;
                OnPropertyChanged("Probes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Circuit(Collection<INode> nodes)
        {
            init(nodes);

            foreach (var node in StartPoints)
            {
                node.PropertyChanged += listener;
            }
        }

        private void init(Collection<INode> nodes)
        {
            Elements = new ObservableCollection<INode>(nodes);
            StartPoints = new ObservableCollection<StartPoint>(Elements.Where(node => typeof(StartPoint).IsAssignableFrom(node.GetType())).Select(startPoint => (StartPoint)startPoint));
            Gates = new ObservableCollection<Gate>(Elements.Where(node => typeof(Gate).IsAssignableFrom(node.GetType())).Select(gate => (Gate)gate));
            Probes = new ObservableCollection<Probe>(Elements.Where(node => typeof(Probe).IsAssignableFrom(node.GetType())).Select(probe => (Probe)probe));
        }

        private void listener(object sender, EventArgs e)
        {
            init(Elements);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
