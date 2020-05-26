using CircuitSimulator.Builders;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ViewModels
{
    public class CircuitViewModel : ViewModelBase
    {
        public Circuit Circuit
        {
            get { return this._circuit; }
            set
            {
                this._circuit = value;
                RaisePropertyChanged(() => Circuit);
            }
        }

        private FileStrategyFactory _fileStrategyFactory;
        private CircuitBuilder _circuitBuilder;
        private Circuit _circuit;

        #region Commands
        public RelayCommand OpenCircuitCommand { get; set; }
        #endregion

        public CircuitViewModel()
        {
            _fileStrategyFactory = FileStrategyFactory.Instance;
            _circuitBuilder = new CircuitBuilder();
            OpenCircuitCommand = new RelayCommand(OpenCircuit);
        }

        private void OpenCircuit()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string ext = Path.GetExtension(openFileDialog.FileName);
                IFileStrategy fileStrategy = _fileStrategyFactory.GetStrategy(ext.Substring(1));
                if(fileStrategy != null)
                {
                    List<NodeDefinition> nodeDefinitions = fileStrategy.ReadFile(openFileDialog.OpenFile());
                    //Circuit = _circuitBuilder.Parse(nodeDefinitions);
                }
            }
        }
    }
}
