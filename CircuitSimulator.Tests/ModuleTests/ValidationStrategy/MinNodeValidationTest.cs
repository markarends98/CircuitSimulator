using System;
using System.Collections.Generic;
using System.Linq;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class MinNodeValidationTest
    {
        private List<NodeDefinition> _nodeDefinitions;

        [TestInitialize]
        public void Initialize()
        {
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
                    Name = "NODE1",
                    Type = "OR",
                    Inputs = { "A" },
                    Outputs = { "Cout" }
                },
                new NodeDefinition()
                {
                    Name = "Cout",
                    Type = "PROBE",
                    Inputs = { "NODE1" }
                }
            };
        }

        [TestMethod]
        public void Validate_NotContainsAtLeastOneStartPointGateProbe_ShouldReturnFalse()
        {
            // Arange
            MinNodeValidation minNodeValidation = new MinNodeValidation();
            _nodeDefinitions.Remove(_nodeDefinitions.FirstOrDefault(node => node.Name == "NODE1"));

            // Act
            bool result = minNodeValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_ContainsAtLeastOneStartPointGateProbe_ShouldReturnFalse()
        {
            // Arange
            MinNodeValidation minNodeValidation = new MinNodeValidation();

            // Act
            bool result = minNodeValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
