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

using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.FileStrategies;
using CircuitSimulator.ValidationStrategies;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace CircuitSimulator.ViewModels
{
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
            nodeFactory.RegisterNode<InputHigh, StartPoint>("INPUT_HIGH");
            nodeFactory.RegisterNode<InputLow, StartPoint>("INPUT_LOW");
            nodeFactory.RegisterNode<Probe, Probe>("PROBE");
            nodeFactory.RegisterNode<NotGate, Gate>("NOT");
            nodeFactory.RegisterNode<AndGate, Gate>("AND");
            nodeFactory.RegisterNode<NandGate, Gate>("NAND");
            nodeFactory.RegisterNode<NorGate, Gate>("NOR");
            nodeFactory.RegisterNode<OrGate, Gate>("OR");
            nodeFactory.RegisterNode<XorGate, Gate>("XOR");

            // register validation strategies
            ValidationStrategyFactory validationStrategyFactory = ValidationStrategyFactory.Instance;
            validationStrategyFactory.RegisterStrategy(new ValidGatesValidation());
            validationStrategyFactory.RegisterStrategy(new DuplicateGateValidation());
            validationStrategyFactory.RegisterStrategy(new NodeConnnectionsValidation());
            validationStrategyFactory.RegisterStrategy(new LoopValidation());


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