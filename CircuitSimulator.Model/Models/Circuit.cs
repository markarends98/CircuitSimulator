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
        private List<INode> _originalElements;
        private ObservableCollection<INode> _elements;
        private ObservableCollection<StartPoint> _startPoints;
        private ObservableCollection<Gate> _gates;
        private ObservableCollection<Probe> _probes;
        public List<INode> OriginalElements
        {
            get { return _originalElements; }
            set
            {
                _originalElements = value;
                OnPropertyChanged("OriginalElements");
            }
        }
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
            // OriginalElements = nodes.Cast<INode>().ToList();
            OriginalElements = new List<INode>();

            foreach (var node in StartPoints)
            {
                node.PropertyChanged += listener;
            }
        }

        public void Reset()
        {
            ObservableCollection<INode> tempOC = new ObservableCollection<INode>(OriginalElements);
            init(tempOC);
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
