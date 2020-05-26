using CircuitSimulator.Builders;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ViewModels
{
    public class CircuitViewModel
    {
        private FileStrategyFactory fileStrategyFactory;
        private CircuitBuilder circuitBuilder;
        public Circuit circuit { get; set; }

        public CircuitViewModel()
        {
            fileStrategyFactory = FileStrategyFactory.Instance;
            circuitBuilder = new CircuitBuilder();
            circuit = circuitBuilder.Parse();
        }
    }
}
