using CircuitSimulator.Builders;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.Interfaces;
using CircuitSimulator.Logs;
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
        public ValidationStrategyFactory _validationStrategyFactory;
        private CircuitBuilder _circuitBuilder;
        private Circuit _circuit;
        public Logger Logger { get; set; }

        #region Commands
        public RelayCommand OpenCircuitCommand { get; set; }
        public RelayCommand QuitCommand { get; set; }
        public RelayCommand ClearLogsCommand { get; set; }
        #endregion
         
        public CircuitViewModel()
        {
            _fileStrategyFactory = FileStrategyFactory.Instance;
            _validationStrategyFactory = ValidationStrategyFactory.Instance;
            _circuitBuilder = new CircuitBuilder();
            OpenCircuitCommand = new RelayCommand(OpenCircuit);
            QuitCommand = new RelayCommand(Quit);
            ClearLogsCommand = new RelayCommand(ClearLogs);
            Logger = Logger.Instance;
        }

        private void OpenCircuit()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filter = GetFileFilter();
            openFileDialog.Filter = filter;
            if (openFileDialog.ShowDialog() == true)
            {
                string ext = Path.GetExtension(openFileDialog.FileName);;
                IFileStrategy fileStrategy = _fileStrategyFactory.GetStrategy(ext.Substring(1));
                if(fileStrategy != null)
                {
                    Logger.Log("Reading file: '" + openFileDialog.FileName + "'");
                    List<NodeDefinition> nodeDefinitions = fileStrategy.ReadFile(openFileDialog.OpenFile());

                    Logger.Log("Validating file: '" + openFileDialog.FileName + "'");
                    List<IValidationStrategy> validationStrategies = _validationStrategyFactory.GetStrategies();
                    foreach(IValidationStrategy validationStrategy in validationStrategies)
                    {
                        bool result = validationStrategy.Validate(nodeDefinitions);
                        if (!result)
                        {
                            return;
                        }
                    }

                    Circuit = _circuitBuilder.Parse(nodeDefinitions);
                }
                else
                {
                    Logger.LogError("Cannot parse files with extension: '" + ext + "'");
                }
            }
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
