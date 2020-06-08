using CircuitSimulator.Builders;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
using CircuitSimulator.Utils;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

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
        private Validator _validator;
        public Logger Logger { get; set; }

        #region Commands
        public RelayCommand OpenCircuitCommand { get; set; }
        public RelayCommand RefreshCircuitCommand { get; set; }
        public RelayCommand QuitCommand { get; set; }
        public RelayCommand ClearLogsCommand { get; set; }
        #endregion
         
        public CircuitViewModel()
        {
            _fileStrategyFactory = FileStrategyFactory.Instance;
            _circuitBuilder = new CircuitBuilder();
            OpenCircuitCommand = new RelayCommand(OpenCircuit);
            RefreshCircuitCommand = new RelayCommand(RefreshCircuit);
            QuitCommand = new RelayCommand(Quit);
            ClearLogsCommand = new RelayCommand(ClearLogs);
            Logger = Logger.Instance;
            _validator = new Validator();
        }

        private void OpenCircuit()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filter = GetFileFilter();
            openFileDialog.Filter = filter;
            if (openFileDialog.ShowDialog() == true)
            {
                string ext = Path.GetExtension(openFileDialog.FileName);
                IFileStrategy fileStrategy = _fileStrategyFactory.GetStrategy(ext.Substring(1));
                if(fileStrategy != null)
                {
                    Logger.Log(String.Format("Reading file: '{0}'", openFileDialog.FileName));
                    List<NodeDefinition> nodeDefinitions = fileStrategy.ReadFile(openFileDialog.OpenFile());

                    Logger.Log("Validating file");
                    if (_validator.Validate(nodeDefinitions)) {
                        Circuit = _circuitBuilder.Parse(nodeDefinitions);
                    }
                }
                else
                {
                    Logger.LogError("Cannot parse files with extension: '" + ext + "'");
                }
            }
        }

        private void RefreshCircuit()
        {
            CollectionViewSource.GetDefaultView(Circuit.Gates).Refresh();
            CollectionViewSource.GetDefaultView(Circuit.Probes).Refresh();
        }

        private void Quit()
        {
            Application.Current.Shutdown();
        }

        private string GetFileFilter()
        {
            List<string> availableStrategies = _fileStrategyFactory.AvailableStrategies;
            string extensions = String.Join("", availableStrategies.Select(ext => "*." + ext + ";"));
            string filter = "Text files (" + extensions + ")|" + extensions;
            return filter;
        }

        private void ClearLogs()
        {
            Logger.ClearLogs();
        }
    }
}
