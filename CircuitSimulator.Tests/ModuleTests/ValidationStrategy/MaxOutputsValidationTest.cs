using System;
using System.Collections.Generic;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class MaxOutputsValidationTest
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
                    Outputs = { "NODE1", "NODE2" }
                }
            };
        }

        [TestMethod]
        public void Validate_NodeExceedingMaxOutput_ShouldReturnFalse()
        {
            // Arange
            MaxOutputsValidation maxOutputsValidation = new MaxOutputsValidation(1);

            // Act
            bool result = maxOutputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeConformingMaxOutput_ShouldReturnTrue()
        {
            // Arange
            MaxOutputsValidation maxOutputsValidation = new MaxOutputsValidation(2);

            // Act
            bool result = maxOutputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
