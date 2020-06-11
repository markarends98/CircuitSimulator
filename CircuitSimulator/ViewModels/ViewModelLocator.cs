/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CircuitSimulator"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CircuitSimulator.Domain.Interfaces;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.FileStrategies;
using CircuitSimulator.ValidationStrategies;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System.Diagnostics.CodeAnalysis;

namespace CircuitSimulator.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // register file strategies
            FileStrategyFactory fileStrategyFactory = FileStrategyFactory.Instance;
            fileStrategyFactory.RegisterStrategy("json", new JsonFileStrategy());
            fileStrategyFactory.RegisterStrategy("txt", new TxtFileStrategy());

            // register node types
            NodeFactory nodeFactory = NodeFactory.Instance;
            nodeFactory.RegisterNode<InputHigh>("INPUT_HIGH");
            nodeFactory.RegisterNode<InputLow>("INPUT_LOW");
            nodeFactory.RegisterNode<Probe>("PROBE");
            nodeFactory.RegisterNode<NotGate>("NOT");
            nodeFactory.RegisterNode<AndGate>("AND");
            nodeFactory.RegisterNode<NandGate>("NAND");
            nodeFactory.RegisterNode<NorGate>("NOR");
            nodeFactory.RegisterNode<OrGate>("OR");
            nodeFactory.RegisterNode<XorGate>("XOR");

            // Validation strategies
            ValidationStrategyFactory validationStrategyFactory = ValidationStrategyFactory.Instance;

            // Circuit validation
            validationStrategyFactory.RegisterStrategy<INode>(new MinNodeValidation());

            // INode validation
            validationStrategyFactory.RegisterStrategy<INode>(new ValidGatesValidation());
            validationStrategyFactory.RegisterStrategy<INode>(new DuplicateGateValidation());
            validationStrategyFactory.RegisterStrategy<INode>(new LoopValidation());

            // StartPoint validation
            validationStrategyFactory.RegisterStrategy<StartPoint>(new MinOutputsValidation(1));

            // Probe validation
            validationStrategyFactory.RegisterStrategy<Probe>(new MinInputsValidation(1));

            // AND gate validation
            validationStrategyFactory.RegisterStrategy<AndGate>(new MinInputsValidation(2));
            validationStrategyFactory.RegisterStrategy<AndGate>(new MinOutputsValidation(1));

            // NAND gate validation
            validationStrategyFactory.RegisterStrategy<NandGate>(new MinInputsValidation(2));
            validationStrategyFactory.RegisterStrategy<NandGate>(new MinOutputsValidation(1));

            // NOR gate validation
            validationStrategyFactory.RegisterStrategy<NorGate>(new MinInputsValidation(2));
            validationStrategyFactory.RegisterStrategy<NorGate>(new MinOutputsValidation(1));

            // NOT gate validation
            validationStrategyFactory.RegisterStrategy<NotGate>(new MinInputsValidation(1));
            validationStrategyFactory.RegisterStrategy<NotGate>(new MaxInputsValidation(1));

            // OR gate validation
            validationStrategyFactory.RegisterStrategy<OrGate>(new MinInputsValidation(2));
            validationStrategyFactory.RegisterStrategy<OrGate>(new MinOutputsValidation(1));

            // XOR gate validation
            validationStrategyFactory.RegisterStrategy<XorGate>(new MinInputsValidation(2));
            validationStrategyFactory.RegisterStrategy<XorGate>(new MinOutputsValidation(1));

            SimpleIoc.Default.Register<CircuitViewModel>();
        }

        public CircuitViewModel Circuit
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CircuitViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}