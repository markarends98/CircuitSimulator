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

            // register factories
            FileStrategyFactory fileStrategyFactory = FileStrategyFactory.Instance;
            fileStrategyFactory.RegisterStrategy("json", new JsonFileStrategy());
            fileStrategyFactory.RegisterStrategy("txt", new TxtFileStrategy());

            NodeFactory nodeFactory = NodeFactory.Instance;
            nodeFactory.RegisterNode<StartPoint>("START");
            nodeFactory.RegisterNode<Probe>("PROBE");
            nodeFactory.RegisterNode<NotGate>("NOT");
            nodeFactory.RegisterNode<AndGate>("AND");
            nodeFactory.RegisterNode<NandGate>("NAND");
            nodeFactory.RegisterNode<NorGate>("NOR");
            nodeFactory.RegisterNode<OrGate>("OR");
            nodeFactory.RegisterNode<XorGate>("XOR");

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