using System;
using System.Collections.Generic;
using CircuitSimulator.Builders;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests
{
    [TestClass]
    public class CircuitBuilderTest
    {
        private CircuitBuilder _circuitBuilder;
        private List<NodeDefinition> _nodeDefinitions;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
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
        }

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            _circuitBuilder = new CircuitBuilder();
            _nodeDefinitions = new List<NodeDefinition>()
            {
                new NodeDefinition()
                {
                    Name = "A",
                    Type = "INPUT_HIGH",
                    Outputs = { "NODE1" }
                },
                new NodeDefinition()
                {
                    Name = "B",
                    Type = "INPUT_HIGH",
                    Outputs = { "NODE1" }
                },
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "AND",
                    Inputs = { "A", "B" },
                    Outputs = { "Cout" }
                }
                ,
                new NodeDefinition()
                {
                    Name = "Cout",
                    Type = "PROBE",
                    Inputs = { "NODE1" }
                }
            };
        }

        [TestMethod]
        public void Build_ShouldReturnCircuit()
        {
            // Act
            Circuit circuit = _circuitBuilder.Build(_nodeDefinitions);

            // Assert
            Assert.IsNotNull(circuit);
        }

        [TestMethod]
        public void Build_CircuitElementsShouldContainFourNodes()
        {
            // Act
            Circuit circuit = _circuitBuilder.Build(_nodeDefinitions);

            // Assert
            Assert.AreEqual(circuit.Elements.Count, 4);
        }
    }
}
